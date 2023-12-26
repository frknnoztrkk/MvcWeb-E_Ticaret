namespace Proje.MvcWebUI.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Kategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kategori()
        {
            this.Urun = new HashSet<Urun>();
        }
    
        public int Id { get; set; }
        [DisplayName(" Kategori Adý")]
        public string Adi { get; set; }
        [DisplayName("Açýklama")]
        public string Aciklama { get; set; }
        public Nullable<int> ResimId { get; set; }
    
        public virtual Resim Resim { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urun> Urun { get; set; }
    }
}
