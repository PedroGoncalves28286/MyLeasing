using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Entities
{
    public class Owner :IEntity
    {
        internal object OwnerName;

        public int Id { get; set; }

        [Required]   
        public double Document { get; set; }

        [Required] 
        [MaxLength(50, ErrorMessage ="The field{0} can contain {1} characters length.")]
        [Display(Name = "Owner Name")]
        public string Name { get; set; }

        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; }

        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        public string Address { get; set; }
        public object User { get; internal set; }
    }
}
