using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIssion13.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; }
        [Required(ErrorMessage = "Please enter a first name.")]
        public string BowlerLastName { get; set; }
        [Required(ErrorMessage = "Please enter a Last name.")]
        public string BowlerFirstName { get; set; }
        public string BowlerMiddleInit { get; set; }
        [Required(ErrorMessage = "Please enter an address.")]
        public string BowlerAddress { get; set; }
        [Required(ErrorMessage = "Please enter a city.")]
        public string BowlerCity { get; set; }
        [Required(ErrorMessage = "Please enter a State.")]
        public string BowlerState { get; set; }
        [Required(ErrorMessage = "Please enter a zip.")]
        public string BowlerZip { get; set; }
        [Required(ErrorMessage = "Please enter a phone number.")]
        public string BowlerPhoneNumber { get; set; }

        // FK Relationship
        [Required(ErrorMessage = "Please select a team")]
        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}
