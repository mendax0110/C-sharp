using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftRegister
{
    public class SN74HC595N
    {
        private bool[] _register;
        private int _numBits;

        public SN74HC595N(int numBits)
        {
            _numBits = numBits;
            _register = new bool[numBits];
        }

        public void ShiftLeft(bool inputBit)
        {
            for (int i = _numBits - 1; i > 0; i--)
            {
                _register[i] = _register[i - 1];
            }
            _register[0] = inputBit;
        }

        public void ShiftRight(bool inputBit)
        {
            for (int i = 0; i < _numBits - 1; i++)
            {
                _register[i] = _register[i + 1];
            }
            _register[_numBits - 1] = inputBit;
        }

        public bool[] GetRegister()
        {
            return _register;
        }
    }
}
