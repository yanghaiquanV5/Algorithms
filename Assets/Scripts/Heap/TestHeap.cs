using UnityEngine;
using System.Collections;

public class TestHeap : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		//测试极小堆
		print("------------------测试极小堆------------------");
		int capicity = 100;
		int n = 10;
		int[] arr = AlgorithmsHelp.generateRandomArray (n,1,20);
		MinHeap<int> minHeap = new MinHeap<int> (100);
		MinHeap<int> minarrHeap = new MinHeap<int> (arr,100);

		for(int i = 0 ; i != n ; i++)
			minHeap.Insert (arr[i]);

		minHeap.print ();

		minarrHeap.print ();
		string str = "";
		while (minHeap.Size () > 0) {
			str += minHeap.ExtraMinItem()+" ";
		}
		Debug.Log (str);

		testChangeInNormalHeap (minarrHeap);
		print("------------------------------------------");
		print("------------------测试极小索引堆------------------");

		//测试极小索引堆
		arr = AlgorithmsHelp.generateRandomArray(n,1,20);
		IndexMinHeap<int> minIndexHeap = new IndexMinHeap<int>(100);
		IndexMinHeap<int> minarrIndexHeap = new IndexMinHeap<int>(arr,100);

		for(int i = 0; i != n; i ++)
			minIndexHeap.Insert(arr[i]);
		minIndexHeap.print ();
		minarrIndexHeap.print ();

		str = "";
		while(minIndexHeap.Size() > 0){
			str += minIndexHeap.ExtraMinItem () + " ";
		}
		print ("从小到大排序 "+ str);
		testChangeInIndexHeap (minarrIndexHeap);

//		测试极大堆
//		int capicity = 100;
//		int n = 10;
//		Heap<int> maxHeap = new Heap<int> (100);
//		int[] arr = AlgorithmsHelp.generateRandomArray (n,1,20);
//		for (int i = 0; i != n; i++) {
//			maxHeap.Insert (arr[i]);
//		}
//		maxHeap.printData ();
//
//		string str = "";
//		for (int i = 0; i != n; i++) {
//			str +=maxHeap.ExtractBigItem()+" ";
//		}
//		print ("data[] : " +str);



	}

	//测试是否改变某个堆中某个数字只需要，对该数字ShiftUP 和shiftDown即可
	public void testChangeInNormalHeap(MinHeap<int> minHeap)
	{
		int index = Random.Range (1, minHeap.Size ());
		int item = 10;
		minHeap.Change(index,10);
		minHeap.print ();
	}

	//测试是否改变某个堆中某个数字只需要，对该数字ShiftUP 和shiftDown即可
	public void testChangeInIndexHeap(IndexMinHeap<int> minIndexHeap)
	{
		print ("改变前");
		minIndexHeap.print ();
		int index = Random.Range (1, minIndexHeap.Size ());
		int item = 10;
		minIndexHeap.Change(index,10);
		print ("改变后，改变第" + index +"元素，改为"+item);

		minIndexHeap.print ();
	}

}

