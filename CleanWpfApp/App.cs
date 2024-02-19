using System.Windows.Markup;

namespace CleanWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public class App : Application, IComponentConnector
    {
        private bool _contentLoaded;

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void IComponentConnector.Connect(int connectionId, object target)
        {
            _contentLoaded = true;
        }

        /// <summary>
        /// InitializeComponent
        /// </summary>
        public void InitializeComponent()
        {
            StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);

            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            var resourceLocater = new Uri("/CleanWpfApp;V1.0.0.0;component/app.xaml", UriKind.Relative);

            LoadComponent(this, resourceLocater);
        }

        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [STAThread()]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
