
namespace SharpBook
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.CreateNewDB = new System.Windows.Forms.Button();
            this.UseExistDB = new System.Windows.Forms.Button();
            this.ContactsList = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NewContact = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateNewDB
            // 
            this.CreateNewDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.CreateNewDB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.CreateNewDB.Location = new System.Drawing.Point(61, 123);
            this.CreateNewDB.Name = "CreateNewDB";
            this.CreateNewDB.Size = new System.Drawing.Size(439, 51);
            this.CreateNewDB.TabIndex = 0;
            this.CreateNewDB.Text = "Create new database";
            this.CreateNewDB.UseVisualStyleBackColor = false;
            this.CreateNewDB.Click += new System.EventHandler(this.CreateNewDB_Click);
            // 
            // UseExistDB
            // 
            this.UseExistDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.UseExistDB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UseExistDB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.UseExistDB.Location = new System.Drawing.Point(682, 123);
            this.UseExistDB.Name = "UseExistDB";
            this.UseExistDB.Size = new System.Drawing.Size(439, 51);
            this.UseExistDB.TabIndex = 1;
            this.UseExistDB.Text = "Use existing database";
            this.UseExistDB.UseVisualStyleBackColor = false;
            this.UseExistDB.Click += new System.EventHandler(this.UseExistDB_Click);
            // 
            // ContactsList
            // 
            this.ContactsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.ContactsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.FirstName,
            this.LastName});
            this.ContactsList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ContactsList.HideSelection = false;
            this.ContactsList.Location = new System.Drawing.Point(38, 123);
            this.ContactsList.Name = "ContactsList";
            this.ContactsList.Size = new System.Drawing.Size(1119, 346);
            this.ContactsList.TabIndex = 2;
            this.ContactsList.UseCompatibleStateImageBehavior = false;
            this.ContactsList.View = System.Windows.Forms.View.Details;
            this.ContactsList.Click += new System.EventHandler(this.ContactsList_Click);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 253;
            // 
            // FirstName
            // 
            this.FirstName.Text = "First name";
            this.FirstName.Width = 465;
            // 
            // LastName
            // 
            this.LastName.Text = "Last name";
            this.LastName.Width = 396;
            // 
            // NewContact
            // 
            this.NewContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(120)))), ((int)(((byte)(87)))));
            this.NewContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.NewContact.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.NewContact.Location = new System.Drawing.Point(38, 13);
            this.NewContact.Name = "NewContact";
            this.NewContact.Size = new System.Drawing.Size(172, 40);
            this.NewContact.TabIndex = 3;
            this.NewContact.Text = "+ New contact";
            this.NewContact.UseVisualStyleBackColor = false;
            this.NewContact.Click += new System.EventHandler(this.NewContact_Click);
            // 
            // Refresh
            // 
            this.Refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(120)))), ((int)(((byte)(87)))));
            this.Refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.Refresh.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Refresh.Location = new System.Drawing.Point(985, 13);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(172, 40);
            this.Refresh.TabIndex = 4;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = false;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(1200, 787);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.NewContact);
            this.Controls.Add(this.ContactsList);
            this.Controls.Add(this.UseExistDB);
            this.Controls.Add(this.CreateNewDB);
            this.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Home";
            this.Text = "SharpBook";
            this.Load += new System.EventHandler(this.SharpBook_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateNewDB;
        private System.Windows.Forms.Button UseExistDB;
        public System.Windows.Forms.ListView ContactsList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader FirstName;
        private System.Windows.Forms.ColumnHeader LastName;
        private System.Windows.Forms.Button NewContact;
        private System.Windows.Forms.Button Refresh;
    }
}

