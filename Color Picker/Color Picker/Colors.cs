using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Color_Picker
{
    [XmlRoot(ElementName ="ColorList")]
    public class Colors
    {
        [XmlElement(ElementName ="color")]
        public List<Items> Items { get; set; }
        public Colors()
        {
            Items = new List<Color_Picker.Items>();
        }
    }
}
