namespace DoAnChuyenNganh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SmallCategory")]
    public partial class SmallCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SmallCategory()
        {
            Products = new HashSet<Product>();
        }

        public int category_id { get; set; }

        [Key]
        public int smallcategory_id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Danh mục")]
        public string smallcategory_name { get; set; }

        //[Display(Name = "Danh mục")]
        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
