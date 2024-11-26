using System;
using DTOs.VitalMoveUsers;
using Util.DB;
using MySql.Data.MySqlClient;

namespace Util.Login
{
    public class Login
    {
        public static bool Authenticate(UserLoginDTO credential)
        {
            string conn = DbString.Context();
            string query = "SELECT usuario, senha FROM usuarios WHERE usuario = @username AND senha = @password";

            using (var connection = new MySqlConnection(conn))
            {
                using (var command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@username", credential.Username);
                    command.Parameters.AddWithValue("@password", credential.Password);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
public static bool Register(UserRegisterDTO credential)
{
    string conn = DbString.Context();
    string selectQuery = "SELECT usuario FROM usuarios WHERE usuario = @username";
    string insertQuery = "INSERT INTO usuarios (usuario, senha, CPF) VALUES (@username, @password, @CPF)";

    try
    {
        using (var connection = new MySqlConnection(conn))
        {
            connection.Open();

            // Verifica se o usuário já existe
            using (var selectCommand = new MySqlCommand(selectQuery, connection))
            {
                selectCommand.Parameters.AddWithValue("@username", credential.Username);

                using (var reader = selectCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return false;
                    }
                }
            }


            using (var insertCommand = new MySqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@username", credential.Username);
                insertCommand.Parameters.AddWithValue("@password", credential.Password);
                insertCommand.Parameters.AddWithValue("@CPF", credential.CPF);

                insertCommand.ExecuteNonQuery();
                return true;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao registrar o usuário: {ex.Message}");
        return false;
    }
}
    }
}
