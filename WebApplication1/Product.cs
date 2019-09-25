//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.BasketProducts = new HashSet<BasketProducts>();
            this.ProductImg = new HashSet<ProductImg>();
        }
        
        public int ProductId { get; set; }
        [Display(Name = "�r�n Kodu")]
        public string ProductCode { get; set; }
        [Display(Name = "�sim")]
        public string Name { get; set; }
        [Display(Name = "A��klama")]
        public string Explanation { get; set; }
        [Display(Name = "Fiyat")]
        public double Price { get; set; }
        [Display(Name = "Stok Adedi")]
        public int Stock { get; set; }
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        [Display(Name = "T�r")]
        public int GenusId { get; set; }
        [Display(Name = "Cinsiyet")]
        public int GenderId { get; set; }
        [Display(Name = "Renk")]
        public int ColorId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BasketProducts> BasketProducts { get; set; }
        [Display(Name = "Kategori")]
        public virtual Category Category { get; set; }
        [Display(Name = "Renk")]
        public virtual Color Color { get; set; }
        [Display(Name = "Cinsiyet")]
        public virtual Gender Gender { get; set; }
        [Display(Name = "T�r")]
        public virtual Genus Genus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImg> ProductImg { get; set; }
    }
}
