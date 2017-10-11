using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCArr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		char[] cArr = { 'a', 'a', 'a', 'a', 'a', 'a' };
		string str = "";
		for (int i = 0; i != cArr.Length; i++)
			str += cArr [i];
		print (str);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
