namespace BreakfastOrder.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductAddOnDetail
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int AddOnCategoryId { get; set; }

        public int AddOnOptionId { get; set; }

        [Required]
        [StringLength(50)]
        public string AddOnOptionName { get; set; }

        public virtual AddOnCategory AddOnCategory { get; set; }

        public virtual AddOnOption AddOnOption { get; set; }

        public virtual Product Product { get; set; }
    }
}
