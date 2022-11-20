using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Interface
{
    public interface ICustomBrowser
    {
        void PreviousPage(bool canGoBack);
        void ForwardPage(bool canGoForward);
        void HomePage();
        void ConfigurationPage();
    }
}
