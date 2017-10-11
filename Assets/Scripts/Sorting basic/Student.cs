using UnityEngine;
using System.Collections;
using System;
public class Student :IComparable
{
	string m_name;
	float m_grade;
	public string name{
		get{ 
			return m_name;
		}
		set{ m_name = value;}
	}
	public Student(string name,float grade){
		this.name = name;
		this.grade = grade;
	}

	public float grade{
		get{ 
			return m_grade;
		}
		set{ m_grade = value;}
	}

	public override string ToString ()
	{
		return "name : " + name + " ,grade :  " + grade;
	}
	 
//	public static bool operator <(Student a,Student b){
//		return (a.grade != b.grade )?a.grade < b.grade:(a.name < b.name);
//	}
//
//	public static bool operator >(Student a,Student b){
//		return (a.grade != b.grade )?a.grade > b.grade:(a.name > b.name);
//	}

	public int CompareTo(System.Object obj){
		Student other = (Student)obj;
		return (this.grade != other.grade )?(int)(this.grade - other.grade):(this.name.ToCharArray()[0] - other.name.ToCharArray()[0]);

	} 
}

