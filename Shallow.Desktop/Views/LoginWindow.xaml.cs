using Shallow.API.Services;
using Shallow.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfApp1.Views
{
    /// <summary>
    /// Lógica interna para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            btnLogin.IsEnabled = false;
            pbLogin.Visibility = Visibility.Visible;

            string email = txtUser.Text;
            string password = txtPassword.Password;

            bool isValid = true;

            if (String.IsNullOrEmpty(email))
            {
                txtUser.Foreground = Brushes.Red;
                isValid = false;
            }
            if (String.IsNullOrEmpty(password))
            {
                txtPassword.Foreground = Brushes.Red;
                isValid = false;
            }

            if (isValid)
            {
                List<CriancaModel> listCrianca = CriancaService.getCrianca();

                List<ResponsavelModel> listResponsavel = ResponsavelService.getResponsavel();

                CriancaModel criancaLogin = listCrianca.Where(c => c.email == email && c.senha == password).FirstOrDefault();
                ResponsavelModel responsavelLogin = listResponsavel.Where(r => r.email == email && r.senha == password).FirstOrDefault();

                if (criancaLogin != null)
                {
                    MainWindow mainWindow = new MainWindow(null, criancaLogin);
                    mainWindow.Show();
                    this.Close();

                }
                else if (responsavelLogin != null)
                {
                    MainWindow mainWindow = new MainWindow(responsavelLogin, null);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválidos");
                    txtUser.Text = "";
                    txtPassword.Name = "";
                    btnLogin.IsEnabled = true;
                    pbLogin.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos");
                txtUser.Text = "";
                txtPassword.Name = "";
                btnLogin.IsEnabled = true;
                pbLogin.Visibility = Visibility.Collapsed;
            }
        }
    }
}
