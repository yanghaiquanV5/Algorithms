using UnityEngine;
using System.Collections;

public class TestGraphDSFBSF : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

		string filename = "testG1.txt";
		SpareGraph sGraph = null;
		string url = FileHelper.FileNameHelper (filename);
		ReadGraph.ReadGraphFromFile (url,out sGraph,false);
		sGraph.print ();
		Components SpareGraphcomponent = new Components (sGraph);
		SpareGraphcomponent.MinLength1(0);
		SpareGraphcomponent.MinLength(0);


	}

	public void testNormalComponent(){
		print ("******测试稠密图的深度优先搜索******");
		DenseGraph dGraph = null;
		string filename = "testG1.txt";
		string url = FileHelper.FileNameHelper (filename);
		ReadGraph.ReadGraphFromFile (url,out dGraph,false);
		Components DenseGraphcomponent = new Components (dGraph);
		print ("******测试稀疏图的深度优先搜索******");
		SpareGraph sGraph = null;
		url = FileHelper.FileNameHelper (filename);
		ReadGraph.ReadGraphFromFile (url,out sGraph,false);
		sGraph.print ();
		Components SpareGraphcomponent = new Components (sGraph);
	}

}

