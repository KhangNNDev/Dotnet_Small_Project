
using System.Data.SqlClient;

public class AuthorRepository : IGenericRepository<AuthorListingDTO, AuthorDetailDTO, AuthorAddDTO, AuthorUpdateDTO>
{
    public int Add(AuthorAddDTO entity)
    {
        SqlConnection connection = DBContext.connectDB();
        try
        {
            //open connection to db
            connection.Open();
            //create sql query
            string sql = "INSERT INTO Author (Name) VALUES (@Name)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", entity.Name);
            return command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Errors: " + ex.Message);
        }
        finally
        {
            //close connection
            connection.Close();
        }
        return 0;
    }

    public int Delete(int id)
    {
        SqlConnection connection = DBContext.connectDB();
        try
        {
            //open connection to db
            connection.Open();
            //create sql query
            string sql = "DELETE FROM Author WHERE Id = @Id ;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            return command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Errors: " + ex.Message);
        }
        finally
        {
            //close connection
            connection.Close();
        }
        return 0;
    }

    public int Update(AuthorUpdateDTO entity)
    {
        SqlConnection connection = DBContext.connectDB();
        try
        {
            //open connection to db
            connection.Open();
            //create sql query
            string sql = "UPDATE Author SET Name = @Name WHERE Id = @Id ;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Id", entity.Id);
            return command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Errors: " + ex.Message);
        }
        finally
        {
            //close connection
            connection.Close();
        }
        return 0;
    }

    public List<AuthorListingDTO> ViewAll()
    {
        SqlConnection connection = DBContext.connectDB();
        try
        {
            //open connection to db
            connection.Open();
            //create sql query
            string sql = "SELECT * FROM Author ORDER BY Name ASC";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<AuthorListingDTO> list;
            if (reader.HasRows)
            {
                list = new List<AuthorListingDTO>();
                while (reader.Read())
                {
                    AuthorListingDTO authorListingDTO = new AuthorListingDTO();
                    authorListingDTO.Id = (int)reader["Id"];
                    authorListingDTO.Name = (string)reader["Name"];
                    list.Add(authorListingDTO);
                }
                return list;
            }
            return null;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Errors: " + ex.Message);
        }
        finally
        {
            //close connection
            connection.Close();
        }
        return null;
    }

    public AuthorDetailDTO ViewDetail(int id)
    {
        SqlConnection connection = DBContext.connectDB();
        try
        {
            //open connection to db
            connection.Open();
            //create sql query
            string sql = "SELECT * FROM Author WHERE Id = @Id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = command.ExecuteReader();
            List<AuthorListingDTO> list;
            if (reader.Read())
            {
                AuthorDetailDTO authorDetailDTO = new AuthorDetailDTO();
                authorDetailDTO.Id = (int)reader["Id"];
                authorDetailDTO.Name = (string)reader["Name"];
                return authorDetailDTO;
            }
            return null;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Errors: " + ex.Message);
        }
        finally
        {
            //close connection
            connection.Close();
        }
        return null;
    }
}