using UnityEngine;
using System.Collections;

public class testLazyPrimMST : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		//利用LazyPrim算法计算稀疏有权图的最短路径
		print("求稀疏有权图的最小生成树");
		string name = "";
		string url = "";
		name = "testWeightG1.txt";
		url = FileHelper.FileNameHelper (name);
		WeightSpareGraph<float> wsGraph = null;
		ReadWeightGraph.ReadGraphFromFile (url,out wsGraph,false);
		wsGraph.print ();
		LazyPrimMST lazyPrim = new LazyPrimMST (wsGraph);
		lazyPrim.print ();
		print ("最小生成树的长度为：" + lazyPrim.length());
		print ("使用深度优先搜索的方法得到一棵生成树");
		lazyPrim = new LazyPrimMST (wsGraph,true);
		lazyPrim.printOneTree ();
		print ("*********************");
		//利用Prim算法计算稀疏有权图的最短路径

		PrimMST prim = new PrimMST (wsGraph);
		prim.print ();


	}
	

}

