using System.ComponentModel.DataAnnotations;

namespace O_T_M_POPUP_WITHCASCADE_SP.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public IList<State> states { get; set; }

        public IList<Employee> employees { get; set; }
    }
}
