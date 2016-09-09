using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hybrid_Encryption_with_Added_Integrity
{
    class CompareArrays
    {
        public static bool CompareUnSecure(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }
            for (int i = 0; i < array1.Length; ++i)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Compare(byte[] array1, byte[] array2)
        {
            var result = array1.Length == array2.Length;
            for (var i = 0; i < array1.Length && i < array2.Length; ++i)
            {
                result &= array1[i] == array2[i];
            }
            return result;
        }
    }
}
