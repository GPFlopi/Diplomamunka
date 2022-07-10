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
    public partial class Form2 : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        private OleDbConnection conn2 = new OleDbConnection();
        Form3 fun;
        public Form4 Sett;
        Form1 f1;
        public System.Windows.Forms.DataGridView data;
        public System.Windows.Forms.ComboBox cb;

        public int i=0;
        public int Of = 0;
        int of = 0;
        int Cf = 1;
        int m;
        public int OP = 0;
        int h=0;
        public int s = 0;
        
        public Form2()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + ConfigurationManager.AppSettings["dir"] + ";Persist Security Info=False;";
            conn2.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=History.accdb;Persist Security Info=False;";
            fun = new Form3(this);
            Sett = new Form4(null, this);
            
            data = dataGridView1;
            cb = comboBox1;
            


        }



        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            if (f1.g == 0)
            {
            }
            else
            {
               
                beviTel.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Application.Restart();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            table();
        }
       
        private void beviTel_Click(object sender, EventArgs e)
        {
            i = 1;
            m = 0;
            func(m);
            this.Location = new Point(this.Location.X + 1, this.Location.Y - 1);
            this.Location = new Point(this.Location.X - 1, this.Location.Y + 1);    
        }

        public void table()
        {

            try
            {
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + ConfigurationManager.AppSettings["dir"] + ";Persist Security Info=False;";
                
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                string query = " select * from " + comboBox1.Text;
                cmd.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable(); 
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
                conn.Close();
            }
        }

        private void Form2_LocationChanged(object sender, EventArgs e)
        {
            fun.Location = new Point(this.Location.X - 255, this.Location.Y + 0);
            Sett.Location = new Point(this.Location.X + 500, this.Location.Y + 255);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
           
            if (s == 0)
            {
                Form4 Sett = new Form4(null,this);
                Sett.Show();
                s = 1;
                this.Location = new Point(this.Location.X + 1, this.Location.Y - 1);
                this.Location = new Point(this.Location.X + 1, this.Location.Y + 1);
            }
            else
            {
                s = 0;
                Sett.Close();
            }
        }

        public void tables()
        {

            if (OP != 1)//Nem akarjuk hogy megállás nélkül hozá adja az értékeket
            {
                
                try
                {
                    cb.Items.Clear();
                    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + ConfigurationManager.AppSettings["dir"] + ";Persist Security Info=False;";

                    conn.Open();
                    DataTable dt2 = conn.GetSchema("TABLES");
                
                    foreach (DataRow r2 in dt2.Rows)
                    {
                        string str, asd;

                        DataTable dt = conn.GetSchema("TABLES")
                          .AsEnumerable()
                          .Where(x => x.Field<string>("TABLE_TYPE") == "TABLE")
                          .CopyToDataTable();
                        str = r2["TABLE_NAME"].ToString();
                        try
                        {
                            asd = str.Substring(0, 4);

                            if (asd == "MSys")
                            {
                                r2["TABLE_NAME"] = "";
                                    
                            }
                        }
                        catch (Exception ex)
                        {
                            r2.ClearErrors();
                        }
                    }
                    
                    foreach (DataRow r in dt2.Rows)
                    {
                        if (r["TABLE_NAME"].ToString() != "")
                        { comboBox1.Items.Add(r["TABLE_NAME"].ToString()); }
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: \n" + ex);
                    conn.Close();
                }
            }
            OP = 1;
        }

        public void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            tables();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="")
            { MessageBox.Show("Kérem adjon meg egy táblát!"); }
            else {del(); }
            
        }
        private void func(int m)
        {
            if (Of == 0)
            {
                fun = new Form3(this);
                fun.Show();
                Of = 1;
                
            }
            else
            {
                fun.Close();
                Of = 0;
                of = 0;
                if (m == 1)
                {
                    i = 2;
                }
                else if (m == 0)
                {
                    i = 1;
                }
                else if (m == 2)
                {
                    i = 2;
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i = 2;
            m = 2;
            of = 1;
            func(m);
            this.Location = new Point(this.Location.X + 1, this.Location.Y - 1);
            this.Location = new Point(this.Location.X - 1, this.Location.Y + 1);
        }
        private void del()
        {
            DialogResult dialogResult = MessageBox.Show("Biztosan szeretnéd kitörölni ezt az adatot?\n-"+ data.CurrentCell.Value +"sor értékei ki lesznek törölve és nem lehet visszavonni", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + ConfigurationManager.AppSettings["dir"] + ";Persist Security Info=False;";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;

                    string q = "DELETE FROM " + cb.Text + " where " + data.CurrentCell.OwningColumn.Name + " = " + data.CurrentCell.Value + ";";

                    cmd.CommandText = q;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sikeresen Adat törlés!");
                    // label1.Text += "Table:" + f2.cb.Text + "\n" + textBox1.Text + " deleted!\n---------------------------\n";
                    delh();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    if (data.CurrentCell.Value != "ID" && data.CurrentCell.Value != "iD" && data.CurrentCell.Value != "Id" && data.CurrentCell.Value != "id")
                    {
                        MessageBox.Show("A sor elsődleges kulcsát válassza ki!");
                    }
                    else { MessageBox.Show("A beírt érték nem megfelelő! Próbálja újra"); }


                    conn.Close();
                }
                table();
            }
           

        }
        private void delh()
        {
            try
            {
                conn2.Open();
                OleDbCommand cmdh = new OleDbCommand();
                cmdh.Connection = conn2;

                    string q = "insert into History([Time],[Function],[Changes]) values('" + DateTime.Now.ToString("yyyy-MM-dd   h:mm:ss") + "','Delete','DELETED ROW " + data.CurrentCell.Value + " From " + comboBox1.Text + "');";
                    cmdh.CommandText = q;
                cmdh.ExecuteNonQuery();
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }


        

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if(of==1)
            {

                fun.tb3.Text = dataGridView1.CurrentCell.Value.ToString(); 
            }
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            if (h == 0)
            {
                comboBox1.Enabled = false;
                try
                {
                    conn2.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn2;
                    string query = " select * from History";
                    cmd.CommandText = query;

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt2 = new DataTable();
                    da.Fill(dt2);
                    dataGridView1.DataSource = dt2;

                    conn2.Close();
                    
                    h=1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt , feltehetőleg a következők történhettek:\n "+ex);
                    conn.Close();
                }
            }
            else
            {
                comboBox1.Enabled = true;
                dataGridView1.Columns.Clear();
                h = 0;
            }
        }
    }
    }
