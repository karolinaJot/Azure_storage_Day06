using Microsoft.Data.SqlClient;
using System;
using System.Data;

string newConnectionString = "Server = tcp:volleyballservkj.database.windows.net,1433;Initial Catalog = VolleballDB; Persist Security Info=False;User ID = karolina; Password=PASSSSSSSS; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

using (SqlConnection connection = new SqlConnection(newConnectionString))
{

	connection.Open();

	//using (SqlCommand command = new SqlCommand("InsertPerson", connection))
	//{
	//	command.CommandType = CommandType.StoredProcedure;
	//	command.Parameters.AddWithValue("@FirstName", "Jan");
	//	command.Parameters.AddWithValue("@LastName", "Kowalski");
	//	int rowsAffected = command.ExecuteNonQuery();

	//	Console.WriteLine($"{rowsAffected} rows affected.");
	//}

	////reading 
	//using (SqlCommand command = new SqlCommand("GetAllPersons", connection))
	//{
	//	command.CommandType = CommandType.StoredProcedure;

	//	using (SqlDataReader reader = command.ExecuteReader())
	//	{
	//		while (reader.Read())
	//		{
	//			Console.WriteLine($"" +
	//				$"Id: {reader.GetInt32(0)}, " +
	//				$"FirstName:{reader.GetString(1)}, " +
	//				$"LastName: {reader.GetString(2)}");
	//		}
	//	}
	//}

	//// updating
	//using (SqlCommand command = new SqlCommand("UpdatePerson", connection))
	//{
	//	command.CommandType = CommandType.StoredProcedure;
	//	command.Parameters.AddWithValue("@Id", 1);
	//	command.Parameters.AddWithValue("@FirstName", "UpdatedFirstName");
	//	int rowsAffected = command.ExecuteNonQuery();
	//	Console.WriteLine($"{rowsAffected} rows affected.");
	//}

	//deleting
	using (SqlCommand command = new SqlCommand("DeletePerson", connection))
	{
		command.CommandType = CommandType.StoredProcedure;
		command.Parameters.AddWithValue("@Id", 1);
		int rowsAffected = command.ExecuteNonQuery();
		Console.WriteLine($"{rowsAffected} rows affected.");
	}
}
