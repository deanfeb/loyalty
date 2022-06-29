using Microsoft.AspNetCore.Identity;

namespace Loyalty.Entities.Master
{
    //[Table("MsUser")]
    //[Table("AspNetUsers")]
    public class User : IdentityUser
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        //[StringLength(50)]
        //public string? UserName { get; set; }

        //[StringLength(100)]
        public string? PersonName { get; set; }

        //[StringLength(100)]
        //public string? Email { get; set; }

        public bool Status { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? DeletedBy { get; set; }

    }
}