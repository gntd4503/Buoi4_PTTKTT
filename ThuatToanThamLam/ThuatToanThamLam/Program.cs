using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuatToanThamLam
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>
        {
            new Item { Value = 60, Weight = 10 },
            new Item { Value = 100, Weight = 20 },
            new Item { Value = 120, Weight = 30 }
        };

            int capacity = 50;

            double maxValue = GreedyKnapsack(capacity, items);
            Console.WriteLine("Maximum value in Knapsack = " + maxValue);
            Console.ReadLine();

        }
        public class Item
        {
            public int Value { get; set; }
            public int Weight { get; set; }
            public double Ratio { get { return (double)Value / Weight; } }
        }
        public static double GreedyKnapsack(int capacity, List<Item> items)
        {
            // Sort items by value-to-weight ratio in descending order
            items.Sort((x, y) => y.Ratio.CompareTo(x.Ratio)); // sap xep theo ti le tren trong luong giam dan

            double totalValue = 0; //bien tong gia tri vat pham duoc chon cho balo
            int currentWeight = 0; // bien tong trong luong hien tai cua balo

            foreach (var item in items) //duyet tung vat pham da duoc sap xep 
            {
                //kiem tra neu co the them tat ca vat pham vao balo
                if (currentWeight + item.Weight <= capacity) // kiem tra trong luong hien tai (currentWeight) + trong luong vat pham (item.Weight) khong vuot qua suc chua cua balo (capacity)
                {
                    //Kiem tra neu dieu kien dung , them toan bo vat pham vao balo :
                    currentWeight += item.Weight; // cap nhat trong luong hien tai cua balo 
                    totalValue += item.Value; // cap nhat tong gia tri cua balo
                }
                // kiem tra neu khong them toan bo vat pham vao balo
                else // neu trong luong vat pham vuot qua suc chua cua balo
                {
                    int remainingWeight = capacity - currentWeight; // tinh toan trong luong toan bo ma balo co the chua : suc chua toi da cua balo (capacity) - trong luong hien tai (currentWeight)
                    //Them gia tri vat pham co the chua duoc vao balo
                    totalValue += item.Value * ((double)remainingWeight / item.Weight); // Tinh toan gtri tuong ung cua vat pham ma balo co the chua duoc :
                    // => item.value (gtri vat pham) * (double)remainingWeight (ti le trong luong con lai) / item.Weight (trong luong vat pham)
                    break;
                }
            }

            return totalValue;
        }



    }
}
