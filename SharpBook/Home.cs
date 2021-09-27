using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;


namespace SharpBook
{

    // ICON DOWNLOADED FROM https://iconarchive.com/show/small-n-flat-icons-by-paomedia/address-book-icon.html
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void SharpBook_Load(object sender, EventArgs e)
        {
            ContactsList.Visible = false;
            NewContact.Visible = false;
            Refresh.Visible = false;

        }

        public bool selected_db = false;
        public string dir_for_db = "";
        public bool close_contact = false;

        private void CreateNewDB_Click(object sender, EventArgs e)
        {
            Stream new_db_file;
            SaveFileDialog save_file_dialog = new SaveFileDialog();

            save_file_dialog.Filter = "SharpBook Database (*.sbook)|*.sbook";
            save_file_dialog.FilterIndex = 2;
            save_file_dialog.RestoreDirectory = true;

            if (save_file_dialog.ShowDialog() == DialogResult.OK)
            {
                if ((new_db_file = save_file_dialog.OpenFile()) != null)
                {
                    dir_for_db = save_file_dialog.FileName;
                    selected_db = true;
                    new_db_file.Close();

                    SQLiteConnection conn = new SQLiteConnection("Data Source=" + dir_for_db + ";Version=3;");
                    conn.Open();
                    SQLiteCommand command = new SQLiteCommand("CREATE TABLE contacts ( id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,first_name VARCHAR(1000), last_name VARCHAR(1000),nickname VARCHAR(1000), website VARCHAR(1000),birthday VARCHAR(1000),work_email VARCHAR(1000),home_email VARCHAR(1000) ,home_phone VARCHAR(1000),work_phone VARCHAR(1000), notes TEXT);", conn);
                    command.ExecuteNonQuery();

                    CreateNewDB.Visible = false;
                    UseExistDB.Visible = false;

                    SQLiteCommand query = new SQLiteCommand("SELECT * FROM contacts", conn);

                    SQLiteDataReader rdr = query.ExecuteReader();

                    if (rdr.HasRows == true)
                    {
                        ContactsList.Visible = true;
                        NewContact.Visible = true;
                        Refresh.Visible = true;
                    }
                    else
                    {
                        ContactsList.Visible = false;
                        NewContact.Visible = true;
                    }

                    conn.Close();
                }
            }
        }

        private void UseExistDB_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Select SharpBook Database",
                Filter = "SharpBook Database|*.sbook"
            };
            using (dialog)
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    dir_for_db = dialog.FileName;
                    selected_db = true;
                    CreateNewDB.Visible = false;
                    UseExistDB.Visible = false;


                    SQLiteConnection conn = new SQLiteConnection("Data Source=" + dir_for_db + ";Version=3;");
                    conn.Open();

                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM contacts", conn);

                    SQLiteDataReader rdr = command.ExecuteReader();

                    if (rdr.HasRows == true)
                    {
                        while (rdr.Read())
                        {
                            ListViewItem listitem = new ListViewItem(rdr[0].ToString());
                            listitem.SubItems.Add(rdr[1].ToString());
                            listitem.SubItems.Add(rdr[2].ToString());
                            ContactsList.Items.Add(listitem);
                        }
                        rdr.Close();
                    }
                    ContactsList.FullRowSelect = true;
                    ContactsList.Visible = true;
                    NewContact.Visible = true;
                    Refresh.Visible = true;
                }
            }
        }
        private void ContactsList_Click(object sender, EventArgs e)
        {
            int contactId = Convert.ToInt32(ContactsList.SelectedItems[0].SubItems[0].Text);

            EditContact editContact = new EditContact();
            editContact.contactId = contactId;
            editContact.data_dir = dir_for_db;
            editContact.ShowDialog();

        }

        private void NewContact_Click(object sender, EventArgs e)
        {
            NewContact newContact = new NewContact();
            newContact.data_dir = dir_for_db;
            newContact.ShowDialog();
        }

        public void Refresh_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + dir_for_db + ";Version=3;");
            conn.Open();

            SQLiteCommand command = new SQLiteCommand("SELECT * FROM contacts", conn);

            SQLiteDataReader rdr = command.ExecuteReader();

            if (rdr.HasRows == true)
            {
                ContactsList.Items.Clear();
                while (rdr.Read())
                {
                    ListViewItem listitem = new ListViewItem(rdr[0].ToString());
                    listitem.SubItems.Add(rdr[1].ToString());
                    listitem.SubItems.Add(rdr[2].ToString());
                    ContactsList.Items.Add(listitem);
                }
                rdr.Close();
            }
        }


    }
}
