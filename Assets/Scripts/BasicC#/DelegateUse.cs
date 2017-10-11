using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateUse : MonoBehaviour {
	delegate void SpeakLanuage(string name);
	delegate void EatSomeThing<Tf>(Tf something);
	// Use this for initialization
	void Start () {
		SpeakLanuage xiaozhang = new SpeakLanuage (SpeakChinese);
		xiaozhang += SpeakEnglish;
		xiaozhang ("小张");

		EatSomeThing<int> xia = new EatSomeThing<int> (eatNum);
		xia (1111111111);
	}

	void SpeakEnglish (string name){
		Debug.Log (name +" speak English!");
	}
	void SpeakChinese(string name){
		Debug.Log (name +" speak Chinese");
	}

	void eatNum<Tf>(Tf t){
		Debug.Log ("eat " + t);	
	}

	//函数加泛型如何使用请看AlgorithmsHelp.test


}
