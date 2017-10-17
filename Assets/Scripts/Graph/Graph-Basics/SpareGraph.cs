using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpareGraph 
{
	List<List<int>> g;
	int n,m;
	bool isDirect;

	public SpareGraph(int n,bool isDirect){
		this.n = n;
		this.isDirect = isDirect;
		this.m = 0;
		g = new List<List<int>> ();
		for (int i = 0; i != n; i++) {
			List<int> row =new List<int> ();
			row.Clear ();
			g.Add (row);
		}

	}

	public void AddEdge(int p, int q){
		Assert (p < n && p >= 0);
		Assert (q < n && q >= 0);

		if (!HasEdge(p,q) && p != q) {
			List<int> pRow = g [p];
			pRow.Add (q);
			m++;
			if (!isDirect)
				g [q].Add (p);
		}
	}

	public bool HasEdge(int p,int q){
		Assert (n >=1);
		List<int> pRow = g[p];

		foreach (int v in pRow) {
			if (v == q)
				return true;
		}
		return false;

	}

	public class adjIterator
	{
		int index;
		SpareGraph graph;
		int v;
		public adjIterator(SpareGraph graph,int v){
			this.graph = graph;
			this.v = v;
			index = 0;
		}
		public int begin(){
//			Assert (graph.E()>=1);
			index = 0;
			if (index < graph.g [v].Count) {
				return graph.g [v] [index];
			} else
				return -1;
		}
		public bool isEnd(){
			if (index < graph.g [v].Count)
				return false;
			else
				return true;
		}
		public int Next(){
			index++;
			if (index < graph.g [v].Count)
				return graph.g [v] [index];
			else
				return -1;
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
				rowsStr +=g[i][j] + " ";
			}
			rowsStr +="\n";
		}
		Debug.Log (rowsStr);
	}
}