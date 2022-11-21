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
        public ConfigurationView()
        {
            InitializeComponent();
            getSites();
        }

        public void getSites()
        {
            Sites = SitesService.getSites();
        }
    }
}
