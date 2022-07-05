using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelime_App_VeriYapilari
{
    public class CumleStack
    {
        public CumleNode Top;
        public CumleStack()
        {
            Top = null;
        }

        
        public void push(Cumle c)
        {
            CumleNode temp = new CumleNode();
            temp.cumle = c;
            temp.link = Top;
            Top = temp;
        }

        public string kntrl()
        {
            string s="";
            CumleNode tmp = Top;
            while (tmp != null)
            {

                // print node data
                 s+="->"+ tmp.cumle.cumle;
                // assign temp link to temp
                 tmp = tmp.link;
               
            }

            return s;
        }

    }  
}


