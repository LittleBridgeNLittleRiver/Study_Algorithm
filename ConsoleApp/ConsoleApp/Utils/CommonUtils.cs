using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Utils {
	public static class CommonUtils {
		private static int GetMax(int[] _arr, int _L, int _R) {
			if (_L == _R) {
				return _arr[_L];
			}
			int mid = _L + ((_R - _L) >> 1);	// 【重点】
			int leftMax = GetMax(_arr, _L, mid);
			int rightMax = GetMax(_arr, mid + 1, _R);
			return Math.Max(leftMax, rightMax);
		}
		/// <summary>
		/// 获取数组中最大的值
		/// </summary>
		/// <param name="_arr"></param>
		/// <returns></returns>
		public static int GetMax(int[] _arr) {
			if (_arr == null || _arr.Length == 0) {
				return Int32.MinValue;
			}
			return GetMax(_arr, 0, _arr.Length - 1);
		}
	}
}
// 【重点】Master公式
// 【要素】子问题规模要一致。eg：可以是T(2N/3)&T(2N/3)，但不可以是T(N/3)&T(2N/3)
// 【公式】T(N) = a * T(N/b) + O(N^d)
// 【判断条件】C = log(b, a); D = d
// ①C>D => 复杂度为O(N^log(b,a));
// ②C=D => 复杂度为O(N^d * logN);
// ③C<D => 复杂度为O(N^d)
// 【判断条件】
