﻿using System;
using System.Data.SqlClient;
using System.Text;

namespace ConnectingToSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");
            //connection string 
            string connString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);
           
             try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");

                //create a new SQL Query using StringBuilder
                StringBuilder strBuilder = new StringBuilder();
                 strBuilder.Append("CREATE TABLE Demotabla ( Name VARCHAR(255), Email VARCHAR(255), Class VARCHAR(255)) ");
                strBuilder.Append("INSERT INTO Demotabla (Name, Email, Class) VALUES ");
                strBuilder.Append("(N'Harsh', N'harsh@gmail.com', N'Class X'), ");
                strBuilder.Append("(N'Ronak', N'ronak@gmail.com', N'Class X') ");

                string sqlQuery = strBuilder.ToString();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn)) //pass SQL query created above and connection
                {
                    command.ExecuteNonQuery(); //execute the Query
                    Console.WriteLine("Query Executed.");
                }

                strBuilder.Clear(); // clear all the string

                //add Query to update to Student_Details table
                strBuilder.Append("UPDATE Demotabla SET Email = N'suri@gmail.com' WHERE Name = 'Surendra'");
                sqlQuery = strBuilder.ToString();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {                   
                    int rowsAffected = command.ExecuteNonQuery(); //execute query and get updated row count
                    Console.WriteLine(rowsAffected + " row(s) updated");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }
    }
}
