namespace DoAnChuyenNganh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        internal int category_id;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            BillDetails = new HashSet<BillDetail>();
            StockinDetails = new HashSet<StockinDetail>();
        }

        [Key]
        [StringLength(15)]
        [Display(Name = "Mã sản phẩm")]
        public string product_id { get; set; }
        

        [Required]
        [StringLength(150)]
        [Display(Name = "Tên sản phẩm")]
        public string product_name { get; set; }

        [Display(Name = "Thương hiệu")]
        public int brand_id { get; set; }

        [Display(Name = "Nước xuất xứ")]
        public int origin_id { get; set; }

        [Display(Name = "Danh mục")]
        public int smallcategory_id { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        public string product_image { get; set; }

        [StringLength(20)]
        [Display(Name = "Dạng bào chế")]
        public string product_format { get; set; }

        [StringLength(25)]
        [Display(Name = "Quy cách")]
        public string product_packing { get; set; }

        [StringLength(100)]
        [Display(Name = "Đối tượng sử dụng")]
        public string product_user { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Công dụng")]
        public string product_uses { get; set; }

        [StringLength(150)]
        [Display(Name = "Điều trị")]
        public string product_treatment { get; set; }

        [StringLength(15)]
        [Display(Name = "Số đăng ký")]
        public string product_number { get; set; }

        [StringLength(100)]
        [Display(Name = "Cảnh báo")]
        public string product_warning { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]
        public string product_description { get; set; }

        [StringLength(5)]
        [Display(Name = "Thuốc cần kê đơn")]
        public string prescription_drugs { get; set; }

        [Display(Name = "Giá nhập")]
        public double? product_imprice { get; set; }

        [Display(Name = "Giá bán")]
        public double? product_saleprice { get; set; }

        [Display(Name = "Trạng thái")]
        public int? product_status { get; set; }

        [Display(Name ="Số lượng")]
        public int? product_quantity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Origin Origin { get; set; }

        public virtual SmallCategory SmallCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockinDetail> StockinDetails { get; set; }
    }
}
