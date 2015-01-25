using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using Npgsql;


public class NodeMap {
	public Dictionary<int,NodeClassMono> nodemap;

	public NodeMap(){
		nodemap = new Dictionary<int, NodeClassMono> ();
	}

	public void append(int key, NodeClassMono node){
		nodemap.Add (key, node);
	}

	public void upsert(int key, NodeClassMono node){
		if (nodemap.ContainsKey (key)) {
			nodemap[key] = node;
		} else {
			nodemap.Add (key, node);
		}
	}

	public void remove(int key){
		nodemap.Remove (key);
	}

	public List<int> getAllNodeIds(){
		List<int> output = new List<int>();
		foreach (KeyValuePair<int,NodeClassMono> item in nodemap) {
			output.Add(item.Key);
		}
		return output;
	}

	public List<string> getAllPrefabIds(){
		List<string> output = new List<string>();
		foreach(KeyValuePair<int,NodeClassMono> item in nodemap){
			output.Add (item.Value.getPrefabId());
		}
		return output;
	}

	public Dictionary<int,string> getNodePrefabPair(){
		Dictionary<int,string> output = new Dictionary<int,string> ();
		foreach (KeyValuePair<int,NodeClassMono> item in nodemap) {
			output.Add(item.Key,item.Value.getPrefabId());
		}
		return output;
	}



}
