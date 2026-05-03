using System.IO;
using System.Windows;

namespace WebView2App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await webView.EnsureCoreWebView2Async();

            var htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "test.html");
            webView.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);
        }
    }
}
