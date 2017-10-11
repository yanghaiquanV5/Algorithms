using UnityEngine;
using System.Collections;

public class Node<Key,Value>where Key : System.IComparable<Key>
{

	public Node<Key,Value> left;
	public Node<Key,Value> right;
	public Key key;
	public Value value;

	public Node(Key key, Value value){
		this.left = null;
		this.right = null;
		this.key = key;
		this.value = value;
	}


}

