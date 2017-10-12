using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class KrusalMST<Weight> where Weight : System.IComparable<Weight> 
{

	List<Edge<float>> minSpanTreeEdge;
	List<Edge<float>> allEdge;
	int[] id;
	float minSpanTreeValue;
	bool[] book;
	WeightSpareGraph<float> graph;//默认为无向图
	int n,m;
	public KrusalMST(WeightSpareGraph<float> graph){
		this.graph = graph;
		this.n = graph.V ();
		this.m = graph.E ();
		book = new bool[n];
		for (int i = 0; i != n; i++)
			book [i] = false;
		minSpanTreeValue = 0f;
		minSpanTreeEdge = new List<Edge<float>> ();

		//遍历图将所有的边加入allEdge数组
		allEdge = new List<Edge<float>>();
		for(int i = 0 ; i != n ; i++){
			WeightSpareGraph<float>.adjIterator iter = 
				new WeightSpareGraph<float>.adjIterator(graph,i);
			for (Edge<float> e = iter.begin (); !iter.isEnd (); e = iter.Next ()) {
				int u = e.U();
				int v = e.V();
				if(u<v)
					allEdge.Add (e);


			}

		}
		Edge<float>[] edges = allEdge.ToArray ();
		QuickSorts (edges,edges.Length);
		string str = "";
		for (int i = 0; i != edges.Length; i++) {
			str += edges [i].ToString ()+"\n";
		}
		Debug.Log (str);

//		UnionFind unionFind = new UnionFind (edges.Length);


		UnionFind uf = new UnionFind (n);
		for(int i = 0 ; i != edges.Length ; i++){
			int u = edges [i].U ();
			int v = edges [i].V ();
			if (uf.isConnected (u, v))
				continue;
			uf.Union_Rank (u,v);
			minSpanTreeEdge.Add (edges[i]);
		}
		for (int i = 0; i != minSpanTreeEdge.Count; i++) {
			minSpanTreeValue += minSpanTreeEdge [i].weight;
		}
		Debug.Log ("n,m = " + n + ", "+m);

		//犯了一个致命的错误， = =虽然数组只有两个状态连或者不连，但是
		//当两个都是false的时候，下面设置为true，这样代表他与第一组也连了，但实际上是没有连的。
		//修改~一旦两个都是false，与下一个交换= =还是不行。还是用并查集。
//		minSpanTreeEdge.Add (edges[0]);
//		book [edges [0].U ()] = true;
//		book [edges [0].V ()] = true;
//		for (int i = 1; i != edges.Length; i++) {
//			int u = edges [i].U ();
//			int v = edges [i].V ();
//
//			if (book [u] == book [v]) {
//				//both true
//				if (book [u])
//					continue;
//				//both false
//				AlgorithmsHelp.Swap(edges[i],edges[i+1]);
//				book [u] = true;
//				book [v] = true;
//				minSpanTreeEdge.Add (edges [i]);
//			} else {
//				//either
//				book[u] = true;
//				book [v] = true;
//				minSpanTreeEdge.Add (edges [i]);
//			}
//				
//		}



		//深度搜索建立并查集,错了。
//		for (int i = 0; i != n; i++) {
//			if (!book [i]) {
//				book [i] = true;
//				DSF (i);
//
//			}
//		}
	}

//	private void DSF(int u){
//		WeightSpareGraph<float>.adjIterator iter
//		= new WeightSpareGraph<float>.adjIterator (graph,u);
//		for (Edge<float> e = iter.begin (); !iter.isEnd (); e = iter.Next ()) {
//			int v = e.Other (u);	
//			if (!book [v]) {
//				book [v] = true;
//				DSF (v);
//			}
//		}
//
//
//	}

//	private QuickSort
	//单路快排
	//对a[0...n-1]进行排序
	private void QuickSorts(Edge<float>[] arr,int n){
		QuickSorts (arr,0,n-1);
	}

	private void QuickSorts(Edge<float>[] arr, int left, int right){
		if (left >= right)
			return;

		int pmid = Partition (arr, left, right);
		QuickSorts (arr,left,pmid-1);
		QuickSorts (arr, pmid + 1, right);
	}
	//对数组arr进行划分，a[left+1...j-1],a[j],a[j+1...right];
	// 1.a[left+1...j] < v, a[j+1...right]>v
	private int Partition(Edge<float>[] arr, int left,int right){
		Edge<float> v = arr [left];
		int j = left;
		//1.a[left+1...j] < v ,a[j+1...right]>v
		for (int i = left + 1; i <= right; i++) {
			if (arr [i].CompareTo(v) < 0) {
				AlgorithmsHelp.Swap (ref arr[j+1],ref arr[i]);
				j++;
			}
		}
		AlgorithmsHelp.Swap (ref arr[j],ref arr[left]);
		return j;

	}

	public void print(){
		string str = "";
		foreach (Edge<float> e in minSpanTreeEdge) {
			str += e.ToString () +"\n";
		}	
		Debug.Log (str);
	}
	public float length(){
		return minSpanTreeValue;
	}

}

