using First_MVC.Models;
using First_MVC.Repository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace First_MVC.Repository
{
    public class GenericRepository<T>  :IGenericRepository<T>  where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        // Constructor to initialize the context and the DbSet
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Add method to insert an entity
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        // Update method to update an existing entity
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        // Delete method to delete an entity by ID
        public void Delete(int id)
        {
            T entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        // Get all entities
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable(); // Use this to allow further querying
        }

        // Get all entities as a List
        public List<T> GetAllAsList()
        {
            return _dbSet.ToList(); // Return List of entities
        }

        // Get an entity by its ID
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        // Save method to commit the changes to the database
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
