using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shallow.Model.Models
{
    public class SiteModel
    {
        public int id { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public int criancaID { get; set; }
    }
}
