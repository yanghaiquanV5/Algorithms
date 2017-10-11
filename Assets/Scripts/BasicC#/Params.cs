using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Params : MonoBehaviour {

	// Use this for initialization
	void Start () {

		LearnParams ("第一个只传入一个参数",1);
		LearnParams ("第一个只传入一个参数",1,2,3,4);
		int[] arr = {1,2,3,4};
		LearnParams ("第一个只传入一个参数",arr);
		print ("Cool!");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LearnParams(string name,params int[] arr){
		string str =name +  " 数组长度为 : ";
		str += arr.Length + "数组元素为 ；" ;
		for (int i = 0; i != arr.Length; i++) {
			str+=arr[i].ToString() + " ";
		}
		print (str);
	}

}
