using UnityEngine;
using System.Collections;

public class TestBSTree : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		BSTree<int,int> orderBst = new BSTree<int, int> ();
		int n = 1000;
		for (int i = 0; i != n; i++) {
			orderBst.Insert (i,i);
		}
		print ("---------从小到大打印二叉搜索树");
		string str = "";
		while (orderBst.Size () != 0) {
			Node<int,int> node = orderBst.ExtraMinNode ();
			str+=node.value + " ";
		}
		print ("从小到大 ：" + str);

		for (int i = 0; i != n; i++) {
			orderBst.Insert (i,i);
		}

		print ("---------从大到小打印二叉搜索树");
		str = "";
		while (orderBst.Size () != 0) {
			Node<int,int> node = orderBst.ExtraMaxNode ();
			str+=node.value + " ";
		}
		print ("从大到小 ：" + str);

		for (int i = 0; i != n; i++) {
			orderBst.Insert (i,i);
		}
		print ("---------修改任意节点的值，删除1,3,4,5,6,8,90,999");
		int[] changeArr = {1,3,4,5,6,8,90,999};
		for (int i = 0; i != changeArr.Length; i++) {
			orderBst.DeleteNode (changeArr [i]);
		}

		str = "";
		while (orderBst.Size () != 0) {
			Node<int,int> node = orderBst.ExtraMinNode ();
			str+=node.value + " ";
		}
		print ("修改后的数值从小到大 ：" + str);


	}

}

