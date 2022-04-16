// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;
using ADONetExample;
class Program {

    public static void Main(String[] args) { 
    Demo demo = new Demo();
        demo.ConnectToDB();
        using (var db = new BloggingContext())
        {
            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"Database path: {db.DbPath}.");

            // Create
            Console.WriteLine("Inserting a new blog");
            db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
            db.SaveChanges();

            // Read
            Console.WriteLine("Querying for a blog");
            var blog = db.Blogs
                .OrderBy(b => b.BlogId)
                .First();

            // Update
            Console.WriteLine("Updating the blog and adding a post");
            blog.Url = "https://devblogs.microsoft.com/dotnet";
            blog.Posts.Add(
                new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
            db.SaveChanges();

            // Delete
            Console.WriteLine("Delete the blog");
            db.Remove(blog);
            db.SaveChanges();
        }

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