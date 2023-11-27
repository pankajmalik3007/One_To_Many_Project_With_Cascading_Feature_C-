using System.ComponentModel.DataAnnotations;

namespace O_T_M_POPUP_WITHCASCADE_SP.Models
{
    public class Department
    {
        [Key]
        public int Dep_ID { get; set; }
        public string Dep_Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
