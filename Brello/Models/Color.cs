using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brello.Models
{
    public class Color : IComparable
    {
        public int ColorId { get; }
        public string Name { get; set; }
        public string Value { get; set; }

        public int CompareTo(object obj)
        {
            Color other_color = obj as Color;
            // Other way to cast is:
            // Color other_color = (Color)obj;
            return this.Name.CompareTo(other_color.Name);
            /*
            if (this.Name == other_color.Name) {
                return 0;
            }
            else if (this.Name < other_color.Name)
            {
                return -1;
            }
            // throw new NotImplementedException();
            */
        }

        public static bool operator ==(Color color1, object obj2)
        {
            return 0 == color1.CompareTo(obj2 as Color);
        }

        public static bool operator !=(Color color1, object obj2)
        {
            return 0 != color1.CompareTo(obj2 as Color); ;
        }

        public static bool operator >(Color color1, object obj2)
        {
            return 1 == color1.CompareTo(obj2 as Color);
        }

        public static bool operator <(Color color1, object obj2)
        {
            return -1 == color1.CompareTo(obj2 as Color);
        }
    }
}