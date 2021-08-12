using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeDemo.Models {
    //数据库是随便网上下载的，所以没有注释
    [Table("customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customer_id { get; set; }
        public byte store_id { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        public string email { get; set; }
        public int address_id { get; set; }
        public byte active { get; set; }
        public DateTime create_date { get; set; }
        public DateTime? last_update { get; set; }
    }
}
