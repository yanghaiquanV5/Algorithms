using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * 统计圣经出现的字母的个数，使用二分搜索树
 * 
 * 
 * */


public class TestSearch : MonoBehaviour
{


	// Use this for initialization
	void Start ()
	{
	
		string DPath = Application.dataPath;
		int num = DPath.LastIndexOf ("/");
		DPath = DPath.Substring (0,num);
		string url = DPath+"/bible.txt";
		List<string> words = FileHelper.ReadFileAllWords (url);

//		SN<string , int> wordSearch = new SN<string , int> (words.Count);
//		System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch ();
//		sw2.Start ();	
//		foreach (string word in words) {
//			if (wordSearch.Contains (word)) {
//				int count = wordSearch.Search(word);
//				count++;
//				wordSearch.Change (word,count);
//			} else {
//				wordSearch.Insert (word,1);
//			}
//		}
//		sw2.Stop ();
//		Debug.Log (string.Format("Algorithm : wordSearch :cost total Time:{0} s",sw2.ElapsedMilliseconds / 1000.0));
////		wordSearch.print ();
//

		BST<string,int> wordBST = new BST<string,int> ();

		System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch ();
		sw.Start ();		

		foreach(string word in words){
			if (wordBST.Contains (word)) {
				int count = wordBST.Search (word);
				count++;
				wordBST.Insert (word, count);
			} else {
				wordBST.Insert (word,1);
			}
		}
		sw.Stop ();
		Debug.Log (string.Format("Algorithm : wordBST :"+name+" cost total Time:{0} s",sw.ElapsedMilliseconds / 1000.0));
		print(wordBST.size ());
		wordBST.VisitLeft (PrintValueBigThan);

	}

	public void PrintValueBigThan(string word,int count){
		if (count > 1)
			print ("word : " + word +" count : " + count);
	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}

