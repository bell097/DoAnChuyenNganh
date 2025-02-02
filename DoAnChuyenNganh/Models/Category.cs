﻿namespace DoAnChuyenNganh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            SmallCategories = new HashSet<SmallCategory>();
        }

        [Key]
        [Display(Name ="Mã danh mục lón")]
        public int category_id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Danh mục lớn")]
        public string category_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SmallCategory> SmallCategories { get; set; }
    }
}
