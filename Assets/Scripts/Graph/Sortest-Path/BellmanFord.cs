using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class BellmanFord {
	WeightSpareGraph<float> graph;
	int n,m;
	int[] from;
	float[] shortPathValue;
	int src;
	bool isContainNegativeCircle;
	float infinite = 9999f;

	public BellmanFord(WeightSpareGraph<float> graph,int src){
		this.graph = graph;
		this.n = graph.V ();
		this.m = graph.E ();
		this.src = src;
		this.from = new int[n];

		shortPathValue = new float[n];
		for (int i = 0; i != n; i++) {
			from [i] = -1;
			shortPathValue [i] = 9999f;
		}
		from [src] = -1;
		shortPathValue [src] = 0f;
		for (int i = 0; i != n - 1; i++) {
			for(int u = 0 ; u !=n ; u++){
				WeightSpareGraph<float>.adjIterator iter = 
					new WeightSpareGraph<float>.adjIterator (graph,u);
				for (Edge<float> e = iter.begin (); !iter.isEnd (); e = iter.Next ()) {
					//
					int v = e.Other(u);
					if (shortPathValue [v] > shortPathValue [u] + e.weight) {
						from [v] = u;
						shortPathValue [v] = shortPathValue [u] + e.weight;
					}
				}
			}
		}
		isContainNegativeCircle = detectNegetiveCircle ();
	
	}
	public bool isContainsNegativeCircle(){
		return isContainNegativeCircle;
	}



	private  bool detectNegetiveCircle(){
		for(int u = 0 ; u !=n ; u++){
			WeightSpareGraph<float>.adjIterator iter = 
				new WeightSpareGraph<float>.adjIterator (graph,u);
			for (Edge<float> e = iter.begin (); !iter.isEnd (); e = iter.Next ()) {
				//
				int v = e.Other(u);
				if (from [v] == -1 || shortPathValue [v] > shortPathValue [u] + e.weight) {
					return false;
				}
			}
		}
		return true;
	}


	public void showPath(int dst){
		if (dst == src)
			return;
		Stack stack = new Stack ();
		stack.Push (dst);
		List<int> path = new List<int> ();
		while (from [(int)stack.Peek ()] != src) {
			stack.Push (from[(int)stack.Peek()]);
		}
		stack.Push (src);

		while(stack.Count != 0)
		{
			path.Add ((int)stack.Pop());
		}

		StringBuilder str = new StringBuilder(200);
		str.AppendFormat ("the path to " + dst + " :");
		for (int i = 0; i != path.Count; i++) {
			str.AppendFormat (path[i]+" => ");
		}
		str.AppendFormat (": " + shortPathValue[dst]);

		Debug.Log (str);

	}

	public void showAllPath(){
		for (int u = 0; u != n; u++)
			showPath (u);

	}





}
