using UnityEngine;
using System.Collections;

[System.Serializable]
public class NodeClassMono : MonoBehaviour {
	public int node_id;
	public string time_stamp;
	public int node_type;
	public bool node_status;
	public Vector3 location;
	public string prefabID = "";

	public NodeClassMono(int node_id, string time_stamp, int node_type, bool node_status, Vector3 location){
		this.node_id = node_id;
		this.time_stamp = time_stamp;
		this.node_type = node_type;
		this.node_status = node_status;
		this.location = location;
	}

	public int getNodeId(){
		return node_id;
	}

	public string getTimeStamp(){
		return time_stamp;
	}

	public int getNodeType(){
		return node_type;
	}

	public bool getNodeStatus(){
		return node_status;
	}

	public Vector3 getLocation(){
		return location;
	}
	
	public string getPrefabID(){
		return prefabID;
	}

	public void setNodeId(int node_id){
		this.node_id = node_id;
	}

	public void setTimeStamp(string time_stamp){
		this.time_stamp = time_stamp;
	}

	public void setNodeType(int node_type){
		this.node_type = node_type;
	}

	public void setNodeStatus(bool node_status){
		this.node_status = node_status;
	}

	public void setLocation(Vector3 location){
		this.location = location;
	}

	public void setPrefabID(string prefabID){
		this.prefabID = prefabID;
	}


}