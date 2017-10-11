using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SelectSort : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] a = {3,9,8,7,6,5,4,3,2,1};
		string s = "";


		foreach(int num in a){
			s += num+ " ";
		}
		print (s + " ");
		s = "";
		SelectionSort (a,10);
	
		foreach(float num in a){
			s += num+ " ";
		}
		print (s + " ");


		s = "";
		float[] b = {4.4f,3.3f,2.2f,1.1f};
		foreach(var num in b){
			s += num+ " ";
		}
		print (s + " ");
		s = "";
		SelectionSort (b,4);

		foreach(var num in b){
			s += num+ " ";
		}
		print (s + " ");

		// 测试模板函数，传入字符串数组
		string[] c = {"D","C","B","A"};
		s = "";
		foreach(var num in c){
			s += num+ " ";
		}
		print (s + " ");
		s = "";
		SelectionSort (c,4);

		foreach(var num in c){
			s += num+ " ";
		}
		print (s + " ");

		Student[] d = {new Student("D",90) ,new Student("C",100) ,
			new Student("B",95) ,new Student("A",95) };
		s = "";
		foreach(var num in d){
			print (num);
		}
		SelectionSort (d,4);
		foreach(var num in d){
			print (num);
		}
		int n = 10000;
//		a = null;
//		a = AlgorithmsHelp.generateRandomArray (n,1,n);
//		AlgorithmsHelp.printData (a);
//		 SelectionSort(a,n);
//		AlgorithmsHelp.printData (a);
//		a = null;

		a = AlgorithmsHelp.generateRandomArray (n,1,n);
		AlgorithmsHelp.printData (a);
		AlgorithmsHelp.testSort ("SelectionSort", SelectionSort, a, n);
		AlgorithmsHelp.printData (a);
		int i = 3;
		float f = i;
	}
	
	public static void SelectionSort<T>(T[] arr,int n)where T:IComparable
	{
//		for (int i = 0; i != n; i++) {
//			int min = -300;
//			int index = i;
//			for (int j = i+1; j != n; j++) {
//				if (min > arr [j]) {
//					index = j;
//					min = arr [j];
//				}
//			}
//			int temp = arr [i];
//			arr [i] = arr [index];
//			arr [index] = temp;
////			AlgorithmsHelp.Swap (i,index,arr);
//		
//		}//错了。写在这里，让我记一辈子吧。

		for (int i = 0; i != n; i++) {
			int minIndex = i;
			for (int j = minIndex + 1 ; j != n; j++) {
				if (arr [j].CompareTo(arr[minIndex])<0) {
					minIndex = j;
				}
			
			}
			AlgorithmsHelp.Swap (ref arr[i],ref arr[minIndex]);
		}


	
	
	}
}
