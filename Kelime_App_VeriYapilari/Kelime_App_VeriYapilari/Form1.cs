using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//--------------------------
using System.Reflection;
using System.Text.RegularExpressions;





namespace Kelime_App_VeriYapilari
{
    // cümleleri stakta tuttum
    //Her cümlenin kelimelerini tutan ayrı ayrı stacklar oluşturdum.
    //Kelimeleri tutan stack'ları dizide tuttum.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        OpenFileDialog openFile = new OpenFileDialog();
        CumleStack CumleStack = new CumleStack();
        KelimeStack DuzenlenmisStack = new KelimeStack();
        KelimeStack[] kelimeStacks;
        KelimeNode[] tumKelimeler;


        string line = "";
        string metin = "";

        int cmlNo = 0;
        int satirSay;
        
        private void btnMtnYukle_Click(object sender, EventArgs e)
        {
            openFile.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                richTxtFile.Text = openFile.FileName;
                richTxtPath.Text = Path.GetFileName(openFile.FileName);

                // metnin satır sayısını bulma.
                satirSay = File.ReadLines(openFile.FileName).Count();

                //Her satırda bir cümle olduğundan satır sayısı kadar kelime stack'ı bulunduran
                //dizi oluşturulur.(Kelimelerden oluşan her cümle için ayrı bir stack oluşturuyoruz.)
                kelimeStacks = new KelimeStack[satirSay];
                
            }
        } 


        int cnt = 0;//satır sayısı
        int count = 0;
        int kelimeSayisi=0;
      


        private void button1_Click(object sender, EventArgs e)
        {
            string Bilgi = "";
            StreamReader streamReader = new StreamReader(openFile.FileName);
            StreamReader streamReader1 = new StreamReader(openFile.FileName);
            StreamReader streamReader2 = new StreamReader(openFile.FileName);

            metin = streamReader.ReadToEnd().ToLower();
            string[] delimitee = { " ", ",", ".", "*", ";", "!", "?", "-","\n", "\r"};
            string[] klmler = metin.Split(delimitee, StringSplitOptions.RemoveEmptyEntries);
            kelimeSayisi = klmler.Length;
     

            for (int q = 0; q < klmler.Length; q++)
            {
                        int indexx = klmler[q].LastIndexOf("'"); //(')' dan sonra gelen eki almamak için.
                        if (indexx > 0)
                        {
                         klmler[q] = klmler[q].Substring(0, indexx).ToLower();//kelimeyi düzeltti.
                        }             
            }


            while (line != null)
            {
               Cumle cml = new Cumle();
               if (streamReader2.ReadLine() == null)
               {
                break;
               }

               line = streamReader1.ReadLine();

               if (line != null)
               {
                 listBox1.Items.Add(line);//txt dosyasındaki orjinal metni listBox'a yazdırır.
                 cml.cumle = line;
                 cmlNo = cmlNo + 1;
                 string[] delimite = {" "};
                 string[] orjKlm = line.Split(delimite, StringSplitOptions.RemoveEmptyEntries);
                 string[] islenmisKlm = line.Split(delimitee, StringSplitOptions.RemoveEmptyEntries);

                    //islenmis kelimelerin tümünü küçük harflerden oluşmuş hale getirerek ön işlemeyi tamamlıyoruz.
                    for (int i = 0; i < islenmisKlm.Length; i++)
                    {
                        islenmisKlm[i]=islenmisKlm[i].ToLower();
                    }

                
                 cml.KelimeSay = orjKlm.Length;

                 //kelime stack'ı oluşturulacak.
                 //Örneğin 1.cümle 1.stack içinde kelimler var.
                 KelimeStack KelimeStack = new KelimeStack();
                 for (int i = 0; i < islenmisKlm.Length; i++)
                 {
                    
                    int index = islenmisKlm[i].LastIndexOf("'"); //Kelimeden sonki eki silmek için.
                    if (index >= 0)
                    {
                      islenmisKlm[i] = islenmisKlm[i].Substring(0, index).ToLower();//kelimeyi düzeltti.
                    }
                    
                    // Metinde aynı olan kelimeleri bulmak için eş patternler aranıyor. 
                    for (int p = 0; p < klmler.Length; p++)
                    {
                     // eğer bulunursa sayı 1 arttırılıyor.
                      if (klmler[p].Contains(islenmisKlm[i]))
                      {
                       count++;
                      }    
                    }

                     KelimeStack.push(orjKlm[i], islenmisKlm[i], cmlNo, count);//oluşan stack'a kelime düğümü eklendi.
                     count = 0;
                 }


                  
                  Bilgi+=KelimeStack.knt();
                  richTextBox1.Text = Bilgi;
                  kelimeStacks[cnt] = KelimeStack; //kelime stack dizisi.
                  cnt = cnt + 1;
                  CumleStack.push(cml);

               }
                
            }  
            MessageBox.Show("NOT:Cümle stack'ında cümleler orijinal haliyele tutulmuştur."+"\n"
                           +"(Kelime Stack'ında kelimelerin hem önişlenmiş hali hem orjianl halleri mevcuttur.)" + "\n\n"
                           + "Cümle Stack"+"\n\n"+CumleStack.kntrl());
            streamReader1.Close();
            streamReader.Close();
        }


        int toplamKsay = 0;
        
        private void button2_Click(object sender, EventArgs e)
        {

            int cumleSay = kelimeStacks.Length;
            int cmlNo = 0;
            int kSay = 0;
            
            string Bilgi="Cümle Numarası      Kelime Sayısı";
            string dgr;
            listBox2.Items.Add(Bilgi);
            for (int i = 0; i <kelimeStacks.Length; i++)
            {
                cmlNo = i+1;        
                kSay = kelimeStacks[i].KelimeSay();
                dgr ="          " +cmlNo.ToString() + "                           " + kSay.ToString();
                listBox2.Items.Add(dgr);

                toplamKsay += kSay;
            }
            listBox2.Items.Add("Dosyadaki toplam cümle sayısı: " +cumleSay);
            listBox2.Items.Add("Dosyadaki toplam kelime sayısı: " + toplamKsay);
            listBox2.Items.Add("Her cümledeki ortalama kelime sayısı: " + toplamKsay/cumleSay);
        }


        int bas = 0;
        KelimeNode[] newDizi;
        Max_bin_heap heap;
        private void btnAgac_Click(object sender, EventArgs e)
        {
            //“Ağaca Aktar” butonu ile de kelimeler tutulan yığıt dizisinden ağaç veri yapısına
            //aktarılmalıdır.

            tumKelimeler = new KelimeNode[toplamKsay+1];

            //kelimeleri stack'tan alıp diziye aktarıyoruz.
            for (int o = 0; o < kelimeStacks.Length; o++)
            {
                kelimeStacks[o].KelimeDizisiOlustur(bas, tumKelimeler);
                bas = kelimeStacks[o].KelimeSay() + bas;
                
            }
            
            Agac BST = new Agac();
            
            int num = tumKelimeler.Length;
            //Binary tree oluşturduk.
            
            for (int i = 0; i < num; i++)
            {
                for (int j= i+1; j < num; j++)
                {
                    if (tumKelimeler[j] !=null)
                    {
                        if (tumKelimeler[i].Klm == tumKelimeler[j].Klm)
                        {
                            for (int k = j; k < num; k++)
                            {
                                if (k + 1 < tumKelimeler.Length)
                                {
                                    tumKelimeler[k] = tumKelimeler[k + 1];
                                }
                                else
                                {
                                    break;
                                }

                            }

                            //Yinelenen öğeyi kaldırdıktan sonra boyutu azalt.
                            //(Ağaca aynı kelimeler farklı konumlarda olsalarda tekrar tekrar eklenmesin diye yinelemeleri engelledim.)
                            num--;
                            j--;
                        }
                    }
                }
            }

            newDizi = new KelimeNode[num-1];
            for (int i = 0; i <num-1; i++)
            {
                newDizi[i] = tumKelimeler[i];
            }

            //heap ağacı oluşturuyorum.(max heap tercih ettim)
            //heap ağacına ekleme yaparken bir kelimeyi konumuna bakmazsızın 1 kere ekliyorum (önceki satırlarda yapı sağlanmıştır).
            heap = new Max_bin_heap(new AgacNode(newDizi[0]));
            for (int p = 1; p < newDizi.Length; p++)
            {
                heap.insert(new AgacNode(newDizi[p]));
            }
           //Oluşturduğum heap ağacı üzerinde gezinerek yazdırıyorum.
            MessageBox.Show("Sırasıyla Heap Ağacındakiler"+"\n\n"+heap.traversal());
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            //İlk kaç kelimeyi vermesini istediğinin kontrolünü sağlıyorum.
            string print(KelimeNode[] arr)
            {
                string a ="Girdiğiniz kelime sayısı uygun değil ! Lütfen uygun değer giriniz!";
                int n = Convert.ToInt32(txtKlmSay.Text);
               
                int l = arr.Length;
               
                if (n<=l && n!=0)
                {
                    a = "";
                    for (int i = 0; i < n; ++i)
                    {
                        a += arr[i].Klm + "\n ";
                    }

                }

                return a;
            }

            //heap sort ile sonucu veriyoruz.
            HeapSort ob = new HeapSort();
            ob.sort(newDizi);
            MessageBox.Show(print(newDizi));
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            //kelimenin kullanım sayısına göre hashleme yapıyorum.
            //çünkü yüklenen text'te tüm kelimelerin aynı olma durumu olabilir.
            int key;
            string kelime;
            HashTable ht = new HashTable(toplamKsay);
            for (int i = 0; i < newDizi.Length; i++)
            {
                key = newDizi[i].KullanimS;
                kelime = newDizi[i].Klm;
                ht.Ekle(key, kelime);
            }
            //Ayrık zincirleme yöntemi ile çakışmaları engelleyorum.
            //oluşan yapıyı görsel hale getirmeye çalışıp gösterdim.
            string cvp = ht.TabloyuYazdir();
            MessageBox.Show("Oluşan yapı görsel hale getirilmeye çalışılmıştır."+"\n\n"+cvp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Tam ekrana geçiniz!");
        }
    }
}
