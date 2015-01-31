using UnityEngine;
using System.Collections;

public class NodeHider : MonoBehaviour {

	private NodeClassMono nodeClassMono;
	public bool isVisible = true;
	public int timestep = 0;
	public int fps = 30;
	public float speed = 10;

	void Awake(){
		nodeClassMono = gameObject.GetComponent<NodeClassMono> ();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (isVisible == true) {
			float step = 100 * Time.deltaTime;
			if (transform.position != nodeClassMono.getLocation()){
				transform.position = Vector3.MoveTowards(nodeClassMono.getLocation(), transform.position, step);
			}



			timestep += 1;
			if (timestep == fps * 3){
				timestep = 0;
				NodePostgreSQL nodeDB = new NodePostgreSQL ();
				nodeClassMono = nodeDB.UpdateNode (nodeClassMono);
				if (nodeClassMono.getNodeStatus() == true){
					nodeClassMono.gameObject.renderer.material.color = new Color(0,1,0,1);
				} else {
					nodeClassMono.gameObject.renderer.material.color = new Color(1,0,0,1);
				}
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
