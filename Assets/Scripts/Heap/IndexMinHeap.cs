using UnityEngine;
using System.Collections;
/*
	by yhq
*/
public class IndexMinHeap<Item> where Item : System.IComparable<Item>
{

	int count;
	int capicity;
	Item[] data; //从1开始数数，父亲节点为index/2
	int[] indexes;// indexes[index],index存的还是代表位置，例如index = 1 代表第一个位置，indexes[index]存的是该位置应该放置的item，在data[]的索引
	int[] reserves;

	public IndexMinHeap(int capicity){
		this.capicity = capicity;
		count = 0; 
		data = new Item [capicity + 1];//data[1...capicity];
		indexes = new int[capicity +1];
		reserves = new int[capicity + 1];
		for (int i = 1; i <= capicity; i++) {
			reserves [i] = 0;
		}
	}

	public IndexMinHeap(Item[] arr,int capicity){
		this.capicity = capicity;
		data = new Item[capicity + 1];
		indexes = new int[capicity + 1];
		reserves = new int[capicity + 1];
		count = arr.Length;
		for (int i = 0; i != count; i++) {
			data[i+1] = arr[i];
			indexes [i + 1] = i + 1;
			reserves [i + 1] = i + 1;
		}
	

		//		begin = 
		int begin = count / 2;//从该节点开始可能不满足极小堆定义
		for (int i = begin; i >= 1; i--) {
			_ShiftDown (i);
		}


	}

	public void Insert(Item item){
		
		Debug.Assert (count + 1 <= capicity);
		count++;
		data [count] = item;
		indexes [count] = count;
		reserves [count] = count;
		_ShiftUp (count);

	}
	//index 是从零开始的，所以有加一的操作
	public void Insert(int index, Item item){
		Debug.Assert (count+1 <= capicity);
		Debug.Assert (index+1>=1 && index+1 <= capicity);
		count++;
		index++;
		data [index] = item;
		indexes [count] = index;
		reserves [index] = count;
		_ShiftUp (count);
	}

	public bool isContain(int index)//是否包含下标w的元素
	{
		Debug.Assert (index + 1>=1 && index + 1 <= capicity );
		return (reserves [index+1] != 0);

	}


	// 向上调整位置，直到父母节点小于原来的data[index]
	private void _ShiftUp(int index){
		int t = index;
		while (t / 2 >= 1 && data[ indexes[t/2] ].CompareTo(data[indexes[t]]) > 0) {
			AlgorithmsHelp.Swap (ref indexes[t/2], ref indexes[t]);
			reserves [indexes [t / 2]] = t / 2;
			reserves [indexes [t]] = t;
			t /= 2;
		}
	}

	//向下调整位置，直到该节点处于合适的位置
	private void _ShiftDown(int index){
		int t = index;
		while (t * 2 <= count) {
			int j = t * 2;
			if (j + 1 <= count && data [indexes[j+1]].CompareTo (data [indexes[j]]) < 0)
				j = j + 1;
			if (data [indexes[t]].CompareTo (data [indexes[j]]) < 0)
				break;
			else {
				AlgorithmsHelp.Swap (ref indexes[t], ref indexes[j]);
				reserves [indexes [t / 2]] = t / 2;
				reserves [indexes [t]] = t;
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
			str +=data[indexes[i]] + " ";

		string strdata = "";
		for(int i = 1; i <= count ; i++)
			strdata +=data[i] + " ";
		Debug.Log (" data[] = "+strdata);
		Debug.Log (IsMinHeap() + " " + str);
	}

	private string IsMinHeap(){
		string isMinHeapStr = "满足最小堆";
		string notMinHeapStr = "不满足最小堆";

		bool isMinHeap = true;
		for (int i = 1; i != count; i++) {
			//是否存在左子节点
			if (i * 2 <= count) {
				if (data [indexes[i]].CompareTo (data [indexes[i * 2]]) > 0) {
					isMinHeap = false;
					break;
				}
				if (i * 2 + 1 <= count)
				if (data [indexes[i]].CompareTo (data[ indexes[i * 2+1]]) > 0) {
					isMinHeap = false;
					break;
				}
			}

		}
		return isMinHeap ? isMinHeapStr : notMinHeapStr;

	}

	public Item ExtraMinItem(){
		Debug.Assert (count -1 >= 0);
		Item res = data [indexes[1]];
		AlgorithmsHelp.Swap (ref indexes[1],ref indexes[count]);
		reserves [indexes [1]] = 1;
		reserves[indexes[count]] = 0;
		count--;
		_ShiftDown (1);
		return res;
	}
	public int ExtraMinItemIndex(){
		Debug.Assert (count -1 >= 0);
		int res = indexes[1] - 1;
		AlgorithmsHelp.Swap (ref indexes[1],ref indexes[count]);

		reserves[indexes[1]] = 1;
		reserves [indexes[count]] =0;//0
		count--;
		_ShiftDown (1);
		return res;
	}

	public int Size(){
		return count;
	}
	//index从0开始
	public void Change(int index,Item item){
		Debug.Assert (index + 1 >=1 && index + 1<= capicity);
		index++;
		data [index] = item;
		//未优化
//		int pos = 0;
//		for (int i = index; i <= count; i++) {
//			if (data [indexes [i]].CompareTo(data [index]) == 0)
//				pos = i;
//		}
//		_Assert (pos != 0);
//		_ShiftUp (pos);
//		_ShiftDown (pos);
		//优化后
		_ShiftUp(reserves[index]);
		_ShiftDown (reserves [index]);
	}

	public Item GetMin(){
		Debug.Assert (count>=1);
		return data [indexes [1]];
	}
	//下标从1开始~
	public int GetMinIndex(){
		Debug.Assert (count >= 1);
		return indexes [1];
	}



}

