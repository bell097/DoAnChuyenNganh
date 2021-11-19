namespace DoAnChuyenNganh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockinDetail")]
    public partial class StockinDetail
    {
        [Key]
        
        public int stockindetail_id { get; set; }
        [Display(Name = "Mã nhập kho")]
        public int stockin_id { get; set; }

        //[Required]
        //[StringLength(15)]
        [Display(Name = "Sản phẩm")]
        public string product_id { get; set; }
        [Display(Name ="Số lượng nhập")]
        public int stockin_quantity { get; set; }
        [Display(Name ="Giá nhập")]
        public double impirce { get; set; }

        public virtual Product Product { get; set; }

        public virtual StockIn StockIn { get; set; }

        public string productname;
    }
}
