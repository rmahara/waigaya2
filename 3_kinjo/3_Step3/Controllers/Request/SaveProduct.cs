using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Waigaya2.Models;

namespace Waigaya2.Controllers.Request
{
    public class SaveProduct
    {
        public int? Id { get; set; }

        public required string Name { get; set; }

        public string Description { get; set; } = "";

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
