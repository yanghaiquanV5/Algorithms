using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWeightGraph : MonoBehaviour {


	// Use this for initialization
	void Start () {
		string name = "";
		string url = "";
		//测试稠密有权图,测试稀疏有权图
		testWeightDSGraph ();


	}

	//测试稠密有权图
	//测试稀疏有权图
	public void testWeightDSGraph(){
		string name = "";
		string url = "";

		//测试稠密有权图~
		print("测试稠密有权图");
		WeightDenseGraph<float> wdGraph = null;
		name = "testWeightG1.txt";
		url = FileHelper.FileNameHelper (name);
		ReadWeightGraph.ReadGraphFromFile (url,out wdGraph,false);// out不可缺少
		wdGraph.print();

		//测试稀疏有权图
		print("测试稀疏有权图");
		WeightSpareGraph<float> wsGraph = null;
		ReadWeightGraph.ReadGraphFromFile (url,out wsGraph,false);
		wsGraph.print ();
	}

}
