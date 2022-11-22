using CefSharp;
using CefSharp.Wpf;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Shallow.API.Services;
using Shallow.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Interface;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.Forms.MessageBox;
using UserControl = System.Windows.Controls.UserControl;
using System.Configuration;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for WebView.xaml
    /// </summary>
    public partial class WebView : UserControl, ICustomBrowser
    {

        Window Window = null;
        ChromiumWebBrowser browser;
        List<SiteModel> sites = new List<SiteModel>();
        public ICommand ForwardCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public WebView(Window window, ResponsavelModel responsavel = null, CriancaModel crianca = null)
        {
            InitializeComponent();
            Window = window;
            if (crianca != null)
                sites = SitesService.getSitesByCriancaID(crianca.id);
            else
                sites = new List<SiteModel>();
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);
            //txtUrl.Text = "https://www.google.com.br";
            browser = new ChromiumWebBrowser("https://www.google.com.br");
            gridContent.Children.Add(browser);
            browser.AddressChanged += Browser_AddressChanged;
        }
        private void Browser_AddressChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            string siteAtual = browser.Address.Replace("https://", "").Replace("http://", "");
            int posFinal = siteAtual.IndexOf("/");
            siteAtual = siteAtual.Substring(0, posFinal);

            List<SiteModel> exists = sites.Where(s => siteAtual.Contains(s.url)).ToList();

            if (exists.Count == 0)
            {
                browser.Back();
                const string message = "Site não permitido, deseja solicitar acesso?";
                const string caption = "ACESSO NEGADO";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);
                // If the no button was pressed ...
                if (result == DialogResult.Yes)
                {
                    SendEmail();
                }
            }
        }

        public void SendEmail()
        {
            try
            {
                //MailMessage message = new MailMessage();
                //SmtpClient smtp = new SmtpClient();

                //message.From = new MailAddress("shallowwebbrowser@gmail.com");
                //message.To.Add(new MailAddress("gguimaraes1602@gmail.com"));
                //message.Subject = "Test";
                //message.Body = "Content";


                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new NetworkCredential("shallowwebbrowser@gmail.com", "shallow123");
                //smtp.Port = 587;
                //smtp.Host = "smtp.gmail.com";
                //smtp.EnableSsl = true;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new NetworkCredential("matheussarquis2@gmail.com", "pwd");
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.Send(message);


                SmtpClient server = new SmtpClient("smtp.gmail.com");
                server.Credentials = new NetworkCredential("shallowwebbrowser@gmail.com", "shallow123"); //Autetificação
                MailMessage email = new MailMessage();
                email.From = new MailAddress("shallowwebbrowser@gmail.com");
                email.To.Add("gguimaraes1602@gmail.com");
                email.Subject = ConfigurationSettings.AppSettings["MailSubject"];
                email.Body = "Usuário";

                server.Send(email);


            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
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

        public void PreviousPage(bool canGoBack)
        {
            browser.Back();
        }

        public void ForwardPage(bool canGoForward)
        {
            browser.Forward();
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
