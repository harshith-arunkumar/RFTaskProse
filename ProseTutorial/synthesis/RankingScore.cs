using System;
using System.Text.RegularExpressions;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.Features;

namespace ProseTutorial
{
    public class RankingScore : Feature<int>
    {
        public RankingScore(Grammar grammar) : base(grammar, "Score")
        {
        }

        [FeatureCalculator(nameof(Semantics.Add))]
        public static int Add(int arr, int ele_1, int ele_2)
        {
            //return ele_1 + ele_2;
            return 1;
        }
        [FeatureCalculator(nameof(Semantics.Mul))]
        public static int Mul(int arr, int ele_1, int ele_2)
        {
            //return ele_1 * ele_2;
            return 1;
        }
        [FeatureCalculator(nameof(Semantics.Div))]
        public static int Div(int arr, int ele_1, int ele_2)
        {
            /*if (ele_2 != 0)
                return ele_1 / ele_2;
            else
                return ele_1;*/
            return 1;
        }

        [FeatureCalculator(nameof(Semantics.Element))]
        public static int Element(int arr, int index)
        {
            //return index;
            return 1;
        }

        [FeatureCalculator("index", Method = CalculationMethod.FromLiteral)]
        public static int index(int index)
        {
            return 1;
        }        
    }
}