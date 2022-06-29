using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty.Entities.Master
{
    [Table("MsMenu")]
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        public string? UrlAddress { get; set; }
        public string? Icon { get; set; }
        public string? Title { get; set; }
        public int Parent { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public bool Feature { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
        public bool isDeleted { get; set; }
    }
}
