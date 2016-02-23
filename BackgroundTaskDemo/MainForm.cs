// Reference for kick start - http://blog.stephencleary.com/2010/06/reporting-progress-from-tasks.html
// Reference on how to pause\resume async task - http://blogs.msdn.com/b/pfxteam/archive/2013/01/13/cooperatively-pausing-async-methods.aspx

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgroundTaskDemo
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancellationTokenSource_Timer;
        private CancellationTokenSource cancellationTokenSource_Worker1;
        private CancellationTokenSource cancellationTokenSource_Worker2;
        private CancellationTokenSource cancellationTokenSource_Worker3;

        private PauseTokenSource worker1_PauseTokenSource;
        private PauseTokenSource worker2_PauseTokenSource;
        private PauseTokenSource worker3_PauseTokenSource;

        private bool worker1ExceptionRequested;
        private bool worker2ExceptionRequested;
        private bool worker3ExceptionRequested;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.textBoxTime.Text = "";

            worker1ExceptionRequested = false;
            worker2ExceptionRequested = false;
            worker3ExceptionRequested = false;

            worker1_PauseTokenSource = new PauseTokenSource();
            worker2_PauseTokenSource = new PauseTokenSource();
            worker3_PauseTokenSource = new PauseTokenSource();

            StartBackgroundTimer();

            this.buttonErrWorker1.Hide();
            this.buttonErrWorker2.Hide();
            this.buttonErrWorker3.Hide();

            this.buttonWaitWorker1.Hide();
            this.buttonWaitWorker2.Hide();
            this.buttonWaitWorker3.Hide();

            this.progressBarWorker1.Hide();
            this.progressBarWorker2.Hide();
            this.progressBarWorker3.Hide();
        }

        #region Timer

        private void StartBackgroundTimer()
        {
            this.cancellationTokenSource_Timer = new CancellationTokenSource();
            CancellationToken token = this.cancellationTokenSource_Timer.Token;
            TimeReporter timeReporter = new TimeReporter();

            Task _task = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (token.IsCancellationRequested)
                        break;

                    timeReporter.ReportProgress(() =>
                    {
                        this.textBoxTime.Text = DateTime.Now.ToLongTimeString();
                    });
                }
            });
        }

        private void RequestStartTime()
        {
            this.buttonStopTimer.Text = "Stop &Timer";

            StartBackgroundTimer();
        }

        private void RequestStopTime()
        {
            this.buttonStopTimer.Text = "Start &Timer";

            this.cancellationTokenSource_Timer.Cancel();
        }

        private void buttonStopTimer_Click(object sender, EventArgs e)
        {
            Button _button = sender as Button;
            if (_button.Text == "Stop &Timer")
            {
                RequestStopTime();
            }
            else
            {
                RequestStartTime();
            }
        }

        #endregion

        #region Worker 1

        private void buttonWorker1_Click(object sender, EventArgs e)
        {
            Button _button = sender as Button;
            if (_button.Text == "Start Worker &1")
            {
                RequestStartWorker1();
            }
            else
            {
                RequestStopWorker1();
            }
        }

        private void UpdateWorker1Message(string message)
        {
            this.richTextBoxWorker1.AppendText(message);
            this.richTextBoxWorker1.ScrollToCaret();
        }

        private void UpdateWorker1OnException(string exceptionMessage)
        {
            this.richTextBoxWorker1.AppendText("\n" + exceptionMessage);
            UpdateWorker1OnEnd();
        }

        private void UpdateWorker1OnCancel()
        {
            this.richTextBoxWorker1.AppendText("\nWorker 1 operation has been cancelled...");
            UpdateWorker1OnEnd();
        }

        private void UpdateWorker1OnComplete()
        {
            this.richTextBoxWorker1.AppendText("\nWorker 1 operation is completed...");
            UpdateWorker1OnEnd();
        }

        private void UpdateWorker1OnEnd()
        {
            this.buttonWaitWorker1.Hide();
            this.buttonErrWorker1.Hide();
            this.richTextBoxWorker1.ScrollToCaret();
            this.buttonWorker1.Text = "Start Worker &1";
            this.progressBarWorker1.Value = 0;
            this.progressBarWorker1.Hide();
        }

        private void StartBackgroundTask1()
        {
            // Set the UI when the task for worker 1 is going to start
            this.buttonWaitWorker1.Show();
            this.buttonErrWorker1.Show();
            this.richTextBoxWorker1.Clear();
            this.progressBarWorker1.Show();

            // CancellationTokenSource is used to signal the background task that the user has requested for the cancellation
            this.cancellationTokenSource_Worker1 = new CancellationTokenSource();

            // The token we will pass to the task that we are going to pass to the asynchronous task
            CancellationToken token = this.cancellationTokenSource_Worker1.Token;

            // The reporter is an instance of Worker1Reporter that we will use to report the status back to the UI Thread
            Worker1Reporter reporter = new Worker1Reporter();

            #region Start a task asynchronously

            WaitHandler _waiter = new WaitHandler();

            // Now we are going to start the task asynchronously
            Task _task = Task.Factory.StartNew(() =>
            {
                int operationCount = 100;
                // Lets run a loop 100 times
                for (int i = 1; i <= operationCount; i++)
                {
                    // The worker1ExceptionRequested is a flag that will be set to true if user request for an exception
                    if (worker1ExceptionRequested)
                    {
                        throw new InvalidOperationException("User has generated an exception for Worker 1...");
                    }

                    // Lets wait for 1 second. We are waiting for 1 second assuming that some long running code will be executing.
                    Task.Delay(1000).Wait();

                    _waiter.WaitAsync(worker1_PauseTokenSource.Token).Wait();

                    // The token we passed is used to see if the user has requested a cancellation. 
                    // We need to throw an exception if cancellation is requested so that on completion of task we can determine IsCancel is true.
                    token.ThrowIfCancellationRequested();

                    // Now lets report the progress to UI. 
                    // Note that if directly use any UI control here we will get exception that cannot access UI since it belongs to different thread.
                    // But we are going to access the UI through another object which will be accepted because the object (i.e. reporter) is running under
                    // current UI Context. You can see the constructor of Worker1Reporter where we have initalized the TaskScheduler isntance.
                    reporter.ReportProgress(() =>
                    {
                        if (i == 1)
                        {
                            UpdateWorker1Message(string.Format("Processing operation {0} of {1}...", i, operationCount));
                        }
                        else
                        {
                            UpdateWorker1Message(string.Format("\nProcessing operation {0} of {1}...", i, operationCount));
                        }

                        // Increment the progress bar
                        this.progressBarWorker1.Value = i;
                    });
                }
            }, token);  // We need to pass the token as another parameter because the continuing task (in below region) will need the status i.e. Exception, Is Cancelled or Completed

            #endregion

            #region Update the text box for Worker 1 on cancellation or completion of Worker 1

            // Once the task is completed we will continue with another task. This is needed on task completion, task cancellation or exception during task execution
            reporter.RegisterContinuation(_task, () =>
                {
                    // If the previous task has raised an exception report it to the UI
                    if (_task.Exception != null)
                    {
                        string exception = _task.Exception.InnerException.Message;
                        UpdateWorker1OnException(exception);
                    }
                    else if (_task.IsCanceled) // If user requested the cancellation, report the message to UI. Note this IsCanceled we get because we used token in previous task.
                    {
                        UpdateWorker1OnCancel();
                    }
                    else // If we are here, then task is completed successfully
                    {
                        UpdateWorker1OnComplete();
                    }
                });

            #endregion
        }

        private void RequestStartWorker1()
        {
            this.buttonWorker1.Text = "Stop Worker &1";
            this.worker1ExceptionRequested = false;
            StartBackgroundTask1();
        }

        private void RequestStopWorker1()
        {
            this.buttonWorker1.Text = "Start Worker &1";
            this.cancellationTokenSource_Worker1.Cancel();
            this.buttonErrWorker1.Hide();
        }

        #endregion

        #region Worker 2

        private void buttonWorker2_Click(object sender, EventArgs e)
        {
            Button _button = sender as Button;
            if (_button.Text == "Start Worker &2")
            {
                RequestStartWorker2();
            }
            else
            {
                RequestStopWorker2();
            }
        }

        private void UpdateWorker2Message(string message)
        {
            this.richTextBoxWorker2.AppendText(message);
            this.richTextBoxWorker2.ScrollToCaret();
        }

        private void UpdateWorker2OnCancel()
        {
            this.richTextBoxWorker2.AppendText("\nWorker 2 operation has been cancelled...");
            UpdateWorker2OnEnd();
        }

        private void UpdateWorker2OnComplete()
        {
            this.richTextBoxWorker2.AppendText("\nWorker 2 operation is completed...");
            UpdateWorker2OnEnd();
        }

        private void UpdateWorker2OnException(string exceptionMessage)
        {
            richTextBoxWorker2.AppendText("\n" + exceptionMessage);
            UpdateWorker2OnEnd();
        }

        private void UpdateWorker2OnEnd()
        {
            this.buttonWaitWorker2.Hide();
            this.buttonErrWorker2.Hide();
            this.richTextBoxWorker2.ScrollToCaret();
            this.buttonWorker2.Text = "Start Worker &2";
            this.progressBarWorker2.Value = 0;
            this.progressBarWorker2.Hide();
        }

        private void StartBackgroundTask2()
        {
            this.buttonWaitWorker2.Show();
            this.buttonErrWorker2.Show();
            this.richTextBoxWorker2.Clear();
            this.progressBarWorker2.Show();

            this.cancellationTokenSource_Worker2 = new CancellationTokenSource();
            CancellationToken token = this.cancellationTokenSource_Worker2.Token;
            Worker2Reporter reporter = new Worker2Reporter();

            #region Start a task asynchronously

            WaitHandler _waiter = new WaitHandler();

            Task _task = Task.Factory.StartNew(() =>
                {
                    int operationCount = 100;
                    for (int i = 1; i <= operationCount; i++)
                    {
                        if (worker2ExceptionRequested)
                        {
                            throw new InvalidOperationException("User has generated an exception for Worker 2...");
                        }

                        Task.Delay(1000).Wait();

                        _waiter.WaitAsync(worker2_PauseTokenSource.Token).Wait();

                        token.ThrowIfCancellationRequested();

                        reporter.ReportProgress(() =>
                            {
                                if (i == 1)
                                {
                                    UpdateWorker2Message(string.Format("Processing operation {0} of {1}...", i, operationCount));
                                }
                                else
                                {
                                    UpdateWorker2Message(string.Format("\nProcessing operation {0} of {1}...", i, operationCount));
                                }

                                this.progressBarWorker2.Value = i;
                            });
                    }
                }, token); // We need to pass the token as another parameter because the continuing task (in below region) will need the status i.e. Exception, Is Cancelled or Completed

            #endregion

            #region Update the text box for Worker 2 on cancellation or completion of Worker 2

            reporter.RegisterContinuation(_task, () =>
                {
                    if (_task.Exception != null)
                    {
                        string exception = _task.Exception.InnerException.Message;
                        UpdateWorker2OnException(exception);
                    }
                    else if (_task.IsCanceled)
                    {
                        UpdateWorker2OnCancel();
                    }
                    else
                    {
                        UpdateWorker2OnComplete();
                    }
                });

            #endregion
        }

        private void RequestStartWorker2()
        {
            this.buttonWorker2.Text = "Stop Worker &2";
            this.worker2ExceptionRequested = false;
            StartBackgroundTask2();
        }

        private void RequestStopWorker2()
        {
            this.buttonWorker2.Text = "Start Worker &2";
            this.cancellationTokenSource_Worker2.Cancel();
            this.buttonErrWorker2.Hide();
        }

        #endregion

        #region Worker 3

        private void buttonWorker3_Click(object sender, EventArgs e)
        {
            Button _button = sender as Button;
            if (_button.Text == "Start Worker &3")
            {
                RequestStartWorker3();
            }
            else
            {
                RequestStopWorker3();
            }
        }

        private void UpdateWorker3Message(string message)
        {
            this.richTextBoxWorker3.AppendText(message);
            this.richTextBoxWorker3.ScrollToCaret();
        }

        private void UpdateWorker3OnException(string exceptionMessage)
        {
            this.richTextBoxWorker3.AppendText("\n" + exceptionMessage);
            UpdateWorker3OnEnd();
        }

        private void UpdateWorker3OnCancel()
        {
            this.richTextBoxWorker3.AppendText("\nWorker 3 operation has been cancelled...");
            UpdateWorker3OnEnd();
        }

        private void UpdateWorker3OnComplete()
        {
            this.richTextBoxWorker3.AppendText("\nWorker 2 operation is completed...");
            UpdateWorker3OnEnd();
        }

        private void UpdateWorker3OnEnd()
        {
            this.buttonWaitWorker3.Hide();
            this.buttonErrWorker3.Hide();
            this.richTextBoxWorker3.ScrollToCaret();
            this.buttonWorker3.Text = "Start Worker &3";
            this.progressBarWorker3.Value = 0;
            this.progressBarWorker3.Hide();
        }

        private void StartBackgroundTask3()
        {
            this.buttonWaitWorker3.Show();
            this.buttonErrWorker3.Show();
            this.richTextBoxWorker3.Clear();
            this.progressBarWorker3.Show();

            this.cancellationTokenSource_Worker3 = new CancellationTokenSource();
            CancellationToken token = this.cancellationTokenSource_Worker3.Token;
            Worker3Reporter reporter = new Worker3Reporter();

            #region Start a task asynchronously

            WaitHandler _waiter = new WaitHandler();

            Task _task = Task.Factory.StartNew(() =>
                {
                    int operationCount = 100;
                    for (int i = 1; i <= operationCount; i++)
                    {
                        if (worker3ExceptionRequested)
                        {
                            throw new InvalidOperationException("User has generated an exception for Worker 3...");
                        }

                        Task.Delay(1000).Wait();

                        _waiter.WaitAsync(worker3_PauseTokenSource.Token).Wait();

                        token.ThrowIfCancellationRequested();

                        reporter.ReportProgress(() =>
                            {
                                if (i == 1)
                                {
                                    UpdateWorker3Message(string.Format("Processing operation {0} of {1}...", i, operationCount));
                                }
                                else
                                {
                                    UpdateWorker3Message(string.Format("\nProcessing operation {0} of {1}...", i, operationCount));
                                }

                                this.progressBarWorker3.Value = i;
                            });
                    }
                }, token); // We need to pass the token as another parameter because the continuing task (in below region) will need the status i.e. Exception, Is Cancelled or Completed

            #endregion

            #region Update the text box for Worker 3 on cancellation or completion of Worker 3

            reporter.RegisterContinuation(_task, () =>
                {
                    if (_task.Exception != null)
                    {
                        string exception = _task.Exception.InnerException.Message;
                        UpdateWorker3OnException(exception);
                    }
                    else if (_task.IsCanceled)
                    {
                        UpdateWorker3OnCancel();
                    }
                    else
                    {
                        UpdateWorker3OnComplete();
                    }
                });

            #endregion
        }

        private void RequestStartWorker3()
        {
            this.buttonWorker3.Text = "Stop Worker &3";
            this.worker3ExceptionRequested = false;
            StartBackgroundTask3();
        }

        private void RequestStopWorker3()
        {
            this.buttonWorker3.Text = "Start Worker &3";
            this.cancellationTokenSource_Worker3.Cancel();
            this.buttonErrWorker3.Hide();
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void buttonErrWorker1_Click(object sender, EventArgs e)
        {
            worker1ExceptionRequested = true;
        }

        private void buttonErrWorker2_Click(object sender, EventArgs e)
        {
            worker2ExceptionRequested = true;
        }

        private void buttonErrWorker3_Click(object sender, EventArgs e)
        {
            worker3ExceptionRequested = true;
        }

        private void buttonWaitWorker1_Click(object sender, EventArgs e)
        {
            Button _button = sender as Button;
            if (_button.Text == "&Pause")
            {
                worker1_PauseTokenSource.IsPaused = true;
                _button.Text = "&Resume";
                this.buttonWorker1.Enabled = false;
                this.buttonErrWorker1.Enabled = false;

                this.richTextBoxWorker1.AppendText("\nWorker 1 is waiting for resume command...");
            }
            else
            {
                worker1_PauseTokenSource.IsPaused = false;
                _button.Text = "&Pause";
                this.buttonWorker1.Enabled = true;
                this.buttonErrWorker1.Enabled = true;
            }
        }

        private void buttonWaitWorker2_Click(object sender, EventArgs e)
        {
            Button _button = sender as Button;
            if (_button.Text == "&Pause")
            {
                worker2_PauseTokenSource.IsPaused = true;
                _button.Text = "&Resume";
                this.buttonWorker2.Enabled = false;
                this.buttonErrWorker2.Enabled = false;

                this.richTextBoxWorker2.AppendText("\nWorker 2 is waiting for resume command...");
            }
            else
            {
                worker2_PauseTokenSource.IsPaused = false;
                _button.Text = "&Pause";
                this.buttonWorker2.Enabled = true;
                this.buttonErrWorker2.Enabled = true;
            }
        }

        private void buttonWaitWorker3_Click(object sender, EventArgs e)
        {
            Button _button = sender as Button;
            if (_button.Text == "&Pause")
            {
                worker3_PauseTokenSource.IsPaused = true;
                _button.Text = "&Resume";
                this.buttonWorker3.Enabled = false;
                this.buttonErrWorker3.Enabled = false;

                this.richTextBoxWorker3.AppendText("\nWorker 3 is waiting for resume command...");
            }
            else
            {
                worker3_PauseTokenSource.IsPaused = false;
                _button.Text = "&Pause";
                this.buttonWorker3.Enabled = true;
                this.buttonErrWorker3.Enabled = true;
            }
        }
    }
}
