using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {            
                var list = dal.Employees.ToList();
                return list;
            }   
        }
        public void Add(Employee emp)
        {
            using (var db = new SalesERPDAL())
            {
                db.Employees.Add(emp);

                db.SaveChanges();
            }
        }
       public void Delete(int id)
        {
            using (var db = new SalesERPDAL())
            {
                Employee emp = db.Employees.Find(id);
                db.Entry(emp).State = EntityState.Deleted;

                db.SaveChanges();
            }
        }
        public void Update(Employee emp)
        {
            using (var db = new SalesERPDAL())
            {
                
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public Employee Query(int id)
        {          
            using (var db = new SalesERPDAL())
            {
                Employee emp= db.Employees.Find(id);
                return emp;
            }
        }

        public IEnumerable<Employee> Select(string name)
        {
            using (var db = new SalesERPDAL())
            {
                // 查询所有包含字符串name的
                var Employees = from b in db.Employees
                            where b.Name.Contains(name)
                            select b;
                return Employees.ToList();
            }
        }
    }
}