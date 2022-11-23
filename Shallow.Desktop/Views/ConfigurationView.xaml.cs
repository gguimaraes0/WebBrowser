using CefSharp;
using CefSharp.DevTools.DOM;
using Shallow.API.Services;
using Shallow.Model.Enums;
using Shallow.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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
    /// Interaction logic for ConfigurationView.xaml
    /// </summary>
    public partial class ConfigurationView : UserControl
    {

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<SiteModel> Sites = new List<SiteModel>();

        public List<CriancaModel> Child = new List<CriancaModel>();

        public ResponsavelModel ResponsavelModel { get; set; }
        public CriancaModel CriancaModel { get; set; }

        public ConfigurationView(ResponsavelModel responsavel = null, CriancaModel crianca = null)
        {
            InitializeComponent();
            CriancaModel = crianca;
            ResponsavelModel = responsavel;            
            if (CriancaModel != null)
            {
                getSites();
                btnVisualizeChild.Visibility = Visibility.Collapsed;
                btnRegisterChild.Visibility = Visibility.Collapsed;
                btnRegisterSiteforChild.Visibility = Visibility.Collapsed;
                btnVisualizeSites.Visibility = Visibility.Visible;
                dgSites.Visibility = Visibility.Visible;
            }
            else
            {
                getChild();
                btnVisualizeChild.Visibility = Visibility.Visible;
                btnRegisterChild.Visibility = Visibility.Visible;
                btnRegisterSiteforChild.Visibility = Visibility.Visible;
                btnVisualizeSites.Visibility = Visibility.Collapsed;
                dgChild.Visibility = Visibility.Visible;
            }
        }


        public void getChildsforResponsavel()
        {
            Child = CriancaService.getSitesByCriancaID(ResponsavelModel.id);
        }

        public void getSites()
        {
            if (CriancaModel != null)
                Sites = SitesService.getSitesByCriancaID(CriancaModel.id);
            else
                Sites = SitesService.getSites();

            dgSites.ItemsSource = null;
            dgSites.ItemsSource = Sites;
        }

        public void getChild()
        {
            dgSites.Visibility = Visibility.Collapsed;
            if (CriancaModel == null)
                Child = CriancaService.getSitesByCriancaID(ResponsavelModel.id);

            dgChild.ItemsSource = null;
            dgChild.ItemsSource = Child;

            dgChild.Visibility = Visibility.Visible;
        }

        private void btnVisualizeChild_Click(object sender, RoutedEventArgs e)
        {
            getChild();
            dgSites.Visibility = Visibility.Collapsed;
            GridCadastroSite.Visibility = Visibility.Collapsed;
            GridCadastroDependente.Visibility = Visibility.Collapsed;
            dgChild.Visibility = Visibility.Visible;
        }

        private void btnVisualizeSites_Click(object sender, RoutedEventArgs e)
        {
            getSites();
            GridCadastroSite.Visibility = Visibility.Collapsed;
            GridCadastroDependente.Visibility = Visibility.Collapsed;
            dgChild.Visibility = Visibility.Collapsed;
            dgSites.Visibility = Visibility.Visible;
        }
        private void btnRegisterChild_Click(object sender, RoutedEventArgs e)
        {
            dgSites.Visibility = Visibility.Collapsed;
            dgChild.Visibility = Visibility.Collapsed;
            GridCadastroSite.Visibility = Visibility.Collapsed;
            GridCadastroDependente.Visibility = Visibility.Visible;
        }

        private void btnRegisterSiteforChild_Click(object sender, RoutedEventArgs e)
        {
            dgSites.Visibility = Visibility.Collapsed;
            dgChild.Visibility = Visibility.Collapsed;
            GridCadastroDependente.Visibility = Visibility.Collapsed;
            GridCadastroSite.Visibility = Visibility.Visible;


            getChildsforResponsavel();
            cbChild.ItemsSource = null;
            cbChild.ItemsSource = Child;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string senha = txtPassword1.Password;
            string senhaConfirmacao = txtPasswordConfirm.Password;

            bool isValid = true;

            if (String.IsNullOrEmpty(nome))
            {
                txtNome.Foreground = Brushes.Red;
                isValid = false;
            }
            if (String.IsNullOrEmpty(email))
            {
                txtEmail.Foreground = Brushes.Red;
                isValid = false;
            }
            if (String.IsNullOrEmpty(senha))
            {
                txtPassword1.Foreground = Brushes.Red;
                isValid = false;
            }
            if (String.IsNullOrEmpty(senhaConfirmacao))
            {
                txtPasswordConfirm.Foreground = Brushes.Red;
                isValid = false;
            }
            if (senha != senhaConfirmacao)
            {
                txtPasswordConfirm.Foreground = Brushes.Red;
                isValid = false;
            }

            if (isValid)
            {
                CriancaModel criancaModel = new CriancaModel();
                criancaModel.nome = nome;
                criancaModel.email = email;
                criancaModel.senha = senha;
                criancaModel.responsavelID = ResponsavelModel.id;
                string resp = CriancaService.postCrianca(criancaModel);

                MessageBox.Show(resp);
                txtNome.Text = "";
                txtNome.Foreground = Brushes.Transparent;
                txtEmail.Text = "";
                txtEmail.Foreground = Brushes.Transparent;
                txtPassword1.Password = "";
                txtPassword1.Foreground = Brushes.Transparent;
                txtPasswordConfirm.Password = "";
                txtPasswordConfirm.Foreground = Brushes.Transparent;
                GridCadastroDependente.Visibility = Visibility.Collapsed;
                dgChild.Visibility = Visibility.Visible;
            }

        }

        private void btnCadastrarSite_Click(object sender, RoutedEventArgs e)
        {
            string url = txtUrl.Text;
            CriancaModel criancaModel = (CriancaModel)cbChild.SelectedItem;
            bool isValid = true;

            if (String.IsNullOrEmpty(url))
            {
                txtUrl.Foreground = Brushes.Red;
                isValid = false;
            }
            if (criancaModel == null)
            {
                txtUrl.Foreground = Brushes.Red;
                isValid = false;
            }

            if (isValid)
            {
                SiteModel siteModel = new SiteModel();
                siteModel.url = url;
                siteModel.status = (int)Enums.Status.Liberado;
                siteModel.criancaID = criancaModel.id;

                string resp = SitesService.postSite(siteModel);

                MessageBox.Show(resp);

                txtUrl.Text = "";
                txtUrl.Foreground = Brushes.Transparent;
                cbChild.SelectedItem = null;
                cbChild.Foreground = Brushes.Transparent;
                GridCadastroSite.Visibility = Visibility.Collapsed;
                dgChild.Visibility = Visibility.Visible;
            }
        }
    }
}
