using System;
using System.Collections.Generic;

namespace ApiTest.Core.Helpers
{
    public class GpaComparer : IComparer<float>
    {
        public int Compare(float x, float y)
        {
            if (Math.Abs(x - y) < float.Epsilon)
            {
                return 0;
            }

            return y - x > 0 ? 1 : -1;
        }
    }
}
