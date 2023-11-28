using System.Linq;

namespace FamilyMembers
{
    public class Person
    {
        private Person? mother;
        private Person? father;

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly Birthday { get; set; }
        public Gender Gender { get; set; }
        public Person? Mother
        {
            get { return mother; }

            set
            {
                mother = value;
                value?.Children.Add(this);
            }
        }
        public Person? Father
        {
            get { return father; }

            set
            {
                father = value;
                value?.Children.Add(this);
            }
        }

        public Person? Partner { get; set; }

        public List<Person> Children { get; set; }

        public Person(string name, string surname, DateOnly birthday, Gender gender)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Gender = gender;
            Children = new List<Person>();
        }

        public Person[] GetParents()
        {
            return new Person[] { Mother, Father };
        }

        public Person[] GetGrandmothers()
        {
            return new Person[] { Mother?.Mother, Father?.Mother };
        }

        public Person[] GetGrandfathers()
        {
            return new Person[] { Mother?.Father, Father?.Father };
        }

        public List<Person> GetBrothers(Person person)
        {
            List<Person> brothers = new List<Person>();
            Person[] parents = person.GetParents();
            foreach (Person parent in parents)
            {
                if (parent != null)
                {
                    brothers.AddRange(from Person child in parent.Children
                                      select child);
                }
            }

            brothers = brothers.Distinct().ToList();
            brothers.Remove(this);
            return brothers;
        }

        public List<Person> GetAllBrothers()
        {
            List<Person> brothers = new List<Person>();
            List<Person> parentBrothers = new List<Person>();
            brothers.AddRange(GetBrothers(this));
            if (Mother != null) parentBrothers.AddRange(GetBrothers(Mother));
            if (Father != null) parentBrothers.AddRange(GetBrothers(Father));
            foreach (Person person in parentBrothers)
            {
                if (person != null)
                {
                    brothers.AddRange(from Person child in person.Children
                                      select child);
                }
            }
            brothers = brothers.Distinct().ToList();
            brothers.Remove(this);
            return brothers;
        }


        public string GetFullName()
        {
            return Name + " " + Surname;
        }

        public void PrintInfoAboutPerson()
        {
            Console.WriteLine("Родители:");
            Print(GetParents());

            Console.WriteLine("Муж/жена: ");
            Console.WriteLine(Partner == null ? "--" : Partner.GetFullName());

            Console.WriteLine("Бабушки:");
            Print(GetGrandmothers());

            Console.WriteLine("Дедушки:");
            Print(GetGrandfathers());

            Console.WriteLine("Дети:");
            Print(Children);

            Console.WriteLine("Братья/сестры:");
            Print(GetAllBrothers());
        }

        public void Print(Person[] persons)
        {
            foreach (Person person in persons)
            {
                if (person == null) Console.WriteLine("--");
                else Console.WriteLine(person.GetFullName());
            }
        }
        public void Print(List<Person> persons)
        {
            if (persons == null || persons.Count == 0) { Console.WriteLine("--"); }
            else
            {
                foreach (Person person in persons)
                {
                    if (person != null) Console.WriteLine(person.GetFullName());
                }
            }
        }
    }
}
