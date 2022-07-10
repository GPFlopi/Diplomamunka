namespace Diplomamunka
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.b1 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.nevBox = new System.Windows.Forms.TextBox();
            this.jelBox = new System.Windows.Forms.TextBox();
            this.nevLab = new System.Windows.Forms.Label();
            this.jelLab = new System.Windows.Forms.Label();
            this.b4 = new System.Windows.Forms.Button();
            this.settButt = new System.Windows.Forms.Button();
            this.guest = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // b1
            // 
            this.b1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.b1.Location = new System.Drawing.Point(71, 186);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(303, 44);
            this.b1.TabIndex = 0;
            this.b1.Text = "Belépés";
            this.b1.UseVisualStyleBackColor = true;
            this.b1.Click += new System.EventHandler(this.b1_Click_1);
            // 
            // b2
            // 
            this.b2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.b2.Location = new System.Drawing.Point(71, 225);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(303, 44);
            this.b2.TabIndex = 1;
            this.b2.Text = "Registráció";
            this.b2.UseVisualStyleBackColor = true;
            this.b2.Visible = false;
            this.b2.Click += new System.EventHandler(this.b2_Click_1);
            // 
            // b3
            // 
            this.b3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Bold);
            this.b3.Location = new System.Drawing.Point(12, 356);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(156, 27);
            this.b3.TabIndex = 2;
            this.b3.Text = "Kilépés";
            this.b3.UseVisualStyleBackColor = true;
            this.b3.Click += new System.EventHandler(this.b3_Click_1);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Times New Roman", 24.768F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(431, 95);
            this.title.TabIndex = 3;
            this.title.Text = "Raktár Adatbázis";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nevBox
            // 
            this.nevBox.Location = new System.Drawing.Point(132, 160);
            this.nevBox.Multiline = true;
            this.nevBox.Name = "nevBox";
            this.nevBox.Size = new System.Drawing.Size(193, 30);
            this.nevBox.TabIndex = 5;
            this.nevBox.Visible = false;
            // 
            // jelBox
            // 
            this.jelBox.Location = new System.Drawing.Point(130, 225);
            this.jelBox.Multiline = true;
            this.jelBox.Name = "jelBox";
            this.jelBox.PasswordChar = '*';
            this.jelBox.Size = new System.Drawing.Size(194, 30);
            this.jelBox.TabIndex = 6;
            this.jelBox.Visible = false;
            // 
            // nevLab
            // 
            this.nevLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.nevLab.Location = new System.Drawing.Point(135, 130);
            this.nevLab.Name = "nevLab";
            this.nevLab.Size = new System.Drawing.Size(190, 27);
            this.nevLab.TabIndex = 7;
            this.nevLab.Text = "Felhasználó név";
            this.nevLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nevLab.Visible = false;
            // 
            // jelLab
            // 
            this.jelLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.jelLab.Location = new System.Drawing.Point(131, 195);
            this.jelLab.Name = "jelLab";
            this.jelLab.Size = new System.Drawing.Size(193, 27);
            this.jelLab.TabIndex = 8;
            this.jelLab.Text = "Jelszó";
            this.jelLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.jelLab.Visible = false;
            // 
            // b4
            // 
            this.b4.Location = new System.Drawing.Point(164, 275);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(121, 33);
            this.b4.TabIndex = 9;
            this.b4.UseVisualStyleBackColor = true;
            this.b4.Visible = false;
            this.b4.Click += new System.EventHandler(this.b4_Click);
            // 
            // settButt
            // 
            this.settButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Bold);
            this.settButt.Location = new System.Drawing.Point(287, 356);
            this.settButt.Name = "settButt";
            this.settButt.Size = new System.Drawing.Size(156, 27);
            this.settButt.TabIndex = 10;
            this.settButt.Text = "Beállítások";
            this.settButt.UseVisualStyleBackColor = true;
            this.settButt.Click += new System.EventHandler(this.settButt_Click);
            // 
            // guest
            // 
            this.guest.AutoSize = true;
            this.guest.Location = new System.Drawing.Point(191, 356);
            this.guest.Name = "guest";
            this.guest.Size = new System.Drawing.Size(78, 20);
            this.guest.TabIndex = 11;
            this.guest.Text = "Vendég";
            this.guest.UseVisualStyleBackColor = true;
            this.guest.Visible = false;
            this.guest.CheckedChanged += new System.EventHandler(this.guest_CheckedChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.b3;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(450, 395);
            this.Controls.Add(this.guest);
            this.Controls.Add(this.settButt);
            this.Controls.Add(this.b4);
            this.Controls.Add(this.jelLab);
            this.Controls.Add(this.nevLab);
            this.Controls.Add(this.jelBox);
            this.Controls.Add(this.nevBox);
            this.Controls.Add(this.title);
            this.Controls.Add(this.b3);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.b1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raktár Adatbázis";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox nevBox;
        private System.Windows.Forms.TextBox jelBox;
        private System.Windows.Forms.Label nevLab;
        private System.Windows.Forms.Label jelLab;
        private System.Windows.Forms.Button b4;
        private System.Windows.Forms.Button settButt;
        private System.Windows.Forms.CheckBox guest;
    }
}

