using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Sort {
	public static class Utils {
		/// <summary>
		/// 交换位置
		/// </summary>
		/// <param name="_arr"></param>
		/// <param name="a"></param>
		/// <param name="b"></param>
		private static void Swap(int[] _arr, int a, int b) {
			_arr[a] = _arr[a] ^ _arr[b];
			_arr[b] = _arr[a] ^ _arr[b];
			_arr[a] = _arr[a] ^ _arr[b];
		}

		private static int GetTheRightMostOne(int num) {
			return num & (~num + 1);	// or (num & -num)
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
				int minIndex = i;
				for (int j = i + 1	; j < _arr.Length; j++) {
					bool swap = _accending ? (_arr[minIndex] < _arr[j]) : (_arr[minIndex] > _arr[j]);
					if (swap) {
						minIndex = j;
					}
				}
				Swap(_arr, i, minIndex);
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
			for (int i = _arr.Length - 1; i > 0; i--) {
				for (int j = 0; j < i; j++) {
					bool swap = _accending ? (_arr[j] > _arr[j + 1]) : (_arr[j] < _arr[j + 1]);
					if (swap) {
						Swap(_arr, j, j + 1);
					}
				}
			}
		}

		/// <summary>
		/// 获得数组中奇数个的项（数组中仅有一种数是奇数个）
		/// </summary>
		/// <param name="_arr"></param>
		/// <returns></returns>
		public static int GetOddTimesNumFromArrayThereIsOne(int[] _arr) {
			int eor = 0;
			for (int i = 0; i < _arr.Length; i++) {
				eor ^= _arr[i];
			}
			return eor;
		}

		/// <summary>
		/// 获得数组中奇数个的项（数组中仅有两种不同的数是奇数个）
		/// </summary>
		/// <param name="_arr"></param>
		/// <param name="_numOne"></param>
		/// <param name="_numTwo"></param>
		public static void GetOddTimesNumFromArrayThereAreTwo(int[] _arr, out int _numOne, out int _numTwo) {
			// 求所有数的异或值eor，其值为两个奇数个的项的异或值
			int eor = 0;
			for (int i = 0; i < _arr.Length; i++) {
				eor ^= _arr[i];
			}
			// 两个不同的数，其异或值一定存在一位，不等于0
			// 获得只包含eor最右侧的1的数，这个位置的1，代表着两个奇数个的项，在该位置一定存在差异
			int rightMostOne = GetTheRightMostOne(eor);
			// 求出差异位上为1的奇数个的项
			_numOne = 0;	// 需要赋默认值
			for (int i = 0; i < _arr.Length; i++) {
				int temp = _arr[i];
				if ((temp & rightMostOne) != 0) {
					_numOne ^= temp;
				}
			}   
			// 求出另一个奇数个的项
			_numTwo = eor ^ _numOne;
		}

		public static void PrintOddTimesNumFromArrayThereIsOne(params int[] _arr) {
			int a = GetOddTimesNumFromArrayThereIsOne(_arr);
			Console.WriteLine("odd = {0}", a.ToString());
		}

		public static void PrintOddTimesNumFromArrayThereAreTwo(params int[] _arr) {
			int a, b;
			GetOddTimesNumFromArrayThereAreTwo(_arr, out a, out b);
			Console.WriteLine("one = {0}, two = {1}", a.ToString(), b.ToString());
		}
	}
}
