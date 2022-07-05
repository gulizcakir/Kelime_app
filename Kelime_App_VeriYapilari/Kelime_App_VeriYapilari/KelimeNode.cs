using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelime_App_VeriYapilari
{
    public class KelimeNode
    {
        public string KlmOrj { get; set; }

        public string  Klm { get; set; }

        public int KullanimS { get; set; }

        public int CumleNo { get; set; }
        public int KelimeNo { get; set; }

        int no;
        public KelimeNode()
        {
            no++;
            KelimeNo = no;
        }

        public KelimeNode link;

       
    }
}
