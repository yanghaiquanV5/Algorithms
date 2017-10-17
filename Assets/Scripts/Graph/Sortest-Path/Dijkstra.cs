using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Dijkstra
{
	float[] shortPathLength;
	int src;
	int n,m;
	int[] from;
	bool[] book;
	float[] shortPath;
	WeightSpareGraph<float> graph;

	public Dijkstra(WeightSpareGraph<float> graph,int src){
		Debug.Assert (src>=0 && src < graph.V());
		this.src = src;
		this.graph = graph;
		this.n = graph.V ();
		this.m = graph.E ();
		shortPath = new float[n];
		book = new bool[n];
		from = new int[n];
		for(int i = 0 ; i != n; i++){
			book [i] = false;
			from [i] = -1;//假设都是可达的
		}

		from [src] = -1;
		shortPath [src] = 0f;
		IndexMinHeap<float> indexMinHeap = new IndexMinHeap<float> (n);

		indexMinHeap.Insert (src,shortPath[src]);
		while(indexMinHeap.Size()!=0){
			int u = indexMinHeap.ExtraMinItemIndex ();
			book [u] = true;
			WeightSpareGraph<float>.adjIterator iter = new WeightSpareGraph<float>.adjIterator (graph,u);
			for (Edge<float> e = iter.begin (); !iter.isEnd (); e = iter.Next ()) {
				int v = e.Other (u);
				if(!book[v]){
					if (from [v] == -1 || shortPath [v] > shortPath [u] + e.weight) {
						from [v] = u;
						shortPath [v] = shortPath [u] + e.weight;
						if (indexMinHeap.isContain (v)) {
							indexMinHeap.Change (v, shortPath [v]);
						} else
							indexMinHeap.Insert (v,shortPath[v]);
					}
				}
			}
				
		}


	}

	public bool isConnect(int dst){
		Debug.Assert (dst != src);
		return from [dst] != -1;
	
	}

	public float ShortestPath(int dst){
		if (!isConnect (dst)) {
			Debug.Log ("不可达" + dst);
			return -1f;
		} else {
			return shortPath [dst];
		}
			
	}

	public void ShowPath(int dst){
		if (dst == 0)
			return;
		Stack stack = new Stack ();
		List<int> path = new List<int> ();
		stack.Push (dst);
		int top;
		while(from[(int)stack.Peek()] != src){
			
			stack.Push (from[(int)stack.Peek()]);
		}
		stack.Push (src);
			
		while(stack.Count != 0){
			path.Add ((int) stack.Pop());
		}

		string str = "";
		for(int i = 0; i != path.Count; i ++){
			str += path [i] + " -> ";
		}
		Debug.Log ("路径到达"+dst+" 路径：" + str + " 。长度 ： " + shortPath[dst]);

	}
	public void ShowAllPath(){
		for (int i = 0; i != n; i++) {
			ShowPath (i);
		}
	
	}



}

