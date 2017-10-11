using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 测试过的程序，二叉搜索树~~~
 * */
public class BSTree <Key,Value> where Key : System.IComparable<Key>
{
	Node<Key,Value> root;
	int count;

	public BSTree(){
		root = null;
		count = 0;
	}

	public void Insert(Key key, Value value){
		 root = _Insert (root,key,value);
	}
	public int Size(){
		return count;
	}
	private Node<Key,Value> _Insert(Node<Key,Value> node,Key key, Value value){
		if (node == null) {
			Node<Key,Value> newnode = new Node<Key, Value> (key, value);
			count++;
			return newnode;
		} else {
			if (node.key.CompareTo (key) > 0) {
				node.left = _Insert (node.left, key, value);
				return node;
			} else if (node.key.CompareTo (key) < 0) {
				node.right = _Insert (node.right, key, value);
				return node;
			} else {
				node.value = value;
				return node;
			}
		}

	}

	public Node<Key,Value> Search(Key key){
		return _Search (root,key);
	}
	//不允许找不到。
	private Node<Key,Value> _Search(Node<Key,Value> node,Key key){
		if (node == null) {
			Debug.Assert (false);
			return null;
		}
		else if (node.key.CompareTo (key) > 0) {
			return _Search (node.left, key);
		} else if (node.key.CompareTo (key) < 0) {
			return _Search (node.right, key);
		} else {
			return node;
		}
			
	}

	public Node<Key,Value> ExtraMinNode(){
		Debug.Assert (count >= 1);
		Node<Key,Value> minNode = null;

		root = _ExtraMinNode(root,ref minNode);
		Debug.Assert (minNode != null);
		return minNode;
	}

	//删除以node为根节点的最小的节点，返回值为修改过的node值，minNode代表被删除的最小节点
	private Node<Key,Value>_ExtraMinNode(Node<Key,Value> node,ref Node<Key,Value> minNode){
		if (node == null) {
			Debug.Assert (false);
			return null;
		}
		else if (node.left != null) {
			node.left = _ExtraMinNode (node.left, ref minNode);
			return node;
		} else {//if(node.left == null){
			count--;
			minNode = node;
			Node<Key,Value> rightNode = node.right;
			return rightNode;
		}
			

	}

	public Node<Key,Value> ExtraMaxNode(){
		Debug.Assert (count >= 1);
		Node<Key,Value> maxNode = null;

		root = _ExtraMaxNode(root,ref maxNode);
		Debug.Assert (maxNode != null);
		return maxNode;
	}

	//删除以node为根节点的最小的节点，返回值为修改过的node值，minNode代表被删除的最小节点
	private Node<Key,Value>_ExtraMaxNode(Node<Key,Value> node,ref Node<Key,Value> maxNode){
		if (node == null)
			Debug.Assert (false);
		else if (node.right != null) {
			node.right = _ExtraMaxNode (node.right, ref maxNode);
			return node;
		} else if(node.right == null){
			count--;
			maxNode = node;
			Node<Key,Value> leftNode = node.left;
			return leftNode;
		}
		return null;
	}


	//返回被删除的节点
	public Node<Key,Value> DeleteNode(Key key){
		Debug.Assert (count>=1);
		Node<Key,Value> deleteNode = null;
		root = _DeleteNode (root,key,ref deleteNode);
		Debug.Assert(deleteNode != null);
		return deleteNode;

	}

	private Node<Key,Value> _DeleteNode(Node<Key,Value> node,Key key,ref Node<Key,Value> deleteNode){
		if (node == null) {
			Debug.Assert (false);
			return null;
		}

		if (node.key.CompareTo (key) > 0) {
			node.left = _DeleteNode (node.left, key, ref deleteNode);
			return node;
		} else if (node.key.CompareTo (key) < 0) {
			node.right = _DeleteNode (node.right, key, ref deleteNode);
			return node;
		} else {//找到key值
			count--;
			Node<Key,Value> leftNode = node.left;
			Node<Key,Value> rightNode = node.right;
			if (leftNode == null && rightNode == null) {
				deleteNode = node;
				return null;
			}
			else if (leftNode!=null && rightNode==null) {
				deleteNode = node;

				return leftNode;
			}
			else if (leftNode==null && rightNode!=null) {
				deleteNode = node;

				return rightNode;
			}else
			{//if (leftNode && rightNode) {
				Node<Key,Value> subNode = null;
				node.right = _ExtraMinNode (node.right,ref subNode);
				count++;
				deleteNode = node;
				subNode.right = node.right;
				subNode.left = node.left;
				return subNode;
			}
				

		}

	}





}





