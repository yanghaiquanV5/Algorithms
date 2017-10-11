using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MergesSort : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int n = 30000000;
		int[] a = AlgorithmsHelp.generateRandomArray (n, 1, 10*n);
		int[] sameA = AlgorithmsHelp.CopyIntArray (a,n);
		int[] same2A = AlgorithmsHelp.CopyIntArray (a,n);
//		AlgorithmsHelp.printData (a);

		AlgorithmsHelp.testSort ("Merge Sort",MergeSort,a,n);
		AlgorithmsHelp.testSort ("Merge Sort1",MergeSort1,a,n);
		AlgorithmsHelp.testSort ("Insert Sort1",InsertSort.InsertionSort1,a,n);
//		AlgorithmsHelp.printData (a);
	}

	//归并排序
	public static void MergeSort<T>(T[] arr,int n)where T:System.IComparable<T>
	{
		
		_MergeSort (arr,0,n-1);
	}

	//将数组a[left..right] 进行插入排序
	private static void _InsertSort<T>(T[] arr, int left,int right)where T:System.IComparable<T>
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

	//归并排序的子过程，对arr[left,right],左右必区间
	private static void _MergeSort<T>(T[] arr,int left,int right)where T:System.IComparable<T>
	{


		if (left - right + 1 <= 15) {
			_InsertSort (arr,left,right);
		}

//		if (left >= right)
//			return;
//		int mid = (left + right) / 2;
//		_MergeSort (arr,left,mid);
//		_MergeSort (arr, mid+1, right);
//		_Merge (arr,left,mid,mid+1,right);
		//optimize
		if (left - right + 1 <= 15) {
			_InsertSort (arr,left,right);
			return;
		}
		int mid = (left + right) / 2;
		_MergeSort (arr,left,mid);
		_MergeSort (arr, mid+1, right);
		if (arr [mid].CompareTo( arr [mid + 1]) < 0)
			return;
		else _Merge (arr,left,mid,mid+1,right);

	}
	//合并的过程,左数组从[left,leftmiddle] 右数组从[rightmid,right]
	private static void _Merge<T>(T[] arr,int left,int leftmiddle,int rightmid,int right)where T:System.IComparable<T>
	{
		int leftIndex = left;
		int rightIndex = rightmid;
		int arrIndex = left;
		T[] newArr = new T[leftmiddle-left +1 +right -rightmid+1];
		//复制数组
		int maxNum = leftmiddle-left +1 +right -rightmid+1;
		int i;
		for (i = 0; i != leftmiddle-left +1; i++) {
			newArr [i] = arr [left + i];
		}
		int begin = leftmiddle-left +1;
		for (i = 0; i != right -rightmid+1 ; i++) {
			newArr [begin + i] = arr [rightmid + i];
		}
		//合并
		leftIndex = 0;
		rightIndex = leftmiddle - left + 1;
		for(i = arrIndex ; i <= right ; i++){
			if (leftIndex !=leftmiddle-left+1 && rightIndex != maxNum) {
				if (newArr [leftIndex].CompareTo (newArr [rightIndex]) < 0)
					arr [i] = newArr [leftIndex++];
				else 
					arr [i] = newArr [rightIndex++];
			}else	
				if (leftIndex != leftmiddle-left+1 && rightIndex == maxNum) {
					arr [i] = newArr [leftIndex++];
				} else {
					arr [i] = newArr [rightIndex++];

				}
		}

	}


	void MergeSort1<T>(T[] arr,int n)where T:System.IComparable<T>
	{

		_MergeSort1 (arr,0,n-1);
	}
	void _MergeSort1<T>(T[] arr,int left,int right)where T:System.IComparable<T>
	{


		//		int mid = (left + right) / 2;
		//		_MergeSort (arr,left,mid);
		//		_MergeSort (arr, mid+1, right);
		//		_Merge (arr,left,mid,mid+1,right);
//		if (left >= right)
//			return;
//		int mid = (left + right) / 2;
//		_MergeSort (arr,left,mid);
//		_MergeSort (arr, mid+1, right);
//		_Merge (arr,left,mid,right);
//
		//optimaze
		if (left - right + 1 <= 15) {
			_InsertSort (arr,left,right);
			return;
		}
		int mid = (left + right) / 2;
		_MergeSort (arr,left,mid);
		_MergeSort (arr, mid+1, right);
		if (arr [mid].CompareTo( arr [mid + 1]) < 0)
			return;
		else _Merge (arr,left,mid,right);


	}
	//合并的过程,左数组从[left,middle] 右数组从[middle+1,right]
	void _Merge<T>(T[] arr,int left,int middle,int right)where T:System.IComparable<T>
	{
		T[] newArr = new T[right - left + 1];
		for (int i = 0; i != middle - left + 1; i++) {
			newArr [i] = arr [left + i];
		}
		for (int i = 0; i != right - middle-1 + 1; i++) {
			newArr [i + middle - left + 1] = arr [middle + 1 + i]; 
		}

		int l = 0;
		int r = middle - left + 1;
		for (int i = 0; i != right - left + 1; i++) {
			if (l != middle - left + 1 && r != right - left + 1) {
				if (newArr [l].CompareTo (newArr [r]) < 0)
					arr [i + left] = newArr [l++];
				else
					arr [i + left] = newArr [r++];
			} else if (l != middle - left + 1 && r == right - left + 1)
				arr [i + left] = newArr [l++];
			else
				arr [r + left] = newArr [r++];
		
		}
			
	}




}
