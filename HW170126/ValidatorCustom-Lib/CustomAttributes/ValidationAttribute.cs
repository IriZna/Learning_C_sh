namespace ValidatorCustom_Lib.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public abstract class ValidationAttribute : Attribute
    {
        public string ErrorMessage { get; protected set; } = "Validation failed";
        public virtual bool IsValid(object value) { return true; }
        public virtual bool IsValid(object value, object instance) => IsValid(value);
        

    }
}
