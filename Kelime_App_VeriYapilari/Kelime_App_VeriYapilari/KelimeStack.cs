using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelime_App_VeriYapilari
{
    public class KelimeStack
    {
        public KelimeNode top;
        int kelimeNo=0;
        
        public KelimeStack()
        {
            top = null;
        }

        public void push(string k, string dk,int cmlNo,int frq)
        {
            KelimeNode temp = new KelimeNode();
            kelimeNo++;
            temp.KlmOrj = k;
            temp.Klm = dk.ToLower();
            temp.link = top;
            temp.CumleNo = cmlNo;
            temp.KelimeNo = kelimeNo;
            temp.KullanimS = frq;   
            top = temp;  
        }

        

        public string knt()
        {
            string s = "";


            KelimeNode tmp = top;
            while (tmp != null)
            {

                // print node data
                s += "Orj.Kelime:"+tmp.KlmOrj+"     Önişlemiş Klm.:"+tmp.Klm + "   Bulunduğu Cümle No:" + tmp.CumleNo.ToString()+"      Cümledeki Kelime Sırası:" + tmp.KelimeNo + "     Sıklığı:" + tmp.KullanimS+  "\n\n";

                // assign temp link to temp
                tmp = tmp.link;

            }

            return s;
        }

        public int KelimeSay()
        {
            int kSay = 0;
            KelimeNode tmp = top;
            while (tmp != null)
            {

                kSay++;
                tmp = tmp.link;
            }

            return kSay;
        }

        public void KelimeDizisiOlustur(int bas,KelimeNode[]Kelimeler )
        {
            KelimeNode tmp = top;
            while (tmp!=null)
            {
                Kelimeler[bas] = tmp;
                tmp = tmp.link;
                bas++;
            }

        }

    }
}
