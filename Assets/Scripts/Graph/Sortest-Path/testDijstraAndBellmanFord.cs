using UnityEngine;
using System.Collections;

public class testDijstraAndBellmanFord : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		string name = "testWeightG1.txt";
//		name = "testShortPath.txt";
		string url = FileHelper.FileNameHelper (name);
		WeightSpareGraph<float> sGraph = null;
		ReadWeightGraph.ReadGraphFromFile (url,out sGraph,false);
		sGraph.print ();
		Dijkstra dijkstra = new Dijkstra (sGraph,0);

		dijkstra.ShowAllPath ();

		BellmanFord bellmanFord = new BellmanFord (sGraph,0);
		bellmanFord.showAllPath ();



	}
	

}

