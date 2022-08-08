using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Catalogs
{
    public class CourseCreateInput
    {
        public string UserId { get; set; }

        [Display(Name = "Kurs Kategorisi")]
        [Required]
        public string CategoryId { get; set; }

        [Display(Name = "Kurs Adı")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Kurs Açıklaması")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Kurs Resmi")]
        public string Picture { get; set; }

        [Display(Name = "Kurs Fiyatı")]
        [Required]
        public decimal Price { get; set; }

        public FeatureViewModel Feature { get; set; }
    }
}
