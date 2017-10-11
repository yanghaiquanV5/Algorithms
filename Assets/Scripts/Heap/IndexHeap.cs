using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//极大堆定义
public class IndexHeap<Item>  where Item: System.IComparable<Item>
{

	private Item[] data;//从1开始索引
	private int[] indexes;
	private int[] reserves;
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
	public IndexHeap(int capicity){
		data = new Item[capicity + 1];
		indexes = new int[capicity + 1];
		reserves = new int[capicity + 1]  ;

		for (int i = 1; i <= capicity; i++)
			reserves [i] = 0;


		this.capicity = capicity;
		count = 0;
	}

//	//将数组改造成极大堆
//	public Heap(Item[] arr, int n){
//		data = new Item[n + 1];
//		this.capicity = n;
//		count = n;
//		for (int i = 1; i <= n; i++) {
//			data [i] = arr [i - 1];
//		}
//
//		//极大二叉堆，最大的非叶子节点是count/2
//		int t = count;
//		for (int i = count / 2; i >= 1; i--) {
//			ShiftDown (i);
//		}
//
//
//	}

	//插入
	public void Insert(int i,Item item){
//		
//		Debug.Assert (count+1 <= capicity);
		Debug.Assert(i + 1 >= 1);
		Debug.Assert (i + 1 <= capicity);
		i += 1;

		data [i] = item;
		indexes [count + 1] = i;
		reserves [i] = count+1;
		count++;
		ShiftUp (count);
	}

	//取出最大的元素的索引
	public int ExtractBigItemIndex(){
		Debug.Assert(count > 0);

		int ret = indexes[1] - 1;
		AlgorithmsHelp.Swap (ref indexes[1],ref indexes[count]);
		reserves [indexes [count]] = 0;
		reserves [indexes [1]] = 1;
		count--;
		ShiftDown (1);

		return ret;
	}

	Item getItem(int i){
		return data [i + 1];
	}

	bool contain(int i){
		Debug.Assert (i + 1 >= 1 && i + 1 <= capicity);
		return reserves[i+1] != 0;
	}

	public void Change(int i ,Item newItem ){
	
		Debug.Assert (contain(i));
		i += 1;
		data [i] = newItem;

		int j = reserves [i];

		ShiftUp (j);
		ShiftDown (j);

		// 找到indexes[j] = i , j 表示data[i]在堆中的元素
	}



	//取出最大的元素
	public Item ExtractBigItem(){
		Debug.Assert(count > 0);
		Item item = data[indexes[1]];
		indexes [1] = indexes [count];
		reserves [count] = 1;
		ShiftDown (1);
		count--;

		return item;
	}
	//t data的的下标，将data[t]的向下调整
	private void ShiftDown(int t){
		while( 2 * t <= count){
			int j = 2 * t;//左孩子下标
			//存在右孩子且右孩子大于左孩子，则交换的下标j改为右孩子
			if(j + 1 <= count && data[indexes[j]].CompareTo(data[indexes[j+1]]) < 0){
				j += 1;
			}

			if (data [indexes[t]].CompareTo( data [indexes[j]])> 0 )
				break;
			else {
				AlgorithmsHelp.Swap (ref indexes[t],ref indexes[j]);
				//不对的
//				AlgorithmsHelp.Swap (ref reserves[t],ref reserves[j]);
				//对的
				reserves[indexes[t]] = t;
				reserves [indexes [j]] = j;


				t = j;
			}

		}
	}



	private void ShiftUp(int count){
		int t = count;
		while (t > 1 && data [indexes[t]].CompareTo( data [indexes[t/2]] )>0) {
			AlgorithmsHelp.Swap (ref indexes[t],ref indexes[t/2]);
//			AlgorithmsHelp.Swap (ref reserves[t],ref reserves[t/2]);
			reserves[indexes[t/2]] = t/2;
			reserves [indexes [t]] = t;
			t = t / 2;
		}

	}

	public void printData(){
		string str = "";
		for(int i = 1 ; i <=count ; i++){
			str += data [indexes[i]]+ " " ;
		}
		Debug.Log ("data[] : " +  str);
	}

}
