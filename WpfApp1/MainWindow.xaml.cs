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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChromiumWebBrowser browser;
      
        
        
        public MainWindow()
        {
            InitializeComponent();
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);

            txtUrl.Text = "https://www.google.com.br";
            browser = new ChromiumWebBrowser(txtUrl.Text);
            gridContent.Children.Add(browser);
            browser.AddressChanged += Browser_AddressChanged;
        }

        private void Browser_AddressChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           txtUrl.Text = e.NewValue.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            browser.Load(txtUrl.Text);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            browser.Load(txtUrl.Text);
        }
    }
}
