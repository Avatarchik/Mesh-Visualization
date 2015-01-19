using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using Npgsql;


public class NodeMap {
	public Dictionary<int,NodeClass> nodemap;

	public NodeMap(){
		nodemap = new Dictionary<int, NodeClass> ();
	}

	public void append(int key, NodeClass node){
		nodemap.Add (key, node);
	}

	public void remove(int key){
		nodemap.Remove (key);
	}

	public List<int> getAllNodeIds(){
		List<int> output = new List<int>();
		foreach (KeyValuePair<int,NodeClass> item in nodemap) {
			output.Add(item.Key);
		}
		return output;
	}

	public List<int> getAllPrefabIds(){
		List<int> output = new List<int>();
		foreach(KeyValuePair<int,NodeClass> item in nodemap){
			output.Add (item.Value.prefabID());
		}
		return output;
	}

	public Dictionary<int,int> getNodePrefabPair(){
		Dictionary<int,int> output = new Dictionary<int,int> ();
		foreach (KeyValuePair<int,NodeClass> item in nodemap) {
			output.Add(item.Key,item.Value.getPrefabID());
		}
		return output;
	}



}
