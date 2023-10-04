using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttributeTesting
{
    public class IdentificationDocument
    {

        [XrmProperty]        
        public string number {get;set;}

        [XrmProperty]
        public string type {get;set;}
    }
}