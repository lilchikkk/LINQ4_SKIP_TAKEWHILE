namespace LINQtakeSkip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kutsume esile LINQ meetodid");
            Console.WriteLine("1. Skip");
            Console.WriteLine("2. Skip_While");
            Console.WriteLine("3. Take_While");
            Console.WriteLine("4. FirstOrDefault");
            Console.WriteLine("5. Avarage Linq");
            Console.WriteLine("6. Count Linq");
            Console.WriteLine("7. Sum");
            Console.WriteLine("8. Max Age");
            Console.WriteLine("9. MinAge");


            //siin kasutada switchi ja peab saama Skip meetodit esile kutsuda
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Skip();
                    break;

                case 2:
                    SkipWhile();
                    break;

                case 3:
                    TakeWhile();
                    break;

                case 4:
                    FirstOrDefault();
                    break;

                case 5:
                    AvarageLinq();
                    break;

                case 6:
                    CountLinq();
                    break;

                case 7:
                    Sum();
                    break;

                case 8:
                    MaxAge();
                    break;

                case 9:
                    MinAge();
                    break;

                default:
                    Console.WriteLine("vale valik");
                    break;
            }
        }

        public static void Skip()
        {
            Console.WriteLine("--------Skip-------");
            //kasuta skip ja jäta 3 tükki vahele
            var skip = PeopleList.peoples.Skip(3);

            foreach (var item in skip)
            {
                Console.WriteLine(item.Name);
            }
        }

        //teette uue meetodi, aga kasutate Skipwhile
        //ja vanemad, kui 18 peab olema tingimus
        public static void SkipWhile()
        {
            Console.WriteLine("--------Skip_While-------");
            //mis tähendab: =>. See tähendab lambda märki ja selle 
            //abil saab kasutada pikemalt slassi nimetus asemel lühendit, mis antud
            //koos sees oleva muutujaga, mis antud juhul on x.
            var skipWhile = PeopleList.peoples.SkipWhile(p => p.Age > 18);

            foreach (var item in skipWhile)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Age);
            }
            //skip while jätab loendis nii kaua vahele ridu kuni vastab tingimusele
            //ehk antud juhul jätab read vahele kuni leiab 18 a isiku 
            //ja peale seda hakkab infot jälle kuvama olenemata vanuse tingimusest
        }

        //kasutada TakeWhile ja  kutsuda see esile switchis
        //tingimus on Age > 18

        //vooskeem teha TakeWhile meetodist
        public static void TakeWhile()
        {
            Console.WriteLine("--------Take_While-------");
            var TakeWhile = PeopleList.peoples.TakeWhile(p => p.Age > 18);

            foreach (var item in TakeWhile)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Age);
            }
            //skip while isikud kuni vastab tingimusele
            //ehk antud juhul näitab anfmeid 18 a isiku 
            //ja peale seda hakkab enam ei näitab andmeid
        }

        public static void FirstOrDefault()
        {
            //peate kasutama Name ja Lenght-i.
            //Nimi peab olema vähemalt 5 tähtemärki pikk
            //kuvab esimese elemendi, mis on järjestuses
            //vastab tingimusele
            Console.WriteLine("--------FirstOrDefault-------");
            string firstLongName = PeopleList.peoples
                .FirstOrDefault(p => p.Name.Length >= 5).Name;
            if (firstLongName != null)
            {
                Console.WriteLine(firstLongName);
            }
            else
            {
                Console.WriteLine("nii pikka nime ei leitud");
            }
        }
        //kasutame Avarage Linq
        public static void AvarageLinq()
        {
            Console.WriteLine("--------AvarageLinq-------");
            double averageAge = PeopleList.peoples.Average(p => p.Age);
            Console.WriteLine("Avarage Age: '{0}' ", averageAge);
        }

        public static void CountLinq()
        {
            Console.WriteLine("--------CountLinq----------");
            var totalPersons = PeopleList.peoples.Count();
            Console.WriteLine("inimesi on kokku: " + totalPersons);
            Console.WriteLine("---------------------------");

            var adultPersons = PeopleList.peoples.Count(p => p.Age >= 18);
            Console.WriteLine("inimesi on kokku: " + adultPersons);
        }

        //kasutame summat ehk Sum
        public static void Sum()
        {
            Console.WriteLine("--------Sum----------");
            var totalAge = PeopleList.peoples.Sum(p => p.Age);
            Console.WriteLine("inimesi vanus kokku: " + totalAge);

            Console.WriteLine("-----------------------");
            var sumAdults = 0;
            var numAdults = PeopleList.peoples.Sum(p =>
            {
                if (p.Age >= 18)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });
            Console.WriteLine("Täisealiste isikute koondarv: " + numAdults);
        }
        //kasutada Max
        public static void MaxAge()
        {
            Console.WriteLine("--------MaxAge----------");
            var oldestPerson = PeopleList.peoples
                .Max(p => p.Age);
            Console.WriteLine("Kõige vanem isik on: " + oldestPerson);

        }
        public static void MinAge()
        {
            Console.WriteLine("--------MinAge----------");
            var youngestPerson = PeopleList.peoples
                .Min(p => p.Age);
            Console.WriteLine("Kõige noorem isik on: " + youngestPerson);

        }
    }
}


