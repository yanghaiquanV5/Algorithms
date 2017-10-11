using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//极大堆定义
public class Heap<Item>  where Item: System.IComparable<Item>
{

	private Item[] data;//从1开始索引
	private int mcount;
	private int mcapicity;

	public int count {
		get{ 
			return mcount;
		}
		set{ 
			mcount = value;
		}
	}

	public int capicity{
		get{ 
			return mcapicity;
		}
		set{ 
			mcapicity = value;
		}
	}


	//数据从1开始，到capicity
	public Heap(int capicity){
		data = new Item[capicity + 1];
		this.capicity = capicity;
		count = 0;
	}

	//将数组改造成极大堆
	public Heap(Item[] arr, int n){
		data = new Item[n + 1];
		this.capicity = n;
		count = n;
		for (int i = 1; i <= n; i++) {
			data [i] = arr [i - 1];
		}

		//极大二叉堆，最大的非叶子节点是count/2
		int t = count;
		for (int i = count / 2; i >= 1; i--) {
			ShiftDown (i);
		}


	}

	//插入
	public void Insert(Item item){
		Debug.Assert (count+1 <= capicity);
		data [count + 1] = item;
		count++;

		ShiftUp (count);

	}
	//取出最大的元素
	public Item ExtractBigItem(){
		Debug.Assert(count > 0);
		Item item = data[1];
		data [1] = data [count];

		ShiftDown (1);
		count--;

		return item;
	}
	//t data的的下标，将data[t]的向下调整
	private void ShiftDown(int t){
		while( 2 * t <= count){
			int j = 2 * t;//左孩子下标
			//存在右孩子且右孩子大于左孩子，则交换的下标j改为右孩子
			if(j + 1 <= count && data[j].CompareTo(data[j+1]) < 0){
				j += 1;
			}

			if (data [t].CompareTo( data [j])> 0 )
				break;
			else {
				AlgorithmsHelp.Swap (ref data[t],ref data[j]);
				t = j;
			}
			
		}
	}



	private void ShiftUp(int count){
		int t = count;
		while (t > 1 && data [t].CompareTo( data [t / 2]) >0) {
			AlgorithmsHelp.Swap (ref data[t],ref data[t/2]);
			t = t / 2;
		}

	}

	public void printData(){
		string str = "";
		for(int i = 1 ; i <=count ; i++){
			str += data [i]+ " " ;
		}
		Debug.Log ("data[] : " +  str);
	}
		
}
