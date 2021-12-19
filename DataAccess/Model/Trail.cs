using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Trail
    {
        //THe table that will appear in the database
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "TItle Too long, try something less than 50 characters")]
        public string Name { get; set; }
        public string Distance { get; set; }
        public string Days { get; set; }
        public string Description { get; set; }

        public DateTime DateCreated { get; set; } 
        public DateTime DateUpdated { get; set; }

    }
}
