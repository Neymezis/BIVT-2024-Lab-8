using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1: Purple
    {
        private string _output;
        public string Output => _output;
        private char[] point = { '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
        private char[] digit = { '0', '1','2','3','4','5','6','7','8','9'};
        public Purple_1(string input) : base(input)
        {

        }
        public override void Review()
        {
            if(String.IsNullOrEmpty(Input))
            {
                _output=Input;
                return;
            }
            
            string[] sum = Input.Split().ToArray();
            for (int j = 0; j < sum.Length; j++)
            {
                char[] y = new char[sum[j].Length];
                int k1 = 0;
                int k2 = 0;
                for(int i=0; i < sum[j].Length; i++)
                {
                    if (point.Contains(sum[j][i]) || digit.Contains(sum[j][i])) continue;
                    else
                    {                      
                        k1 = i;
                        break;
                    } 
                }
                for (int i = sum[j].Length - 1; i >= 0; i--)
                {
                    if (point.Contains(sum[j][i]) || digit.Contains(sum[j][i])) continue;
                    else
                    {
                        k2 = i;
                        break;
                    }
                }
                int k = 0;
                for (int i = k1; i < k2+1; i++)
                {

                    y[i] = sum[j][k2-k];
                    k++;
                }
                for(int i=0;i<k1; i++)
                {
                    y[i] = sum[j][i];
                }
                for (int i = k2+1; i < sum[j].Length; i++)
                {
                    y[i] = sum[j][i];
                }
                sum[j] = new String(y);
            }
            _output = String.Join(" ", sum);
        }
        public override string ToString()
        {
            return Output;
        }
    }
}
