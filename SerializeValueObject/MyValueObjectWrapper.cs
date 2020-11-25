using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializeValueObject
{
    public class MyValueObjectWrapper
    {
        public int Id { get; set; }
        public string Testo { get; set; }

        public MyValueObjectWrapper()
        {

        }
        public static implicit operator MyValueObject(MyValueObjectWrapper myVoWrapper)
        {
            return new MyValueObject(myVoWrapper.Id, myVoWrapper.Testo);
        }
        public static implicit operator MyValueObjectWrapper(MyValueObject  myValueObject)
        {
            return new MyValueObjectWrapper() { Id = myValueObject.Id, Testo = myValueObject.Testo };
        }

    }
}
