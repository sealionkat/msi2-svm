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
        public ProgressWorker(ProgressWorkHandler<ArgumentType, ResultType> handler, ArgumentType argument,
            ProgressWorkCompleted<ResultType> completedHandler, string title = null,
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
            completedHandler(this, new ProgressWorkCompletedArgs<ResultType>(e));
            if (this.progressBar.Style != ProgressBarStyle.Marquee)
            {
                this.progressBar.Value = 100;
            }
            this.Hide();
        }

        public bool ReportInfo { get; private set; }

        public bool ReportProgress { get; private set; }

        public ArgumentType Argument { get; private set; }

        private ProgressWorkHandler<ArgumentType, ResultType> workHandler;
        private ProgressWorkCompleted<ResultType> completedHandler;

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            this.workHandler(this, new ProgressWorkerEventArgs<ArgumentType, ResultType>(this, e));
        }

        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            string info = e.UserState as string;
            if (info!=null)
                this.infoLabel.Text = info;
        }

        private void ProgressWorkerOnLoad(object sender, EventArgs e)
        {
            this.backgroundWorker.RunWorkerAsync(this.Argument);
        }

        public delegate void ProgressWorkCompleted<RType>(object sender, ProgressWorkCompletedArgs<RType> eventArgs)
            where RType : class;

        public class ProgressWorkCompletedArgs<RType>
            where RType : class
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

            public RType Result
            {
                get
                {
                    return this.args.Result as RType;
                }
            }
        }

        public delegate void ProgressWorkHandler<AType, RType>(object sender,
            ProgressWorkerEventArgs<ArgumentType, ResultType> eventArgs);

        public class ProgressWorkerEventArgs<AType, RType> : EventArgs
            where AType : class
            where RType : class
        {
            DoWorkEventArgs args;
            ProgressWorker<AType, RType> parent;

            public ProgressWorkerEventArgs(ProgressWorker<AType, RType> parent, DoWorkEventArgs sourceArgs)
            {
                this.args = sourceArgs;
                this.parent = parent;
            }

            public void ReportProgress(int percentProgress)
            {
                if (!this.parent.ReportProgress)
                    throw new InvalidOperationException("Reporting progress not supported");
                this.parent.backgroundWorker.ReportProgress(percentProgress);
            }

            public void ChangeProgressInfo(string info)
            {
                if (!this.parent.ReportInfo)
                    throw new InvalidOperationException("Reporting info not supported");
                this.parent.backgroundWorker.ReportProgress(this.parent.progressBar.Value, info);
            }

            public AType Argument
            {
                get
                {
                    return args.Argument as AType;
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

            public RType Result
            {
                get
                {
                    return args.Result as RType;
                }
                set
                {
                    args.Result = value;
                }
            }
        }
    }
}
