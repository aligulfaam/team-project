using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace MySQL_Mobile_App;

public partial class PlayerInfo : ContentPage
{
	public PlayerInfo()
	{
		InitializeComponent();
	}
    private void Button(Object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());

        string connectionString = "Server=192.169.144.133;Database=sr_team_3;Uid=mcctc3;Pwd=mcctcrocks;";
        string query = "SELECT * FROM playerInput";





        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();

            command.CommandText = $"INSERT INTO playerInput (FIRST_NAME,LAST_NAME,PHONE_NUMBER,DISCORD_ID,PLAYER_ID,ESPORT_GAME) VALUES ('{First_Name.Text}','{Last_Name.Text}','{Phone_Number.Text}','{Discord_ID.Text}','{Player_ID.Text}','{Esport_Game.Text}');";

            First_Name.Text = Last_Name.Text = Phone_Number.Text = Discord_ID.Text = Player_ID.Text = Esport_Game.Text = "";


            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
            }
        }
    }
}