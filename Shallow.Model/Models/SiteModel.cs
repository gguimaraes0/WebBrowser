using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shallow.Model.Enums.Enums;

namespace Shallow.Model.Models
{
    public class SiteModel
    {
        public int id { get; set; }
        public string url { get; set; }
        public Status status { get; set; }
        public int criancaID { get; set; }
    }
}
