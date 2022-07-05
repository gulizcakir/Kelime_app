using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelime_App_VeriYapilari
{
    public class AgacNode
    {
        public KelimeNode data { get; set; }
        public AgacNode left { get; set; }
        public AgacNode right { get; set; }
        public AgacNode parent { get; set; }


        public AgacNode(KelimeNode data)
        {
            this.data = data;
            this.parent = null;

        }
    }
}
