using System.Data.SqlClient;

public static class DBContext
{
    public static SqlConnection connectDB()
    {
        try
        {
            string connectionString = "Data Source=localhost;Initial Catalog=bookManagement;User ID=sa;Password=2582000Khang@";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error : " + ex.Message);
        }
        return null;
    }
}