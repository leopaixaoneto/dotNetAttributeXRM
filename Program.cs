using System.Reflection.Metadata;
using System;
using System.Reflection;

namespace AttributeTesting{
    class Program{
        static void Main(string[] args){
            var payload = new Payload();

            payload.owner = new Person{
                Age = 25,
                FullName = "Roberto Vasconcélos",
                Document = new IdentificationDocument{
                    number = "39428287822",
                    type = "cpf"
                }
            };

            payload.subOwner = new Person{
                Age = 30,
                FullName = "José Pereira",
                Document = new IdentificationDocument{
                    number = "15288046867",
                    type = "cpf"
                }
            };

            payload.ToEntity();
        }
    }
}