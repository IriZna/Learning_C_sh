using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorCustom_Lib.CustomAttributes
{
    public class NegativeAttribute:ValidationAttribute
    {
        public NegativeAttribute()
        {
            ErrorMessage = "The number must be <0 ";
        }

        public override bool IsValid(object value)
        {
            return value switch
            {
                int i => i < 0,
                long l => l < 0,
                double d => d < 0,
                decimal dec => dec < 0,
                float f => f < 0,
                short s => s < 0,
                byte b => b < 0,
                sbyte sb => sb < 0,
                ushort us => us < 0,
                uint ui => ui < 0,
                ulong ul => ul < 0,

                _ => false
            };
        }
    }
}
