using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_4: Purple
    {
        private string _output;
        public string Output => _output;
        private (string, char)[] _codes;
        public Purple_4(string input, (string, char)[] codes) : base(input) 
        {
            if (codes == null) return;
            _codes = new (string, char)[codes.Length];
            Array.Copy(codes, _codes, codes.Length);
        }
        public override void Review()
        {
            if (_codes == null || Input == null) return;
            string new1 = Input;
            for (int i=0; i<_codes.Length; i++)
            {
               new1 = new1.Replace($"{_codes[i].Item2}", $"{_codes[i].Item1}");
            }
            _output = new1;
        }
        public override string ToString()
        {
            return _output;
        }

    }
}
