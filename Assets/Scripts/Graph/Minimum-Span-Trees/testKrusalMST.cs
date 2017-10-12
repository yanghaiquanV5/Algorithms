using UnityEngine;
using System.Collections;

public class testKrusalMST : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		string name = "testWeightG1.txt";
		string url = FileHelper.FileNameHelper (name);
		WeightSpareGraph<float> sGraph = null;
		ReadWeightGraph.ReadGraphFromFile (url,out sGraph,false);
		KrusalMST<float> krusalMST = new KrusalMST<float> (sGraph);
		print ("Krusal算法生成的最小生成树,长度为" + krusalMST.length());
		krusalMST.print ();
	}

}

