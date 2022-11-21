using Shallow.API.Services;
using Shallow.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

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
            //string email = txtUser.Text;
            //string password = txtPassword.Password;

            string email ="teste";
            string password = "123456";

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
            }
        }
    }
}
