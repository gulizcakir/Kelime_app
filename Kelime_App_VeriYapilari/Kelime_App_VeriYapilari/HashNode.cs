using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelime_App_VeriYapilari
{
    public class HashNode
    {
        public int key;
        public string kelime;
        public HashNode next;
        public HashNode()
        {
            this.next = null;
        }
        public HashNode(int key,string kelime)
        {
            this.key = key;
            this.kelime = kelime;
            this.next = null;
        }
    }
}
