
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace O_T_M_POPUP_WITHCASCADE_SP.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(50)]
        public string CityName { get; set; }
      
        public int StateId { get; set; }
      
        public State State { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
