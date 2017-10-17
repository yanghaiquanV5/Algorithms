using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class String : MonoBehaviour {

	private void AppendString(string str){
		str = "string is change";//实际上没有修改...
	}
	private void AppendString(out string str){
		str = "string is change";
	}

	class TestContent{
		int id = 1;
		public TestContent(int id){
			this.id = id;
		}
		public void changeId(int id){
			this.id = id;
		}
		public int GetId(){
			return id;
		}
	}
	private void ChangeContent(TestContent content){
		//修改
		content.changeId(100);
		//content = new TestContent (100);
	}

	// Use this for initialization
	//说明了string是一个一开始就定下来的，如果给string添加新的字符串，则相当于指定了新的整个字符串；
	void Start () {
		string str = "I am string";
		print("oldstr id " + str.GetHashCode() + " contents : " + str);
		AppendString (str);
		print("newstr id " + str.GetHashCode() + " contents : " + str);

		str = "I am string";
		print("oldstr id " + str.GetHashCode() + " contents : " + str);
		AppendString (out str);
		print("newstr id " + str.GetHashCode() + " contents : " + str);


		//测试类经过外部的函数修改，时候会修改内容
		TestContent t = new TestContent(1);
		print ("old class content id : " + t.GetId());
		ChangeContent (t);
		print ("new class content id : " + t.GetId());

		//结论，C#中，如果通过外部函数（类外的函数）修改类的引用
		//则引用不会改变，还是指向原来的目标，应该类似c++中使用了const &来限定。

	}





}
