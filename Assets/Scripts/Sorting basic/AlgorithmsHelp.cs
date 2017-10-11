using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class AlgorithmsHelp 
{

	public static void Swap<T>(ref T i,ref T j){
		T temp = i;
		i = j;
		j = temp;
	}
	public static int[] generateNearlyOrderArray(int n,int swapTime){
		int[] arr = new int[n];
		for (int i = 0; i != n; i++) {
			arr [i] = i;
		}

		for (int i = 0; i != swapTime; i++) {
			int r1 = UnityEngine.Random.Range (0,n); 
			int r2 = UnityEngine.Random.Range (0,n); 

			Swap (ref arr [r1], ref arr [r2]);
		}
		return arr;

	}
	public static int[] generateRandomArray(int n, int randomLeft, int randomRight){
		Debug.Assert (randomLeft - randomRight <= 0,"randomLeft > randomRight");
		int[] arr = new int[n];
		for(int i = 0 ; i != n ; i++)
		{
			arr[i] = UnityEngine.Random.Range(randomLeft,randomRight);
		}
		return arr;
	}
	public static void printData<T>(T[] arr)
	{
		string s = "";
		foreach(T t in arr){
			s += t + " ";
		}
		Debug.Log(s);
	}
	public static bool isSorted<T>(T[] arr,int n) where T:IComparable
	{
		for(int i = 0 ; i < n -1 ; i++)
		{
			if (arr[i].CompareTo(arr[i+1]) > 0)
				return false;	
		}
		return true;
	}

	public delegate void SortAlgorithm<T>(T[] arr, int n)where T:IComparable;
	public static void testSort<T>(string name,SortAlgorithm<T> functionDelegate, T[] arr, int n) where T:IComparable
	{
		

		System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch ();
		sw.Start ();		
		functionDelegate(arr,n);
		sw.Stop ();
		Debug.Assert (isSorted(arr,n));
		Debug.Log (string.Format("Algorithm : name :"+name+"cost total Time:{0} s",sw.ElapsedMilliseconds / 1000.0));


//		float beginTime = Time.realtimeSinceStartup;
//		functionDelegate(arr,n);
//		float endTime = Time.realtimeSinceStartup;
//		Debug.Assert (isSorted(arr,n));
//		float costTime = endTime - beginTime;
//		Debug.Log ("Algorithm : " + name +" cost Time : " + costTime+ "s");
	}

	public static int[] CopyIntArray(int[] arr,int n){
		int[] newArr = new int[n];
		Array.Copy (arr, newArr, n);

		return newArr; 
	}




}

