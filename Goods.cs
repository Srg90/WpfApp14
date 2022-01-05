using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Markup;

namespace WpfApp14
{
    public enum GoodsTypes
    {
        [Description("Продукты питания")]
        Food,
        [Description("Бытовая техника")]
        Appliances,
       
    }
    public class Goods
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public GoodsTypes Category { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
 
    public class EnumToItemsSource : MarkupExtension
    {
        private readonly Type _type;

        public EnumToItemsSource(Type type)
        {
            _type = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _type.GetMembers().SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>()).Select(x => x.Description).ToList();
        }
    }
}
