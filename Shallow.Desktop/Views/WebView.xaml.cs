using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Interface;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for WebView.xaml
    /// </summary>
    public partial class WebView : UserControl, ICustomBrowser
    {

        Window Window = null;
        ChromiumWebBrowser browser;
        public ICommand ForwardCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public WebView(Window window)
        {
            InitializeComponent();
            Window = window;
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);
            //txtUrl.Text = "https://www.google.com.br";
            browser = new ChromiumWebBrowser("https://www.google.com.br");
            gridContent.Children.Add(browser);
            browser.AddressChanged += Browser_AddressChanged;
        }
        private void Browser_AddressChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //txtUrl.Text = e.NewValue.ToString();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            browser.Load("https://www.google.com.br");
        }

        private void txtUrl_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void btnFav_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    browser.Load("https://www.google.com.br");
            //}
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            //  CanGoBack
        }

        private void btnAvancar_Click(object sender, RoutedEventArgs e)
        {
            // CanGoForward
        }

        public void PreviousPage()
        {
            throw new NotImplementedException();
        }

        public void ForwardPage()
        {
            throw new NotImplementedException();
        }

        public void HomePage()
        {
            browser.Load("https://www.google.com.br");
        }

        public void ConfigurationPage()
        {

        }
    }
}
