using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public void RemoveSeller(Seller seller)
        {
            Sellers.Remove(seller);
        }

        /// <summary>
        /// Retorna o total de vendas de cada vendedor , com base no metodo ja existente no Seller
        /// </summary>
        /// <param name="initial">The initial.</param>
        /// <param name="final">The final.</param>
        /// <returns></returns>
        public double TotalSales(DateTime initial , DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial,final));
        }

    }
}
