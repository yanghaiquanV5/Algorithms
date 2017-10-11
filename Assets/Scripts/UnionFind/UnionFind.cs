using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//基于rank优化+路径压缩的并查集，有些rank会有些错误，但是不是很影响
public class UnionFind  {
	int[] parent;//从0开始
	int[] size;//表示该树的结点数量
	int[] rank;//表示该树的高度；
	int count;



	public UnionFind(int count){
		Assert (count>=1);
		this.count = count;
		parent = new int[count];
		size = new int[count];
		rank = new int[count];
		for (int i = 0; i != count; i++) {
			parent [i] = i;
			size [i] = 1;
			rank [i] = 1;
		}
	}

	public int Find(int index){
		int p = index;
//		while (p != parent [p]) {
//			p = parent [p];
//		}
		//pathCompassion
		while(p != parent[p]){
			parent[p] = parent [parent [p]];
			p = parent [p];
		}
		return parent [p];
	}

	public bool isConnected(int p, int q)
	{
		int pRoot = Find (p);
		int qRoot = Find (q);
		return pRoot == qRoot;
	}
	//将q的parent设置为p的父母节点
	//第一个没有优化的版本
	public void Union(int p, int q){
		if (isConnected (p, q))
			return;
		int pRoot = Find (p);
		int qRoot = Find (q);

		parent [qRoot] = pRoot;
	}

	//基于Size的优化
	public void Union_Size(int p, int q){
		if (isConnected (p, q))
			return;
		int pRoot = Find (p);
		int qRoot = Find (q);

		if (size [pRoot] > size [qRoot]) {
			parent [qRoot] = pRoot;
			size [pRoot] += size [qRoot];
		} else {
			parent [pRoot] = qRoot;
			size [qRoot] += size [pRoot];
		}
	}

	//基于Rank的优化
	public void Union_Rank(int p,int q){

		int pRoot = Find (p);
		int qRoot = Find (q);

		if (pRoot == qRoot)
			return;
		if (rank [pRoot] > rank [qRoot]) {
			parent [qRoot] = pRoot;
			//rank不变
		}else if(rank[pRoot] < rank[qRoot]){
			parent [pRoot] = qRoot;
			//rank不变
		}else{
			parent [qRoot] = pRoot;
			rank [pRoot] += 1;
		}

	}

	public void printParentArr(){
		string parentArrStr = "";
		for (int i = 0; i != count; i++)
			parentArrStr += parent[i]+" ";
		Debug.Log ("parent[] "+parentArrStr);
	}
	public void printPAndSize(){
		string parentArrStr = "";
		string sizeArrStr = "";
		for (int i = 0; i != count; i++) {
			parentArrStr +=parent[i]+" ";
			sizeArrStr +=size[i] + " ";
		}
		Debug.Log ("parent[] " + parentArrStr);
		Debug.Log ("  size[] " + sizeArrStr);
	}
	public void printPAndRank(){
		printParentArr ();
		string str = "";
		for (int i = 0; i != count; i++) {
			str += rank[i] + " ";
		}
		Debug.Log ("   rank[] " + str);
	}


	private void Assert(bool isTrue)
	{
		Debug.Assert (isTrue);
	}
}
