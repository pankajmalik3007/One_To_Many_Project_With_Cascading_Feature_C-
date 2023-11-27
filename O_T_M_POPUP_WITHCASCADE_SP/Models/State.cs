
using System.ComponentModel.DataAnnotations;

namespace O_T_M_POPUP_WITHCASCADE_SP.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(50)]
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
