using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airdia
{
    class Date
    {
        public Date(string y, string m, string d)
        {
            this.y = y;
            this.m = m;
            this.d = d;
        }

        public string y { set; get; }
        public string m { set; get; }
        public string d { set; get; }
    }
}
