using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Diplomamunka
{
    public partial class Form4 : Form
    {
      
        Form1 f1;
        Form2 f2;
        Form3 f3;

        public int BS = 0;
        
     

        public Form4(Form1 f,Form2 ff)
        {
            InitializeComponent();
            f1 = f;
            f2 = ff;

            
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            f1 = new Form1();
            f2=  new Form2();
            int n;
            f1.Location = new Point(f1.Location.X + 1, f1.Location.Y - 1);
            f1.Location = new Point(f1.Location.X - 1, f1.Location.Y + 1);
            radioButton2.Checked = true;
            f2 = new Form2();
            f1 = new Form1();
        }

        

        private void back_Click(object sender, EventArgs e)
        {
            
            f2.s = 0;
            f1.ss = 0;
            this.Close(); 
        }

        private void Form4_LocationChanged(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            if (f1.g == 0)
            {
                
            }
            else
            {
                button2.Enabled = false;
                textBox1.Enabled = false;
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !="")
            {
                ConfigurationManager.AppSettings["dir"] = textBox1.Text;
                //ConfigurationManager.AppSettings["dir"].Replace(ConfigurationManager.AppSettings["dir"], textBox1.Text);
                if (ConfigurationManager.AppSettings["dir"] == textBox1.Text)
                {
                    MessageBox.Show("Sikeres" + ConfigurationManager.AppSettings["dir"]);
                }
                else
                {
                    MessageBox.Show("Sikertelen+" + ConfigurationManager.AppSettings["dir"]);
                }


                f2.tables();//Nem cseréli ki a táblázatokat, marad az eredetinél
                f2.OP = 0;
            }
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (BS == 0)
            {
                BS = 1;
                f1 = new Form1();
                f1.Sb = 1;
                
                f1.Show();
            }else
            {
                f1.Close();
                BS = 0;
            }
            
        }

     
        //Sikertelen próbálkozás a Szín megváltoztatására
        //private void radioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    Form1 f1= new Form1();
        //    Form2 f2= new Form2();
        //    Form3 f3= new Form3(f2);
        //    if (radioButton2.Checked)
        //    {

        //        ConfigurationManager.AppSettings["color"] = "1";
        //    }
        //    else if (radioButton3.Checked)
        //    {
        //        ConfigurationManager.AppSettings["color"] = "2";
                
        //    }
        //    else { MessageBox.Show(""); }
        //}
    }
}
