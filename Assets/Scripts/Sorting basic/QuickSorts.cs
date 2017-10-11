using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSorts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int n = 1900;
		int[] arr = AlgorithmsHelp.generateRandomArray(n,1,n);
		int[] arrCp = AlgorithmsHelp.CopyIntArray(arr,n);
		int[] arrCp2 = AlgorithmsHelp.CopyIntArray (arr,n);
//		AlgorithmsHelp.testSort ("MerSort", MergesSort.MergeSort, arr, n);
//		AlgorithmsHelp.testSort ("QuickSort1", QuickSort, arrCp, n);
//		AlgorithmsHelp.testSort ("QuickSort2", QuickSort2, arrCp2, n);
//		AlgorithmsHelp.testSort ("QuickSort3", QuickSort3, arrCp2, n);
//
//		arr = AlgorithmsHelp.generateNearlyOrderArray(n,5);
//		arrCp = AlgorithmsHelp.CopyIntArray(arr,n);
//		arrCp2 = AlgorithmsHelp.CopyIntArray (arr,n);
//		AlgorithmsHelp.testSort ("MerSort", MergesSort.MergeSort, arr, n);
//		AlgorithmsHelp.testSort ("QuickSort1", QuickSort, arrCp, n);
//		AlgorithmsHelp.testSort ("QuickSort2", QuickSort2, arrCp2, n);
//		AlgorithmsHelp.testSort ("QuickSort3", QuickSort3, arrCp2, n);

		arr = AlgorithmsHelp.generateRandomArray(n,1,10);
		arrCp = AlgorithmsHelp.CopyIntArray(arr,n);
		arrCp2 = AlgorithmsHelp.CopyIntArray (arr,n);
		AlgorithmsHelp.testSort ("MerSort", MergesSort.MergeSort, arr, n);
		AlgorithmsHelp.testSort ("QuickSort1", QuickSort, arrCp, n);
		AlgorithmsHelp.testSort ("QuickSort2", QuickSort2, arrCp2, n);
		AlgorithmsHelp.testSort ("QuickSort3", QuickSort3, arrCp2, n);

//
//		arr = AlgorithmsHelp.generateRandomArray(n,1,5);
//		AlgorithmsHelp.testSort ("QuickSort", QuickSort, arr, n);

//		int[] arr = AlgorithmsHelp.generateNearlyOrderArray(n,5);
//		AlgorithmsHelp.testSort ("QuickSort", QuickSort, arr, n);
	}





	
	public void QuickSort<T>(T[] arr, int n) where T : System.IComparable<T>
	{
		_QuickSort (arr, 0, n-1);
	}
	// 对a[left...right]进行排序
	private void _QuickSort<T>(T[] arr, int left,int right) where T : System.IComparable<T>
	{
			
		if (right - left <= 15) {
			_InsertSort (arr,left,right);
			return;
		}

		int p = _Partition (arr, left, right);
		_QuickSort (arr,left,p-1);
		_QuickSort (arr,p+1,right);
	}
	// 对a[left...right]进行划分
	private int _Partition<T>(T[] arr, int left, int right) where T: System.IComparable<T>
	{
		int randomIndex = Random.Range (left,right+1);//n很大，而且基本为有序时会出问题
	
		AlgorithmsHelp.Swap (ref arr[left],ref arr[randomIndex]);

		T v = arr [left];
		int j = left;
		//a[left+1...j]均小于v,而a[j+1...right]均大于v
		for (int i = left +1; i <= right; i++) {
			if (arr [i].CompareTo(v) < 0) {
				AlgorithmsHelp.Swap (ref arr [j + 1] ,ref arr [i]);
				j++;
			}
		}
		AlgorithmsHelp.Swap (ref arr[left],ref arr[j]);
		return j;
	}

	//将数组a[left..right] 进行插入排序
	static void _InsertSort<T>(T[] arr, int left,int right)where T:System.IComparable<T>
	{
		for (int i = left + 1; i <= right; i++) {
			T temp = arr [left];
			int j;
			for (j = i; j > left && arr [j].CompareTo (arr [j - 1]) < 0 ; j--) {
				arr [j] = arr [j - 1];
			}
			arr[j] = temp;
		}

	}
	//二路快速排序
	public void QuickSort2<T>(T[] arr, int n)where T: System.IComparable<T>{
		_QuickSort2 (arr,0,n-1);
	}

	//对数组arr[left...right] 进行排序
	private void _QuickSort2<T>(T[] arr, int left, int right) where T : System.IComparable<T>{
		if (right - left <= 15) {
			_InsertSort (arr,left,right);
			return;//这里经常犯错误，忘记写
		}

		int p = _Partition2 (arr,left,right);
		_QuickSort2 (arr,left,p-1);
		_QuickSort2 (arr, p + 1, right);
	}

	//对数组arr[left...right]进行划分,双路划分
	private int _Partition2<T>(T[] arr,int left, int right)where T:System.IComparable<T>{
		int randomIndex = Random.Range (left,right+1);
		AlgorithmsHelp.Swap (ref arr [left], ref arr [randomIndex]);

		//arr[left + 1...i)小于，等于v,arr(j,right]大于等于v
		T v = arr[left];
		int i = left + 1;
		int j = right;
		while(true){
			while (i <= right && arr [i].CompareTo(v) < 0)
				i++;
			while (j >= left + 1 && arr [j].CompareTo(v) > 0)
				j--;
			if (i > j)//这里需要记得
				break;
			
			AlgorithmsHelp.Swap (ref arr[i],ref arr[j]);
			i++;//这里犯过错误，记得
			j--;//这里犯过错误，记得
		}
		AlgorithmsHelp.Swap (ref arr[left],ref arr[j]);
		return j;

	}

	//对arr数组进行三路快速排序
	public static void QuickSort3<T>(T[] arr, int n) where T : System.IComparable<T>{
	
		_QuickSort3 (arr, 0, n - 1);
	
	}
	//对arr[left...right]进行三路快速排序
	public static void _QuickSort3<T> (T[] arr, int left, int right) where T : System.IComparable<T>
	{
		if (right - left <= 15) {
			_InsertSort (arr,left,right);
			return;
		}

		//Partition
		//arr[left+1...lj] < v , arr[lj+1...i-1]=v , arr[rj...right] < v
		int randomIndex = Random.Range(left,right+1);
		AlgorithmsHelp.Swap (ref arr[randomIndex],ref arr[left]);
		T v = arr[left];
		int lj = left;
		int rj = right + 1;
		int i = left + 1;
		while (i < rj) {
			if (arr [i].CompareTo (v) < 0) {
				AlgorithmsHelp.Swap(ref arr[lj+1], ref arr[i]);
				lj++;
				i++;
			}else if (arr [i].CompareTo (v) > 0) {
					AlgorithmsHelp.Swap (ref arr[i],ref arr[rj-1]);
					rj--;
				}
			else if (arr [i].CompareTo (v) == 0) {
					i++;
			}
		
		}
		//
		AlgorithmsHelp.Swap(ref arr[left],ref arr[lj]);

		_QuickSort3 (arr,left, lj-1);
		_QuickSort3 (arr,rj,right);


	}



}
