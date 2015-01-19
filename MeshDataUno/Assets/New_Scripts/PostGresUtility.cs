using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Npgsql;

public class PostGresUtility {
	public NpgsqlConnection conn;

	public PostGresUtility(string server = "10.221.11.30", string port = "5432", string user_id = "postgres", string password = "password", string database = "postgres"){
		string connectionString = "Server=" + server + ";Port=" + port + ";User Id=" + user_id + ";Password=" + password + ";Database=" + database;
		//conn = new NpgsqlConnection ("Server=localhost;Port=5432;User Id=postgres;Password=password;Database=postgres");
		conn = new NpgsqlConnection (connectionString);
		conn.Open();
	}

	public List<NodeClass> getLocations(){
		NpgsqlCommand command = conn.CreateCommand ();
		string sql = "SELECT * FROM test_table";
		command.CommandText = sql;
		NpgsqlDataReader reader = command.ExecuteReader ();
		List<NodeClass> outputList = new List<NodeClass>();

		while (reader.Read()) {
			int id = (int)reader["node_id"];
			//Debug.Log(id);
			string time_stamp = (string)reader["time_stamp"];
			//Debug.Log(time_stamp);
			int node_type = (int)reader["node_type"];
			//Debug.Log(node_type);
			bool node_status = (bool)reader["node_status"];
			//Debug.Log(node_status);
			string locationString = (string)reader["location"];
			//Debug.Log(locationString);
			Vector3 locationVector3 = parseLocation(locationString);

			NodeClass outputNode = new NodeClass(id, time_stamp, node_type, node_status, locationVector3);
			outputList.Add(outputNode);
		}
		return outputList;
	}


	public static Vector3 parseLocation(string location_string){

		Match Digit1temp = Regex.Match (location_string, "[(][-]?[0-9]*[,]");
		string Digit1tempString = (string) Digit1temp.ToString();
		Match Digit1Out = Regex.Match (Digit1tempString, "[-]?[0-9]+");
		string Digit1OutString = (string) Digit1Out.ToString();

		Match Digit2temp = Regex.Match (location_string, "[,][-]?[0-9]*[,]");
		string Digit2tempString = (string)Digit2temp.ToString ();
		Match Digit2Out = Regex.Match (Digit2tempString, "[-]?[0-9]+");
		string Digit2OutString = (string)Digit2Out.ToString ();

		Match Digit3temp = Regex.Match (location_string, "[,][-]?[0-9]*[)]");
		string Digit3tempString = (string)Digit3temp.ToString ();
		Match Digit3Out = Regex.Match (Digit3tempString, "[-]?[0-9]+");
		string Digit3OutString = (string)Digit3Out.ToString ();

		float Digit1Float = float.Parse (Digit1OutString);
		float Digit2Float = float.Parse (Digit2OutString);
		float Digit3Float = float.Parse (Digit3OutString);

		Vector3 outputVector = new Vector3 (Digit1Float, Digit2Float, Digit3Float);


		return outputVector;

		                             

	}
}
