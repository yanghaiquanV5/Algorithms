using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PrimMST 
{
//	List<Edge<float>> minSpanTree;
	float minSpanTreeValue;
	IndexMinHeap<float> indexMinHeap;
	List<Edge<float>> toEdgeArr;
	bool[] book;
	WeightSpareGraph<float> graph;
	int n,m;

	public PrimMST(WeightSpareGraph<float> graph)
	{
		this.graph = graph;
		this.n = graph.V ();
		this.m = graph.E ();
		minSpanTreeValue = 0;
		book = new bool[n];
		toEdgeArr = new List<Edge<float>>();
		for (int i = 0; i != n; i++)
			toEdgeArr.Add(null);
		for (int i = 0; i != n; i++)
			book [i] = false;
		indexMinHeap = new IndexMinHeap<float> (m);
		book [0] = true;
		visit (0);
		while (indexMinHeap.Size () != 0) {
			int index = indexMinHeap.ExtraMinItemIndex ();
			Debug.Assert (toEdgeArr[index]!=null);
			book[index] = true;
			visit (index);	
//			int u = toEdgeArr [index].U ();
//			int v = toEdgeArr [index].V ();
//			if (book [u] && !book [v]) {
//				book [v] = true;
//				visit (v);
//			} else if(!book [u] && book [v]){
//				book [u] = true;
//				visit (u);
//			}

		}

		for (int i = 1; i != n; i++) {
			minSpanTreeValue += toEdgeArr [i].weight;
		}

	}

	public void visit(int u)
	{
		WeightSpareGraph<float>.adjIterator iter = new WeightSpareGraph<float>.adjIterator (graph,u);
		for (Edge<float> e = iter.begin (); !iter.isEnd (); e = iter.Next ()) {
			if (book [e.Other (u)])
				continue;
			int v = e.Other (u); // u

			if (toEdgeArr [v] == null) {
				toEdgeArr [v] = e;
				indexMinHeap.Insert (v, e.weight);
			} else {
				if (toEdgeArr [v].CompareTo (e) > 0) {
					toEdgeArr [v] = e;
					indexMinHeap.Change (v, e.weight);
				}
			} 
		}
	}

	public void print(){
		string str = "";
//		foreach(Edge<float> e in toEdgeArr){
//			str += e.ToString ();
//			str += "\n";
//		}
		for(int i = 1 ; i != n ; i++){
			str += toEdgeArr [i].ToString ();
			str += "\n";
		}
		Debug.Log ("最小生成树为 ： "+"\n"+str);
		Debug.Log ("最小权值为 ：" + Length());
	}

	public float Length(){

		return minSpanTreeValue;
	}






}

