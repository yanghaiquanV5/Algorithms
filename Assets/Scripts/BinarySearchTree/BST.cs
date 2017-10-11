using UnityEngine;
using System.Collections;

public class BST<Key,Value> where Key : System.IComparable<Key>
{



	private Node<Key,Value> root;
	private int count = 0;

	#region Public method
	public BST(){
		root = null;
		count = 0;
	}

	public int size(){
		return count;
	}
	public bool isEmpty(){
		return count == 0;
	}

	public void Insert(Key key,Value value){

		//		return _Insert (root, key, value);
		root = _Insert(root,key,value);

	}

	public bool Contains(Key key){

		return _Contains (root,key);
	}

	public Value Search(Key key){

		return _Search (root, key);

	}
	public delegate void PrintWay(Key key, Value value);
	public void VisitLeft(PrintWay func)
	{

		VisitLeft (root,func);
	}
	public void PreOrder(){
		PreOrder (root);
	}
	public void InOrder(){
		InOrder (root);
	}
	public void PostOrder(Node<Key,Value> node){
		mPostOrder (root);
	}

	public void LevelOrder(){
		Queue queue = new Queue ();
		queue.Enqueue (root);

		while (!(queue.Count == 0)) {
			Node<Key,Value> node = (Node<Key,Value>)queue.Dequeue ();

			Debug.Log ("Key = " + node.key);

			if (node.left != null)
				queue.Enqueue (node.left);
			if (node.right != null)
				queue.Enqueue (node.right);
			
		
		}
	
	}

	public Node<Key,Value> returnMax(){
		Debug.Assert (root != null);
		return returnMax (root);
	}

	//返回最大的节点
	private Node<Key,Value> returnMax(Node<Key,Value> node){
		if (node.right == null) {
			return node;
		} else {
			return returnMax (node.right);
		}

	}

	public Node<Key,Value> returnMin(){
		Debug.Assert (root != null);
		return returnMin (root);
	}
	private Node<Key,Value> returnMin(Node<Key,Value> node){
		if (node.left == null)
			return node;
		else
			return returnMin (node.left);
	}

	public Node<Key,Value> DeleteMin(){
		if (root == null)
			return null;
		return root = DeleteMin (root);
	}

	//返回删除最小的节点的根结点，1.为空，当最小节点没有右子树2，不为空，存在右子树
	private Node<Key,Value> DeleteMin(Node<Key,Value> node){
		if (node.left == null) {
			Node<Key,Value> rightNode = node.right;
			count--;
			return rightNode;
		}	
		node.left = DeleteMin (node.left);
		return node;//如果node->left ！=null node.left = node.left;

	}

	public Node<Key,Value> DeleteMax(){
		if (root == null)
			return null;
		return root = DeleteMax (root);
	}
	public Node<Key,Value> DeleteMax(Node<Key,Value> node){
		if (node.right == null) {
			Node<Key,Value> nodeLeft = node.left;
			count--;
			return nodeLeft;
		}
		node.right = DeleteMax (node.right);//关键，
		return node;//关键
			

	}

	public void DeleteKey(Key key){
		root = DeleteKey (root,key);
	}






	#endregion


	#region Private method


	//搜索以root为根结点的key值，返回value值
	//并且调用_Search必须先调用Contains函数且为真
	private Value _Search(Node<Key,Value> node, Key key){
		Debug.Assert (node!=null);
		if (node.key.CompareTo(key) == 0)
			return node.value;
		else if (key.CompareTo(node.key) < 0)
			return _Search (node.left, key);
		else //if (key.CompareTo(root.key) > 0)
			return _Search (node.right, key);

	}

	private bool _Contains(Node<Key,Value> node,Key key){

		if (node == null)
			return false;
		if (node.key.CompareTo( key) == 0)
			return true;
		else if (key.CompareTo(node.key) < 0)
			return _Contains (node.left, key);
		else //if (key.CompareTo(node.key) > 0)
			return _Contains (node.right,key);

	}

	private Node<Key,Value> _Insert(Node<Key,Value> node,Key key, Value value){

		if (node == null) {
			;
			count++;
			return new Node<Key,Value> (key,value);
		}
		if (node.key.CompareTo(key)==0) {
			node.value = value;
			//			return root;  错误
		} else if (key.CompareTo(node.key)<0) {
			//			return root.left = _Insert (root.left, key, value);//错误
			node.left = _Insert(node.left,key,value);

		} else if (key.CompareTo(node.key)>0) {
			//			return _Insert (root.left, key, value);
			//			return root.right = _Insert (root.left, key, value);
			node.right = _Insert(node.right,key,value);
		}
		return node;

	}


	private void VisitLeft(Node<Key,Value> node,PrintWay func){

		if (node != null) {
			func(node.key,node.value);
			VisitLeft (node.left,func);
			VisitLeft (node.right,func);
		}
	}


	private void PreOrder(Node<Key,Value> node){
		if (node != null) {
			Debug.Log ("Key = " + node.key);
			PreOrder (node.left);
			PreOrder (node.right);
		}
	}


	private void InOrder(Node<Key,Value> node){
		if (node != null) {
			InOrder (node.left);
			Debug.Log ("Key = " + node.key);
			InOrder (node.right);
		}
	}


	private void mPostOrder(Node<Key,Value> node){
		if (node != null) {
			mPostOrder (node.left);
			mPostOrder (node.right);
			Debug.Log ("Key = " + node.key);
		}
	}
	//Node为根结点的树，删除最小值，返回根节点。
	private Node<Key,Value> DeleteKey(Node<Key,Value> node,Key key)
	{
		if (node == null)
			return null;
		else {
			if (node.key.CompareTo (key) > 0)
				node.left = DeleteKey (node.left,key);
			else if (node.key.CompareTo (key)< 0)
				node.right = DeleteKey (node.right,key);
			else {
				if (node.right == null) {
					Node<Key,Value> nodeLeft = node.left;
					count--;
					return nodeLeft;
				}
				if (node.left == null) {
					Node<Key,Value> nodeRight = node.right;
					count--;
					return nodeRight;
				}

				Node<Key,Value> succeedNode = returnMin (node.right); 
				count++;
				DeleteMin (node.right);
				succeedNode.left = node.left;
				succeedNode = node.right;
				count--;
				return succeedNode;

			}
			return null;

		}


	}
	#endregion

//	private void PrintValue(Node node){
//		Debug.Log ("key : " + node.key + " : "+ node.value);
//	}
	

}

