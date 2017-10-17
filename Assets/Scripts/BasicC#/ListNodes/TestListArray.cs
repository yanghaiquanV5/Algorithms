using UnityEngine;

public class TestListArray : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		//测试自定义链表，并正序逆序打印
		ArrayList<int> array = new ArrayList<int>();
		ArrayList<int> outArray = new ArrayList<int> ();
		for (int i = 0; i != 100; i++) {
			array.addNodeToEnd (i);
			outArray.addNodeToHead (i);
		}
		array.print ();
		array.printFromEndToEnd();

		outArray.print ();
		outArray.printFromEndToEnd ();
		int[] karray = { 1, 2, 3, 4, 100 ,};
		for(int i = 0 ; i != karray.Length; i++)
			print("倒数第 " +karray[i] +" 数为 "+array.FindFromEndNumItem (karray[i]));


	}
	

}

