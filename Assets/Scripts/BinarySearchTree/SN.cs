using UnityEngine;
using System.Collections;

//使用顺序数组建立搜索组。
public class SN<Key,Value> where Key : System.IComparable<Key>
{
	class Node{
		public Key key;
		public Value value;
		public Node(Key key, Value value){
			this.key = key;
			this.value = value;
		}
		public Node(){
		}

	}

	Node[] data;
	int count;
	int capicity;

	public SN(int capicity){
		data = new Node[capicity];
		count = 0;
		this.capicity = capicity;
	}

	public int Size(){
		return count;
	}
	public bool isEmpty(){
		return count == 0;
	}

	public void Insert(Key key, Value value){
		Debug.Assert (count+1<= capicity);
		int i = 0;
		for (; i != count; i++) {
			if (data [i].key.CompareTo(key) == 0)
				break;
		}
		if (i != count)//存在钥匙一样，替换value
			data [i].value = value;
		else {
			Node newNode = new Node (key,value);
			data [count] = newNode;
			count++;
		}
	}

	public bool Contains(Key key){
		for (int i = 0; i != count; i++) {
			if (data [i].key.CompareTo (key) == 0)
				return true;
		}
		return false;

	}
	//必须先调用Contains为True，才能调用该函数
	public Value Search(Key key){
		int i = 0;
		for (; i != count; i++)
			if (data [i].key.CompareTo (key) == 0)
				break;
		return data [i].value;
	}


	//change必须先调用Contains为True，否则修改一个key不存在的
	//相当于插入一个新的Node
	public void Change(Key key, Value value){
		for (int i = 0; i != count; i++)
			if (data [i].key.CompareTo (key) == 0)
				data [i].value = value;
	}

	public void print(){
		for (int i = 0; i != count; i++) {
			Debug.Log (data[i].key + " : " + data[i].value);
		}
	
	}

}

