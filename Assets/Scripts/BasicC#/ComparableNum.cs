using UnityEngine;
using System.Collections;

public class ComparableNum : System.IComparable<ComparableNum>
{
	int m_num;
	public int num{
		get{
			return m_num;
		}
		set {
			m_num = value;
		}

	} 
	public int CompareTo(ComparableNum other){
		return this.num - other.num;
	}
}

