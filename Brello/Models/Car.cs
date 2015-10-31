using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brello.Models
{
    public interface ICar
    {
        string Honk();
    }

    public class Car
    {
        // In order for Mock to change behavior, Method must be virtual.
        public virtual string Horn()
        {
            ReadyEngines();
            return "HONK!";
        }

        // Even when counting methods calls, Methods must be virtual.
        public virtual void ReadyEngines() { }
    }
}