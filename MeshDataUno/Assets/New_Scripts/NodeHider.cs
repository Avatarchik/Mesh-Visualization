using UnityEngine;
using System.Collections;

public class NodeHider : MonoBehaviour {

	private NodeClassMono nodeClassMono;
	public bool isVisible = true;
	public int time = 0;
	public int fps = 30;

	void Awake(){
		nodeClassMono = gameObject.GetComponent<NodeClassMono> ();
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Its here!");
	}
	
	// Update is called once per frame
	void Update () {
		if (isVisible == true) {
			time += 1;
			if (time == fps * 5){
				time = 0;
				NodePostgreSQL nodeDB = new NodePostgreSQL ();
				nodeClassMono = nodeDB.UpdateNode (nodeClassMono);
			}
		}
	}

	void OnBecameVisible(){
		isVisible = true;
	}

	void OnBecameInvisible(){
		isVisible = false;
	}
}
