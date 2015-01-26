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

		/*
		Rigidbody nodeInstance;
		nodeInstance = (Rigidbody)Instantiate(Node, new Vector3(0,0,0), Quaternion.Euler (0,0,0));
		nodeClassMono = nodeInstance.GetComponent<NodeClassMono> ();
		nodeClassMono.setLocation (new Vector3(10, 10, 10));
		nodeClassMono.setNodeId (22);
		nodeClassMono.setNodeStatus (true);
		nodeClassMono.setNodeType (42);
		nodeClassMono.setPrefabID(nodeInstance.GetInstanceID().ToString ());
		nodeClassMono.setTimeStamp("nine y nine o clock");

		Rigidbody nodeInstance;
		PostGresUtility db = new PostGresUtility ();
		List<NodeClass> NodeList = db.getNodeList ();

		foreach (NodeClass node in NodeList) {
			nodeInstance = (Rigidbody)Instantiate (Node, node.getLocation (), Quaternion.Euler (0, 0, 0));
			nodeInstance.name = nodeInstance.GetInstanceID().ToString();
			node.setPrefabID(nodeInstance.name);
		}
		*/
	}
			





	// Update is called once per frame
	void Update () {


	}
}