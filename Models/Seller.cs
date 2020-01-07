using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public int DepartmentId { get; set; }

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSalles(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        /// <summary>
        /// Totals the sales.
        /// Filtra as vendas entre as datas e depois retorna a soma das vendas
        /// </summary>
        /// <param name="initial">The initial.</param>
        /// <param name="final">The final.</param>
        /// <returns></returns>
        public double TotalSales(DateTime initial,DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }



    }
}
