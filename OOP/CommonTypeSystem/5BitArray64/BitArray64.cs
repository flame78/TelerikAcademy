using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5BitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong bitArray64;

        public BitArray64(ulong bitArray64)
        {
            this.bitArray64 = bitArray64;
        }

        public BitArray64(string bitArray64)
        {
            ulong result = 0;
            bitArray64 = bitArray64.PadLeft(64, '0');

            for (int i = 0; i < 64; i++)
            {
                result *= 2;
                result += ulong.Parse(bitArray64[i].ToString());

            }

            this.bitArray64 = result;
        }

        public int this[int index]
        {
            get
            {
                CheckIndex(index);
                return (int)((this.bitArray64 >> index) & 1);
            }
            set
            {
                CheckIndex(index);
                if (value ==1 ) this.bitArray64 |= (ulong)1 << index; 
                else if (value == 0) this.bitArray64 ^= (ulong) 1 << index;
                else throw new ApplicationException("Invalid value for Bit");
            }
        }

        private void CheckIndex(int index)
        {
            if (index<0 || index>63)
            throw new ApplicationException("Invalid index for Bit Array 64");
        }

      

        public override string ToString()
        {
            var result = new StringBuilder();
           
            for (int i = 0; i < 64; i++)
            {
               result.Insert(0,((this.bitArray64 >> i) & 1));
            }
            result.AppendLine();
            result.AppendLine(this.bitArray64.ToString());
            return result.ToString();
        }

        public override bool Equals(Object obj)
        {
            var input  = obj as BitArray64;
            if (Object.Equals(input, null)) return false;
            return this.bitArray64.Equals(input.bitArray64);
        }

        public static  bool operator ==(BitArray64 ba1, BitArray64 ba2)
        {
            if (ba1.bitArray64.Equals(ba2.bitArray64))
            return true;
            return false;
        }
        public static  bool operator !=(BitArray64 ba1, BitArray64 ba2)
        {
            return !(ba1 == ba2);
        }

        public override int GetHashCode()
        {
            return this.bitArray64.GetHashCode() ^ base.GetHashCode();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return (int)((this.bitArray64 >> i) & 1);
            }
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
