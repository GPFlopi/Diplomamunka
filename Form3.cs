using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace Diplomamunka
{
    public partial class Form3 : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        private OleDbConnection conn2 = new OleDbConnection();
        public System.Windows.Forms.TextBox tb3;
        Form2 f2;
        string Table;
        string Field;
        string Data;
        string LL;

        public Form3(Form2 f)
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + ConfigurationManager.AppSettings["dir"] + ";Persist Security Info=False;";
            conn2.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=History.accdb;Persist Security Info=False;";
            f2 = f;
            // this.TopMost = true;
            
            tb3 = textBox1;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X + 47, this.Location.Y + 88);

            if (f2.i==1)
            {
                button3.Text = "Hozzáadás";
            } else if (f2.i ==2)
            {
                button3.Text = "Módosítás";
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            f2.Of = 0;
            f2.i = 1;


        }

        private void button2_Click(object sender, EventArgs e)
        {
                if (f2.i == 1)
                { add(); }
                else if (f2.i == 2)
                { mod();  }
        }

        private void add()
        {

            //MessageBox.Show(Convert.ToString(f2.data.Columns[0]));

            if (f2.data.CurrentCell.OwningColumn.Name == "ID" && f2.data.CurrentCell.OwningColumn.Name == "id" && f2.data.CurrentCell.OwningColumn.Name == "iD" && f2.data.CurrentCell.OwningColumn.Name == "Id")
            {
                MessageBox.Show("Az tábla Elsődleges kulcsához nem tud hozzá adni adatot, próbáld ujra!");
            }
            else
            {
                
                Field += "[" + f2.data.CurrentCell.OwningColumn.Name + "],";
                //MessageBox.Show(f2.data.CurrentCell.OwningColumn.Name);
                Data += "'" + textBox1.Text + "',";
                label1.Text += "Table:" + f2.cb.Text + "\nField:" + f2.data.CurrentCell.OwningColumn.Name + "\nNew Value:" + textBox1.Text + "\n---------------------------\n";
            }

        }
        private void add2()
        {
            try
            {   
                int ID = 1;
                
                foreach (DataGridViewRow dr in f2.data.Rows)
                {

                    var index =dr.Cells[0].Value;
                    
                    if (Convert.ToInt32(index) > ID)
                    {
                       
                        ID= Convert.ToInt32(index);
                    }
                    
                }
                    ID++;
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;
               
                    Field = Field.Substring(0, Field.Length - 1);
                    Data = Data.Substring(0, Data.Length - 1);
                   // MessageBox.Show(f2.cb.Text + "-" + Field + "-" + Data);
       

                
                    string q = "insert into " + f2.cb.Text + "([ID]," + Field + ") values('"+ID+"'," + Data + ");";
                    cmd.CommandText = q;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sikeresen Adat bevitel!");
                    addh(ID);
                    conn.Close();
                    Field = "";
                    Data = "";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Rosz értéket adtál meg!" + ex);
                conn.Close();
            }
        }
        public void addh(int id)
        {
            try
            {

                conn2.Open();
                OleDbCommand cmdh = new OleDbCommand();
                cmdh.Connection = conn2;

                string q = "insert into History([Time],[Function],[Changes]) values('" + DateTime.Now.ToString("yyyy-MM-dd   h:mm:ss") + "','ADD','ADDED ROW " + id + " TO " + f2.cb.Text + "');";
                cmdh.CommandText = q;
                cmdh.ExecuteNonQuery();
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        private void mod()
        {
            Field = "[" + f2.data.CurrentCell.OwningColumn.Name + "]";

            Data = "'" + textBox1.Text + "'";
            LL += Field + "=" + Data + ",";
            MessageBox.Show("Addat hozzá adva");
            //MessageBox.Show(LL);
        }

        private void mod2()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                
                LL = LL.Substring(0, LL.Length - 1);
                //MessageBox.Show(LL);
                var index = Convert.ToString(f2.data.CurrentRow.Cells[0].Value);
                string q = "update "+f2.cb.Text+" set "+LL+" Where ID="+index+" ;";
                cmd.CommandText = q;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sikeresen Adat Változtatas");
                label1.Text += "In"+f2.cb.Text+" Line "+textBox1.Text+" Modified\n---------------------------\n";
                modh();
                LL = "";
                Field = "";
                Data = "";
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n"+ex);
                conn.Close();
            }
        }

        public void modh()
        {
            try
            {

                conn2.Open();
                OleDbCommand cmdh = new OleDbCommand();
                cmdh.Connection = conn2;

                string q = "insert into History([Time],[Function],[Changes]) values('" + DateTime.Now.ToString("yyyy-MM-dd   h:mm:ss") + "','MODIFY','MODIFIED ROW " + textBox1.Text + " IN " + f2.cb.Text + "');";
                cmdh.CommandText = q;
                cmdh.ExecuteNonQuery();
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (f2.i == 1)
            {
                add2();
            }
            else if (f2.i == 2)
            {
                mod2(); 
            }
            f2.table();
        }

     
    }
}
