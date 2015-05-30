using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airdia
{
    class Date
    {
        // Singleton ( Design Pattern )
        private static Date instance;
        private Date(string y, string m, string d)
        {
            this.y = y;
            this.m = m;
            this.d = d;
        }
        public static Date getInstance(string y, string m, string d)
        {
            if (instance == null)
            {
                instance = new Date(y, m, d);
            }
            else
            {
                instance.y = y;
                instance.m = m;
                instance.d = d;
            }
            return instance;
        }

        public string y { set; get; }
        public string m { set; get; }
        public string d { set; get; }
    }
}
