using UnityEngine;
using System.Collections;

public class Edge<Weight> : System.IComparable<Edge<Weight>>
	where Weight :System.IComparable<Weight>
{
	int u,v;
	Weight mweight ;
	public Edge(int u,int v,Weight weight){
		this.u = u;
		this.v = v;
		this.mweight = weight;
	}
	public Edge(){
	}

	public int U(){
		return u;
	}
	public int V(){
		return v;
	}
	public int Other(int x){
		Debug.Assert (x==u || x ==v);
		return (x==u ? v : u);
	}
	public int CompareTo(Edge<Weight> other){
		return this.weight.CompareTo(other.weight);
	}
	public Weight weight{
		get{ 
			return mweight;
		}
	}

	public override string ToString(){
		string str = "";
		if (this != null) {
			str += u + " -> " + v +" : " + weight;
		}else
			str = " null ";
		return str;
	}
}