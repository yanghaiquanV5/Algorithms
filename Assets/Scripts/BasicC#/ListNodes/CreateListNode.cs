using UnityEngine;
using System.Text;
public class ArrayList<Item>  {

	ListNode<Item> head;
	int count;
	// Use this for initialization
	void Start () {
		
	}
	public ArrayList(){
		count = 0;
		head = null;
	}

	public void addNodeToEnd(Item item){
		count++;

		ListNode<Item> newNode = new ListNode<Item>(item);
		if (head == null) {
			head = newNode;
			return;
		}
		ListNode<Item> p = head;
		while (p.nextNode != null) {
			p = p.nextNode;
		}
		p.nextNode = newNode;
	}

	public void addNodeToHead(Item item){
		count++;

		ListNode<Item> newNode = new ListNode<Item> (item);
		if (head == null) {
			head = newNode;
			return;
		}
		newNode.nextNode = head;
		head = newNode;

	}

	//in order print
	public void print(){
		if (head == null){
			Debug.Log ("ListArray is null");
			return;
		}
		StringBuilder str = new StringBuilder (1000);
		ListNode<Item> p = head;
		while (p.nextNode != null) {
			str.AppendFormat (p.getItem().ToString()+ " ");
			p = p.nextNode;
		}
		Debug.Log ("content : " + str.ToString());

	}
	//from end to begin 
	public void printFromEndToEnd(){
		if (head == null){
			Debug.Log  ("ListArray is null");
			return;
		}
		Debug.Log(NextNodeString (head));
	}

	public string NextNodeString(ListNode<Item> node){
		if (node.nextNode == null)
			return node.getItem().ToString ();
		else {
			return NextNodeString (node.nextNode) +" "+node.getItem ().ToString ();
		}

	}
	public int GetCount(){
		return count;
	}

	//找到从倒数第k个数，例如最后一个数就是倒数第一个数，第二个数就是倒数第二个数
	public string FindFromEndNumItem(int k){
		//判断边界
		Debug.Assert(1<=k&&count >= k);

		ListNode<Item> pk = head;
		ListNode<Item> p = head;
		int step = 0;//p 指针走k-1步
		while(step < k-1){
			p = p.nextNode;
			step++;
		}
		while(p.nextNode != null){
			p = p.nextNode;
			pk = pk.nextNode;
		}

		return pk.getItem ().ToString ();

	}

	

}
