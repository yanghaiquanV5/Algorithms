using UnityEngine;
using System.Collections;

public class Components{
	DenseGraph dgraph;
	SpareGraph sgraph;
	int count;
	int n,m;
	bool[] book;
	int[] id;
	int[] from;

	public Components(DenseGraph graph){
		dgraph = graph;
		count = 0;
		book = new bool[dgraph.V ()];
		id = new int[dgraph.V ()];
		from = new int[dgraph.V ()];
		for (int i = 0; i != dgraph.V (); i++) {
			id [i] = -1;
			book [i] = false;
			from [i] = -1;

		}

//		//dfs
//		for (int i = 0; i != dgraph.V (); i++) {
//			if (!book [i]) {
//				book[i] = true;
//				from [i] = -1;
//				DenseGraphDFS (i);
//				count++;
//
//			}
//		}
//		for (int i = 0; i != dgraph.V (); i++) {
//			findPath (i);
//		}
//		Debug.Log ("图里有几个联通分量 ： " + count);
		//广度优先搜索BSF
		for(int i = 0 ; i != dgraph.V(); i++){
			if (!book [i]) {
				DenseGraphBSF (i);
				book [i] = true;
				from [i] = -1;
				count++;
			}
		}
		Debug.Log ("图里有几个联通分量 ： " + count);
				
//		for (int i = 0; i != dgraph.V (); i++) {
//			findPath (i);
//		}


	}
	private void DenseGraphBSF(int i){
		int beginU = i;
		Queue q = new Queue ();
		q.Enqueue (beginU);

		while (q.Count != 0) {
			int u = (int)q.Dequeue ();
			Debug.Log ("正在访问的节点 ：" + u);

			DenseGraph.adjIterator iter = new DenseGraph.adjIterator (dgraph,u);
			int j = 0;
			for (int v = iter.begin (); !iter.IsEnd (); v = iter.next (),j++) {
				if (v == 1 && !book [j]) {
					book [j] = true;
					from [j] = u;
					q.Enqueue (j);
				}
			}

		}

	}
	private void DenseGraphDFS(int u){

		id [u] = count;
		//标记
		Debug.Log ("正在访问的节点 ：" + u);
		//
		DenseGraph.adjIterator iter = new DenseGraph.adjIterator(dgraph,u);
		int j = 0;
		for(int v = iter.begin(); !iter.IsEnd(); v = iter.next(),j++){
			if (v==1 && !book[j]) {
				from [j] = u;
				book[j] = true;
				DenseGraphDFS (j);
			}

		}
	}


	public Components(SpareGraph sGraph){
		this.sgraph = sGraph;
		Debug.Log ("V=" + sGraph.V() + " E = " + sGraph.E());
		this.n = sGraph.V ();
		this.m = sGraph.E ();
		count = 0;
		id = new int[n];
		book = new bool[n];
		from = new int[n];
		for (int i = 0; i != n; i++) {
			from [i] = -1;
			book [i] = false;
			id [i] = -1;
		}
		//Spare DSF
		for (int v = 0; v != n; v++) {
			if(!book[v]){
				count++;
				id [v] = count;
				book [v] = true;
				from [v] = -1;
				SpareGraphDFS (v);

			}
		}

		Debug.Log ("图里有几个联通分量 ： " + count);

		for (int i = 0; i != n; i++) {
			findPath (i);
		}

//		//Spare BSF
//		for (int v = 0; v != n; v++) {
//			if (!book [v]) {
//				count++;
//				id [v] = count;
//				book [v] = true;
//				from [v] = -1;
//				SpareGraphBSF (v);
//			}
//		}
//		Debug.Log ("图里有几个联通分量 ： " + count);
//		for (int v = 0; v != n; v++) {
//			findPath (v);
//		}

	}

	private void  SpareGraphDFS(int i){
		int u = i;
//		Debug.Log ("正在访问的节点 ：" + u);

		SpareGraph.adjIterator iter = new SpareGraph.adjIterator (this.sgraph,u );
		for (int v = iter.begin (); !iter.isEnd (); v = iter.Next ()) {
			if (!book [v]) {
				book [v] = true;
				id [v] = count;
				from [v] = u;
				SpareGraphDFS (v);
			}
		}
		
	}

