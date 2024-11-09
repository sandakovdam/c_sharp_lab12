using c_sharp_lab12;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
class Program
{
    static void Main(string[] args)
    {
        void InterfaceLab()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Добавление организации");
            Console.WriteLine("2 - Вывод из XML");
            Console.WriteLine("3 - Поиск организации по названию");
            Console.WriteLine("4 - Удаление огранизации");
            Console.WriteLine("5 - Выход");
            Console.WriteLine("Введите код операции:");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Console.WriteLine("-=Добавление организации=-");
                    Console.WriteLine("Имя организации:");
                    string name = Console.ReadLine();
                    Console.WriteLine("ИНН организации:");
                    string inn = Console.ReadLine();
                    Console.WriteLine("Email организации:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Телефон приемной:");
                    string receptionPhone = Console.ReadLine();
                    Console.WriteLine("Телефон отдела кадров:");
                    string hrPhone = Console.ReadLine();
                    Console.WriteLine("Телефон бухгалтерии:");
                    string accountingPhone = Console.ReadLine();
                    PhoneDirectory ADDPD = PhoneDirectory.LoadFromXml("phoneDirectory.xml");
                    ADDPD.Add(new Organization(name, inn, email, receptionPhone, hrPhone, accountingPhone));
                    ADDPD.PrintAll();
                    ADDPD.SaveToXml("phoneDirectory.xml");

                    InterfaceLab();
                    break;
                case 2:
                    Console.WriteLine("-=Вывод из XML=-");
                    PhoneDirectory LPD = PhoneDirectory.LoadFromXml("phoneDirectory.xml");
                    LPD.PrintAll();

                    InterfaceLab();
                    break;
                case 3:
                    Console.WriteLine("-=Поиск организации по названию=-");
                    PhoneDirectory FLPD = PhoneDirectory.LoadFromXml("phoneDirectory.xml");
                    Console.WriteLine("Введите имя организации:");
                    string fnpd = Console.ReadLine();
                    Organization FPD = FLPD.FindOrganizationByName(fnpd);
                    if (FPD != null)
                    {
                        Console.WriteLine("Найдено: " + FPD);
                    } else { Console.WriteLine("Организация не найдена."); }

                    InterfaceLab();
                    break;
                case 4:
                    Console.WriteLine("-=Удаление огранизации=-");
                    PhoneDirectory DPD = PhoneDirectory.LoadFromXml("phoneDirectory.xml");
                    Console.WriteLine("Введите имя организации:");
                    string dnpd = Console.ReadLine();
                    if (DPD.FindOrganizationByName(dnpd) != null)
                    {
                        DPD.Delete(dnpd);
                        Console.WriteLine("Организация удалена.");
                        DPD.PrintAll();
                    } else { Console.WriteLine("Организация не найдена. Удаление невозможно."); }

                    InterfaceLab();
                    break;
                case 5:
                    break;
            }
        }
        InterfaceLab();
    }
}