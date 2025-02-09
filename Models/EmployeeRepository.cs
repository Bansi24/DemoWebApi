﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DemoWebApi.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlDbContext db = new SqlDbContext();
        public async Task Add(Employee employee)
        {
           // employee.Id = Guid.NewGuid().toin();
            db.Employees.Add(employee);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Employee> GetEmployee(string id)
        {
            try
            {
                Employee employee = await db.Employees.FindAsync(id);
                if (employee == null)
                {
                    return null;
                }
                return employee;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                var employees = await db.Employees.ToListAsync();
                return employees.AsQueryable();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Employee employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(string id)
        {
            try
            {
                Employee employee = await db.Employees.FindAsync(id);
                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        //private bool EmployeeExists(string id)
        //{
        //    return db.Employees.Count(e => e.Id == id) > 0;
        //}

    }
}