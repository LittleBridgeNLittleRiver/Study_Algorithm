using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Utils {
	public static class SortingUtils {
		/// <summary>
		/// 交换位置
		/// </summary>
		/// <param name="_arr"></param>
		/// <param name="a"></param>
		/// <param name="b"></param>
		private static void Swap(int[] _arr, int a, int b) {
			if (a == b)
				return;
			_arr[a] = _arr[a] ^ _arr[b];
			_arr[b] = _arr[a] ^ _arr[b];
			_arr[a] = _arr[a] ^ _arr[b];
		}

		/// <summary>
		/// 选择排序
		/// </summary>
		/// <param name="_arr"></param>
		/// <param name="_accending">是否为升序</param>
		public static void SelectionSort(int[] _arr, bool _accending = true) {
			if (_arr == null || _arr.Length < 2) {
				return;
			}
			for (int i = 0; i < _arr.Length; i++) {
				int targetIndex = i;
				for (int j = i + 1; j < _arr.Length; j++) {
					bool swap = _accending ? (_arr[targetIndex] > _arr[j]) : (_arr[targetIndex] < _arr[j]);
					if (swap) {
						targetIndex = j;
					}
				}
				Swap(_arr, i, targetIndex);
			}
		}

		/// <summary>
		/// 冒泡排序
		/// </summary>
		/// <param name="_arr"></param>
		/// <param name="_accending"></param>
		public static void BubbleSort(int[] _arr, bool _accending = true) {
			if (_arr == null || _arr.Length < 2) {
				return;
			}
			for (int i = _arr.Length - 1; i >= 0; i--) {
				for (int j = 0; j < i; j++) {
					bool swap = _accending ? (_arr[j] > _arr[j + 1]) : (_arr[j] < _arr[j + 1]);
					if (swap) {
						Swap(_arr, j, j + 1);
					}
				}
			}
		}

		/// <summary>
		/// 插入排序
		/// </summary>
		/// <param name="_arr"></param>
		/// <param name="_accending"></param>
		public static void InsertSort(int[] _arr, bool _accending = true) {
			for (int i = 1; i < _arr.Length; i++) {
				int insertPos = i;
				for (int j = i - 1; j >= 0; j--) {
					bool accend = _arr[j] > _arr[j + 1];
					bool swap = _accending ? accend : !accend;
					if (swap)
						Swap(_arr, j, j + 1);
					else
						break;
				}
			}
		}

		private static void Merge(int[] _arr, int _L, int _M, int _R) {
			int[] help = new int[_R - _L + 1];
			int i = 1;
			int p1 = _L;
			int p2 = _M + 1;
			while(p1 <= _M && p2 <= _R) {
				help[i++] = _arr[p1] <= _arr[p2] ? _arr[p1++] : _arr[p2++];
			}
			while (p1 <= _M) {
				help[i++] = _arr[p1++];
			}
			while (p2 <= _R) {
				help[i++] = _arr[p2++];
			}
			// 结果返回
			for (i = 0; i < help.Length; i++) {
				_arr[_L + i] = help[i];
			}
		}

		public static void MergeSort(int[] _arr, int _L, int _R) {
			// 中止条件
			if (_L == _R) {
				return;
			}
			int mid = _L + ((_R - _L) >>  1);
			MergeSort(_arr, _L, mid);
			MergeSort(_arr, mid + 1, _R);
			Merge(_arr, _L, mid, _R);
		}

		/// <summary>
		/// 归并排序
		/// </summary>
		/// <param name="_arr"></param>
		public static void MergeSort(int[] _arr) {
			if (_arr == null || _arr.Length < 2)
				return;
			MergeSort(_arr, 0, _arr.Length - 1);
		}
	}
}
