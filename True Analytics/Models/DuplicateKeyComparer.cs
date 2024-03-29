﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace True_Analytics.Models
{
    public class DuplicateKeyComparer<TKey>:IComparer<TKey> where TKey : IComparable
    {
        #region IComparer<TKey> Members

        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);

            if (result == 0)
                return 1;   // Handle equality as beeing greater
            else
                return result*-1;
        }

        #endregion
    }
}