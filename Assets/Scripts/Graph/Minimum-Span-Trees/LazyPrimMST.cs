using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LazyPrimMST
{
	List<Edge<float>> minSpanTreeEdge;
	WeightSpareGraph<float> g;
	MinHeap<Edge<float>> minHeap;	
	float minSpanValue;
	bool[] book;
	int n;
	int m;
	float oneSpanValue;//一条生成树
	List<Edge<float>> oneSpantreeEdge;
	public LazyPrimMST(WeightSpareGraph<float> g){
		this.g = g;
		this.n = g.V ();
		this.m = g.E() ;
		minHeap = new MinHeap<Edge<float>> (m);
		minSpanTreeEdge = new List<Edge<float>> ();
		book = new bool[n];
		for (int i = 0; i != n; i++)
			book [i] = false;
		
		book [0] = true;
		visit (0);
		while(minHeap.Size()!=0){
			Edge<float> e = minHeap.ExtraMinItem ();
			int u = e.U ();
			int v = e.V ();
			if (book [u] == book [v])
				continue;
			if (!book [u]) {
				book [u] = true;
				minSpanTreeEdge.Add (e);
				visit (u);
			} else {
				book [v] = true;
				visit (v);
				minSpanTreeEdge.Add (e);
			}


//			if (!book [e.V ()] && book [e.U ()]) {//这里出错了~~~= =other也出错了。。。
//				book [e.V ()] = true;
//				visit (e.V ());
//				minSpanTreeEdge.Add (e);
//				minSpanValue =minSpanValue+ e.weight;
//			} else if (book [e.V ()] && !book [e.U ()]) {
//				book [e.U ()] = true;
//				visit (e.U ());
//				minSpanTreeEdge.Add (e);
//				minSpanValue += e.weight;
//			} else if (book [e.V ()] && book [e.U ()]) {
//				continue;
//			} else {
//				Debug.Assert (false);
//			}
			
		}

		foreach (Edge<float> e  in minSpanTreeEdge) {
			minSpanValue += e.weight;
		}

	}

	//访问n节点,将所有的横切边加入最小索引堆
	private void visit(int u){

		WeightSpareGraph<float>.adjIterator iter = new WeightSpareGraph<float>.adjIterator (g, u);
		for (Edge<float> e = iter.begin (); !iter.isEnd (); e = iter.Next ()) {
			if (book [e.Other (u)] == true)
				continue;
			minHeap.Insert (e);
		}

	}

	public void print(){
		string str = "";
		foreach(Edge<float> e in minSpanTreeEdge){

			str += e.ToString() + "\n";
		}

		Debug.Log (str);

	}
	//使用深度优先搜索得到一棵深沉树
	public LazyPrimMST(WeightSpareGraph<float> g,bool usingDSF){
		this.g = g;
		this.n = g.V ();
		oneSpantreeEdge = new List<Edge<float>> ();
		oneSpanValue = 0f;
		book = new bool[n];
		for (int i = 0; i != n; i++)
			book [i] = false;

		for (int u = 0; u != n; u++) {
			if (!book [u]) {
				book [u] = true;
				DSF (u);
			}
		}
		Debug.Log ("一条生成树的长度为： " + oneSpanValue);
	}
	public void printOneTree(){
		string str = "";
		foreach(Edge<float> e in oneSpantreeEdge){

			str += e.ToString() + "\n";
		}

		Debug.Log (str);

	}
	private void DSF(int u){
		WeightSpareGraph<float>.adjIterator iter = new WeightSpareGraph<float>.adjIterator (g, u);
		for (Edge<float> edge = iter.begin (); !iter.isEnd (); edge = iter.Next ()) {
			if (book [edge.Other (u)] == false) {
				book [edge.Other (u)] = true;
				oneSpantreeEdge.Add (edge);
				oneSpanValue += edge.weight;
				DSF (edge.Other (u));
			}
		}

	}

	public float length() {
			return minSpanValue;
	}


}

