using UnityEngine;
using System.Collections;
using System.IO;
public class ReadGraph 
{
	public static void ReadGraphFromFile(string fileName,out DenseGraph graph,bool isDirected){
		int V, E;
		string[] strs = File.ReadAllLines (fileName);
		Debug.Assert (strs.Length >= 2);
		string veline = strs [0];

		readGraphFileVELine (veline,out V,out E);
//		Debug.Log ("V , E " + V +"," + E);
		graph = new DenseGraph(V,isDirected);
		for (int i = 0; i != E; i++) {
			string line = strs [i + 1];
			int p, q;
			readGraphFileVELine (line,out p,out q);
			graph.AddEdge (p,q);
		}

	}

	public static void ReadGraphFromFile(string fileName,out SpareGraph graph,bool isDirected){
		int V, E;
		string[] strs = File.ReadAllLines (fileName);
		Debug.Assert (strs.Length >= 2);
		string veline = strs [0];

		readGraphFileVELine (veline,out V,out E);
		//		Debug.Log ("V , E " + V +"," + E);
		graph = new SpareGraph(V,isDirected);
		for (int i = 0; i != E; i++) {
			string line = strs [i + 1];
			int p, q;
			readGraphFileVELine (line,out p,out q);
			graph.AddEdge (p,q);
		}

	}
	//读取Graph第n行的V，E个数
	//如果是第一行，V是顶点个数，E是边的个数，如果是其他行，则VE都是顶点的编号
	private static void readGraphFileVELine(string line,out int V,out int E)
	{
		Debug.Assert (line.Length >= 2);
		string[] veStr = line.Split (' ');

		Debug.Assert (veStr.Length == 2);
		V = int.Parse(veStr[0]) ;
		E = int.Parse(veStr[1]);

	}



}