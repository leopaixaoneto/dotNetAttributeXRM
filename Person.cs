namespace AttributeTesting
{
    public class Person
    {
        [XrmProperty(propertyName = "full_name")]
        public string FullName {get;set;} = String.Empty;

        [XrmProperty(propertyName = "age")]
        public int Age {get;set;}

        [XrmProperty]
        public IdentificationDocument Document {get;set;}
    }
}