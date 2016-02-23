using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTaskDemo
{
    public sealed class Worker3Reporter
    {
        private TaskScheduler scheduler;

        /// <summary>
        /// A constructor to initialize the TaskScheduler instance. TaskScheduler will be set to the current context i.e. the UI Thread.
        /// </summary>
        public Worker3Reporter()
        {
            this.scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        /// <summary>
        /// Report progress aysnchronously.
        /// </summary>
        /// <param name="action">A block of code to execute to report the progress. 
        /// This is a delegate that caller will pass in order to execute and it will be executed asynchronously.</param>
        /// <returns>Returns the async task for progress reporting.</returns>
        public Task ReportProgressAsync(Action action)
        {
            // Task.Factory.StartNew will start a new task in parallel mode
            return Task.Factory.StartNew(() => action(), CancellationToken.None, TaskCreationOptions.None, this.scheduler);
        }

        /// <summary>
        /// Report progress and wait for the task to finish.
        /// </summary>
        /// <param name="action">A block of code to execute to report the progress.
        /// This is a delegate that caller will pass in order to execute and it will call the ReportProgressAsync and will wait until it is finished.</param>
        public void ReportProgress(Action action)
        {
            ReportProgressAsync(action).Wait();
        }

        /// <summary>
        /// Continue with other task once the passed task is finished executing. The code to execute after parent task is finished is passed in Action delegate.
        /// </summary>
        /// <param name="task">The parent task. After this task is finished the new task with specified action will executed. This asynchronous execution.</param>
        /// <param name="action">The block of code to execute after the parent task is finished.</param>
        /// <returns>Returns the new task that just started after the parent task is finished.</returns>
        public Task RegisterContinuation(Task task, Action action)
        {
            return task.ContinueWith(_ => action(), CancellationToken.None, TaskContinuationOptions.None, this.scheduler);
        }
    }
}
