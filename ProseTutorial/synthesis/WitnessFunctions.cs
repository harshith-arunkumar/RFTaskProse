using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.Learning;
using Microsoft.ProgramSynthesis.Rules;
using Microsoft.ProgramSynthesis.Specifications;

namespace ProseTutorial
{
    public class WitnessFunctions : DomainLearningLogic
    {
        public WitnessFunctions(Grammar grammar) : base(grammar)
        {
        }
        
            

        [WitnessFunction(nameof(Semantics.Add), 1)]
        public DisjunctiveExamplesSpec WitnessFirstElement(GrammarRule rule, ExampleSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();

            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                var input = (int[] )inputState[rule.Body[0]];
                var output = (int)example.Value;
                if (output <= 1)
                    continue;
                var occurences = new List<int>();
                int i = 0;
                while (i < input.Length)
                {
                    if(input[i] >= output)
                    {
                        i += 1;
                        continue;
                    }
                    occurences.Add(input[i]);
                    i += 1;
                }
                result[inputState] = occurences.Cast<object>();
            }
            return new DisjunctiveExamplesSpec(result);
        }

        [WitnessFunction(nameof(Semantics.Add), 2, DependsOnParameters = new[] { 1 })]
        public ExampleSpec WitnessSecondElement(GrammarRule rule, ExampleSpec spec, ExampleSpec firstSpec)
        {
            var result = new Dictionary<State, object>();
            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                var input = (int[])inputState[rule.Body[0]];
                var output = (int)example.Value;
                var ele_1 = (int)firstSpec.Examples[inputState];

                int ele_2 = output - ele_1;
                
                if (output <= ele_1)
                {
                    continue;
                }

                if (ele_2 <= 0 || output == 1 || ele_1 == output)
                {
                    continue;
                }
                
                result[inputState] = ele_2;
            }
            return new ExampleSpec(result);
        }
        

        [WitnessFunction(nameof(Semantics.Mul), 1)]
        public DisjunctiveExamplesSpec WitnessFirstElementM(GrammarRule rule, ExampleSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();

            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                var input = (int[])inputState[rule.Body[0]];
                var output = (int)example.Value;
                if (output <= 1)
                    continue;
                var occurences = new List<int>();
                int i = 0;
                while (i < input.Length)
                {
                    if(input[i] >= output || input[i] == 1)
                    {
                        i += 1;
                        continue;
                    }
                    occurences.Add(input[i]);
                    i += 1;
                }
                result[inputState] = occurences.Cast<object>();
            }
            return new DisjunctiveExamplesSpec(result);
        }

        [WitnessFunction(nameof(Semantics.Mul), 2, DependsOnParameters = new[] { 1 })]
        public ExampleSpec WitnessSecondElementM(GrammarRule rule, ExampleSpec spec, ExampleSpec firstSpec)
        {
            var result = new Dictionary<State, object>();
            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                var input = (int[])inputState[rule.Body[0]];
                var output = (int)example.Value;
                var ele_1 = (int)firstSpec.Examples[inputState];

                int ele_2_int = output / ele_1;
                double ele_2_double = (double)output / ele_1;
                if (((double)ele_2_int) != ele_2_double) continue;
                int ele_2 = ele_2_int;
                
                if (output <= ele_1)
                {
                    continue;
                }

                if (ele_1 == 1 || ele_2 == 1)
                {
                    continue;
                }
                

                result[inputState] = ele_2;
            }
            return new ExampleSpec(result);
        }






        [WitnessFunction(nameof(Semantics.Div), 1)]
        public DisjunctiveExamplesSpec WitnessFirstElementD(GrammarRule rule, ExampleSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();

            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                var input = (int[])inputState[rule.Body[0]];
                var output = (int)example.Value;
                if (output <= 1)
                    continue;
                var occurences = new List<int>();
                int i = 0;
                while (i < input.Length)
                {
                    if (output == 1 && input[i] == 1 || (input[i] <= output))
                    {
                        i += 1;
                        continue;
                    }
                    occurences.Add(input[i]);
                    i += 1;
                }
                result[inputState] = occurences.Cast<object>();
            }
            return new DisjunctiveExamplesSpec(result);
        }

        [WitnessFunction(nameof(Semantics.Div), 2, DependsOnParameters = new[] { 1 })]
        public ExampleSpec WitnessSecondElementD(GrammarRule rule, ExampleSpec spec, ExampleSpec firstSpec)
        {
            var result = new Dictionary<State, object>();
            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                var input = (int[])inputState[rule.Body[0]];
                var output = (int)example.Value;
                var ele_1 = (int)firstSpec.Examples[inputState];
                int ele_2_int = ele_1 / output;
                double ele_2_double = (double)ele_1 / output;
                if (((double)ele_2_int) != ele_2_double) continue;
                int ele_2 = ele_2_int;
                
                if (output == 1 && ele_1 != 1)
                {
                    result[inputState] = ele_1;
                    continue;
                }
                

                if (ele_1 == 1 || ele_2 == 1 ) continue;
                
                result[inputState] = ele_2;
            }
            return new ExampleSpec(result);
        }

        
        [WitnessFunction(nameof(Semantics.Element), 1)]
        public DisjunctiveExamplesSpec WitnessElement(GrammarRule rule, DisjunctiveExamplesSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();
            foreach (KeyValuePair<State, IEnumerable<object>> example in spec.DisjunctiveExamples)
            {
                State inputState = example.Key;
                int[] arr = (int[])inputState[rule.Body[0]];
                var positions = new List<int>();
                if (example.Value == null)
                    continue;

                foreach(int ele in example.Value)
                {
                    int i = 0;
                    while (i < arr.Length)
                    {
                        int index = Array.IndexOf(arr, ele, i);
                        if (index != -1)
                        {
                            positions.Add(index);
                            i = index + 1;
                        }
                        else
                            break;
                    }
                }
                if (positions.Count == 0) return null;
                result[inputState] = positions.Cast<object>();
            }
            return new DisjunctiveExamplesSpec(result);
        }
        
    }
}