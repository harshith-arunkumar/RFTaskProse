using System;
using System.Text.RegularExpressions;

namespace ProseTutorial
{
    public static class Semantics
    {
        public static int? Add(int[] arr, int ele_1, int ele_2)
        {
            return ele_1 + ele_2;
        }
        public static int? Mul(int[] arr, int ele_1, int ele_2)
        {
            return ele_1 * ele_2;
        }
        public static int? Div(int[] arr, int ele_1, int ele_2)
        {
            return ele_1 / ele_2;
        }
        public static int? Element(int[] arr, int index)
        {
            return arr[index];               
        }
    }
}