using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_41
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = true;
            List<Sick> sicks = new List<Sick>();
            AddSicks(sicks);

            while (isExit)
            {
                Console.WriteLine("Выберите нужный пункт меню :\n\n1 - Отсортировать всех больных по фио\n\n2 - Отсортировать всех больных по возрасту\n\n3 - Вывести больных с определенным заболеванием\n\n4 - выйти\n\n");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        var filteredSicksForFullName = sicks.OrderBy(sick => sick.FullName);

                        foreach (var sick in filteredSicksForFullName)
                        {
                            sick.ShowInfo();
                        }
                        break;
                    case 2:
                        var filteredSicksForAge = sicks.OrderBy(sick => sick.Age);

                        foreach (var sick in filteredSicksForAge)
                        {
                            sick.ShowInfo();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Введите заболевание : ");
                        string disease = Console.ReadLine();

                        var filteredSicksForDisease = from Sick sick in sicks where sick.Disease == disease select sick;

                        foreach (var sick in filteredSicksForDisease)
                        {
                            sick.ShowInfo();
                        }
                        break;
                    case 4:
                        isExit = false;
                        break;
                }
                Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
            
        }

        private static void AddSicks(List<Sick> sicks)
        {
            sicks.Add(new Sick("Кузнецова Надежда", 25, "Пневмания"));
            sicks.Add(new Sick("Козлова Беатрис", 34, "Герпес"));
            sicks.Add(new Sick("Антонов Павел", 40, "Омфалит"));
            sicks.Add(new Sick("Петров Петр", 18, "Панникулит"));
            sicks.Add(new Sick("Нигреев Юрий", 28, "Дромомания"));
            sicks.Add(new Sick("Антонов Сергей", 49, "Кокцидиоз"));
            sicks.Add(new Sick("Козлов Казимир", 22, "Габронемоз"));
            sicks.Add(new Sick("Егоров Захар", 17, "Бартолинит"));
            sicks.Add(new Sick("Антонов Ефим", 35, "Нанофиетоз"));
            sicks.Add(new Sick("Иванова Агнесса", 38, "Ахолия"));
        }
    }
    class Sick
    {
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }
        public Sick(string fullName, int age, string disease)
        {
            FullName = fullName;
            Age = age;
            Disease = disease;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Полное имя - {FullName}, Возраст - {Age}, Заболевание - {Disease}");
        }
    }
}
