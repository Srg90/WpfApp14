using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WpfApp14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Goods> goods;

        public MainWindow()
        {
            InitializeComponent();

            goods = new ObservableCollection<Goods>();
         
            goods.Add(new Goods()
            {
                Name = "Товар 1",
                Price = 100,
                Category = GoodsTypes.Food
        });
            goods.Add(new Goods()
            {
                Name = "Товар 2",
                Price = 200,
                Category = GoodsTypes.Appliances
            });

            listType.ItemsSource = goods;
        }
        
        private GoodsTypes GetCategory()
        {
            string Category1 = categoryGoods.SelectedItem.ToString();
                        
                switch (Category1)
                {
                    case "Продукты питания":

                        return GoodsTypes.Food;



                    case "Бытовая техника":

                        return GoodsTypes.Appliances;

                    default:

                        return GoodsTypes.Food;

                }
        }

        private void GoodsNew(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nameGoods.Text != "" & priceGoods.Text != "")
                {
                    goods.Add(new Goods()
                    {
                        Name = nameGoods.Text,
                        Price = double.Parse(priceGoods.Text),
                        Category = GetCategory()

                    });
                }
                else
                {
                    MessageBox.Show("Введите корректные данные", "Ошибка!");
                }
            }
            catch 
            {
                
                MessageBox.Show("Введите корректные данные", "Ошибка!");
            }
        }
        private void GoodsRemove(object sender, RoutedEventArgs e)
        {
            goods.RemoveAt(goods.Count -1);
        }
    }
}
