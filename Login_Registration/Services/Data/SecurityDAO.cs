using Login_Registration.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Login_Registration.Services.Data
{
    public class SecurityDAO
    {
        // connection to DB
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Game;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool FindBUser(RegisterModel register)
        {
            bool success = false;

            // sql expression
            string queryString = "SELECT * FROM dbo.Users WHERE username = @Username AND password = @Password";

            // closing after leaving DB
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = register.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = register.Password;

                // open DB connection
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }

        public bool Create(RegisterModel register)
        {
            //start with a false variable 
            bool success = false;

            // queryString with a placeholder
            string queryString = "insert into dbo.Users (firstname, lastname, sex, age, email, username , password) values (@firstname, @lastname, @sex, @age, @email, @username , @password )";


            //create and open connection iin using block, connection will be closed after command is executed
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Create command and Parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = register.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = register.Password;
                command.Parameters.Add("@Firstname", System.Data.SqlDbType.VarChar, 50).Value = register.Firstname;
                command.Parameters.Add("@Lastname", System.Data.SqlDbType.VarChar, 50).Value = register.Lastname;
                command.Parameters.Add("@Sex", System.Data.SqlDbType.VarChar, 50).Value = register.Sex;
                command.Parameters.Add("@Age", System.Data.SqlDbType.Int, 50).Value = register.Age;
                command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 50).Value = register.Email;

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    success = true;


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }
            return success;
        }

        public bool authenticate(UserModel user)
        {
            //start with a false variable
            bool success = false;

            // queryString with a placeholder
            string queryString = "select * from dbo.Users where username = @username and password = @password";

            //create and open connection iin using block, connection will be closed after command is executed
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Create command and Parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;

                    }
                    reader.Close();

                    // Exception handler that returns error message
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }

    }
}