using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Common.Infrastructure.Helpers
{
    public class UpdateUITask
    {
        private TaskScheduler uiScheduler;
        private Task BackgroundTask;
        private Task UITask;
        private Action backAction;
        private Action uiAction;
        public UpdateUITask(ref Action backgroundAction,ref Action uiAction)
        {
            uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            backAction = backgroundAction;
            this.uiAction = uiAction;
        }

        public void Run()
        {
            BackgroundTask = Task.Factory.StartNew(() => backAction);
            // when t1 is done run t1..on the Ui thread.
            UITask = BackgroundTask.ContinueWith(t => uiAction, uiScheduler);
        }
    }
}
