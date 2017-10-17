using System.Collections;
using UnityEngine;

//定义一个指针
public class ListNode<Item>  {
	Item item;
	ListNode<Item> node;
	public ListNode(Item item){
		this.item = item;
		node = null;
	}

	public ListNode<Item> nextNode{
		get{ 
			return node;
		}
		set{ 
			node = value;
		}
	}
	public Item getItem(){
		return item;
	}
}