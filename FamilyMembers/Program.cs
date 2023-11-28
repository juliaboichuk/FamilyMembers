namespace FamilyMembers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person firstGrandmother = new Person(
                "Ольга", "Дихтярь", new DateOnly(1960, 1, 1), Gender.woman
            );
            Person secondGrandmother = new Person(
                "Надежда", "Бойчук", new DateOnly(1961, 2, 2), Gender.woman
            );

            Person firstGrandfather = new Person(
                "Василий", "Дихтярь", new DateOnly(1962, 3, 3), Gender.man
            );
            Person secondGrandfather = new Person(
                "Валерий", "Бойчук", new DateOnly(1963, 4, 4), Gender.man
            );
            firstGrandmother.Partner = firstGrandfather;
            secondGrandmother.Partner = secondGrandfather;
            firstGrandfather.Partner = firstGrandmother;
            secondGrandfather.Partner = secondGrandmother;

            Person mother = new Person(
                "Юлия", "Бойчук", new DateOnly(1980, 5, 5), Gender.woman
            );
            Person father = new Person(
                "Иван", "Дихтярь", new DateOnly(1981, 6, 6), Gender.man
            );
            mother.Mother = secondGrandmother;
            mother.Father = secondGrandfather;
            mother.Partner = father;

            father.Mother = firstGrandmother;
            father.Father = firstGrandfather;
            father.Partner = mother;


            Person firstChild = new Person(
                "Полина", "Дихтярь", new DateOnly(2000, 7, 7), Gender.woman
            );
            Person secondChild = new Person(
                "Сергей", "Дихтярь", new DateOnly(2001, 8, 8), Gender.man
            );
            firstChild.Mother = mother;
            firstChild.Father = father;
            secondChild.Mother = mother;
            secondChild.Father = father;

            Person motherSister = new Person(
                "Татьяна", "Дихтярь", new DateOnly(1877, 9, 9), Gender.woman
            );
            Person motherSisterChild = new Person(
                "Давид", "Дихтярь", new DateOnly(2001, 10, 10), Gender.man
            );
            motherSister.Mother = firstGrandmother;
            motherSister.Father = firstGrandfather;
            motherSisterChild.Mother = motherSister;

            Console.WriteLine("Первая бабушка: " + firstGrandmother.GetFullName());
            firstGrandmother.PrintInfoAboutPerson();
            Console.WriteLine();

            Console.WriteLine("Вторая бабушка: " + secondGrandmother.GetFullName());
            secondGrandmother.PrintInfoAboutPerson();
            Console.WriteLine();

            Console.WriteLine("Первый дедушка: " + firstGrandfather.GetFullName());
            firstGrandfather.PrintInfoAboutPerson();
            Console.WriteLine();

            Console.WriteLine("Второй  дедушка: " + secondGrandfather.GetFullName());
            secondGrandfather.PrintInfoAboutPerson();
            Console.WriteLine();

            Console.WriteLine("Мама: " + mother.GetFullName());
            mother.PrintInfoAboutPerson();
            Console.WriteLine();

            Console.WriteLine("Папа: " + father.GetFullName());
            father.PrintInfoAboutPerson();
            Console.WriteLine();

            Console.WriteLine("Ребенок 1: " + firstChild.GetFullName());
            firstChild.PrintInfoAboutPerson();
            Console.WriteLine();

            Console.WriteLine("Ребенок 2: " + secondChild.GetFullName());
            secondChild.PrintInfoAboutPerson();
            Console.WriteLine();

            Console.WriteLine("Сестра мамы: " + motherSister.GetFullName());
            motherSister.PrintInfoAboutPerson();
            Console.WriteLine();

            Console.WriteLine("Двоюродный брат ребенка: " + motherSisterChild.GetFullName());
            motherSisterChild.PrintInfoAboutPerson();
            Console.WriteLine();

        }
        
    }
}