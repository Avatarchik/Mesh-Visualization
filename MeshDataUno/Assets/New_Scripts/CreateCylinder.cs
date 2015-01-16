using UnityEngine;
using System.Collections;
using Npgsql;

public class CreateCylinder : MonoBehaviour {

	public Rigidbody Node;

	// Use this for initialization
	void Start () {
		Instantiate(Node, new Vector3(0, 10, 0), Quaternion.Euler(0, 0, 0));
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