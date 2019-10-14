using System;
using System.Collections.Generic;
using System.Text;

namespace RPH.Oftamed
{
    partial class DBConnection
    {
        public static List<Medicament> ListaMedicamente;
        //public static List<Medicament> ListaMedicamente = new List<Medicament>();

        public static List<GhidHardCode> GetGhidName()
        {
            List<GhidHardCode> v = new List<GhidHardCode>();

            v.Add(new GhidHardCode{ Ghid = "Ghid medicamente antiglaucomatoase" });

            return v;
        }
    }
}
