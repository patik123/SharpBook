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
    public partial class NewContact : Form
    {
        public string data_dir = ""; // PUBLIC zaradi dostopnosti iz terminala za zapis podatkov -> PRENOS
        public NewContact()
        {
            InitializeComponent();
        }

        private void NewContact_Load(object sender, EventArgs e)
        {
            Input_Birthday.Format = DateTimePickerFormat.Custom;
            Input_Birthday.CustomFormat = "dd. MM. yyyy";
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            // TODO -> SQL INJECTION PREVENT
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + data_dir + ";Version=3;");
            conn.Open();
            SQLiteCommand command = new SQLiteCommand("INSERT INTO contacts (first_name, last_name,nickname, website, birthday, work_email, home_email, home_phone, work_phone, notes) VALUES ('" + Input_FirstName.Text + "','" + Input_LastName.Text + "','" + Input_Nickname.Text + "','" + Input_Website.Text + "','" + Input_Birthday.Text + "','" + Input_WorkEmail.Text + "','" + Input_HomeEmail.Text + "','" + Input_HomePhone.Text + "','" + Input_WorkPhone.Text + "','" + Input_Notes.Text + "')", conn);

            try
            {
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Uspešno dodan kontakt", "Obvestilo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Težava pri dodajanju kontakta\nNapaka: " + ex + "", "Težava", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
