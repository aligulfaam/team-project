using Microsoft.Maui.Controls;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.CRUD;
using MySqlX.XDevAPI.Relational;

namespace MySQL_Mobile_App;

public partial class MainPage : ContentPage
{


    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void First_Name_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
    private void BtnPlayerInfo_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new PlayerInfo());
    }
    private void BtnPrevious_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
    private void Player_clicked(Object sender, EventArgs e)
    {
        string connectionString = "Server=192.169.144.133;Database=sr_team_5;Uid=mcctc5;Pwd=mcctcrocks;";
        string query = "SELECT * FROM playerInput";





        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();


            command.CommandText = $"SELECT * FROM playerInput WHERE First_Name = '{infoText.Text}';";





            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    infoGiven.Text = $"First Name: {reader.GetString(0)} |Last Name: {reader.GetString(1)} |Phone:  {reader.GetString(2)} |Discord: {reader.GetString(3)} |Game: {reader.GetString(4)} |ID: {reader.GetString(5)}";
                    reader.NextResult();
                }
            }
        }
    }
}