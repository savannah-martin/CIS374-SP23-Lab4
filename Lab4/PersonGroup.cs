using System;
using System.Collections.Generic;

namespace Lab4
{
    public class PersonGroup
    {
        public List<Person> Persons { get; set; } = new List<Person>();

        public char? StartingLetter {
            get {
                // if Persons is SORTED
                return Persons[0].FirstName[0];
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (Persons.Count == 0)
                {
                    return true;
                }
                else return false;
            }
        }

        // DONE
        public char? EndingLetter {
            get
            {
                // if Persons is SORTED
                return Persons[-1].FirstName[0];
            }
        }

        public int Count => Persons.Count;

        public Person this[int i]
        {
            get
            {
                if (Persons == null)
                    throw new NullReferenceException("Persons is null");

                if (i < 0 || i > Persons.Count)
                    throw new IndexOutOfRangeException();

                Persons.Sort();
                return Persons[i];
            }
        }

        public PersonGroup(List<Person> persons = null)
        {
            if( persons != null)
            {
                foreach(var p in persons)
                {
                    Persons.Add(p);
                }
            }

            Persons.Sort();
        }

        public override string ToString()
        {
            return "[" + String.Join(", ", Persons)+ "]";
        }


        // DONE
        public static List<PersonGroup> GeneratePersonGroups(List<Person> persons, int distance)
        {
            persons.Sort();

            // list of groups
            var personGroups = new List<PersonGroup>();

            // new group of people
            var currentGroup = new PersonGroup();

            foreach (Person person in persons)
            {

                if (currentGroup.IsEmpty)
                {
                    currentGroup.Persons.Add(person);
                }

                else if (person.Distance(currentGroup[0]) <= distance)
                {
                    currentGroup.Persons.Add(person);
                }
                else
                {
                    personGroups.Add(currentGroup);
                    currentGroup = new PersonGroup();
                    currentGroup.Persons.Add(person);
                }
            }

            return personGroups;
        }
    }
}
