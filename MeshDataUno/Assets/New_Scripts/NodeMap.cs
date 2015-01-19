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

	public List<string> getAllPrefabIds(){
		List<string> output = new List<string>();
		foreach(KeyValuePair<int,NodeClass> item in nodemap){
			output.Add (item.Value.getPrefabID());
		}
		return output;
	}

	public Dictionary<int,string> getNodePrefabPair(){
		Dictionary<int,string> output = new Dictionary<int,string> ();
		foreach (KeyValuePair<int,NodeClass> item in nodemap) {
			output.Add(item.Key,item.Value.getPrefabID());
		}
		return output;
	}



}
