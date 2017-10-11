using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InsertSort : MonoBehaviour {
	
	public static void InsertionSort<T>(T[] arr, int n)where T:IComparable
	{
		for (int i = 1; i != n; i++) {
		
			for (int j = i; j > 0; j--) {
				if (arr [j].CompareTo (arr [j - 1]) < 0)
					AlgorithmsHelp.Swap (ref arr [j], ref arr [j - 1]);
				else
					break;
			}
		
		}
	}

	public static void InsertionSort1<T>(T[] arr, int n)where T:IComparable
	{
		for (int i = 1; i != n; i++) {
			T temp = arr [i];
			int j;
			for (j = i; j > 0&&temp.CompareTo (arr [j - 1]) < 0; j--) {
					arr[j] = arr[j-1];
			}
			arr [j] = temp;
		}


	}

	// Use this for initialization
	void Start () {
//		int n = 1000;
//		//实验1
//		int[] arr = AlgorithmsHelp.generateRandomArray (n, 1, n);
//		int[] sameArr = AlgorithmsHelp.CopyIntArray (arr,n);
//		AlgorithmsHelp.testSort ("InsertionSort1", InsertionSort1, sameArr, n);
//		AlgorithmsHelp.printData (sameArr);
////		AlgorithmsHelp.testSort ("SelectionSort", SelectSort.SelectionSort,arr,n);
////		AlgorithmsHelp.printData (sameArr);
//		AlgorithmsHelp.testSort ("InsertionSort", InsertionSort, arr, n);
//		AlgorithmsHelp.printData (arr);

		//实验2 比较有序数组的，选择排序的超快性
		int n = 10000;
		int[] arr = AlgorithmsHelp.generateNearlyOrderArray (n, 10);
		int[] sameArr = AlgorithmsHelp.CopyIntArray (arr,n);
		AlgorithmsHelp.testSort ("InsertionSort1", InsertionSort1, arr, n);
		AlgorithmsHelp.printData (arr);
		AlgorithmsHelp.testSort ("SelectionSort", SelectSort.SelectionSort, sameArr, n);
		AlgorithmsHelp.printData (sameArr);

	}


}
