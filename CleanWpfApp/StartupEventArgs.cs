// Description:
//          This event is fired when the application starts  - once that application’s Run() 
//          method has been called. 
//
//          The developer will typically hook this event if they want to take action at startup time 
//

namespace CleanWpfApp
{
    /// <summary>
    /// Event args for Startup event
    /// </summary>
    public class StartupEventArgs : EventArgs
    {
        private string[] _args;
        private bool _performDefaultAction;

        /// <summary>
        /// constructor
        /// </summary>
        internal StartupEventArgs()
        {
            _performDefaultAction = true;
        }


        /// <summary>
        /// Command Line arguments
        /// </summary>
        public string[] Args
        {
            get
            {
                _args ??= GetCmdLineArgs();
                return _args;
            }
        }

        internal bool PerformDefaultAction
        {
            get { return _performDefaultAction; }
            set { _performDefaultAction = value; }
        }

        private string[] GetCmdLineArgs()
        {
            string[] args = Environment.GetCommandLineArgs();
            Invariant.Assert(args.Length >= 1);

            int newLength = args.Length - 1;
            newLength = (newLength >= 0 ? newLength : 0);

            string[] retValue = new string[newLength];

            for (int i = 1; i < args.Length; i++)
            {
                retValue[i - 1] = args[i];
            }

            return retValue;
        }
    }
}
