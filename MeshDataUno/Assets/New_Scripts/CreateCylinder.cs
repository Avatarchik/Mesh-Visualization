using UnityEngine;
using System.Collections;
using System;
//using System.Data;
using Npgsql;


public class CreateCylinder : MonoBehaviour {

	public Rigidbody Node;

	// Use this for initialization
	void Start () {
		NpgsqlConnection conn = new NpgsqlConnection ("Server=10.221.11.23;Port=5432;User Id=postgres;Password=password;Database=postgres");
		conn.Open();
		NpgsqlCommand command = conn.CreateCommand ();
		string sql = "SELECT * FROM test_table";
		command.CommandText = sql;
		NpgsqlDataReader reader = command.ExecuteReader ();

		while (reader.Read()) {
			string location = (string)reader["location"];
			//Vector3(1,2,3) Vector3("1,2,3")
			Instantiate(Node, PostGresUtility.parseLocation(location), Quaternion.Euler(0, 0, 0));
			//Debug.Log(PostGresUtility.parseLocation(location));
		}
			
			conn.Close();


	}

	// Update is called once per frame
	void Update () {
		//Rigidbody newNode = (Rigidbody)Instantiate (Node, transform.position, transform.rotation);
	}
}



/*
 * // C#

// Require the rocket to be a rigidbody.
// This way we the user can not assign a prefab without rigidbody
public Rigidbody rocket;
public float speed = 10f;

void FireRocket () {
    Rigidbody rocketClone = (Rigidbody) Instantiate(rocket, transform.position, transform.rotation);
    rocketClone.velocity = transform.forward * speed;
    
    // You can also acccess other components / scripts of the clone
    rocketClone.GetComponent<MyRocketScript>().DoSomething();
}

// Calls the fire method when holding down ctrl or mouse
void Update () {
    if (Input.GetButtonDown("Fire1")) {
        FireRocket();
    }
}
*/