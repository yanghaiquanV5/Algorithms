using UnityEngine;
using System.Collections;

public class Edge : System.IComparable<Edge>
{
	int u,v;
	int mweight ;
	public Edge(int u,int v,int weight){
		this.u = u;
		this.v = v;
		this.mweight = weight;
	}




	public int CompareTo(Edge other){
		return this.weight - other.weight;
	}
	public int weight{
		get{ 
			return mweight;
		}
	}
}