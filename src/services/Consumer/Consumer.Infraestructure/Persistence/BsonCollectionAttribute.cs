using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Infraestructure.Persistence
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute : Attribute
    {
        public string CollectioName { get;}

        public BsonCollectionAttribute(string collectioName)
        {
            CollectioName = collectioName;
        }
    }
}
