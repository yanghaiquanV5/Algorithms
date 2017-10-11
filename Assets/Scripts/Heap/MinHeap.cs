using UnityEngine;
using System.Collections;

public class MinHeap<Item> where Item : System.IComparable<Item>
{
	int count;
	int capicity;
	Item[] data; //从1开始数数，父亲节点为index/2



	public MinHeap(int capicity){
		this.capicity = capicity;
		count = 0;
		data = new Item [capicity + 1];//data[1...capicity];
	}

	public MinHeap(Item[] arr,int capicity){
		this.capicity = capicity;
		data = new Item[capicity + 1];
		count = arr.Length;
		for (int i = 0; i != count; i++) {
			data[i+1] = arr[i];
		}
//		begin = 
		int begin = count / 2;//从该节点开始可能不满足极小堆定义
		for (int i = begin; i >= 1; i--) {
			_ShiftDown (i);
		}


	}

	public void Insert(Item item){
		_Assert (count + 1 <= capicity);
		count++;
		data [count] = item;
		_ShiftUp (count);

	}

	// 向上调整位置，直到父母节点小于原来的data[index]
	private void _ShiftUp(int index){
		int t = index;
		while (t / 2 >= 1 && data[t/2].CompareTo(data[t]) > 0) {
			AlgorithmsHelp.Swap (ref data[t/2], ref data[t]);
	
			t /= 2;
		}
	}

	//向下调整位置，直到该节点处于合适的位置
	private void _ShiftDown(int index){
		int t = index;
		while (t * 2 <= count) {
			int j = t * 2;
			if (j + 1 <= count && data [j+1].CompareTo (data [j]) < 0)
				j = j + 1;
			if (data [t].CompareTo (data [j]) < 0)
				break;
			else {
				AlgorithmsHelp.Swap (ref data [t], ref data [j]);
				t = j;
			}
		}
	}


	private void _Assert(bool isTrue){
		Debug.Assert (isTrue);
	}
		
	public void print(){
		string str = "";
		for(int i = 1; i <= count ; i++)
			str +=data[i] + " ";
		
		Debug.Log (IsMinHeap() + " " + str);
	}

	private string IsMinHeap(){
		string isMinHeapStr = "满足最小堆";
		string notMinHeapStr = "不满足最小堆";

		bool isMinHeap = true;
		for (int i = 1; i != count; i++) {
			//是否存在左子节点
			if (i * 2 <= count) {
				if (data [i].CompareTo (data [i * 2]) > 0) {
					isMinHeap = false;
					break;
				}
				if (i * 2 + 1 <= count)
					if (data [i].CompareTo (data [i * 2+1]) > 0) {
						isMinHeap = false;
						break;
					}
			}

		}
		return isMinHeap ? isMinHeapStr : notMinHeapStr;

	}
		
	public Item ExtraMinItem(){
		_Assert (count -1 >= 0);
		Item res = data [1];
		data[1] = data[count];
		count--;
		_ShiftDown (1);
		return res;
	}

	public int Size(){
		return count;
	}
	public void Change(int index,Item item){
		_Assert (index>=1 && index<= count);
		data [index] = item;
		_ShiftUp (index);
		_ShiftDown (index);
	}

}

