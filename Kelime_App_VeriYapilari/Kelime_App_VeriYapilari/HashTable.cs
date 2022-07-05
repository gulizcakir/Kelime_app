using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelime_App_VeriYapilari
{
    public class HashTable
    {
        //kelimenin kullanım sayısına göre hashleme yaptım.
        //key= kelimenin kullanım sayısıdır.
        public int size;
        public HashNode[] dizi { get; set; }
        public HashTable(int size)
        {
            this.size = size;
            dizi = new HashNode[size];
            for (int i = 0; i < size; i++)
            {
                dizi[i] = new HashNode();
            }
        }
        public int indexUret(int key)
        {
            return key % size;
        }

        public void Ekle(int key, string kelime)
        {
            HashNode eleman = new HashNode(key, kelime);
            int indis = indexUret(key);
            HashNode temp = dizi[indis];

                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = eleman;
            
        }
        
        //ayrık zincirleme ile çakışma problemi önlenmiş hash table 'ı yazdırır.
        public string TabloyuYazdir()
        {
            string tbl="";
           
            for (int i = 0; i < size; i++)
            {
                HashNode temp = dizi[i];
                tbl+= (" Dizi["+i.ToString()+"]->");

                while (temp.next!=null)
                {
                    temp = temp.next;
                    tbl += temp.kelime+" ->";
                }
                tbl += "\n";
            }
            return tbl;
        }

    }
}
