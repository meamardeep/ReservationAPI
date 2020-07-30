using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationWebAPI.Model
{
    
    public class ReservationModel
    {
        public int ReservationId { get; set; }

        public string Name { get; set; }

        public string StartLocation { get; set; }

        public string EndLocation { get; set; }

        public bool IsActive { get; set; }
    }
    
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
    }

}