	private void SpareGraphBSF(int i){
		int u = i;
		Queue q = new Queue ();
		q.Enqueue (u);
		while (q.Count != 0) {
			u = (int)q.Dequeue ();
//			Debug.Log ("正在访问的节点 ：" + u);

			SpareGraph.adjIterator iter = new SpareGraph.adjIterator (this.sgraph,u);
			for (int v = iter.begin (); !iter.isEnd (); v = iter.Next ()) {
				if(!book[v]){
					book [v] = true;
					id[v] = count;
					from [v] = u;
					q.Enqueue (v);
				}
			}


		}


	}

	public bool isConnected(int p,int q){
		return id[p] == id[q];
	}

	public void findPath(int end){
		Stack stack = new Stack ();
		stack.Push (end);

		while (from[(int)stack.Peek ()] != -1) {
			int v = from[(int)stack.Peek ()];
			stack.Push (v);
		}
		string path = "一条到" + end + "点路径 ：";
		while (stack.Count != 0) {
			path += (int)stack.Pop () + " --》 ";
		}

		Debug.Log (path);

	}


	static int Max = 9999; 
	int vertexCount = 0;
	int[] minLength;
	//求其他顶点到该点src以及路径的最近距离
	public void MinLength1(int src){
		Debug.Assert (src<=n-1 && src >= 0);
		minLength = new int[this.n];
		int[] tempLength = new int[this.n];
		int[] tempfrom = new int[this.n];
		for (int i = 0; i != this.n; i++) {
			minLength[i] = Max;
			tempLength[i] = Max;
			from [i] = -1;
			tempfrom [i] = -1;
			book [i] = false;
		}

//		//跳不出循环，，，，因为n错了，不是所有的通路~·
//		//这个还是错。。。
//		int srcToVnum = 0;
//		for(int i = 0; i!= n ; i ++)
//			if(id[i] == id[src]&&src!=i){
//				srcToVnum++;
//
//			}
		
		minLength [src] = 0;
		tempLength [src] = 0;
		tempfrom [src] = -1;
		book [src] = true;
		MinSGraphDFS1 (src,1,tempLength,tempfrom);
		string str="";
		for (int i = 0; i != n; i++) {
			str+= minLength[i]+" , ";
		}
		Debug.Log (str);

		Debug.Log ("***从"+src +"其他点的路径如下");
		for (int v = 0; v != n; v++) {
			findPath (v);
		}

	} 

	private void MinSGraphDFS1(int i,int vnum,int[] templength,int[] tempfrom){

		SpareGraph.adjIterator iter = new SpareGraph.adjIterator (this.sgraph,i);
		int u = i;
		for (int v = iter.begin (); !iter.isEnd (); v = iter.Next ()) {
			if (!book [v]) {
				book [v] = true;
				templength [v] = templength [u] + 1;
				tempfrom [v] = u;
				MinSGraphDFS1 (v,vnum+1,templength,tempfrom);
				for (int k = 0; k != n; k++) {
					if (minLength [k] > templength [k] && book [k]) {
						minLength [k] = templength [k];
						from [k] = tempfrom [k];
					}
				}
				book [v] = false;

			}
		}
		
	}

	//求其他顶点到该点src以及路径的最近距离,代码好看的写法
	public void MinLength(int src){
		Debug.Assert (src<=n-1 && src >= 0);
		minLength = new int[this.n];
		for (int i = 0; i != this.n; i++) {
			from [i] = -1;
			minLength [i] = Max;
			book [i] = false;
		}
			

		minLength [src] = 0;
		book [src] = true;
		MinSGraphDFS1 (src);

		//
		string str = "";
		for (int i = 0; i != n; i++) {
			str+= minLength[i]+" , ";
		}
		Debug.Log (str);

		Debug.Log ("***从"+src +"其他点的路径如下");
		for (int v = 0; v != n; v++) {
			findPath (v);
		}

	} 

	private void MinSGraphDFS1(int i){

		SpareGraph.adjIterator iter = new SpareGraph.adjIterator (this.sgraph,i);
		int u = i;
		for (int v = iter.begin (); !iter.isEnd (); v = iter.Next ()) {
			if (!book [v]) {
				book [v] = true;
				if (minLength [v] > minLength [u] + 1) {
					minLength [v] = minLength [u] + 1;
					from [v] = u;
				}
				MinSGraphDFS1 (v);
				book [v] = false;
			}
		}

	}

		
}




