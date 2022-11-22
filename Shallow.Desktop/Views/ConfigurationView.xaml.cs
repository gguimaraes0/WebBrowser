using CefSharp;
using Shallow.API.Services;
using Shallow.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<SiteModel> Sites = new List<SiteModel>();

        public List<CriancaModel> Child = new List<CriancaModel>();

        public ResponsavelModel ResponsavelModel { get; set; }
        public CriancaModel CriancaModel { get; set; }

        public ConfigurationView(ResponsavelModel responsavel = null, CriancaModel crianca = null)
        {
            InitializeComponent();
            CriancaModel = crianca;
            ResponsavelModel = responsavel;
            getSites();

            if (CriancaModel != null)
            {
                btnVisualizeChild.Visibility = Visibility.Collapsed;
                btnRegisterChild.Visibility = Visibility.Collapsed;
                btnRegisterSiteforChild.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnVisualizeChild.Visibility = Visibility.Visible;
                btnRegisterChild.Visibility = Visibility.Visible;
                btnRegisterSiteforChild.Visibility = Visibility.Visible;
            }
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
                Child = CriancaService.getSitesByResponsavelID(ResponsavelModel.id);

            dgChild.ItemsSource = null;
            dgChild.ItemsSource = Child;

            dgChild.Visibility = Visibility.Visible;
        }

        private void btnRegisterChild_Click(object sender, RoutedEventArgs e)
        {
            dgSites.Visibility = Visibility.Collapsed;
            dgChild.Visibility = Visibility.Collapsed;

        }

        private void btnVisualizeChild_Click(object sender, RoutedEventArgs e)
        {
            getChild();
        }

        private void btnVisualizeSites_Click(object sender, RoutedEventArgs e)
        {
            getSites();
        }

        private void btnRegisterSiteforChild_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
