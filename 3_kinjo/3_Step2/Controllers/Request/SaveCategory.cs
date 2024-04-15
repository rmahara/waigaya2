using System.ComponentModel.DataAnnotations.Schema;

namespace Waigaya2.Controllers.Request
{
    public class SaveCategory
    {
        public int Id { get; set; }

        public required string Title { get; set; }
    }
}
