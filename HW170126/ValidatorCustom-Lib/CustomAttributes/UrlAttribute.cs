using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorCustom_Lib.CustomAttributes
{
    public class UrlAttribute:ValidationAttribute
    {
        public UrlAttribute()
        {
            ErrorMessage="The URL must be starting with https:// or http://).";
        }
        public override bool IsValid(object value)
        {
            if (value == null ) return true;
            
            string url = value as string?? value.ToString();

            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri)) return false;

            return uri.Scheme == "https" || uri.Scheme == "http";
            
        }
    }
}
