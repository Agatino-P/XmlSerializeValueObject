using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SerializeValueObject
{
    public class MyEntity
    {
        public DateTime CreationDT { get; set; }
        [XmlIgnore]
        public MyValueObject MyValueObject { get; set; }

        [XmlElement(ElementName = "MyValueObject")]
        public MyValueObjectWrapper MyValueObjectWrapper
            {
            get => MyValueObject;
            set => MyValueObject = value;
            }
        public MyEntity()
        {

        }
        public MyEntity(MyValueObject myValueObject)
        {
            CreationDT = DateTime.Now;
            MyValueObject = myValueObject;
        }
    }
}
