using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Interface
{
    public interface ICustomBrowser
    {
        void PreviousPage();
        void ForwardPage();
        void HomePage();
        void ConfigurationPage();
    }
}
