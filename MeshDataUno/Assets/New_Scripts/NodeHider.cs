using UnityEngine;
using System.Collections;

public class NodeHider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Its here!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameVisible(){
		Debug.Log ("In View");
	}

	void OnBecameInvisible(){
		Debug.Log ("ANNNNND Its gone");
	}
}
