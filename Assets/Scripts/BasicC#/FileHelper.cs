using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
public class FileHelper : MonoBehaviour
{
	//从linenumber从第一行开始读取
	public static string ReadFile(string fileName, int linenumber){
		string[] strs = File.ReadAllLines (fileName);
		if (linenumber == 0)
			return "";
		else
			return strs [linenumber - 1]; 
	}


	public static string[] ReadAllLines(string fileName){
		string[] strs = File.ReadAllLines (fileName);
		return strs;
	}

	public static List<string> ReadFileAllWords(string fileName){
		string[] allText = ReadAllLines (fileName);
		List<string> words = new List<string> ();
		foreach (string line in allText) {
			int length = line.Length;
			char[] cArr = new char[length];
			for (int i = 0; i != length; i++)
				cArr [i] = line [i];

			for (int start = 0, i = 0; i <= length; i++) {
				while ((i <= length - 1)&&(char.IsLetter (cArr [i]))) {
					if (char.IsUpper (cArr [i])) {
						cArr [i] = char.ToLower (cArr[i]);

					}
					i++;
				}
				if (i - start == 0) {
					start = i + 1;
				} else {
					string str="";
					for(int j = start ; j!= i; j++ )
						str +=cArr[j]; 
					string word = str;
					words.Add (word);
					start = i + 1;
				}
			}

		}
		return words;
	}



	// Use this for initialization
	void Start ()
	{
//		string DPath = Application.dataPath;
//		int num = DPath.LastIndexOf ("/");
//		DPath = DPath.Substring (0,num);
//		string url = DPath+"/bible.txt";
//		List<string> words = ReadFileAllWords (url);
//		int f= 0;
//		foreach(string str in words){
//			if (f < 1000)
//				print (str);
//			else
//				break;
//			f++;
//		}
		//删除从PDF拷贝到word过来的自动生成换行符
		string DPath = Application.dataPath;
		int num = DPath.LastIndexOf ("/");
		DPath = DPath.Substring (0,num);
		string url = DPath+"/test.txt";
		string[] allText = ReadAllLines (url);
		string resText = "";
		for (int i = 0; i != allText.Length; i++) {
			resText += allText[i] + " ";
		}
//		print (resText);

		WriteNewFile (url,resText);


	}
	public static string FileNameHelper(string name){
		string DPath = Application.dataPath;
		int num = DPath.LastIndexOf ("/");
		DPath = DPath.Substring (0,num);
		string url = DPath+"/"+name;
		return url;

	}

	private void WriteNewFile(string path,string info){
		StreamWriter sw = null;
		FileInfo t = new FileInfo (path);
		if (!t.Exists) {
			Debug.Assert (false);
		} else {
			sw = t.CreateText ();
		}
		sw.WriteLine (info);
		sw.Close ();
		sw.Dispose ();
	}
}
	


