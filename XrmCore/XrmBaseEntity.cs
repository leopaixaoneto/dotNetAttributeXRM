using System.Reflection;

namespace AttributeTesting.XrmCore
{
    public class XrmBaseEntity
    {
        //property to set the start prefix of the final names
        private string _PrefixText {get; set;}

        //property to set if will force lower case in the final names
        private bool _bForceLowerCase {get; set;}
        
        //property to set if will force snake_case in the final names
        private bool _bUseSnakeCase {get; set;}

        public XrmBaseEntity(string prefixText = "", bool bForceLowerCase = true, bool bUseSnakeCase = true){
            _PrefixText = prefixText;
            _bForceLowerCase = bForceLowerCase;
            _bUseSnakeCase = bUseSnakeCase;
        }


        //Inherited method for transformation into Entity
        public void ToEntity(){
            mapProperties(this);
        }

        //Map with inherance the prop's of start object and carry the prefix name
        private void mapProperties(object obj, string prefix = ""){
            var obj_type = obj.GetType();

            prefix = (prefix == "") ? obj_type.Name.ToLower() : prefix;

            var properties =
                from p in obj_type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                where p.GetCustomAttributes(false).Any(a => propertyAttributeCheck(a))
                select p;

            foreach(PropertyInfo prop in properties){
                if(isPrimitive(prop.PropertyType)){
                    string text = prefix+$"_{prop.Name}";

                    text = _bUseSnakeCase ? CamelCaseToSnakeCase(text) : text;
                    text = _bForceLowerCase ? text.ToLower() : text;

                    Console.WriteLine(text);
                }else{
                    mapProperties(obj_type.GetProperty(prop.Name).GetValue(obj, null), prefix+$"_{prop.Name}");
                }
            }
        }

        //Check if the searched Type is primitive (to know when enter a object to search for new props)
        private bool isPrimitive(Type t){
            return t.IsPrimitive || t == typeof(Decimal) || t == typeof(String);
        }

        //Base checks for prop - Check if has Attribute 
        private bool propertyAttributeCheck(Object obj){
            return obj is XrmPropertyAttribute;
        }

        //Base function to transform CamelCase name into snake_case name
        private string CamelCaseToSnakeCase(string str){
            return string.Concat(
                         str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())
                     ).Replace("__", "_");
        }
    }
}