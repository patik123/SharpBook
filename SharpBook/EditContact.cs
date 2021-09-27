using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SharpBook
{
    public partial class EditContact : Form
    {
        public EditContact()
        {
            InitializeComponent();
        }

        public string data_dir;
        public int contactId;

        private void Save_Button_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + data_dir + ";Version=3;");
            conn.Open();

            try
            {
                SQLiteCommand command = new SQLiteCommand("UPDATE contacts SET first_name = '" + FirstName_Input.Text + "', last_name = '" + LastName_Input.Text + "',nickname = '" + NickName_Input.Text + "', website = '" + Website_Input.Text + "', birthday = '" + Birthday_Input.Text + "', work_email = '" + WorkEmail_Input.Text + "', home_email = '" + HomeEmail_Input.Text + "', home_phone = '" + HomePhone_Input.Text + "', work_phone = '" + WorkPhone_Input.Text + "', notes ='" + Notes_Input.Text + "' WHERE id = '" + contactId + "' ", conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successful updated contact", "Succesfull", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error\nError: " + ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void EditContact_Load(object sender, EventArgs e)
        {
            Birthday_Input.Format = DateTimePickerFormat.Custom;
            Birthday_Input.CustomFormat = "dd. MM. yyyy";

            SQLiteConnection conn = new SQLiteConnection("Data Source=" + data_dir + ";Version=3;");
            conn.Open();

            SQLiteCommand command = new SQLiteCommand("SELECT * FROM contacts WHERE id = " + contactId + "", conn);

            SQLiteDataReader rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                FirstName_Input.Text = (string)rdr[1];
                LastName_Input.Text = (string)rdr[2];
                NickName_Input.Text = (string)rdr[3];
                Website_Input.Text = (string)rdr[4];
                Birthday_Input.Text = (string)rdr[5];
                WorkEmail_Input.Text = (string)rdr[6];
                HomeEmail_Input.Text = (string)rdr[7];
                HomePhone_Input.Text = (string)rdr[8];
                WorkPhone_Input.Text = (string)rdr[9];
                Notes_Input.Text = (string)rdr[10];
            }
            rdr.Close(); // Zaradi zaklepanja baze podatkov
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + data_dir + ";Version=3;");
            conn.Open();
            var delete_dialog = MessageBox.Show("Are you sure for delete contact", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (delete_dialog == DialogResult.OK) // potrditev izbrisa uporabnika
            {
                try
                {
                    SQLiteCommand deleteCommand = new SQLiteCommand("DELETE FROM contacts WHERE id = '" + contactId + "'", conn);
                    deleteCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
                this.Close();
            }
        }
    }
}

