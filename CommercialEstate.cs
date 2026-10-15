using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pisPractice2_14._10
{
    internal class CommercialEstate: Estate
    {
        public string Name_ofCE;
        public double Square_ofCE;

        public CommercialEstate(string owner, DateTime date, int price, string name_ofCE, double square_ofCE) : base(owner, date, price)
        {
            Name_ofCE = name_ofCE;
            Square_ofCE = square_ofCE;
        }

        public override void Print_String() 
        {
            Console.WriteLine("Создан объект недвижимости: коммерческая недвижимость");
            CommonPrint_String();
            Console.WriteLine($"Название: {Name_ofCE}");
            Console.WriteLine($"Площадь: {Square_ofCE}");
        }
    }
}
