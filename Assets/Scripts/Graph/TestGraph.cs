using UnityEngine;
using System.Collections;

public class TestGraph : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		//测试图的基本功能
//		testGraphBasicOperation ();
		//从File读取图
		print("*********测试稠密图的读取文件获得数据*********");
		string filename1 = "testG1.txt";
		string filename2 = "testG2.txt";
		string url	= FileHelper.FileNameHelper(filename1);
		bool isDirect = false;
		DenseGraph dGraph = null;
		ReadGraph.ReadGraphFromFile(url,out dGraph,isDirect);
		dGraph.print ();

		dGraph = null;
		ReadGraph.ReadGraphFromFile(url,out dGraph,isDirect);
		url = FileHelper.FileNameHelper (filename2);
		ReadGraph.ReadGraphFromFile (url,out dGraph, isDirect);
		dGraph.print ();
		print("*******************************************");

		print("*********测试稀疏图的读取文件获得数据*********");
		url	= FileHelper.FileNameHelper(filename1);
		SpareGraph sGraph = null;
		ReadGraph.ReadGraphFromFile(url,out sGraph,isDirect);
		sGraph.print ();

		sGraph = null;
		ReadGraph.ReadGraphFromFile(url,out sGraph,isDirect);
		url = FileHelper.FileNameHelper (filename2);
		ReadGraph.ReadGraphFromFile (url,out sGraph, isDirect);
		sGraph.print ();
	}

	public void testGraphBasicOperation(){
		//*********测试稠密图的基本功能*********
		print("*********测试稠密图的基本功能*********");
		int n = 10;
		int m = 3;
		bool isDirected = false;//无向图
		DenseGraph dGraph = new DenseGraph (n, isDirected);
		for (int i = 0; i != m; i++) {
			int p = Random.Range (0,n);
			int	q = Random.Range (0,n);
			dGraph.AddEdge(p , q);
		}
		dGraph.print ();
		print("*                                    *");
		string rowsStr = "";
		for (int i = 0; i != n; i++) {
			DenseGraph.adjIterator iter = new DenseGraph.adjIterator (dGraph,i);
			for(int hasEdge = iter.begin() ; !iter.IsEnd(); hasEdge = iter.next()){
				rowsStr +=hasEdge + " ";
			}
			rowsStr +="\n";
		}
		print (rowsStr);

		print("*************************************");

		print("*********测试稀疏图图的基本功能*********");
		n = 10;
		m = 3;
		isDirected = false;//无向图
		SpareGraph sGraph = new SpareGraph (n, isDirected);
		dGraph = new DenseGraph (n, isDirected);
		for (int i = 0; i != m; i++) {
			int p = Random.Range (0,n);
			int	q = Random.Range (0,n);
			sGraph.AddEdge(p , q);
			dGraph.AddEdge (p,q);
		}
		//		dGraph.print ();
		print("*                                    *");
		rowsStr = "";
		for (int i = 0; i != n; i++) {
			SpareGraph.adjIterator iter = new SpareGraph.adjIterator (sGraph,i);
			rowsStr += "第" + i + "结点 ";
			for(int hasEdge = iter.begin() ; !iter.isEnd(); hasEdge = iter.Next()){
				rowsStr +=hasEdge + " ";
			}
			rowsStr +="\n";
		}
		print (rowsStr);
		dGraph.print ();
		print("*************************************");
	}
}

