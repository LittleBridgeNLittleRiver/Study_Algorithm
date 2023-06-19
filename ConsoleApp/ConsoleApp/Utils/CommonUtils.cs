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
			int mid = _L + ((_R - _L) >> 2);
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
