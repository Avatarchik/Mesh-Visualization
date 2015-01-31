using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using Npgsql;


public class CreateCylinder : MonoBehaviour {

	public Rigidbody Node;
	//NpgsqlConnection conn;

	void Awake(){

	}

	

	// Use this for initialization
	void Start () {
		PostGresUtility postGresUtility = new PostGresUtility ();
		postGresUtility.createNodeMap ();
	}
			





	// Update is called once per frame
	void Update () {


	}
}