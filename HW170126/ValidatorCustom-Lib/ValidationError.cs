using System;
using System.Collections.Generic;
using System.Text;

namespace ValidatorCustom_Lib
{
    public class ValidationError
    {
        
        public string MemberName { get; set; }
        public string ErrorMesssage { get; set; }

        public override string ToString()
        {
            return $"{nameof(MemberName)}: {MemberName}, {nameof(ErrorMesssage)}: {ErrorMesssage}";
        }

    }
}
