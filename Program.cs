// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;

class Program {

    public static void Main(String[] args) { 
    Demo demo = new Demo();
        demo.ConnectToDB();
    }
    
}


public class Demo {

    string connectionString = "Data Source=localhost;Initial Catalog=userdb;User Id=sa;Password=Teng!n@404;Encrypt=False;Trusted_Connection=True;";
    SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
   
    public void ConnectToDB() {
        connString.UserID = "sa";
        connString.Encrypt = false;
        connString.Password = "Teng!n@404";
        connString.DataSource = "localhost";
        connString.InitialCatalog = "userdb";
        connString.DataSource = "localhost";
        connString.InitialCatalog = "userdb";
        
        Console.WriteLine("Connecting to db....");
        using (SqlConnection conn = new SqlConnection(connString.ToString())) {

            try
            {
                conn.Open();
                Console.WriteLine("Connection Open");
                SqlCommand cmd = new SqlCommand("select * from customer",conn);
                SqlDataReader reader = cmd.ExecuteReader();
               
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}", reader.GetString(0),
                     reader.GetString(1),reader.GetString(2));
                    }
                    
                }
                else {
                    Console.WriteLine("Failed to fetch any records");
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }


        }

       
    }

    public void FetchRecord() { 
    
    }

    
}