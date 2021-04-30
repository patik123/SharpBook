using System;
using System.Data.SQLite;
using System.IO;
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
    class Program
    {

        // Izpis menija v nadaljevanju programa
        static void Moznosti(string option_1, string option_2)
        {
            Console.Clear();
            Console.WriteLine("\r\nIzberite dejanje:");
            Console.WriteLine("1) " + option_1);
            Console.WriteLine("2) " + option_2);
            Console.WriteLine("3) Izhod");

            Console.Write("\r\nIzberite možnost: ");
        }

        [STAThread]
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear(); // zaradi obarvanja celotne konzole
            Console.ForegroundColor = ConsoleColor.White;
            // Variables
            bool selected_db = false; // Uporablja se za izvajanje izbire podatkovne baze dokler ta ni izbrana
            string dir_for_db = ""; // Shrani pot kje je shranjena podatkovna baza
            var close_app = false; // Spremenljivka v zanki za zagotavljanja zapiranja aplikacije
            bool close_contact = false; // Spremenljivka v zanki za zagotavljanje zapiranja kontakta

            while (selected_db == false) // Izvaja dokler ni izbrana podatkovna baza
            {
                Console.Clear();
                Console.WriteLine("\r\nIzberite dejanje:");
                Console.WriteLine("1) Ustvari novo bazo");
                Console.WriteLine("2) Izberi obstoječo bazo");

                Console.Write("\r\nIzberite možnost: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Stream new_db_file;
                        SaveFileDialog save_file_dialog = new SaveFileDialog();

                        save_file_dialog.Filter = "SQLite Database (*.sqlite)|*.sqlite";
                        save_file_dialog.FilterIndex = 2;
                        save_file_dialog.RestoreDirectory = true;

                        if (save_file_dialog.ShowDialog() == DialogResult.OK)
                        {
                            if ((new_db_file = save_file_dialog.OpenFile()) != null)
                            {
                                dir_for_db = save_file_dialog.FileName;
                                selected_db = true;
                                new_db_file.Close();

                                // Po ustvarjanju datoteke sestavi podatkovno bazo
                                SQLiteConnection conn = new SQLiteConnection("Data Source=" + dir_for_db + ";Version=3;");
                                conn.Open();
                                SQLiteCommand command = new SQLiteCommand("CREATE TABLE contacts ( id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,first_name VARCHAR(1000), last_name VARCHAR(1000),nickname VARCHAR(1000), website VARCHAR(1000),birthday VARCHAR(1000),work_email VARCHAR(1000),home_email VARCHAR(1000) ,home_phone VARCHAR(1000),work_phone VARCHAR(1000), notes TEXT);", conn);
                                command.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                        break;
                    case "2":

                        // TODO -> Mogoče preverjanje pravilnosti podatkovne baze
                        var dialog = new OpenFileDialog
                        {
                            Multiselect = false,
                            Title = "Izberi podatkovno bazo",
                            Filter = "Podatkovna baza SQLite|*.sqlite"
                        };
                        using (dialog)
                        {
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                dir_for_db = dialog.FileName;
                                selected_db = true;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Ta možnost ne obstaja");
                        break;
                }
            }

            while (close_app == false)
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + dir_for_db + ";Version=3;");
                conn.Open(); // Povezava odprta celoten tek delovanja aplikacje v terminalu

                Moznosti("Ustvari nov kontakt", "Prikaži vse kontakte");

                switch (Console.ReadLine())
                {
                    case "1":
                        Application.EnableVisualStyles();
                        NewContact newContact = new NewContact();
                        newContact.data_dir = dir_for_db; // DEKLARIRA SPREMENLJIVKO V FORM - NewUser
                        Application.Run(newContact);
                        break;
                    case "2":

                        SQLiteCommand command = new SQLiteCommand("SELECT * FROM contacts", conn);

                        SQLiteDataReader rdr = command.ExecuteReader();

                        if (rdr.HasRows == true)
                        {
                            while (rdr.Read())
                            {
                                Console.WriteLine(rdr.GetInt32(0) + ") " + rdr[1] + " " + rdr[2]);
                            }
                            rdr.Close(); // zaradi zaklepanja baze

                            Console.WriteLine("\nProsim vpišite številko uporabnika");

                            int contactId = int.Parse(Console.ReadLine());

                            close_contact = false; // Zaradi vrnitve v meni v prihodnje

                            while (close_contact == false)
                            {

                                Moznosti("Urejanje kontakta", "Izbriši kontakta");

                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        Application.EnableVisualStyles();
                                        EditContact editContact = new EditContact();
                                        editContact.data_dir = dir_for_db; // deklarira spremenljivko v form EditContact
                                        editContact.contactId = contactId; // deklarira spremenljivko v form EditContact
                                        Application.Run(editContact);
                                        break;
                                    case "2":

                                        var delete_dialog = MessageBox.Show("Ali ste prepričani, da želite izbrisati kontakt?", "Izbriši", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                                        if (delete_dialog == DialogResult.OK) // potrditev izbrisa uporabnika
                                        {
                                            try
                                            {
                                                SQLiteCommand command1 = new SQLiteCommand("DELETE FROM contacts WHERE id = '" + contactId + "'", conn);
                                                command1.ExecuteNonQuery();

                                                close_contact = true;
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Prišlo je do nepričakovane napake. Napaka: " + ex, "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                close_contact = true;
                                            }

                                        }
                                        break;
                                    case "3":
                                        close_contact = true;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("V bazi ni nobenega kontakta - poskusite ustvariti nov kontakt");
                        }
                        break;
                    case "3":
                        conn.Close(); // Zapre povezavo s podatkovno bazo - popolnoma zaključen program
                        close_app = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ta funkcija ne obstaja");
                        break;
                }
            }
        }
    }
}