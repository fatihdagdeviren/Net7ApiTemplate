using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity
    {    
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}