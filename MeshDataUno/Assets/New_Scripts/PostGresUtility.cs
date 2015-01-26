using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Npgsql;

public class PostGresUtility : MonoBehaviour {
	public NodeMap nodeMap;
	public NpgsqlConnection conn;
	public Rigidbody Node;
	private NodeClassMono nodeClassMono;

	/*
	public PostGresUtility(string server = "10.221.11.23", string port = "5432", string user_id = "postgres", string password = "password", string database = "postgres"){
		string connectionString = "Server=" + server + ";Port=" + port + ";User Id=" + user_id + ";Password=" + password + ";Database=" + database;
		//conn = new NpgsqlConnection ("Server=localhost;Port=5432;User Id=postgres;Password=password;Database=postgres");
		conn = new NpgsqlConnection (connectionString);
		conn.Open();
		this.createNodeMap ();
	}
	*/

	public void Start(){
		string server = "10.221.11.23";
		string port = "5432";
		string user_id = "postgres";
		string password = "password";
		string database = "postgres";
		string connectionString = "Server=" + server + ";Port=" + port + ";User Id=" + user_id + ";Password=" + password + ";Database=" + database;
		//conn = new NpgsqlConnection ("Server=localhost;Port=5432;User Id=postgres;Password=password;Database=postgres");
		conn = new NpgsqlConnection (connectionString);
		conn.Open();
		this.createNodeMap ();
	}

	public NodeMap createNodeMap(){
		NpgsqlCommand command = conn.CreateCommand ();
		string sql = "SELECT * FROM current_table";
		command.CommandText = sql;
		NpgsqlDataReader reader = command.ExecuteReader ();
		nodeMap = new NodeMap();

		while (reader.Read()) {
			int node_id = (int)reader["node_id"];
			//Debug.Log(id);
			bool node_status = (bool)reader["node_status"];
			//Debug.Log(node_status);
			string locationString = (string)reader["location"];
			Debug.Log(locationString);
			Vector3 locationVector3 = parseLocation(locationString);
			int transaction_id = (int)reader.GetInt64(3);
			//Debug.Log(reader["transaction_id"]);
			string time_stamp = reader.GetDateTime (4).ToString();
			//Debug.Log(reader["time_stamp"]);

			Rigidbody nodeInstance = (Rigidbody)GameObject.Instantiate(Node, new Vector3(0,0,0), Quaternion.Euler (0,0,0));
			nodeClassMono = nodeInstance.GetComponent<NodeClassMono>();
			nodeClassMono.setLocation (locationVector3);
			nodeClassMono.setNodeId (node_id);
			nodeClassMono.setNodeStatus (node_status);
			nodeClassMono.setTransactionId (transaction_id);
			nodeClassMono.setPrefabId(nodeInstance.GetInstanceID().ToString ());
			nodeClassMono.setTimeStamp(time_stamp);
			nodeMap.append(node_id, nodeClassMono);
		}
		return nodeMap;
	}
	
	public static Vector3 parseLocation(string location_string){

		Match Digit1temp = Regex.Match (location_string, "[(][-]?[0-9]*[.]?[0-9]*[,]");
		string Digit1tempString = (string) Digit1temp.ToString();
		Match Digit1Out = Regex.Match (Digit1tempString, "[-]?[0-9]+[.]?[0-9]*");
		string Digit1OutString = (string) Digit1Out.ToString();

		Match Digit2temp = Regex.Match (location_string, "[,][-]?[0-9]*[.]?[0-9]*[,]");
		string Digit2tempString = (string)Digit2temp.ToString ();
		Match Digit2Out = Regex.Match (Digit2tempString, "[-]?[0-9]+[.]?[0-9]*");
		string Digit2OutString = (string)Digit2Out.ToString ();

		Match Digit3temp = Regex.Match (location_string, "[,][-]?[0-9]*[.]?[0-9]*[)]");
		string Digit3tempString = (string)Digit3temp.ToString ();
		Match Digit3Out = Regex.Match (Digit3tempString, "[-]?[0-9]+[.]?[0-9]*");
		string Digit3OutString = (string)Digit3Out.ToString ();

		float Digit1Float = float.Parse (Digit1OutString);
		float Digit2Float = float.Parse (Digit2OutString);
		float Digit3Float = float.Parse (Digit3OutString);

		Vector3 outputVector = new Vector3 (Digit1Float, Digit2Float, Digit3Float);


		return outputVector;

		                             

	}
}