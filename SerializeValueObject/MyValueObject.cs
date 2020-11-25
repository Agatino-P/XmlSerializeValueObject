
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializeValueObject
{
    public class MyValueObject : ValueObject
    {
        public MyValueObject(int id, string testo)
        {
            Id = id;
            this.Testo = testo;
        }

        public int Id{ get; private set; }

        public string Testo{ get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Testo;
        }

    }
}
