using System;
using System.Collections.Generic;
using System.Threading;
using Lab10Library;

namespace Laba11Next
{
    public class TestCollections
    {
        public Queue<Worker> WorkerList;
        public Queue<string> StringList;
        public SortedDictionary<Worker, Engineer> WorkerEngineerSorted = new SortedDictionary<Worker, Engineer>();
        public SortedDictionary<string, Engineer> StringEngineerSorted = new SortedDictionary<string, Engineer>();

        public TestCollections(int Size)
        {
            Random rnd = new Random();
            WorkerList = new Queue<Worker>(Size);
            StringList = new Queue<string>(Size);
            //WorkerEngineerSorted = new SortedDictionary<Worker, Engineer>();
            //StringEngineerSorted = new SortedDictionary<string, Engineer>();

            string[] Names = {"Дмитрий", "Роман", "Алексей", "Олег", "Евгений", "Александр", "Энакин", "Оби-Ван", "Мейс", "Шиив", "Стив", "Майк", "Борис", "Сергей", "Денис", "Илья", "Ильнар", "Василий","Алёша","Фёдор","Антон","Ярослав","Даниил","Доминик","Брайн","Дуэйн","Скала","Дарт","Тёмный","Граф","Генерал","Кайло"};

            string[] Families = {"Петров", "Иванов", "Сидоров", "Попов", "Джексон", "ДеСанта", "Кеноби", "Скайуокер", "Винду", "Палпатин", "Карелл", "Огурцов", "Орехов", "Смирнов", "Хлебников", "Мельников","Вейдер","Мол","Сидиус","Дуку","Гривус","Реван","Рен","Джонсон","Властелин"};

            string[] NWS = {"Advance", "SF", "LS", "LV", "SW", "Marvel", "Diamond", "Music", "TeamSoft", "Microsoft", "Щ", "12", "Trust", "Nalog", "Jedi", "Order", "Empire","Republic","CIS","Rebellion","Chernobyl","Moscow","Kiev","St.Petersburg","Perm","Khabarovsk","Vladivostok","NewYork","LosAngeles","LosSantos","SanFierro","LasVenturas","LasVegas","SanFrancisco","USA","FirstOrder","LastOrder"};

            string[] NF = {"Green", "Red", "Blue", "Lime", "PD", "Army", "Iron", "Radiant", "Emerald", "Jazz", "Trilliant", "XBox", "Pop","Аквариум","Бутсы","Я",",Не","Знаю","Что","Придумать","Ликвидаторы","Милиция","Полиция","Похоже","На","Курсач","АГА","АШАН","Жена"}; 

            for (int i = 0; i < Size; i++)
            {
               Engineer ENG = new Engineer(Names[rnd.Next(1, Names.Length - 5)], Families[rnd.Next(1, Families.Length - 5)], rnd.Next(18, 65), NWS[rnd.Next(1, NWS.Length - 5)], NF[rnd.Next(1, NF.Length - 5)]);
                  //  Engineer ENG = new Engineer(rnd.Next(0,1000).ToString(),rnd.Next(0,1000).ToString(),rnd.Next(0,100),rnd.Next(1000).ToString(),rnd.Next(0,1000).ToString());

                while (WorkerEngineerSorted.ContainsKey(ENG.BaseWorker) | StringEngineerSorted.ContainsKey(ENG.BaseWorker.ToString()))
                {
                    ENG = new Engineer(Names[rnd.Next(1, Names.Length)], Families[rnd.Next(1, Families.Length)],
                        rnd.Next(18, 65), NWS[rnd.Next(1, NWS.Length)], NF[rnd.Next(1, NF.Length)]);
                }
                WorkerList.Enqueue(ENG.BaseWorker);
                StringList.Enqueue(ENG.BaseWorker.Display());
                WorkerEngineerSorted.Add(ENG.BaseWorker, ENG);
                StringEngineerSorted.Add(ENG.BaseWorker.Display(), ENG);
            }
        }
    }
}
