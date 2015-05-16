using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSVM.SpamClassifier
{
    public partial class ProgressWorker<ArgumentType, ResultType> : Form
            where ArgumentType : class
            where ResultType : class
    {
        public ProgressWorker(ProgressWorkHandler handler, ArgumentType argument,
            ProgressWorkCompleted completedHandler, string title = null,
            bool reportProgress = false, bool reportInfo = false, bool supportCancelation = false)
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = reportProgress || reportInfo;
            backgroundWorker.ProgressChanged += OnProgressChanged;
            backgroundWorker.WorkerSupportsCancellation = supportCancelation;
            backgroundWorker.DoWork += DoWork;
            backgroundWorker.RunWorkerCompleted += WorkCompleted;
            this.Argument = argument;
            this.workHandler = handler;
            this.completedHandler = completedHandler;
            if (title != null)
                this.Text = title;
            else this.Text = "Work in progress";
            if (!supportCancelation)
                this.ControlBox = false;
            if (!reportProgress)
                this.progressBar.Style = ProgressBarStyle.Marquee;
            ReportInfo = reportInfo;
            ReportProgress = reportProgress;
        }

        void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            completedHandler(this, new ProgressWorkCompletedArgs(e));
            if (this.progressBar.Style != ProgressBarStyle.Marquee)
            {
                this.progressBar.Value = 100;
            }
            this.Hide();
        }

        public bool ReportInfo { get; private set; }

        public bool ReportProgress { get; private set; }

        public ArgumentType Argument { get; private set; }

        private ProgressWorkHandler workHandler;
        private ProgressWorkCompleted completedHandler;

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            this.workHandler(this, new ProgressWorkerEventArgs(this, e));
        }

        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            string info = e.UserState as string;
            if (info!=null)
                this.infoLabel.Text = info;
            if (this.ProgressChanged != null)
                ProgressChanged(this, e);
        }

        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;

        private void ProgressWorkerOnLoad(object sender, EventArgs e)
        {
            this.backgroundWorker.RunWorkerAsync(this.Argument);
        }

        public delegate void ProgressWorkCompleted(object sender, ProgressWorkCompletedArgs eventArgs);

        public class ProgressWorkCompletedArgs
        {
            RunWorkerCompletedEventArgs args;
            public ProgressWorkCompletedArgs(RunWorkerCompletedEventArgs sourceArgs)
            {
                this.args = sourceArgs;
            }

            public bool Cancelled
            {
                get
                {
                    return this.args.Cancelled;
                }
            }

            public Exception Error
            {
                get
                {
                    return this.args.Error;
                }
            }

            public ResultType Result
            {
                get
                {
                    return this.args.Result as ResultType;
                }
            }
        }

        public delegate void ProgressWorkHandler(object sender,
            ProgressWorkerEventArgs eventArgs);

        public class ProgressWorkerEventArgs : EventArgs
        {
            DoWorkEventArgs args;
            ProgressWorker<ArgumentType, ResultType> parent;

            public ProgressWorkerEventArgs(ProgressWorker<ArgumentType, ResultType> parent, DoWorkEventArgs sourceArgs)
            {
                this.args = sourceArgs;
                this.parent = parent;
            }

            public void ReportProgress(int percentProgress, object userData = null)
            {
                if (!this.parent.ReportProgress)
                    throw new InvalidOperationException("Reporting progress not supported");
                this.parent.backgroundWorker.ReportProgress(percentProgress, userData);
            }

            public void ChangeProgressInfo(string info)
            {
                if (!this.parent.ReportInfo)
                    throw new InvalidOperationException("Reporting info not supported");
                this.parent.backgroundWorker.ReportProgress(this.parent.progressBar.Value, info);
            }

            public ArgumentType Argument
            {
                get
                {
                    return args.Argument as ArgumentType;
                }
            }

            public bool Cancel
            {
                get
                {
                    return args.Cancel;
                }
                set
                {
                    args.Cancel = value;
                }
            }

            public ResultType Result
            {
                get
                {
                    return args.Result as ResultType;
                }
                set
                {
                    args.Result = value;
                }
            }
        }
    }
}
