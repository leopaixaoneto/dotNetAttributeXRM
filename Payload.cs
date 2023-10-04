using AttributeTesting.XrmCore;

namespace AttributeTesting
{
    public class Payload : XrmBaseEntity
    {
        public Payload():base("oy8", false, false){}

        [XrmProperty]
        public Person owner {get; set;}

        [XrmProperty]
        public Person subOwner {get; set;}
    }
}