using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfFinds : MonoBehaviour {


	public int HalfFind1<T>(T[] arr, int n, T v)where T : System.IComparable<T>{

		int l = 0, r = n - 1;
		//对arr的[l,r]进行二分查找
		int mid = l + (r-l)/2;

		while (l <= r) {
			if (arr [mid].CompareTo (v) == 0) {
				return mid;
			} else if (arr [mid].CompareTo(v) > 0) {
				r = mid - 1;
			} else if (arr [mid].CompareTo(v) < 0 ) {
				l = mid + 1;
			}
			mid = l + (r - l) / 2;
		}

		return -1;


	}

	public int HalfFind2<T>(T[] arr,int n,T v)where T : System.IComparable<T>{
	

		return _HalfFind2 (arr, 0, n-1, v);
	
	
	}

	//对arr[left...right]进行二分查找
	private int _HalfFind2<T>(T[] arr, int left, int right, T v)where T: System.IComparable<T>{
	
		if(left <= right){
			int mid = left + (right - left) / 2;
			if (arr [mid].CompareTo (v) == 0) {
				return mid;
			} else if (arr [mid].CompareTo (v) > 0) {
				right = mid - 1;
			} else if (arr [mid].CompareTo (v) < 0) {
				left = mid + 1;
			}

			return _HalfFind2 (arr,left,right,v);
		}
		return -1;
	}












	// Use this for initialization
	void Start () {
		int n = 10000;
		int[] arr = AlgorithmsHelp.generateNearlyOrderArray (n, 0);
		int[] arrCopy = AlgorithmsHelp.CopyIntArray (arr,n);
		int needFindValue = 500;
		int index = HalfFind1 (arr, n, needFindValue);
		int index2 = HalfFind2 (arr, n , needFindValue);
		print (index == -1 ? "No Find Value" : "Find value in + arr "+index+" and arr[index] = " + arr[index]);
		print (index2 == -1 ? "No Find Value" : "Find value in + arr "+index2+" and arrCopy[index2] = " + arrCopy[index2]);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
