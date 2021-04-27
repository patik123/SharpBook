using System;
using System.Data.SQLite;
using System.Windows.Forms;

/* Version: 1.1
 * Program je namenjen lokalni uporabi na računalniku.
 * Avtor programa je Patrick KOŠIR.
 * 
 * github: patik123
 * email: patik.developer@outlook.com
 * 
 * Nastal je v okviru naloge pri predmetu UPN. 
 * 
 * 
 * Licenciran pod GNU General Public License v3.0
 */

namespace SharpBook
{
    public partial class EditContact : Form
    {
        public string data_dir = ""; // PUBLIC zaradi dostopnosti iz terminala za zapis podatkov -> PRENOS
        public int contactId; // PUBLIC zaradi dostopnosti iz terminala za zapis podatkov -> PRENOS

        public EditContact()
        {
            InitializeComponent();
        }

        private void EditContact_Load(object sender, EventArgs e)
        {
            Input_Birthday.Format = DateTimePickerFormat.Custom;
            Input_Birthday.CustomFormat = "dd. MM. yyyy";

            SQLiteConnection conn = new SQLiteConnection("Data Source=" + data_dir + ";Version=3;");
            conn.Open();

            SQLiteCommand command = new SQLiteCommand("SELECT * FROM contacts WHERE id = " + contactId + "", conn);

            SQLiteDataReader rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                Input_FirstName.Text = (string)rdr[1];
                Input_LastName.Text = (string)rdr[2];
                Input_Nickname.Text = (string)rdr[3];
                Input_Website.Text = (string)rdr[4];
                Input_Birthday.Text = (string)rdr[5];
                Input_WorkEmail.Text = (string)rdr[6];
                Input_HomeEmail.Text = (string)rdr[7];
                Input_HomePhone.Text = (string)rdr[8];
                Input_WorkPhone.Text = (string)rdr[9];
                Input_Notes.Text = (string)rdr[10];
            }
            rdr.Close(); // Zaradi zaklepanja baze podatkov
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + data_dir + ";Version=3;");
            conn.Open();

            try
            {
                // TODO -> SQL INJECTION PREVENT
                SQLiteCommand command = new SQLiteCommand("UPDATE contacts SET first_name = '" + Input_FirstName.Text + "', last_name = '" + Input_LastName.Text + "',nickname = '" + Input_Nickname.Text + "', website = '" + Input_Website.Text + "', birthday = '" + Input_Birthday.Text + "', work_email = '" + Input_WorkEmail.Text + "', home_email = '" + Input_HomeEmail.Text + "', home_phone = '" + Input_HomePhone.Text + "', work_phone = '" + Input_WorkPhone.Text + "', notes ='" + Input_Notes.Text + "' WHERE id = '" + contactId + "' ", conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Uspešno posodobljen kontakt", "Potrdilo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Prišlo je do nepričakovane napake\nNapaka: " + ex + "", "Težava", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
