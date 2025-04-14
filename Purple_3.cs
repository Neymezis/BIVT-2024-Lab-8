using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_3: Purple
    {
        private string _output;
        public string Output => _output;
        public (string, char) [] _codes;
        public (string, char)[] Codes
        {
            get
            {
                if (_codes == null) return null;
                (string, char)[] codes = new(string, char)[_codes.Length];
                Array.Copy(_codes, codes, _codes.Length);
                return codes;
            }
            

            
        }
        public Purple_3(string input): base(input) 
        {
            _codes = new (string, char)[5];
        }
        public override void Review()
        {
            if (_codes == null || Input == null) return;
            string[] f =new string[0];
            for(int i=0;i<Input.Length-1;i++)
            {
                if (Input[i] == ' ' || Input[i + 1] == ' ') continue;
                Array.Resize(ref f, f.Length+1);
                f[f.Length - 1] = $"{Input[i]}{Input[i + 1]}";
            }
            string[] one = new string[f.Length];
            one[0] = f[0];

            for (int i = 1, m = 1; i < f.Length; i++)
            {

                for (int j = 0; j < m; j++)
                {

                    if (f[i] == one[j])
                    {
                        Array.Resize(ref one, one.Length - 1);
                        j = m;
                    }
                    else if (j == m - 1)
                    {
                        one[m] = f[i];
                        m++;
                        break;
                    }

                }
            }
            int[] mas = new int[one.Length];
            for (int i = 0; i < one.Length; i++)
            {
                mas[i] = f.Count(x => x == one[i]);
            }

            for (int i = 1; i < mas.Length;)
            {
                if (i == 0 || mas[i] <= mas[i - 1])
                {
                    i++;
                }
                else
                {
                    int temp1 = mas[i];
                    mas[i] = mas[i - 1];
                    mas[i - 1] = temp1;
                    string temp = one[i];
                    one[i] = one[i - 1];
                    one[i - 1] = temp;
                    i--;
                }
            }

            Array.Resize(ref one, 5);
            int k = 0;
            char[] sin1= new char[5];
            for(int i=32; i<127; i++)
            {
                if (k == 5)
                {
                    break;
                }
                else
                {
                    char sin = (char)i;
                    if (Input.Contains(sin)) continue;
                    _codes[k] = (one[k], sin);
                    sin1[k] = sin;
                    k++;
                }
            }
            foreach((string, char) x in _codes) Console.WriteLine(x);
            string new1 = Input.Replace($"{one[0]}", $"{sin1[0]}");
            for(int i=1;i < 5; i++)
            {
                new1 = new1.Replace($"{one[i]}", $"{sin1[i]}");
            }
            _output= new1;
            
        }
        public override string ToString()
        {
            return _output;
        }
    }
}
