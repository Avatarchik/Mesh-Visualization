using UnityEngine;
using System.Collections;

public class ToggleNode : MonoBehaviour {
	public Ray shootRay;
	public RaycastHit shootHit;
	public int distance = 30;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
		if (Input.GetMouseButtonDown(0)){
			if(Physics.Raycast (shootRay.origin, shootRay.direction, out shootHit, distance)){
				NodeClassMono nodeClassMono = shootHit.collider.GetComponent<NodeClassMono>();

				string url = "http://" + nodeClassMono.getIpAddress() + ":5000/toggle_led";
				WWW www = new WWW (url);
				Debug.Log (www);
			}
		}
	}
}
