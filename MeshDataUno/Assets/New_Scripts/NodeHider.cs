using UnityEngine;
using System.Collections;

public class NodeHider : MonoBehaviour {

	private NodeClassMono nodeClassMono;

	void Awake(){
		nodeClassMono = gameObject.GetComponent<NodeClassMono> ();
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Its here!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameVisible(){
		nodeClassMono.setNodeStatus (true);
	}

	void OnBecameInvisible(){
		nodeClassMono.setNodeStatus (false);
	}
}
