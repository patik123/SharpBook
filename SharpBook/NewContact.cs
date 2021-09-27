using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SharpBook
{
    public partial class NewContact : Form
    {
        public string data_dir = "";

        public NewContact()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + data_dir + ";Version=3;");
            conn.Open();
            SQLiteCommand command = new SQLiteCommand("INSERT INTO contacts (first_name, last_name,nickname, website, birthday, work_email, home_email, home_phone, work_phone, notes) VALUES ('" + FirstName_Input.Text + "','" + LastName_Input.Text + "','" + NickName_Input.Text + "','" + Website_Input.Text + "','" + Birthday_Input.Text + "','" + WorkEmail_Input.Text + "','" + HomeEmail_Input.Text + "','" + HomePhone_Input.Text + "','" + WorkPhone_Input.Text + "','" + Notes_Input.Text + "')", conn);

            try
            {
                command.ExecuteNonQuery();


                MessageBox.Show("Successfull add new contact", "Notification", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error with adding new contact\nError: " + ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void NewContact_Load(object sender, EventArgs e)
        {
            Birthday_Input.Format = DateTimePickerFormat.Custom;
            Birthday_Input.CustomFormat = "dd. MM. yyyy";
        }
    }
}
