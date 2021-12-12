using System;
/*Иерархия
  Разработчик  Вирус  CConficker
  Разработчик  ПО  Игрушка  Сапер
  Разработчик  ПО  Текстовый редактор  Word
*/

namespace Lab_5
{
    class Program
    {
        //Одноименные методы
        interface IInterface1
        {
            void Method1();
        }
        interface IInterface2
        {
            void Method1();
        }

        class KakoytoClass : IInterface2, IInterface1
        {
            void IInterface1.Method1()
            {
                Console.WriteLine("Interface1");
            }
            void IInterface2.Method1()
            {
                Console.WriteLine("Interface2");
            }
        }

        // интерфейс
        interface ISetOfOperations
        {
            void info();

            static void Hello()
            {
                Console.WriteLine("Privet");
            }
            static int MaxNumber = 9;
            const int MinNumber = 0;
        } // Интерфейс

        class Developer
        {
            public string developer { set; get; }

            public override string ToString()
            {
                return $"Dev: {developer}";
            }
        }
        //абстрактный класс
        abstract class Software : Developer
        {
            public string name { set; get; }        //название ПО
            public string type { set; get; }        //тип ПО
            public string developer { set; get; }   //разраб ПО

            public override string ToString()
            {
                return $"Software: {name}, {type}, {developer}";
            }

            public abstract void NewMethod();

        }

        // Ветка: разработчик Вирус  CConficker
        class Virus : Developer
        {
            public string name { set; get; }//имя вируса
            public string type { set; get; }//тип вируса
            public string developer { set; get; }//разраб вируса
            public void Name()
            {
                Console.WriteLine($"Название вируса: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип вируса: {type}");
            }
            public void Developer()
            {
                Console.WriteLine($"Разработчик вируса: {developer} \n");
            }
        }
        sealed class CConficker : Virus, ISetOfOperations
        {
            public void info()
            {
                Console.WriteLine($"Description: {developer}");
            }

            public override string ToString()
            {
                return $"CConficker: {name}, {type}";
            }

        }

        // Ветка: разраб ПО игрушка сапер
        class Game : Software, ISetOfOperations
        {
            public string developer { set; get; }

            public void Developer()
            {
                Console.WriteLine($"Разработчик сапера: {developer} \n");
            }

            public void info()
            {
                Console.WriteLine("<- Game is Saper ->");
            }

            public override void NewMethod()
            {
                Console.WriteLine("Abstr meth");
            }
        }
        class Saper : Game
        {
            public void Name()
            {
                Console.WriteLine($"Название игрушки: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип игрушки: {type}");
            }
            public override string ToString()
            {
                return $"Saper: {name}, {type}, {developer}";
            }

        }


        // Ветка: разработчик ПО Текстовый процессор Word
        class WordProcessor : Software, ISetOfOperations
        {
            public string developer { set; get; }

            public void Developer()
            {
                Console.WriteLine($"Разработчик текстового процессора: {developer} \n");
            }

            public void info()
            {
                Console.WriteLine("<- WordProcessor is Word ->");
            }

            public override void NewMethod()
            {
                Console.WriteLine("Abstr meth2");
            }
        }

        class Word : WordProcessor
        {
            public void Name()
            {
                Console.WriteLine($"Название: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип: {type}");
            }
            public override string ToString()
            {
                return $"Word: {name}, {type}, {developer}";
            }
        }

        // Printer с полиморфным методом IAmPrinting
        class Printer : APrinter
        {
            public string IamPrinting;
        }
        abstract class APrinter
        {
            public void IamPrinting(Developer someobj)
            {
                Console.WriteLine($"Тип этого обьекта: " + someobj.GetType());
                Console.WriteLine(someobj.ToString());
            }
        }


        class Over
        {
            public string name { get; set; } = "Overriding";

            public Over(string fame)
            {
                this.name = fame;
            }

            public override int GetHashCode()
            {
                Console.WriteLine($"\nHash of {this.name} is: {name.GetHashCode()}\n");
                return name.GetHashCode();
            }

            public override string ToString()
            {
                return $"{name}\n";
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                Over el = obj as Over;
                if (el as Over == null)
                    return false;

                return el.name == this.name;
            }
        }

        static void Main(string[] args)
        {
            CConficker conf = new CConficker { name = "zorizr.dll", type = "Computer worm", developer = "Hacker" };
            conf.Name();
            conf.Type();
            conf.Developer();
            Saper saper = new Saper { name = "Saper", type = "Game", developer = "Microsoft" };
            saper.Name();
            saper.Type();
            saper.Developer();
            Word word = new Word { name = "Word", type = "Program", developer = "Microsoft" };
            word.Name();
            word.Type();
            word.Developer();

            Printer print = new Printer();
            print.IamPrinting(conf);
            print.IamPrinting(saper);
            print.IamPrinting(word);

            Virus Vir = conf as CConficker;
            if (Vir == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                Console.WriteLine("Преобразование прошло удачно");
            }
            if (saper is Saper)
            {
                Saper soft2 = (Saper)saper;
                Console.WriteLine("Преобразование допустимо");
            }
            else
            {
                Console.WriteLine("Преобразование не допустимо");
            }

            // Одноименные методы
            KakoytoClass interf = new KakoytoClass();
            ((IInterface1)interf).Method1();
            ((IInterface2)interf).Method1();

            ISetOfOperations.Hello();
        }
    }
}