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
    public partial class Form1 : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        private OleDbConnection conn2 = new OleDbConnection();
        public Form2 AdatB = new Form2();
        public Form4 Sett;
        public Form1 f1;
        public int g = 0;
        public int ss = 0;
        public int Sb = 0;
       

        public Form1()
        {
            InitializeComponent();
            
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + ConfigurationManager.AppSettings["udir"] + ";Persist Security Info=False;";
            conn2.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + ConfigurationManager.AppSettings["udir"] + ";Persist Security Info=False;";

            Sett = new Form4(this, null);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(Sb==1)
            { RegB();}
            
        }

        private void b1_Click_1(object sender, EventArgs e)
        {
            b4.Location = new Point(123, 225);
            title.Text = "Belépés";
            b1.Visible = false;
            b2.Visible = false;
            b3.Text = "Vissza";
            b4.Visible = true;
            nevLab.Visible = true;
            nevBox.Visible = true;
            jelLab.Visible = true;
            jelBox.Visible = true;
            b4.Text = "Belépés";
            guest.Visible = true;
        }

        private void b2_Click_1(object sender, EventArgs e)
        {
            RegB();
        }

        public void RegB()
        {
            b4.Location = new Point(123, 225);
            title.Text = "Regisztráció";
            b1.Visible = false;
            b2.Visible = false;
            b3.Text = "Vissza";
            settButt.Visible = false;
            b4.Visible = true;
            nevLab.Visible = true;
            nevBox.Visible = true;
            jelLab.Visible = true;
            jelBox.Visible = true;
            b4.Text = "Registráció";
            Sett.BS = 1;
        }

        private void b3_Click_1(object sender, EventArgs e)
        {
            Back();
        }

        public void color()
        {
            this.BackColor = SystemColors.Desktop;
            //never used
        }
            

        private void b4_Click(object sender, EventArgs e)
        {
            if (guest.Checked == true)
            {
                try
                {
                    conn2.Open();
                    OleDbCommand hist = new OleDbCommand();
                    hist.Connection = conn2;


                    hist.CommandText = "insert into Ido (Nev,Datum) values('" + nevBox.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd   h:mm:ss") + "')";
                    hist.ExecuteNonQuery();
                    g = 1;
                    conn2.Close();
                    AdatB.Show();
                    try
                    {
                        this.Hide();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba" + ex);
                    conn.Close();
                }
            }
            else
            {
                //if (b4.Text == "Registráció")
                //{
                //    try
                //    {
                //        conn.Open();
                //        OleDbCommand cmd = new OleDbCommand();
                //        cmd.Connection = conn;
                //        try
                //        {
                //            cmd.CommandText = " insert into Admin(user_name,[password]) values('" + nevBox.Text + "','" + jelBox.Text + "')";

                //            cmd.ExecuteNonQuery();
                //            conn.Close();
                            

                //        }
                //        catch (Exception ex)
                //        {

                //            //MessageBox.Show("Ezt a jelszót már valaki már használja." + "\n" + "Próbáld újra!"+ex);
                //            conn.Close();
                //        }

                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("Error " + ex);
                //        conn.Close();
                //    }

                //    try
                //    {
                //        this.Hide();
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //}
                //else
                if (b4.Text == "Belépés")
                {
                    try
                    {
                        conn.Open();

                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "select * from Admin where user_name='" + nevBox.Text + "' and [password]='" + jelBox.Text + "'";
                        g = 1;
                        OleDbDataReader read = cmd.ExecuteReader();
                        int c = 0;
                        while (read.Read())
                        {
                            c++;
                        }
                        if (c == 1)
                        {
                            try
                            {
                                conn2.Open();
                                OleDbCommand hist = new OleDbCommand();
                                hist.Connection = conn2;

                                    
                                hist.CommandText = "insert into Ido (Nev,Datum) values('" + nevBox.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd   h:mm:ss") + "')";
                                hist.ExecuteNonQuery();
                                conn2.Close();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Hiba" + ex);
                                conn.Close();
                            }
                            AdatB.Show();
                            ss = 0;
                            Sett.Close();
                            try
                            {
                              
                                this.Hide();
                            }catch(Exception ex)
                            {
                                
                            }

                        }
                        else
                        {

                            MessageBox.Show("Nem jó a felhasználó név vagy a jelszó, kérem próbálja újra!");
                            conn.Close();


                        }

                        conn.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("hiba:\n"+ex);
                    }
                        
                }

                else { MessageBox.Show("Something went wrong!"); }

            }
        }

        private void settButt_Click(object sender, EventArgs e)
        {
            if (ss == 0)
            {
                ss = 1;
                Sett = new Form4(this, null);
                Sett.Show();
               
            }
            else if (ss==1)
            {
                ss = 0;
                Sett.Close();
            }
            this.Location = new Point(this.Location.X + 1, this.Location.Y - 1);
            this.Location = new Point(this.Location.X - 1, this.Location.Y + 1);

        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            Sett.Location = new Point(this.Location.X + 346, this.Location.Y + 0);
        }

        private void guest_CheckedChanged(object sender, EventArgs e)
        {


            if (guest.Checked == true)
            {
                jelBox.Visible = false;
                jelLab.Visible = false;
                b4.Location = new Point(123, 175);

            }
            else if (guest.Checked == false)
            {
                jelBox.Visible = true;
                jelLab.Visible = true;
                b4.Location = new Point(123, 225);

            }
        }
        private void Back()
        {
            if (b3.Text == "Vissza")
            { 
                if (Sett.BS == 1)
                {
                   
                    this.Hide();
                    Sett.BS = 0;
                }
                title.Text = "Raktár adatbázis";
                b1.Visible = true;
                //b2.Visible = true;
                b3.Text = "Kilépés";
                b4.Visible = false;
                nevLab.Visible = false;
                nevBox.Visible = false;
                jelLab.Visible = false;
                jelBox.Visible = false;
                nevBox.Text = "";
                jelBox.Text = "";
                guest.Visible = false;
            }
            else if (b3.Text == "Kilépés")
            {
                System.Windows.Forms.Application.Exit();
            }else { MessageBox.Show("Something went wrong!"); }
        }

       

        
    }
}
