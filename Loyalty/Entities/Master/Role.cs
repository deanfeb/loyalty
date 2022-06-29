using Microsoft.AspNetCore.Identity;

namespace Loyalty.Entities.Master
{
    //[Table("MsRole")]
    public class Role : IdentityRole
    {
        //[Key]
        public int RoleId { get; set; }

        //[StringLength(50)]
        //public string? RoleName { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public bool Status { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? DeletedBy { get; set; }

    }
}
