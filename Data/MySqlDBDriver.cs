using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AddressBook_mvc3_jQuery
{
	public class MySqlDBDriver
	{
		public static void init()
		{
			string connectionString =
				"Server=localhost;" +
					"Database=test;" +
					"User ID=myuserid;" +
					"Password=mypassword;" +
					"Pooling=false";
			IDbConnection dbcon;
			dbcon = new MySqlConnection(connectionString);
			dbcon.Open();
			IDbCommand dbcmd = dbcon.CreateCommand();
			// requires a table to be created named employee
			// with columns firstname and lastname
			// such as,
			//        CREATE TABLE employee (
			//           firstname varchar(32),
			//           lastname varchar(32));
			string sql =
				"SELECT firstname, lastname " +
					"FROM employee";
			dbcmd.CommandText = sql;
			IDataReader reader = dbcmd.ExecuteReader();
			while(reader.Read()) {
				string FirstName = (string) reader["firstname"];
				string LastName = (string) reader["lastname"];
				Console.WriteLine("Name: " +
				                  FirstName + " " + LastName);
			}
			// clean up
			reader.Close();
			reader = null;
			dbcmd.Dispose();
			dbcmd = null;
			dbcon.Close();
			dbcon = null;
		}
	}
}

