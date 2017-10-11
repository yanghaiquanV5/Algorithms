using UnityEngine;
using System.Collections;

public class TestUnionFind : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		int n = 100;
		UnionFind unionFind = new UnionFind (n);
		UnionFind unionFindCopy = new UnionFind (n);
		UnionFind unionFindCopy2 = new UnionFind (n);

		int num = 30;
		for (int i = 0; i != num; i++) {
			int p = Random.Range (0, n);
			int q = Random.Range (0,n);
			unionFind.Union (p,q);
			unionFindCopy.Union_Size (p,q);
			unionFindCopy2.Union_Rank (p, q);
		}

		unionFind.printParentArr ();
		unionFind.printPAndSize ();
		unionFind.printPAndRank ();

	}

}

