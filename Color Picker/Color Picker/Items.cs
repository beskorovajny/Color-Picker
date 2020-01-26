using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Color_Picker
{
    [Serializable]
    [XmlRoot(ElementName ="Colors")]
    public class Items
    {
        [XmlAttribute(AttributeName ="Color")]
        public Color color { get; set; }
        [XmlIgnore]
        public SolidColorBrush SampleBrush
        {
            get { return new SolidColorBrush(color); }
        }
       [XmlIgnore]
        public string HexValue
        {
            get { return color.ToString(); }
        }
       
        //public Items(Color color)
        //{
        //    this.color = color;
        //}
    }
}
