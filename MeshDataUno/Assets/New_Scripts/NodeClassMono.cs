using UnityEngine;
using System.Collections;

[System.Serializable]
public class NodeClassMono : MonoBehaviour {
	public int node_id;
	public bool node_status;
	public Vector3 location;
	public int transaction_id;
	public string time_stamp;
	public string prefabId = "";
	public string ip_address;

	public NodeClassMono(int node_id, bool node_status,  Vector3 location, int transaction_id, string time_stamp, string ip_address){
		this.node_id = node_id;
		this.node_status = node_status;
		this.location = location;
		this.transaction_id = transaction_id;
		this.time_stamp = time_stamp;
		this.ip_address = ip_address;
	}

	public int getNodeId(){
		return node_id;
	}

	public bool getNodeStatus(){
		return node_status;
	}

	public Vector3 getLocation(){
		return location;
	}

	public int getTransactionId(){
		return transaction_id;
	}

	public string getTimeStamp(){
		return time_stamp;
	}

	public string getPrefabId(){
		return prefabId;
	}

	public string getIpAddress(){
		return ip_address;
	}

	public void setNodeId(int node_id){
		this.node_id = node_id;
	}

	public void setNodeStatus(bool node_status){
		this.node_status = node_status;
	}

	public void setLocation(Vector3 location){
		this.location = location;
	}

	public void setTransactionId(int transaction_id){
		this.transaction_id = transaction_id;
	}

	public void setTimeStamp(string time_stamp){
		this.time_stamp = time_stamp;
	}

	public void setPrefabId(string prefabId){
		this.prefabId = prefabId;
	}

	public void setIpAddress(string ip_address){
		this.ip_address = ip_address;
	}



}