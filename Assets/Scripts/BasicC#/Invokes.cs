using UnityEngine;
using System.Collections;

public class Invokes : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		learnInvoke ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	int depth = 0;
	void learnInvoke(){
		if (depth < 3) {
			float time = Time.time;
			print ("我先出来了, 时间为 ： " + time);
			Invoke ("learnInvoke",1);	
			depth++;
		}


	}


}

