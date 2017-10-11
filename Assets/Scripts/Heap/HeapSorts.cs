using UnityEngine;
using System.Collections;

public class HeapSorts : MonoBehaviour
{

	public void HeapSort<T>(T[] arr, int n) where T: System.IComparable<T>
	{
		Heap<T> maxHeap = new Heap<T> (n);
		for (int i = 0; i != n; i++) {
			maxHeap.Insert (arr[i]);
		}

		for (int i = n - 1; i >= 0; i--) {
			arr [i] = maxHeap.ExtractBigItem ();
		}

	}

	public void HeapSort2<T>(T[] arr,int n) where T: System.IComparable<T>
	{
		Heap<T> maxHeap = new Heap<T> (arr,n);

		for (int i = n - 1; i >= 0; i--) {
			arr [i] = maxHeap.ExtractBigItem ();
		}
	
	}

	//不需要开辟新的空间，进行的原地堆排序
	public void HeapSort3<T>(T[] arr, int n)where T: System.IComparable<T>
	{
		int count = n;
		int t = (count -1) / 2;
		while( 0<=t ){
			_ShiftDown (arr,n,t);
			t--;
		}

		for (int i = n - 1; i >= 1; i--) {
			AlgorithmsHelp.Swap (ref arr[i],ref arr[0]);
			_ShiftDown (arr,i,0);//这里又犯错了。。。
		}

	}

	private void _ShiftDown<T>(T[] arr, int n,int t)where T : System.IComparable<T>
	{

		while(2 * t + 1<= n-1){//这里犯错误了
			int j = 2 * t + 1;
			if (j + 1 <= n - 1 && arr [j].CompareTo (arr [j + 1]) < 0)
				j += 1;
			if (arr [t].CompareTo (arr [j]) > 0)
				break;
			else {
				AlgorithmsHelp.Swap (ref arr[t],ref arr[j]);
				t = j;
			}

		}

	}



	// Use this for initialization
	void Start ()
	{
		int n = 1000000;
		int[] arr = AlgorithmsHelp.generateRandomArray (n , 1, n);
		int[] arrCopy1 = AlgorithmsHelp.CopyIntArray (arr, n);
		int[] arrCopy2 = AlgorithmsHelp.CopyIntArray (arr, n);
		int[] arrCopy3 = AlgorithmsHelp.CopyIntArray (arr, n);
		int[] arrCopy4 = AlgorithmsHelp.CopyIntArray (arr, n);


		AlgorithmsHelp.testSort ("Merge Sort", MergesSort.MergeSort,arr,n);
		AlgorithmsHelp.testSort ("Quick Sort 3 ways",QuickSorts.QuickSort3,arrCopy1,n);
		AlgorithmsHelp.testSort ("Heap Sort", HeapSort, arrCopy2, n);
		AlgorithmsHelp.testSort ("Heap Sort2", HeapSort2, arrCopy3, n);
		AlgorithmsHelp.testSort ("Heap Sort3", HeapSort3, arrCopy4, n);
//
//
//		arr = AlgorithmsHelp.generateRandomArray (n,1,20);
//		arrCopy1 = AlgorithmsHelp.CopyIntArray (arr,n);
//		arrCopy2 = AlgorithmsHelp.CopyIntArray (arr, n);
//		arrCopy3 = AlgorithmsHelp.CopyIntArray (arr, n);
//		 
//
//		AlgorithmsHelp.testSort ("Merge Sort", MergesSort.MergeSort,arr,n);
//		AlgorithmsHelp.testSort ("Quick Sort 3 ways",QuickSorts.QuickSort3,arrCopy1,n);
//		AlgorithmsHelp.testSort ("Heap Sort", HeapSort, arrCopy2, n);
//		AlgorithmsHelp.testSort ("Heap Sort2", HeapSort2, arrCopy3, n);
//
//
//		arr = AlgorithmsHelp.generateNearlyOrderArray (n,20);
//		arrCopy1 = AlgorithmsHelp.CopyIntArray (arr,n);
//		arrCopy2 = AlgorithmsHelp.CopyIntArray (arr, n);
//		arrCopy3 = AlgorithmsHelp.CopyIntArray (arr, n);
//
//
//		AlgorithmsHelp.testSort ("Merge Sort", MergesSort.MergeSort,arr,n);
//		AlgorithmsHelp.testSort ("Quick Sort 3 ways",QuickSorts.QuickSort3,arrCopy1,n);
//		AlgorithmsHelp.testSort ("Heap Sort", HeapSort, arrCopy2, n);
//		AlgorithmsHelp.testSort ("Heap Sort2", HeapSort2, arrCopy3, n);

	}

}

