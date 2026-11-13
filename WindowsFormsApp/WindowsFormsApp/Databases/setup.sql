
using MySql.Data.MySqlClient;

string connectionString =
    "server=localhost;database=CybersecurityTasks;uid=root;pwd=yourpassword;";

MySqlConnection connection =
    new MySqlConnection(connectionString);

connection.Open();

MessageBox.Show("Connected to MySQL successfully!");

connection.Close();

