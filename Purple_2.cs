using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2: Purple
    {
        private string [] _output;
        public string [] Output
        {
            get
            {
                if (_output == null) return null;
               string[] output =new string[_output.Length];
                Array.Copy(_output, output, _output.Length);
                return output;
            }
        }
        private char[] point = { '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
        public Purple_2(string input) : base(input)
        {
            _output=new string[0];
        }
        public override void Review()
        {
            if (String.IsNullOrEmpty(Input))
            {
                return;
            }
            string[] sum = Input.Split().ToArray();
            string[] answer = {""};

            for(int i=0,j=0; i<sum.Length; i++)
            {
                if (answer[j].Length + sum[i].Length+1 > 50)
                {
                    j++;
                    Array.Resize(ref answer, answer.Length + 1);
                    answer[j] = "";
                    i--;
                }
                else
                {
                    if (answer[j].Length==0)
                    {
                        string temp1 = $"{answer[j]}{sum[i]}";
                        answer[j] = temp1;
                    }
                    else
                    {
                        string temp = $"{answer[j]} {sum[i]}";
                        answer[j] = temp;
                    }
                   
                }
            }
            for (int i = 0; i < answer.Length; i++)
            {
                int k = 0;
                int l = 2;
                if (answer[i].IndexOf(" ", k) == -1) continue;
                while (answer[i].Length < 50)
                {
                    if(answer[i].IndexOf(" ", k) == -1)
                    {
                        l++;
                        k = 0;
                    }
                    int index = answer[i].IndexOf(" ",k);
                    k = index + l;
                    string temp = $"{answer[i].Substring(0, index+1)} {answer[i].Substring(index + 1)}";
                    answer[i] = temp;
                }
            }
            _output = new string[answer.Length];
            Array.Copy(answer,_output, answer.Length);
        }
        public override string ToString()
        {
            if (Output == null) return null;
            return String.Join("\n", Output);
        }
    }
}
