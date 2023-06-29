using ConsoleApp.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Structure {
	/// <summary>
	/// 大根堆
	/// ①heap[0]不存放值
	/// ②对于index，父index>>1，左index<<1，右(index<<1)|1
	/// </summary>
	public class Heap {
		private int[] _heap;
		private int _heapSize;
		private int _heapLimit;

		public Heap(int size) {
			_heap = new int[size + 1];
			_heapLimit = size;
			_heapSize = 0;
		}

		public Heap(int[] heap) : this(heap.Length) {
			for (int i = 0; i < heap.Length; i++) {
				Push(heap[i]);
			}
		}

		public int? Pop() {
			if (IsEmpty()) {
				Debug.WriteLine("Heap is empty.");
				return null;
			}
			int result = _heap[1];
			CommonUtils.Swap(_heap, 1, _heapSize--);
			Heapify(1);
			return result;
		}

		public void Push(int value) {
			if (IsFull()) {
				throw new Exception("Heap is full.", new Exception("堆溢出"));
			}
			_heap[++_heapSize] = value;
			HeapInsert(_heapSize);
		}

		private void HeapInsert(int index) {
			int[] arr = _heap;
			int parent = index >> 1;
			while ((arr[index] > arr[parent]) && (index != 1)) {
				CommonUtils.Swap(arr, parent, index);
				index = parent;
				parent = index >> 1;
			}
		}

		private void Heapify(int index) {
			if (IsValidIndex(index) == false) {
				return;
			}
			int[] arr = _heap;
			int heapSize = _heapSize;
			// 左孩子有效，则说明仍然有孩子
			int left = index << 1;
			while (IsValidIndex(left)) {
				int right = left | 1;
				int largest = (IsValidIndex(right) && arr[right] > arr[left]) ? right : left;
				largest = arr[largest] >= arr[index] ? largest : index;
				if (largest == index) {
					break;
				}
				CommonUtils.Swap(arr, index, largest);
				index = largest;
				left = index << 1;
			}
		}

		/// <summary>
		/// 索引值是否合理
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		private bool IsValidIndex(int index) {
			return index <= _heapSize;
		}

		private bool IsFull() {
			return _heapSize == _heapLimit;
		}

		private bool IsEmpty() {
			return _heapSize == 0;
		}
	}
}
