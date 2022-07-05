using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelime_App_VeriYapilari
{
    public class Max_bin_heap
    {
        AgacNode root;
        AgacNode insert_pos;

        public Max_bin_heap(AgacNode node)
        {
            root = node;
            insert_pos = node;
        }

        public void insert(AgacNode n)
        {
            if (insert_pos.left == null)
            {
                insert_pos.left = n;
                n.parent = insert_pos;
                balance_heap(n);
                return;
            }
            else
            {
                insert_pos.right = n;
                n.parent = insert_pos;
                adjust_insert_pos();
                balance_heap(n);
            }
        }

        private void adjust_insert_pos()
        {
            AgacNode node;
            Queue<AgacNode> q = new Queue<AgacNode>();
            q.Enqueue(root);
            while (q.Count>0)
            {
                node = q.Dequeue();
                if (node.left !=null)
                {
                    q.Enqueue(node.left);
                }
                else
                {
                    insert_pos = node;
                    break;
                }
                if (node.right !=null)
                {
                    q.Enqueue(node.right);
                }
                else
                {
                    insert_pos = node;
                    break;
                }
            }
        }

        private void balance_heap(AgacNode n)
        {
            while (n.parent.data != null)
            {
                if (n.parent.data.KullanimS<n.data.KullanimS)
                {
                    KelimeNode tmp = n.data;
                    n.data = n.parent.data;
                    n.parent.data = tmp;
                    n = n.parent;
                }
                else
                {
                    break;
                }

            }
        }

        public string traversal()
        {
            int a = 0;
            AgacNode node;
            string icerik="";
            Queue<AgacNode> q = new Queue<AgacNode>();
            q.Enqueue(root);
            while (q.Count>0)
            {
                a++;
                node = q.Dequeue();
                icerik += a+" "+"Kelime:" + node.data.Klm + "  Kelimenin kullanım sıklığı:" + node.data.KullanimS+"\n";

                if (node.left !=null)
                {
                    q.Enqueue(node.left);
                }
                if (node.right!=null)
                {
                    q.Enqueue(node.right);
                }
            }
            return icerik;
        }
       
    }
}
