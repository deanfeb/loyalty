using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty.Entities.Master
{
    [Table("MsGroup")]
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
        public bool isDeleted { get; set; }
    }
}
