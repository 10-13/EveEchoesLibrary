using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EveEchoes.Basic;

namespace EveEchoes.Mechanics.Stats
{
    public interface IStat : INamed, ISubTyped, ICloneable
    {
        public object Value { get; set; }
        public float Numeric { get; set; }
        public bool IsNumeric { get; }

        public StatSumMode SumMode { get; set; }

        public void AddStat(IStat stat);
    }

    public enum StatSumMode
    {
        NumericSum,
        NumericRem,
        NumericMlt,
        NumericDev,
        NumericOverrideIfNull,

        Override,
        OverrideIfNull,
        OverrideIfNum,
        
    }
}
