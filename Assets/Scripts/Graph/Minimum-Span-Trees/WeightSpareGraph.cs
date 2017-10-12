using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WeightSpareGraph<Weight> where Weight : System.IComparable<Weight>
{
	List<List<Edge<Weight>>> g;
	int n,m;
	bool isDirect;

	public WeightSpareGraph(int n,bool isDirect){
		this.n = n;
		this.isDirect = isDirect;
		this.m = 0;
		g = new List<List<Edge<Weight>>> ();
		for (int i = 0; i != n; i++) {
			List<Edge<Weight>> row =new List<Edge<Weight>> ();
			row.Clear ();
			g.Add (row);
		}

	}

	public void AddEdge(int p, int q,Weight weight){
		Assert (p < n && p >= 0);
		Assert (q < n && q >= 0);

		if (!HasEdge(p,q) && p != q) {
			List<Edge<Weight>> pRow = g [p];
			Edge<Weight> edge = new Edge<Weight> (p, q, weight);
			pRow.Add (edge);
			m++;
			if (!isDirect) {
				Edge<Weight> otherEdge = new Edge<Weight> (q,p, weight);
				g [q].Add (otherEdge);//注意，这里是两个顶点指向同一条边~，删除一条另外一条也就删除了~
			}
		}
	}

	public bool HasEdge(int p,int q){
		Assert (n >=1);
		List<Edge<Weight>> pRow = g[p];

		foreach (Edge<Weight> edge in pRow) {
			if(edge.Other(p) == q)
				return true;
		}
		return false;

	}

	public class adjIterator
	{
		int index;
		WeightSpareGraph<Weight> graph;
		int v;
		public adjIterator(WeightSpareGraph<Weight> graph,int v){
			this.graph = graph;
			this.v = v;
			index = 0;
		}
		public Edge<Weight> begin(){
//			Assert (graph.E()>=1);
			index = 0;
			if (index < graph.g [v].Count) {
				return graph.g [v] [index];
			} else
				return null;
		}
		public bool isEnd(){
			if (index < graph.g [v].Count)
				return false;
			else
				return true;
		}
		public Edge<Weight> Next(){
			index++;
			if (index < graph.g [v].Count)
				return graph.g [v] [index];
			else
				return null;
		}

		private void Assert (bool isTrue)
		{
			Debug.Assert (isTrue);
		}
	}


	public int V(){
		return n;
	}
	public int E(){
		return m;
	}
	private void Assert (bool isTrue)
	{
		Debug.Assert (isTrue);
	}


	public void print(){
		string rowsStr = "";

		for (int i = 0; i != n; i++) {
			rowsStr += "第" + i + "结点 ";
			for(int j = 0 ; j != g[i].Count ; j++){
				rowsStr +=g[i][j].U()+"-"+g[i][j].V() +"("+ g[i][j].weight + ") ";
			}
			rowsStr +="\n";
		}
		Debug.Log (rowsStr);
	}
}