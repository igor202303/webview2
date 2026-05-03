using System.IO;
using System.Windows;
using System.Windows.Media.Animation;

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

            webView.CoreWebView2.NavigationCompleted += (s, args) =>
            {
                Dispatcher.Invoke(() =>
                {
                    var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(150));
                    webView.BeginAnimation(OpacityProperty, fadeIn);
                });
            };

            var htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "test.html");
            webView.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);
        }
    }
}
