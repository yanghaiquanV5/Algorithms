using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DenseGraph 
{
	List<List<int>> g;//顶点从0开始~//值0代表没有边，值1代表边
	int n,m;//顶点个数，边的数量\
	bool isDirected;//是否是有向图
	public DenseGraph(int n,bool isDirected){
		this.n = n;
		this.m = 0;
		this.isDirected = isDirected;
		g = new List<List<int>> ();
		for (int i = 0; i != n; i++) {
			List<int> row = new List<int> ();
			row.Clear ();
			int[] rowValue = new int[n];
			row.AddRange (rowValue);
			g.Add (row);

//			for (int j = 0; j != n; j++)
//				row.Add (0);
//			g.Add (row);
		}

	}

	public void AddEdge(int p, int q){
		Assert (p<=n-1&&p>=0);
		Assert (q<=n-1&&q>=0);

		if (!hasEdge (p, q) && p != q) {
			g [p] [q] = 1;
			m++;
			if (!isDirected)
				g [q] [p] = 1;
			
		}

	}
	public bool hasEdge(int p, int q){
		Assert (n >=1);
		return g [p] [q]==1;
			
	}

	public class adjIterator
	{
		int index;
		DenseGraph G;
		int v;//从0开始~
		public adjIterator(DenseGraph graph,int v){
			this.G = graph;
			this.v = v;
			this.index = 0;
		}
		public int begin(){
			Assert (G.V()>=1);
			index = 0;
			if (index < G.V ())
				return G.g [v] [index];
			return -1;
		}
		public int next(){
			index++;
			if (index < G.V ())
				return G.g [v] [index];
			else
				return -1;
		}
		public bool IsEnd(){
			if (index < G.V ())
				return false;
			else
				return true;
		}

		private void Assert (bool isTrue)
		{
			Debug.Assert (isTrue);
		}

	}


	public void print(){
		string matrixStr = "";
		for (int i = 0; i != n; i++) {
			for(int j = 0 ; j != n; j++)
				matrixStr +=g[i][j] + " ";
			matrixStr+="\n";
		}
		Debug.Log (matrixStr);
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

}

