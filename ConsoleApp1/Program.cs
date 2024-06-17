using Npgsql;

internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Port=5432;Database=BankConnection_temp;username=postgres;Password=123456;";

        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();


        using NpgsqlCommand updateCmd = new NpgsqlCommand("UPDATE public.\"IntegrationHistory\" SET \"IsSend\" = false WHERE \"ResponseContent\" LIKE '%xml version%'", connection);

        try
        {
            int rowsAffected = updateCmd.ExecuteNonQuery();
            Console.WriteLine("Checked and updated all bad responses");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unnable to check bad response");
            throw new Exception(ex.Message);
        }

    }
}