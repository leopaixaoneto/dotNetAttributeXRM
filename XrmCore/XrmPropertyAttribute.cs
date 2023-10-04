namespace AttributeTesting 
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XrmPropertyAttribute: Attribute
    {
        //property name if needs to be different from the prop name
        public string propertyName {get; set;}  = string.Empty;

        //preFix to add in the name if needed
        public string preFix {get; set;} = string.Empty;
        
        //Final XRM PropertyName, ignore all path name convention || Final name of this prop
        public string xrmPropertyFinalName {get; set;} = string.Empty;
    }
}