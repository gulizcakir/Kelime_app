using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelime_App_VeriYapilari
{
    public class Agac
    {
        public AgacNode root;
        public Agac()
        {
            root = null;
        }

       public AgacNode newNode(KelimeNode data)
       {
            root = new AgacNode(data);
            return root;
       }
      
        public AgacNode insert(AgacNode root ,KelimeNode data)
        {
            AgacNode eleman = new AgacNode(data);
            if (root != null)
            {
                if (data.KullanimS < root.data.KullanimS)
                {
                    root.left = insert(root.left, data);
                }
                else
                {
                    root.right = insert(root.right, data);
                }
            }
            else root = new AgacNode(data);
            return root;
        }
    }
}
