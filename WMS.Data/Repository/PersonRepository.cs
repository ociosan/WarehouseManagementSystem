﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Data.Contracts;
using WMS.Data.Entities;

namespace WMS.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly WMSDbContext _theContext;

        public PersonRepository(WMSDbContext thecontext)
        {
            _theContext = thecontext;
        }
        public bool Create(Person entity)
        {
            _theContext.Persons.Add(entity);
            return Save();
        }

        public bool Delete(Person entity)
        {
            _theContext.Persons.Remove(entity);
            return Save();
        }

        public ICollection<Person> FindAll()
        {
            return _theContext.Persons.ToList();
        }

        public Person FindById(int id)
        {
            return _theContext.Persons.Find(id);
        }

        public bool IsExists(int id)
        {
            return _theContext.Persons.Any(q => q.Id == id);
        }

        public bool Save()
        {
            return _theContext.SaveChanges() > 0;

        }

        public bool Update(Person entity)
        {
            _theContext.Update(entity);
            return Save();
        }
    }
}
