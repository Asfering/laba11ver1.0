using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Lab10Library;

namespace Laba11Next
{
    class Program
    {
        #region  StartHere

        //_______________________________________________________________________________________________________________________

        public static int EngCountFirst = 0;
        public static int EngCount = 0;
        public static List<Person> PerList = new List<Person>() { new Administer("Dima", "Volkov", 18, "Microsoft"), new Engineer("Shokk", "Kikov", 17, "Idiot", "Interesting"), new Worker("Leonardo", "Daunizo", 57, "Idiot") };
        public static List<Person> PSecond = new List<Person>();
        public static SortedList SortedPerson = new SortedList();
        public static SortedList SortClonePerson = new SortedList();
        public static TestCollections CheckCollections = new TestCollections(0);
        public static int IndexatorPart3 = 0;

        //_______________________________________________________________________________________________________________________

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в лабораторную работу номер 11! Вариант номер 4. Создана: Решетняк Р.М.");
            AddSortList();
            GotoMenu();
        }

        //_______________________________________________________________________________________________________________________

        static void GotoMenu()
        {
            Console.WriteLine("         Меню:\n1. Часть 1, SortedList\n2. Часть 2, List\n3. Часть 3, MySortedDictionary\n4. Выход из программы");
            int MenuGotoMe = PersonArray.InputNumber("", 1, 4);
            do
            {
                switch (MenuGotoMe)
                {
                    case 1:
                        Part1();
                        break;
                    case 2:
                        Part2();
                        break;
                    case 3:
                        Part3StartCollection();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            } while (MenuGotoMe != 4);
        }

        //_______________________________________________________________________________________________________________________

        #endregion

        //=================================================================================================================
        //=================================================================================================================
        //=================================================================================================================

        #region Part1

        //_______________________________________________________________________________________________________________________

        static void AddSortList()
        {
            Engineer ENG = new Engineer("Polyak", "Ugin", 18, "Locked", "Room");
            Administer ADM = new Administer("Alex", "Linked", 22, "AdvanceRP");
            Worker WRK = new Worker("Steve", "Jobs", 57, "Apple");
            Administer ADMSECOND = new Administer("Michael", "DeSanta", 45, "PoliceSF");

            SortedPerson.Add(Convert.ToString(SortedPerson.Count), "- id. Имя: " + ENG.FirstName + ", Фамилия: " + ENG.LastName + ", Возраст: " + ENG.Age + ", Наименование места работы: " + ENG.NameWorkShop + ", Наименование цеха: " + ENG.NameFactory);
            SortedPerson.Add(Convert.ToString(SortedPerson.Count), "- id. Имя: " + ADM.FirstName + ", Фамилия: " + ADM.LastName + ", Возраст: " + ADM.Age + ", Наименование места администрирования: " + ADM.WhatManage);
            SortedPerson.Add(Convert.ToString(SortedPerson.Count), "- id. Имя: " + WRK.FirstName + ", Фамилия: " + WRK.LastName + ", Возраст: " + WRK.Age + ", Наименование места работы: " + WRK.NameWorkShop);
            SortedPerson.Add(Convert.ToString(SortedPerson.Count), "- id. Имя: " + ADMSECOND.FirstName + ", Фамилия: " + ADMSECOND.LastName + ", Возраст: " + ADMSECOND.Age + ", Наименование места администрирования: " + ADMSECOND.WhatManage);
        }

        //_______________________________________________________________________________________________________________________

        static void Part1()
        {
            StartMenuPart1();
            int option = PersonArray.InputNumber("", 1, 8);
            switch (option)
            {
                case 1:
                    for (int i = 0; i < SortedPerson.Count; i++)
                    {
                        Console.WriteLine(SortedPerson.GetKey(i) + " " + SortedPerson.GetByIndex(i) + "\n");
                    }
                    break;
                case 2:
                    Console.WriteLine("Что вас интересует? 1 - Рабочий (Инженер), 2 - Рабочий, 3 - Администратор");
                    int optionCaseTwo = PersonArray.InputNumber("", 1, 3);
                    if (optionCaseTwo == 1)
                        SelectCaseTwoOptionEngFirst();
                    if (optionCaseTwo == 2)
                        SelectCaseTwoOptionWkFirst();
                    if (optionCaseTwo == 3)
                        SelectCaseTwoOptionAdmFirst();
                    break;
                case 3:
                    Console.WriteLine("Что вас интересует? 1 - Рабочий (Инженер), 2 - Рабочий, 3 - Администратор");
                    int optionCaseThree = PersonArray.InputNumber("", 1, 3);
                    if (optionCaseThree == 1)
                        SelectCaseThreeEngFirst();
                    if (optionCaseThree == 2)
                        SelectCaseThreeWorkFirst();
                    if (optionCaseThree == 3)
                        SelectCaseThreeAdmFirst();
                    EngCountFirst = 0;
                    break;
                case 4:
                    YesNO:
                    SelectCaseFourAddFirst();
                    Console.WriteLine("Добавить ещё? 1 - Да, 2 - Нет");
                    int YesNo = PersonArray.InputNumber("", 1, 2);
                    if (YesNo == 1)
                        goto YesNO;
                    else
                        break;
                case 5:
                   
                    NOU:
                    SelectCaseFiveDeleteFirst();   //FIXIT
                    Console.WriteLine("Удалить ещё? 1 - Да, 2 - Нет");
                    int NoNo = PersonArray.InputNumber("", 1, 2);
                    if (NoNo == 1)
                        goto NOU;
                    else
                        break;
                case 6:
                    SelectCaseSixFirstClone();
                    break;
                case 7:
                    SelectCaseSevenFirst();
                    break;
                case 8:
                    GotoMenu();
                    break;
            }
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseSevenFirst()
        {
            try
            {
                bool ok = false;
                Console.Write("Введите имя:");
                string findFirstName = Console.ReadLine();
                Console.Write("Введите фамилию: ");
                string findLastName = Console.ReadLine();
                Console.Write("Введите возраст: ");
                int findAge = PersonArray.InputNumber("", 0, 100);
                Console.WriteLine("Кого нужно искать: 1 - Работник; 2 - Администратор");
                int findCount = PersonArray.InputNumber("", 1, 2);
                if (findCount == 1)
                {
                    Console.WriteLine("Инженер? 1 - Да, 2 - Нет.");
                    int choiceEngl = PersonArray.InputNumber("", 1, 2);
                    Console.WriteLine();

                    Console.Write("Введите название места работы: ");
                    string findNameWorkShop = Console.ReadLine();
                    string searchWk = "";
                    if (choiceEngl == 2)
                    {
                        try
                        {
                            searchWk = " - id. Имя: " + findFirstName + ", Фамилия: " + findLastName + ", Возраст: " + findAge + ", Наименование цеха: " + findNameWorkShop;
                            foreach (DictionaryEntry WkCheck in SortedPerson)
                            {
                                if (WkCheck.Value.Equals(searchWk))
                                {
                                    Console.WriteLine("Найдено: " + WkCheck.Key + WkCheck.Value);
                                    ok = true;
                                }
                            }
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine("Пользователя нет!");
                        }
                    }

                    if (choiceEngl == 1)
                    {
                        Console.Write("Введите наименование цеха: ");
                        string findNameFactory = Console.ReadLine();
                        string searchEng = "";
                        try
                        {
                            searchEng = " - id. Имя: " + findFirstName + ", Фамилия: " + findLastName + ", Возраст: " + findAge + ", Наименование места работы: " + findNameFactory + ", Наименование цеха: " + findNameWorkShop;
                            foreach (DictionaryEntry EngCheck in SortedPerson)
                            {
                                if (EngCheck.Value.Equals(searchEng))
                                {
                                    Console.WriteLine("Найдено: " + EngCheck.Key + EngCheck.Value);
                                    ok = true;
                                }
                            }
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine("Пользователя нет!");
                        }
                    }
                }

                if (findCount == 2)
                {
                    Console.Write("Введите наименоение места администрирования: ");
                    string findWhatManage = Console.ReadLine();
                    string searchAdm = "";
                    try
                    {
                        searchAdm = " - id. Имя: " + findFirstName + ", Фамилия: " + findLastName + ", Возраст: " + findAge + ", Наименование места администрирования: " + findWhatManage;
                        foreach (DictionaryEntry AdmCheck in SortedPerson)
                        {
                            if (AdmCheck.Value.Equals(searchAdm))
                            {
                                Console.WriteLine("Найдено: " + AdmCheck.Key + AdmCheck.Value);
                                ok = true;
                            }
                        }
                        Console.WriteLine();
                    }
                    catch
                    {
                        Console.WriteLine("Пользователя нет!");
                    }
                }
                if (ok == false) 
                    Console.WriteLine("Пользователя нет!");
            }
            catch
            {
                Console.WriteLine("Элемента нет");
            }
        }
        
        //_______________________________________________________________________________________________________________________

        static void SelectCaseSixFirstClone()
        {
            SortClonePerson = (SortedList) SortedPerson.Clone();

            // отображение элементов

            Console.WriteLine("Начальные объекты: ");

            for (int i = 0; i < SortedPerson.Count; i++)
            {
                Console.WriteLine(SortedPerson.GetKey(i) + " " + SortedPerson.GetByIndex(i));
            }

            // отображение элементов клонирования

            Console.WriteLine("\nКлонируемые объекты: ");

            for (int i = 0; i < SortClonePerson.Count; i++)
            {
                Console.WriteLine(SortClonePerson.GetKey(i) + " " + SortClonePerson.GetByIndex(i));
            }
        }

        //_______________________________________________________________________________________________________________________

        #region FirstPartSelectCaseTwo

        //_______________________________________________________________________________________________________________________

        static void SelectCaseTwoOptionAdmFirst()
        {
            foreach (DictionaryEntry AdmIn in SortedPerson)
            {
                string strCheck = AdmIn.Value.ToString();
                string[] str2 = strCheck.Split(new char[] { ' ', ',', ';', '!', '?', '.', ':', '-', '+', '^', '@', '#', '$', '%', '(', ')', '=', '|', '*', '<', '>', ']', '[', '`', '&', '№', '/', '\r', '\n', '«', '»', '\"', '\\', '\'', '—', '–' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string rev in str2)
                {
                    if (rev == "администрирования")
                        Console.WriteLine(AdmIn.Key + " " + AdmIn.Value + "\n");
                }

            }
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseTwoOptionWkFirst()
        {
            foreach (DictionaryEntry WkIn in SortedPerson)
            {
                string strCheck = WkIn.Value.ToString();
                string[] str2 = strCheck.Split(new char[] { ' ', ',', ';', '!', '?', '.', ':', '-', '+', '^', '@', '#', '$', '%', '(', ')', '=', '|', '*', '<', '>', ']', '[', '`', '&', '№', '/', '\r', '\n', '«', '»', '\"', '\\', '\'', '—', '–' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string rev in str2)
                {
                    if (rev == "работы")
                        Console.WriteLine(WkIn.Key + " " + WkIn.Value + "\n");
                }

            }
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseTwoOptionEngFirst()
        {
            foreach (DictionaryEntry EngIn in SortedPerson)
            {
                string strCheck = EngIn.Value.ToString();
                string[] str2 = strCheck.Split(new char[] { ' ', ',', ';', '!', '?', '.', ':', '-', '+', '^', '@', '#', '$', '%', '(', ')', '=', '|', '*', '<', '>', ']', '[', '`', '&', '№', '/', '\r', '\n', '«', '»', '\"', '\\', '\'', '—', '–' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string rev in str2)
                {
                    if (rev == "цеха")
                        Console.WriteLine(EngIn.Key + " " + EngIn.Value + "\n");
                }

            }
        }

        //_______________________________________________________________________________________________________________________

        #endregion

        //_______________________________________________________________________________________________________________________

        #region FirstPartSelectCaseThree

        //_______________________________________________________________________________________________________________________

        static void SelectCaseThreeAdmFirst()
        {
            foreach (DictionaryEntry AdmIn in SortedPerson)
            {
                string strCheck = AdmIn.Value.ToString();
                string[] str2 = strCheck.Split(new char[] { ' ', ',', ';', '!', '?', '.', ':', '-', '+', '^', '@', '#', '$', '%', '(', ')', '=', '|', '*', '<', '>', ']', '[', '`', '&', '№', '/', '\r', '\n', '«', '»', '\"', '\\', '\'', '—', '–' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string rev in str2)
                {
                    if(rev == "администрирования")
                        EngCountFirst++;
                }

            }
            Console.WriteLine("Количество администраторов - " + EngCountFirst);
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseThreeWorkFirst()
        {
            foreach (DictionaryEntry WkIn in SortedPerson)
            {
                string strCheck = WkIn.Value.ToString();
                string[] str2 = strCheck.Split(new char[] { ' ', ',', ';', '!', '?', '.', ':', '-', '+', '^', '@', '#', '$', '%', '(', ')', '=', '|', '*', '<', '>', ']', '[', '`', '&', '№', '/', '\r', '\n', '«', '»', '\"', '\\', '\'', '—', '–' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string rev in str2)
                {
                    if (rev == "работы")
                        EngCountFirst++;
                }

            }
            Console.WriteLine("Количество рабочих - " + EngCountFirst);
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseThreeEngFirst()
        {
            foreach (DictionaryEntry EngIn in SortedPerson)
            {
                string strCheck = EngIn.Value.ToString();
                string[] str2 = strCheck.Split(new char[] { ' ', ',', ';', '!', '?', '.', ':', '-', '+', '^', '@', '#', '$', '%', '(', ')', '=', '|', '*', '<', '>', ']', '[', '`', '&', '№', '/', '\r', '\n', '«', '»', '\"', '\\', '\'', '—', '–' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string rev in str2)
                {
                    if (rev == "цеха")
                        EngCountFirst++;
                }

            }
            Console.WriteLine("Количество инженеров - " + EngCountFirst);
        }

        //_______________________________________________________________________________________________________________________

        #endregion

        //_______________________________________________________________________________________________________________________

        static void SelectCaseFiveDeleteFirst()
        {
            Console.WriteLine("Введите индекс элемента");
            try
            {
                int IndexEl = Convert.ToInt32(Console.ReadLine());
                SortedPerson.RemoveAt(IndexEl);   // как исправить индексы у других элементов?
            }
            catch
            {
                Console.WriteLine("Элемента с данным индексом нет");
            }
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseFourAddFirst()
        {
            try
            {
                Console.WriteLine("Введите должность, которую хотите добавить. 1 - Рабочий (Инженер), 2 - Рабочий, 3 - Администратор");
                int SelectOptionAdd = PersonArray.InputNumber("", 1, 3);
                if (SelectOptionAdd == 1)
                {
                    Console.Write("Введите имя:");
                    string F_FirstName = Console.ReadLine();
                    Console.Write("Введите фамилию: ");
                    string F_LastName = Console.ReadLine();
                    Console.Write("Введите возраст: ");
                    int F_Age = PersonArray.InputNumber("", 0, 100);
                    Console.Write("Введите название цеха: ");
                    string F_NameWorkShop = Console.ReadLine();
                    Console.Write("Введите наименование места работы: ");
                    string F_NameFactory = Console.ReadLine();
                    Engineer ENG = new Engineer(F_FirstName, F_LastName, F_Age, F_NameWorkShop, F_NameFactory);
                    string testing = Convert.ToString(SortedPerson.Count);
                    SortedPerson.Add(testing, "- id. Имя: " + ENG.FirstName + ", Фамилия: " + ENG.LastName + ", Возраст: " + ENG.Age + ", Наименование места работы: " + ENG.NameWorkShop + ", Наименование цеха: " + ENG.NameFactory);
                }

                if (SelectOptionAdd == 2)
                {
                    Console.Write("Введите имя:");
                    string S_FirstName = Console.ReadLine();
                    Console.Write("Введите фамилию: ");
                    string S_LastName = Console.ReadLine();
                    Console.Write("Введите возраст: ");
                    int S_Age = PersonArray.InputNumber("", 0, 100);
                    Console.Write("Введите название цеха: ");
                    string S_NameWorkShop = Console.ReadLine();
                    Worker WRK = new Worker(S_FirstName, S_LastName, S_Age, S_NameWorkShop);
                    string testing = Convert.ToString(SortedPerson.Count);
                    SortedPerson.Add(testing, "- id. Имя: " + WRK.FirstName + ", Фамилия: " + WRK.LastName + ", Возраст: " + WRK.Age + ", Наименование места работы: " + WRK.NameWorkShop);
                }

                if (SelectOptionAdd == 3)
                {
                    Console.Write("Введите имя:");
                    string T_FirstName = Console.ReadLine();
                    Console.Write("Введите фамилию: ");
                    string T_LastName = Console.ReadLine();
                    Console.Write("Введите возраст: ");
                    int T_Age = PersonArray.InputNumber("", 0, 100);
                    Console.Write("Введите наименование места администрирования: ");
                    string T_WhatManage = Console.ReadLine();
                    Administer ADM = new Administer(T_FirstName, T_LastName, T_Age, T_WhatManage);
                    string testing = Convert.ToString(SortedPerson.Count);
                    SortedPerson.Add(testing, "- id. Имя: " + ADM.FirstName + ", Фамилия: " + ADM.LastName + ", Возраст: " + ADM.Age + ", Наименование места администрирования: " + ADM.WhatManage);
                }
            }
           catch
        {
                Console.WriteLine("Неверные параметры");
            }

        }

        //_______________________________________________________________________________________________________________________

        static void StartMenuPart1()
        {
            Console.WriteLine("         Меню:\n1. Печать всех элементов\n2. Печать определенных элеменов\n3. Печать количества определенных элементов\n4. Добавить в коллекцию\n5. Удалить из коллекции\n6. Клонирование\n7. Поиск элемента в коллекции\n8. Выход в меню");
        }

        //_______________________________________________________________________________________________________________________

        #endregion

        //=================================================================================================================
        //=================================================================================================================
        //=================================================================================================================

        #region Part2

        //_______________________________________________________________________________________________________________________

        static void Part2()
        {
            StartMenuPart2();
            int option = PersonArray.InputNumber("", 1, 9);
            switch (option)
            {
                case 1:
                    SelectCaseOneOption();
                    break;
                case 2:
                    Console.WriteLine("Что вас интересует? 1 - Рабочий (Инженер), 2 - Рабочий, 3 - Администратор");
                    int optionCaseTwo = PersonArray.InputNumber("", 1, 3);
                    if (optionCaseTwo == 1)
                        SelectCaseTwoOptionEng();
                    if (optionCaseTwo == 2)
                        SelectCaseTwoOptionWork();
                    if (optionCaseTwo == 3)
                        SelectCaseTwoOptionAdm();
                    break;
                case 3:
                    Console.WriteLine("Что вас интересует? 1 - Рабочий (Инженер), 2 - Рабочий, 3 - Администратор");
                    int optionCaseThree = PersonArray.InputNumber("", 1, 3);
                    if (optionCaseThree == 1)
                        SelectCaseThreeEng();
                    if (optionCaseThree == 2)
                        SelectCaseThreeWork();
                    if (optionCaseThree == 3)
                        SelectCaseThreeAdm();
                    EngCount = 0;
                    break;
                case 4:
                    YesNO:
                    SelectCaseFourAdd();
                    Console.WriteLine("Добавить ещё? 1 - Да, 2 - Нет");
                    int YesNo = PersonArray.InputNumber("", 1, 2);
                    if (YesNo == 1)
                        goto YesNO;
                    else
                        break;
                case 5:
                    NOU:
                    SelectCaseFiveDelete();
                    Console.WriteLine("Удалить ещё? 1 - Да, 2 - Нет");
                    int NoNo = PersonArray.InputNumber("", 1, 2);
                    if (NoNo == 1)
                        goto NOU;
                    else
                        break;
                case 6:
                    SelectCaseSixClone();  
                    PerList.AddRange(PSecond.ToArray());
                    break;
                case 7:
                    PerList.Sort();
                    SelectCaseOneOption();
                    break;
                case 8:
                    SelectCaseEight();    
                    break;
                case 9:
                    GotoMenu();
                    break;
            }
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseEight()
        {
            try
            {
                Console.Write("Введите имя:");
                string findFirstName = Console.ReadLine();
                Console.Write("Введите фамилию: ");
                string findLastName = Console.ReadLine();
                Console.Write("Введите возраст: ");
                int findAge = PersonArray.InputNumber("", 0, 100);
                Console.WriteLine("Кого нужно искать: 1 - Работник; 2 - Администратор");
                int findCount = PersonArray.InputNumber("", 1, 2);
                if (findCount == 1)
                {
                    Console.WriteLine("Инженер? 1 - Да, 2 - Нет.");
                    int choiceEngl = PersonArray.InputNumber("", 1, 2);
                    Console.WriteLine();

                    Console.Write("Введите название цеха: ");
                    string findNameWorkShop = Console.ReadLine();
                    if (choiceEngl == 2)
                    {
                        try
                        {
                            Person p = new Worker(findFirstName, findLastName, findAge, findNameWorkShop);
                            Person finded = PerList.Find(x => x == p);
                            Console.WriteLine($"Найдено: \n" + finded.Show());
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine("Пользователя нет!");
                        }
                    }

                    if (choiceEngl == 1)
                    {
                        Console.Write("Введите наименование места работы: ");
                        string findNameFactory = Console.ReadLine();
                        try
                        {
                            Person p = new Engineer(findFirstName, findLastName, findAge, findNameWorkShop, findNameFactory);
                            Person finded = PerList.Find(x => x == p);
                            Console.WriteLine($"Найдено: \n" + finded.Show());
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine("Пользователя нет!");
                        }
                    }
                }

                if (findCount == 2)
                {
                    Console.Write("Введите наименоение места администрирования: ");
                    string findWhatManage = Console.ReadLine();
                    try
                    {
                        Person p = new Administer(findFirstName, findLastName, findAge, findWhatManage);
                        Person finded = PerList.Find(x => x == p);
                        Console.WriteLine($"Найдено: \n" + finded.Show());
                        Console.WriteLine();
                    }
                    catch
                    {
                        Console.WriteLine("Пользователя нет!");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Элемента нет");
            }
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseSixClone()
        {
            foreach (Person CloneablePerson in PerList)
            {
                if (CloneablePerson is Worker)
                {
                    if (CloneablePerson is Engineer)
                    {
                        Person ClonePers = (Engineer) CloneablePerson.Clone();
                        Console.WriteLine(ClonePers.Show());
                    }
                    else
                    {
                        Person ClonePers = (Worker)CloneablePerson.Clone();
                        Console.WriteLine(ClonePers.Show());
                    }
                }

                if (CloneablePerson is Administer)
                {
                    Person ClonePers = (Administer)CloneablePerson.Clone();
                    Console.WriteLine(ClonePers.Show());
                }
                Console.WriteLine();
                Console.WriteLine("____________________________________________________________________________");
                Console.WriteLine();
            }
            Console.WriteLine("Клонирование завершено!");
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseFiveDelete()
        {
            Console.WriteLine("Введите индекс элемента");
            try
            {
                int IndexEl = Convert.ToInt32(Console.ReadLine());
                PerList.RemoveAt(IndexEl);
            }
            catch
            {
                Console.WriteLine("Элемента с данным индексом нет");
            }
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseFourAdd()
        {
            try
            {
                Console.WriteLine("Введите должность, которую хотите добавить. 1 - Рабочий (Инженер), 2 - Рабочий, 3 - Администратор");
                int SelectOptionAdd = PersonArray.InputNumber("", 1, 3);
                if (SelectOptionAdd == 1)
                {
                    Console.Write("Введите имя:");
                    string F_FirstName = Console.ReadLine();
                    Console.Write("Введите фамилию: ");
                    string F_LastName = Console.ReadLine();
                    Console.Write("Введите возраст: ");
                    int F_Age = PersonArray.InputNumber("", 0, 100);
                    Console.Write("Введите название цеха: ");
                    string F_NameWorkShop = Console.ReadLine();
                    Console.Write("Введите наименование места работы: ");
                    string F_NameFactory = Console.ReadLine();
                    PerList.Add(new Engineer(F_FirstName, F_LastName, F_Age, F_NameWorkShop, F_NameFactory));
                }

                if (SelectOptionAdd == 2)
                {
                    Console.Write("Введите имя:");
                    string S_FirstName = Console.ReadLine();
                    Console.Write("Введите фамилию: ");
                    string S_LastName = Console.ReadLine();
                    Console.Write("Введите возраст: ");
                    int S_Age = PersonArray.InputNumber("", 0, 100);
                    Console.Write("Введите название цеха: ");
                    string S_NameWorkShop = Console.ReadLine();
                    PerList.Add(new Worker(S_FirstName, S_LastName, S_Age, S_NameWorkShop));
                }

                if (SelectOptionAdd == 3)
                {
                    Console.Write("Введите имя:");
                    string T_FirstName = Console.ReadLine();
                    Console.Write("Введите фамилию: ");
                    string T_LastName = Console.ReadLine();
                    Console.Write("Введите возраст: ");
                    int T_Age = PersonArray.InputNumber("", 0, 100);
                    Console.Write("Введите наименование места администрирования: ");
                    string T_WhatManage = Console.ReadLine();
                    PerList.Add(new Administer(T_FirstName, T_LastName, T_Age, T_WhatManage));
                }
            }
            catch
            {
                Console.WriteLine("Неверные параметры");
            }

        }

        //_______________________________________________________________________________________________________________________

        #region SecondPartSelectCaseThree

        //_______________________________________________________________________________________________________________________

        static void SelectCaseThreeAdm()
        {
            foreach (Person Ad in PerList)
            {
                if (Ad is Administer)
                    EngCount++;
            }
            Console.WriteLine("Количество администраторов - " + EngCount);
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseThreeWork()
        {
            foreach (Person Worke in PerList)
            {
                if (Worke is Worker)
                    EngCount++;
            }
            Console.WriteLine("Количество рабочих - " + EngCount);
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseThreeEng()
        {
            foreach (Person Engin in PerList)
            {
                if (Engin is Engineer)
                    EngCount++;
            }
            Console.WriteLine("Количество инженеров - " + EngCount);
        }

        //_______________________________________________________________________________________________________________________

        #endregion

        //_______________________________________________________________________________________________________________________

        #region SecondPartSelectCaseTwo

        static void SelectCaseTwoOptionAdm()
        {
            Administer admIn = new Administer("", "", 0, "");
            foreach (Person Ad in PerList)
            {
                if (Ad is Administer)
                {
                    admIn = Ad as Administer;
                    Console.WriteLine("Администратор - " + admIn.FirstName + " " + admIn.LastName + " " + admIn.Age + " " + admIn.WhatManage);
                }
            }
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseTwoOptionWork()
        {
            Worker wrkln = new Worker("", "", 0, "");
            foreach (Person Worke in PerList)
            {
                if (Worke is Worker)
                {
                    wrkln = Worke as Worker;
                    Console.WriteLine("Рабочий - " + wrkln.FirstName + " " + wrkln.LastName + " " + wrkln.Age + " " + wrkln.NameWorkShop);
                }
            }
        }

        //_______________________________________________________________________________________________________________________

        static void SelectCaseTwoOptionEng()
        {
            Engineer engIn = new Engineer("", "", 0, "", "");
            foreach (Person Engin in PerList)
            {
                if (Engin is Engineer)
                {
                    engIn = Engin as Engineer;
                    Console.WriteLine("Инженер - " + engIn.FirstName + " " + engIn.LastName + " " + engIn.Age + " " + engIn.NameWorkShop + " " + engIn.NameFactory);
                }
            }
        }

        //_______________________________________________________________________________________________________________________

        #endregion

        //_______________________________________________________________________________________________________________________

        static void SelectCaseOneOption()
        {
            Engineer engIn = new Engineer("", "", 0, "", "");
            Worker wrkln = new Worker("", "", 0, "");
            Administer admIn = new Administer("", "", 0, "");
            foreach (Person p in PerList)
            {
                if (p is Worker)
                {
                    if (p is Engineer)
                    {
                        engIn = p as Engineer;
                        Console.WriteLine("Инженер - " + engIn.FirstName + " " + engIn.LastName + " " +
                                          engIn.Age + " " + engIn.NameWorkShop + " " + engIn.NameFactory);
                    }
                    else
                    {
                        wrkln = p as Worker;
                        Console.WriteLine("Рабочий - " + wrkln.FirstName + " " + wrkln.LastName + " " +
                                          wrkln.Age + " " + wrkln.NameWorkShop);
                    }
                }

                if (p is Administer)
                {
                    admIn = p as Administer;
                    Console.WriteLine("Администратор - " + admIn.FirstName + " " + admIn.LastName + " " +
                                      admIn.Age + " " + admIn.WhatManage);
                }
            }
        }

        //_______________________________________________________________________________________________________________________

        static void StartMenuPart2()
        {
            Console.WriteLine("         Меню:\n1. Печать всех элементов\n2. Печать определенных элеменов\n3. Печать количества определенных элементов\n4. Добавить в коллекцию\n5. Удалить из коллекции\n6. Клонирование\n7. Сортировка\n8. Поиск элемента в коллекции\n9. Выход в меню");
        }

        //_______________________________________________________________________________________________________________________

        #endregion

        //=================================================================================================================
        //=================================================================================================================
        //=================================================================================================================

        #region Part3

        //_______________________________________________________________________________________________________________________

      public  static void SearchInCollections()
        {
            try
            {
                #region Первый

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    "\nПоиск по ЗНАЧЕНИЮ, не по ССЫЛКЕ, т.е. поиск тут и показания в методе показа коллекции могут различаться!\n");
                Console.ResetColor();
                Stopwatch MyTimeHasCome = new Stopwatch();
                Engineer ENG = new Engineer(CheckCollections.WorkerEngineerSorted.Values.First().FirstName,
                    CheckCollections.WorkerEngineerSorted.Values.First().LastName,
                    CheckCollections.WorkerEngineerSorted.Values.First().Age,
                    CheckCollections.WorkerEngineerSorted.Values.First().NameWorkShop,
                    CheckCollections.WorkerEngineerSorted.Values.First().NameFactory);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Первый");
                Console.ResetColor();
                Console.WriteLine();

                //SORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО VALUE, ЗАПИСЬ ПО VALUE

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("SORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО VALUE, ЗАПИСЬ ПО VALUE");
                Console.ResetColor();
                if (CheckCollections.WorkerEngineerSorted.ContainsKey(ENG))      
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(ENG.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                //SORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО KEY

                Worker ENGKey = new Worker(CheckCollections.WorkerEngineerSorted.Keys.First().FirstName,
                    CheckCollections.WorkerEngineerSorted.Keys.First().LastName,
                    CheckCollections.WorkerEngineerSorted.Keys.First().Age,
                    CheckCollections.WorkerEngineerSorted.Keys.First().NameWorkShop);

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО KEY");
                Console.ResetColor();
                if (CheckCollections.WorkerEngineerSorted.ContainsKey(ENGKey))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(ENGKey.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                //SORTEDDICTIONARY<STRING><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО VALUE

                Engineer ENGKeyString = new Engineer(CheckCollections.StringEngineerSorted.Values.First().FirstName,
                    CheckCollections.StringEngineerSorted.Values.First().LastName,
                    CheckCollections.StringEngineerSorted.Values.First().Age,
                    CheckCollections.StringEngineerSorted.Values.First().NameWorkShop,
                    CheckCollections.StringEngineerSorted.Values.First().NameFactory);

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSORTEDDICTIONARY<STRING><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО VALUE");
                Console.ResetColor();
                if (CheckCollections.StringEngineerSorted.ContainsKey(ENGKeyString.BaseWorker.Display()))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(ENGKeyString.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                //QUEUE <WORKER>, ПОИСК ПО CONTAINS

                Worker wrkNew = new Worker(CheckCollections.WorkerList.First().FirstName,CheckCollections.WorkerList.First().LastName,CheckCollections.WorkerList.First().Age,CheckCollections.WorkerList.First().NameWorkShop);

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nQUEUE <WORKER>, ПОИСК ПО CONTAINS");
                Console.ResetColor();
             //  Console.WriteLine(CheckCollections.StringList.Peek());    //Первый элемент
             //  Console.WriteLine(wrkNew.Display());                               //Элемент, который записан
                if (CheckCollections.WorkerList.Contains(ENG.BaseWorker))         //Почему не ищет??
               // {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(wrkNew.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
               // }
               // else
               // {
               //     MyTimeHasCome.Stop();
               //     Console.WriteLine("Элемент не найден!");
               // }

                MyTimeHasCome.Reset();

                //QUEUE <STRING>, ПОИСК ПО CONTAINS ДОБАВИТЬ

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nQUEUE <STRING>, ПОИСК ПО CONTAINS");
                Console.ResetColor();
                if (CheckCollections.StringList.Contains(wrkNew.Display()))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(wrkNew.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                //SORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО VALUE, ЗАПИСЬ ПО VALUE

                Engineer ENGSecond = new Engineer(CheckCollections.WorkerEngineerSorted.Values.Last().FirstName,
                    CheckCollections.WorkerEngineerSorted.Values.Last().LastName,
                    CheckCollections.WorkerEngineerSorted.Values.Last().Age,
                    CheckCollections.WorkerEngineerSorted.Values.Last().NameWorkShop,
                    CheckCollections.WorkerEngineerSorted.Values.Last().NameFactory);

                #endregion

                //_________________________________________________________________________________________

                #region Последний

                //_________________________________________________________________________________________

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Последний");
                Console.ResetColor();
                Console.WriteLine();

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО VALUE, ЗАПИСЬ ПО VALUE");
                Console.ResetColor();
                if (CheckCollections.WorkerEngineerSorted.ContainsKey(ENGSecond))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(ENGSecond.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                //SORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО KEY

                Worker ENGKeyAgain = new Worker(CheckCollections.WorkerEngineerSorted.Keys.Last().FirstName,
                    CheckCollections.WorkerEngineerSorted.Keys.Last().LastName,
                    CheckCollections.WorkerEngineerSorted.Keys.Last().Age,
                    CheckCollections.WorkerEngineerSorted.Keys.Last().NameWorkShop);

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО KEY");
                Console.ResetColor();
                if (CheckCollections.WorkerEngineerSorted.ContainsKey(ENGKeyAgain))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(ENGKeyAgain.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                //SORTEDDICTIONARY<STRING><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО VALUE

                Engineer ENGKeyStringAgain = new Engineer(CheckCollections.StringEngineerSorted.Values.Last().FirstName,
                    CheckCollections.StringEngineerSorted.Values.Last().LastName,
                    CheckCollections.StringEngineerSorted.Values.Last().Age,
                    CheckCollections.StringEngineerSorted.Values.Last().NameWorkShop,
                    CheckCollections.StringEngineerSorted.Values.Last().NameFactory);

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSORTEDDICTIONARY<STRING><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО VALUE");
                Console.ResetColor();
                if (CheckCollections.StringEngineerSorted.ContainsKey(ENGKeyStringAgain.BaseWorker.Display()))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(ENGKeyStringAgain.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                //QUEUE <WORKER>, ПОИСК ПО CONTAINS

                Worker wrkNewAgain = new Worker(CheckCollections.WorkerList.Last().FirstName, CheckCollections.WorkerList.Last().LastName, CheckCollections.WorkerList.Last().Age, CheckCollections.WorkerList.Last().NameWorkShop);

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nQUEUE <WORKER>, ПОИСК ПО CONTAINS");
                Console.ResetColor();
               // if (CheckCollections.WorkerList.Contains(wrkNewAgain))
                //{
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(wrkNewAgain.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
             //   }
                //else
               // {
              //      MyTimeHasCome.Stop();
              //      Console.WriteLine("Элемент не найден!");
              //  }

                MyTimeHasCome.Reset();

                //QUEUE <STRING>, ПОИСК ПО CONTAINS ДОБАВИТЬ

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nQUEUE <STRING>, ПОИСК ПО CONTAINS");
                Console.ResetColor();
                if (CheckCollections.StringList.Contains(wrkNewAgain.Display()))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(wrkNewAgain.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                #endregion

                //_________________________________________________________________________________________

                #region Центральный

                //_________________________________________________________________________________________

                //SORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО VALUE, ЗАПИСЬ ПО VALUE

                int ConstAverage = CheckCollections.WorkerEngineerSorted.Count / 2;

                Engineer ENGThird = new Engineer(
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAverage).FirstName,
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAverage).LastName,
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAverage).Age,
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAverage).NameWorkShop,
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAverage).NameFactory);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Центральный");
                Console.ResetColor();
                Console.WriteLine();

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nSORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО VALUE, ЗАПИСЬ ПО VALUE");
                Console.ResetColor();
                if (CheckCollections.WorkerEngineerSorted.ContainsKey(ENGThird))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(ENGThird.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                //SORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО KEY

                Worker ENGKeyAnotherOne = new Worker(CheckCollections.WorkerEngineerSorted.Keys.ElementAt(ConstAverage).FirstName,
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAverage).LastName,
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAverage).Age,
                    CheckCollections.WorkerEngineerSorted.Keys.ElementAt(ConstAverage).NameWorkShop);

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nSORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО KEY");
                Console.ResetColor();
                if (CheckCollections.WorkerEngineerSorted.ContainsKey(ENGKeyAnotherOne))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(ENGKeyAnotherOne.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                //SORTEDDICTIONARY<STRING><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО VALUE

                Engineer ENGKeyStringAnotherOne = new Engineer(CheckCollections.StringEngineerSorted.Values.ElementAt(ConstAverage).FirstName,
                    CheckCollections.StringEngineerSorted.Values.ElementAt(ConstAverage).LastName,
                    CheckCollections.StringEngineerSorted.Values.ElementAt(ConstAverage).Age,
                    CheckCollections.StringEngineerSorted.Values.ElementAt(ConstAverage).NameWorkShop,
                    CheckCollections.StringEngineerSorted.Values.ElementAt(ConstAverage).NameFactory);

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nSORTEDDICTIONARY<STRING><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО VALUE");
                Console.ResetColor();
                if (CheckCollections.StringEngineerSorted.ContainsKey(ENGKeyStringAnotherOne.BaseWorker.Display()))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(ENGKeyStringAnotherOne.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                //QUEUE <WORKER>, ПОИСК ПО CONTAINS

                Worker wrkNewAnotherOne = new Worker(CheckCollections.WorkerList.Last().FirstName, CheckCollections.WorkerList.Last().LastName, CheckCollections.WorkerList.Last().Age, CheckCollections.WorkerList.Last().NameWorkShop);

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nQUEUE <WORKER>, ПОИСК ПО CONTAINS");
                Console.ResetColor();
             //   if (CheckCollections.WorkerList.Contains(wrkNewAnotherOne))
              //  {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(wrkNewAnotherOne.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
              //  }
             //   else
              //  {
             //       MyTimeHasCome.Stop();
             ///      Console.WriteLine("Элемент не найден!");
            //    }

                MyTimeHasCome.Reset();

                //QUEUE <STRING>, ПОИСК ПО CONTAINS ДОБАВИТЬ

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nQUEUE <STRING>, ПОИСК ПО CONTAINS");
                Console.ResetColor();
                if (CheckCollections.StringList.Contains(wrkNewAnotherOne.Display()))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(wrkNewAnotherOne.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();
                #endregion

                //_________________________________________________________________________________________

                #region Вне коллекции

                //_________________________________________________________________________________________

                int ConstAfter = CheckCollections.WorkerEngineerSorted.Count + 1;

                Engineer ENGFour = new Engineer(
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAfter).FirstName,
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAfter).LastName,
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAfter).Age,
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAfter).NameWorkShop,
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAfter).NameFactory);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вне границ");
                Console.ResetColor();
                Console.WriteLine();

                //SORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО VALUE, ЗАПИСЬ ПО VALUE

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nSORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО VALUE, ЗАПИСЬ ПО VALUE");
                Console.ResetColor();
                if (CheckCollections.WorkerEngineerSorted.ContainsKey(ENGFour))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(ENGFour.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                //SORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО KEY

                Worker ENGKeyAnotherOneAgain = new Worker(CheckCollections.WorkerEngineerSorted.Keys.ElementAt(ConstAfter).FirstName,
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAfter).LastName,
                    CheckCollections.WorkerEngineerSorted.Values.ElementAt(ConstAfter).Age,
                    CheckCollections.WorkerEngineerSorted.Keys.ElementAt(ConstAfter).NameWorkShop);

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nSORTEDDICTIONARY<WORKER><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО KEY");
                Console.ResetColor();
                if (CheckCollections.WorkerEngineerSorted.ContainsKey(ENGKeyAnotherOneAgain))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(ENGKeyAnotherOneAgain.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                //SORTEDDICTIONARY<STRING><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО VALUE

                Engineer ENGKeyStringAnotherOneAgain = new Engineer(CheckCollections.StringEngineerSorted.Values.ElementAt(ConstAfter).FirstName,
                    CheckCollections.StringEngineerSorted.Values.ElementAt(ConstAfter).LastName,
                    CheckCollections.StringEngineerSorted.Values.ElementAt(ConstAfter).Age,
                    CheckCollections.StringEngineerSorted.Values.ElementAt(ConstAfter).NameWorkShop,
                    CheckCollections.StringEngineerSorted.Values.ElementAt(ConstAfter).NameFactory);

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nSORTEDDICTIONARY<STRING><ENGINEER>, ПОИСК ПО KEY, ЗАПИСЬ ПО VALUE");
                Console.ResetColor();
                if (CheckCollections.StringEngineerSorted.ContainsKey(ENGKeyStringAnotherOneAgain.BaseWorker.Display()))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(ENGKeyStringAnotherOneAgain.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();

                //QUEUE <WORKER>, ПОИСК ПО CONTAINS

                Worker wrkNewAnotherOneAgain = new Worker(CheckCollections.WorkerList.Last().FirstName, CheckCollections.WorkerList.Last().LastName, CheckCollections.WorkerList.Last().Age, CheckCollections.WorkerList.Last().NameWorkShop);

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nQUEUE <WORKER>, ПОИСК ПО CONTAINS");
                Console.ResetColor();
               // if (CheckCollections.WorkerList.Contains(wrkNewAnotherOneAgain))
                //{
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(wrkNewAnotherOneAgain.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
             //   }
               // else
               // {
               //     MyTimeHasCome.Stop();
              //      Console.WriteLine("Элемент не найден!");
               // }

                MyTimeHasCome.Reset();

                //QUEUE <STRING>, ПОИСК ПО CONTAINS ДОБАВИТЬ

                MyTimeHasCome.Start();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nQUEUE <STRING>, ПОИСК ПО CONTAINS");
                Console.ResetColor();
                if (CheckCollections.StringList.Contains(wrkNewAnotherOneAgain.Display()))
                {
                    Console.WriteLine("Найдено!");
                    MyTimeHasCome.Stop();
                    Console.WriteLine(wrkNewAnotherOneAgain.Show());
                    Console.WriteLine("Затраченное время: " + MyTimeHasCome.Elapsed.Ticks + " Тиков");
                }
                else
                {
                    MyTimeHasCome.Stop();
                    Console.WriteLine("Элемент не найден!");
                }

                MyTimeHasCome.Reset();
                // var stringDelete = CheckCollections.StringEngineerSorted.Keys.First();
                // CheckCollections.StringEngineerSorted.ContainsKey(stringDelete);
                // Console.WriteLine("Найдено!" + stringDelete);
                #endregion
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nНе входящий в коллекцию\n");
                Console.ResetColor();
                Console.WriteLine("Элемент находится за границами коллекции");
            }
            catch
            {
                Console.WriteLine("Ошибка!");
            }
        }

        //_______________________________________________________________________________________________________________________

        static void Part3StartCollection()
        {
            while (IndexatorPart3 == 0)
            {
                Console.WriteLine("Укажите размер коллекции");
                int SizeOfCollection = PersonArray.InputNumber("", 0, 1001);
                CheckCollections = new TestCollections(SizeOfCollection);
                IndexatorPart3++;
            }

            Part3();
        }

        //_______________________________________________________________________________________________________________________

        static void Part3()
        {
            Part3Menu();
            int choice = PersonArray.InputNumber("", 1, 5);
            switch (choice)
            {
                case 1:
                    ElementAdd();    //Баг с элементами, узнать у преподавателя
                    break;
                case 2:
                    ElementShow();
                    break;
                case 3:
                    ElementDelete();   //Доработать
                    break;
                case 4:
                    SearchInCollections();
                    break;
                case 5:
                    IndexatorPart3 = 0;
                    GotoMenu();
                    break;
            }
        }

        //_______________________________________________________________________________________________________________________

        static void ElementDelete()
        {
            Console.WriteLine("1. Удаление 1 элемента (ссылка)\n2. Удаление всего");
            int ChoiceDelete = PersonArray.InputNumber("", 0, 2);
           
                try
                {
                    switch (ChoiceDelete)
                    {
                        case 1:
                            var stringDelete = CheckCollections.StringEngineerSorted.Keys.First();
                            CheckCollections.StringEngineerSorted.Remove(stringDelete);
                            var workerDelete = CheckCollections.WorkerEngineerSorted.Keys.First();
                            CheckCollections.WorkerEngineerSorted.Remove(workerDelete);
                            CheckCollections.StringList.Dequeue();
                            CheckCollections.WorkerList.Dequeue();
                            break;
                    case 2:
                            CheckCollections.WorkerEngineerSorted.Clear();
                            CheckCollections.StringEngineerSorted.Clear();
                            CheckCollections.StringList.Clear();
                            CheckCollections.WorkerList.Clear();
                            break;
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Коллекция пуста");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат введённых данных");
                }
            
        }

        //_______________________________________________________________________________________________________________________

        static void ElementShow()
        {
            foreach (KeyValuePair<string,Engineer> ShowAllElements in CheckCollections.StringEngineerSorted)
            {
                Console.Write("ID - ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ShowAllElements.Key);
                Console.ResetColor();
                Console.WriteLine(", Значение - " + ShowAllElements.Value.Show());
            }
        }

        //_______________________________________________________________________________________________________________________

        static void ElementAdd()
        {
            Console.WriteLine("Введите количество добавляемых элементов");
            int CountAddedElements = PersonArray.InputNumber("",0,1000);
            for (int i = 0; i < CountAddedElements; i++)
            {
                try
                {
                    Console.Write("Введите имя элемента: ");
                    string FName = Console.ReadLine();
                    Console.Write("Введите фамилию элемента: ");
                    string LName = Console.ReadLine();
                    Console.Write("Введите возраст элемента: ");
                    int Age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите наименование цеха элемента: ");
                    string NWorkShop = Console.ReadLine();
                    Console.Write("Введите наименование места работы: ");
                    string NFactory = Console.ReadLine();
                    Engineer eng = new Engineer(FName, LName, Age, NWorkShop, NFactory);
                    CheckCollections.WorkerEngineerSorted.Add(eng.BaseWorker, eng);
                    CheckCollections.StringEngineerSorted.Add(eng.Display(), eng);
                    CheckCollections.WorkerList.Enqueue(eng.BaseWorker);
                    CheckCollections.StringList.Enqueue(eng.BaseWorker.Show());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат введённых данных");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Элемент с таким ключом уже имеется");
                }
            }
        }

        //_______________________________________________________________________________________________________________________

        static void Part3Menu()
        {
            Console.WriteLine("         Меню:\n1. Добавить элементы\n2. Показать элементы коллекции\n3. Удаление из коллекции\n4. Поиск по коллекции\n5. Выход в главное меню");
        }

        //_______________________________________________________________________________________________________________________

        #endregion

    }

}
