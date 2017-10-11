using UnityEngine;
using System.Collections;
using System;
public class BubbleSort : MonoBehaviour
{

	public void BubblableSort<T>(T[] arr, int n) where T :IComparable<T> 
	{
		
		while(n != 0){
			for (int i = 0; i != n-1; i++) {
				if (arr [i].CompareTo (arr [i + 1]) > 0)
					AlgorithmsHelp.Swap (ref arr[i], ref arr[i+1]);			
			}
			n--;
		}

	
	}
	//优化过的bubble
	public void BubblableSort1<T>(T[] arr,int n) where T: IComparable<T>
	{
		bool swapped = false;
		do {
			swapped = false;
			for (int i = 1; i != n; i++) {
				if (arr [i].CompareTo (arr [i-1]) < 0) {
					AlgorithmsHelp.Swap (ref arr [i], ref arr [i - 1]);
					swapped = true;
				}

			}
			n--;

		} while(swapped);

	}


	// Use this for initialization
	void Start ()
	{
		int n = 1000;
		int[] arr = AlgorithmsHelp.generateRandomArray(n,1,3);
		int[] arrcopy = AlgorithmsHelp.CopyIntArray (arr, n);

		AlgorithmsHelp.testSort ("BubbleSort", BubblableSort, arr, n);
		AlgorithmsHelp.printData (arr);

		AlgorithmsHelp.testSort ("BubbleSort1", BubblableSort1, arrcopy, n);
		AlgorithmsHelp.printData (arrcopy);

	}
	

}

