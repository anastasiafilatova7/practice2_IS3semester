using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pisPractice2_14._10
{
    class Apartment: Estate
    {
        public double Square;
        public int Count_ofRoom;

        public Apartment(string owner, DateTime date, int price, double square, int Count_ofRoom):base(owner, date, price)
        {
            Square = square;
            this.Count_ofRoom = Count_ofRoom;
        }

        public override void Print_String() //override- чтобы мы его могли изменить в apartment, сохравнив ,базовую структуры из др класса
        {
            Console.WriteLine("Создан объект недвижимости: квартира");
            CommonPrint_String();
            Console.WriteLine($"Площадь квартиры: {Square}");
            Console.WriteLine($"Количество комнат в квартире: {Count_ofRoom}");
        }
    }
}
