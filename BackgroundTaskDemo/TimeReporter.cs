using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTaskDemo
{
    public sealed class TimeReporter
    {
        private readonly TaskScheduler scheduler;

        /// <summary>
        /// A constructor to initialize the TaskScheduler instance. TaskScheduler will be set to the current context i.e. the UI Thread.
        /// </summary>
        public TimeReporter()
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
            this.ReportProgressAsync(action).Wait();
        }
    }
}
