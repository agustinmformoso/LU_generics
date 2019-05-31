using System;
using System.Collections.Generic;
using System.Linq;
using PersonRepository.Entities;
using PersonRepository.Interfaces;
using System.Text.RegularExpressions;

namespace PersonValidator {
    public class Agustin : IPersonRepositoryBasic
    {
        private Person Find(int id) {
            return People.Find(x => x.Id == id);
        }
        public List<Person> People { get; set; }

            public void Add(Person person)
        {
            Regex regex = new Regex(@"\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
            Match match = regex.Match(person.Email);        
            
            if(People.Any(n => n.Id == person.Id)) {
                if (person.Age > 0) {
                    if(match.Success) {
                        People.Add(person);
                    }                    
                }
            }
        }

        public void Delete(int id)
        {
            Person search = Find(id);
            People.Remove(search);
        }

        public int GetCountRangeAges(int min, int max)
        {
            return (from e in People where(e.Age >= min && e.Age <= max) select e.Age).Count();
        }

        public List<Person> GetFiltered(string name, int age, string email)
        {
            Func<Person,bool> filter_age = (p) => p.Age == age;
            Func<Person,bool> filter_name = (p) => p.Name == name;
            Func<Person,bool> filter_email = (p) => p.Email.Contains(email);

            Func<Person,bool> filter = (p) => (filter_name(p) && filter_age(p) && filter_email(p));
            return (from p in People where filter(p) select p).ToList();
        }

        public Person GetPerson(int Id)
        {
            return Find(Id);            
        }

        public void Update(Person person)
        {
            Regex regex = new Regex(@"\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
            Match match = regex.Match(person.Email);        
            
            if (person.Age > 0) {
                if(People.Any(n => n.Id == person.Id)) {
                        People.Where(usr=>usr.Id == person.Id)
                        .Select(usr => { usr.Name = usr.Name + ""; return usr;} )
                        .ToList();
                }     
            }
        }
    }
}