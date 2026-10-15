using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pisPractice2_14._10
{
    class Estate
    {
        public string Owner;
        public DateTime Date;
        public int Price;

        public Estate(string owner, DateTime date, int price)
        {
            Owner = owner;
            Date = date;
            Price = price; //или через this, Owner, Date
        }

        //для красоты, для качества кода
        public virtual void Print_String() //virtual - чтобы мы его могли изменить в apartment(а так его можно использовать целостно в др классе)
        {
            Console.WriteLine("Создан объект недвижимости");
            CommonPrint_String();
        }

        protected void CommonPrint_String()
        {
            Console.WriteLine($"Владелец: {Owner}");
            Console.WriteLine($"Дата постановки на учет: {Date:yyyy.MM.dd}");
            Console.WriteLine($"Ориентировочная стоимость: {Price}");
        }
    }


    internal class Program
    {
        //делим введенную пользователем строку на разные объекты через ;
        static void Split_Str(string User_str_Start)
        {
            string[] matrix_str = User_str_Start.Split(';');
            for (int i = 0; i < matrix_str.Length; i++)
            {
                Parse_Split_Str(matrix_str[i].Trim());
            }

        }

        //метод, чтобы понять, что мы сейчас разбиваем на строчки: недвиж, или коммерч, или квартира 
        static void Parse_Split_Str(string User_str_Start)
        {
            if (User_str_Start.StartsWith("Недвижимость: "))
            {
                Regex_Estate_Parse_Split_Str(User_str_Start);
            }
            else if (User_str_Start.StartsWith("Квартира: "))
            {
                Regex_Apartment_Parse_Split_Str(User_str_Start);
            }
            else if (User_str_Start.StartsWith("Коммерческое помещение: "))
            {
                Regex_CE_Parse_Split_Str(User_str_Start);
            }
            else
            {
                Console.WriteLine("Проверьте введенные данные");
            }
        }

        static void Regex_Estate_Parse_Split_Str(string User_str_Start)
        {
            string str_regex = @"^Недвижимость\:\s+""([А-Яа-я. ]+)""\s+(\d{4}\.\d{2}\.\d{2})\s+(\d+)$";
            Match regex = match_mistakeFromUser(User_str_Start, str_regex);

            //чтобы сказать пользователю, что он неверно ввел строку
            string owner_Program = regex.Groups[1].Value; //0-вся строка, а 1,2,3 - подходящее
            DateTime date_Program = Date_Regex_Estate_Parse_Split_Str(regex.Groups[2].Value); //без времени
            
            int price_Program = Convert.ToInt32(regex.Groups[3].Value);
            Estate estate = new Estate(owner_Program, date_Program, price_Program);
            estate.Print_String();
        }

        static void Regex_Apartment_Parse_Split_Str(string User_str_Start)
        {
            string str_regex = @"^Квартира:\s+""([А-Яа-я. ]+)""\s+(\d{4}\.\d{2}\.\d{2})\s+(\d+)\s+(\d+,\d+)\s+(\d+)$";
            Match regex = match_mistakeFromUser(User_str_Start, str_regex);

            //чтобы сказать пользователю, что он неверно ввел строку
            string owner_Program = regex.Groups[1].Value; //0-вся строка, а 1,2,3 - подходящее
            DateTime date_Program = Date_Regex_Estate_Parse_Split_Str(regex.Groups[2].Value); //без времени

            int price_Program = Convert.ToInt32(regex.Groups[3].Value);
            double square = Convert.ToDouble(regex.Groups[4].Value);
            int count_A = Convert.ToInt32(regex.Groups[5].Value);
            Apartment apartment = new Apartment(owner_Program, date_Program, price_Program, square, count_A);
            apartment.Print_String();
        }

        static void Regex_CE_Parse_Split_Str(string User_str_Start)
        {
            string str_regex = @"^Коммерческая недвижимость:\s+""([А-Яа-я. ]+)""\s+(\d{4}\.\d{2}\.\d{2})\s+(\d+)\s+""([А-Яа-я ]+)""\s+(\d+,\d+)$";
            Match regex = match_mistakeFromUser(User_str_Start, str_regex);

            //чтобы сказать пользователю, что он неверно ввел строку
            string owner_Program = regex.Groups[1].Value; //0-вся строка, а 1,2,3 - подходящее
            DateTime date_Program = Date_Regex_Estate_Parse_Split_Str(regex.Groups[2].Value); //без времени

            int price_Program = Convert.ToInt32(regex.Groups[3].Value);
            string name_ce = regex.Groups[4].Value;
            double square = Convert.ToDouble(regex.Groups[5].Value);
            CommercialEstate commercialEstate = new CommercialEstate(owner_Program, date_Program, price_Program, name_ce, square);
            commercialEstate.Print_String();
        }
        static DateTime Date_Regex_Estate_Parse_Split_Str(string date_Regex)
        {
            return DateTime.ParseExact(date_Regex, "yyyy.MM.dd", null);
        }

        //обрабатывает ошибки пользователя match
        static Match match_mistakeFromUser(string User_str_Start, string str_regex)
        {
            Match regex = Regex.Match(User_str_Start, str_regex);
            if (!regex.Success)
            {
                Console.WriteLine("Ваша строка была введена неверно. Введите еще раз, пожалуйста");
            }
            return regex;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку, содержащую: Недвижимость: владелец (строка), дата постановки на учет, \nориентировочная стоимость (целое число).");
            Console.WriteLine("Ведите строку по примеру: Недвижимость: \"Громов С.А.\" 2008.09.08 4000\n");
            Console.WriteLine("ИЛИ\n");
            Console.WriteLine("Введите строку, содержащую: Квартира: владелец (строка), дата постановки на учет,\nориентировочная стоимость (целое число), площадь (дробное число), число комнат (целое число). ");
            Console.WriteLine("Ведите строку по примеру: Квартира: \"Громов С.А.\" 2008.09.08 4000 56,5 2\n");
            Console.WriteLine("ИЛИ\n");
            Console.WriteLine("Введите строку, содержащую: Коммерческая недвижимость: владелец (строка), дата постановки на учет, \nориентировочная стоимость (целое число), название (строка), площадь (дробное число)");
            Console.WriteLine("Ведите строку по примеру: Коммерческая недвижимость: \"Громов С.А.\" 2008.09.08 4000 Торговый центр 250,6");
            //тру кэч  чтобы бесконечно пользователь мог вводить вариантов строки
            while (true)
            {
                try
                {
                    string User_str_Start = Console.ReadLine();
                    Split_Str(User_str_Start);
                    break;
                }
                catch
                {
                    Console.WriteLine("Строка введена неверно, не как в примере");
                    continue;
                }
            }
        }
    }
}
