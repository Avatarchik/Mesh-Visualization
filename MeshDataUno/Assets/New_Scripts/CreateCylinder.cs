using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using Npgsql;


public class CreateCylinder : MonoBehaviour {

	public Rigidbody Node;
	//NpgsqlConnection conn;

	// Use this for initialization
	void Start () {
		string test;
		Rigidbody nodeInstance;
		PostGresUtility db = new PostGresUtility ();
		List<NodeClass> NodeList = db.getLocations ();

		foreach (NodeClass node in NodeList) {
			nodeInstance = (Rigidbody)Instantiate (Node, node.getLocation (), Quaternion.Euler (0, 0, 0));
			nodeInstance.name = nodeInstance.GetInstanceID().ToString();
			node.setPrefabID(nodeInstance.name);
		}
	}
			





	// Update is called once per frame
	void Update () {


	}
}