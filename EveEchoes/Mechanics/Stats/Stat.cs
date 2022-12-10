using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EveEchoes.Mechanics.Stats
{
    public class Stat : IStat
    {
        public object Value { get; set; } = 1;
        public string Name { get; set; } = string.Empty;
        public string SubType { get; set; } = string.Empty;
        public StatSumMode SumMode { get; set; } = StatSumMode.NumericMlt;

        [XmlIgnore]
        public float Numeric
        {
            get
            {
                if (Value == null && Value is float)
                    return (float)Value;
                return 0;
            }
            set
            {
                Value = value;
            }
        }
        [XmlIgnore]
        public bool IsNumeric 
        {
            get
            {
                return (Value != null && Value is float);
            }
        }

        public Stat() { }
        public Stat(string Name,string SubType = null)
        {
            this.Name = Name;
            this.SubType = SubType == null ? Name : SubType;
        }

        public void AddStat(IStat stat)
        {
            switch (stat.SumMode)
            {
                case StatSumMode.NumericSum:
                    this.Numeric += stat.Numeric;
                    break;
                case StatSumMode.NumericRem:
                    this.Numeric -= stat.Numeric;
                    break;
                case StatSumMode.NumericDev:
                    this.Numeric /= stat.Numeric;
                    break;
                case StatSumMode.NumericMlt:
                    this.Numeric *= stat.Numeric;
                    break;
                case StatSumMode.NumericOverrideIfNull:
                    if(Value == null)
                        this.Numeric = stat.Numeric;
                    break;
                case StatSumMode.OverrideIfNum:
                    if(this.IsNumeric)
                        this.Numeric = stat.Numeric;
                    break;
                case StatSumMode.Override:
                    this.Value = stat.Value;
                    break;
                case StatSumMode.OverrideIfNull:
                    if (Value == null)
                        this.Value = stat.Value;
                    break;
            }
        }

        public object Clone()
        {
            XmlSerializer f = new XmlSerializer(this.GetType());
            MemoryStream s = new MemoryStream();
            f.Serialize(s, this);
            s.Seek(0, SeekOrigin.Begin);
            return f.Deserialize(s);
        }
    }
}
