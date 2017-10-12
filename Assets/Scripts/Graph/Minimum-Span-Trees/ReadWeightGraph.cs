using UnityEngine;
using System.Collections;
using System.IO;
public class ReadWeightGraph
{
	public static void ReadGraphFromFile(string fileName,out WeightDenseGraph<float> graph,bool isDirected){
		int V, E;
		float W;
		string[] strs = File.ReadAllLines (fileName);
		Debug.Assert (strs.Length >= 2);
		string veline = strs [0];

		readGraphFileVELine (veline,out V,out E);
		Debug.Log ("V , E " + V +"," + E );
		graph = new WeightDenseGraph<float>(V,isDirected);
		for (int i = 0; i != E; i++) {
			string line = strs [i + 1];
			int p, q;
			float w;
			readGraphFileVEWLine (line,out p,out q,out w);
//			Debug.Log ("V , E , W" + p +"," + q+" , "+ w);
			graph.AddEdge (p,q,w);
		}

	}

	public static void ReadGraphFromFile(string fileName,out WeightSpareGraph<float> graph,bool isDirected){
		int V, E;
		string[] strs = File.ReadAllLines (fileName);
		Debug.Assert (strs.Length >= 2);
		string veline = strs [0];

		readGraphFileVELine (veline,out V,out E);
		//		Debug.Log ("V , E " + V +"," + E);
		graph = new WeightSpareGraph<float>(V,isDirected);
		for (int i = 0; i != E; i++) {
			string line = strs [i + 1];
			int p, q;
			float w;
			readGraphFileVEWLine (line,out p,out q,out w);
			graph.AddEdge (p,q,w);
		}

	}
	//读取Graph第n行的V，E个数
	//如果是第一行，V是顶点个数，E是边的个数，如果是其他行，则VE都是顶点的编号


	private static void readGraphFileVELine(string line,out int V,out int E)
	{
		string[] veStr = line.Split (' ');

		Debug.Assert (veStr.Length == 2);
		V = int.Parse(veStr[0]) ;
		E = int.Parse(veStr[1]);
	}
	private static void readGraphFileVEWLine(string line,out int V,out int E,out float W)
	{
		string[] veStr = line.Split (' ');

		Debug.Assert (veStr.Length == 3);
		V = int.Parse(veStr[0]) ;
		E = int.Parse(veStr[1]);
		W = float.Parse (veStr[2]);

	}

}