using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O_T_M_POPUP_WITHCASCADE_SP.Models
{
    public class Employee
    {
        [Key]
        public int Emp_ID { get; set; }
        public string Emp_name { get; set; }

        public string Gender { get; set; }
       public string Sallary { get; set; }

        public int Dep_ID { get; set; }
        public int StateId { get; set; }

        public int CityId { get; set; }
        public int CountryId { get; set; }

        public Department department { get; set; }
        public City City { get; set; }
        public State State { get; set; }

        public Country Country { get; set; }
    }
}
