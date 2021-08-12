using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeDemo.Models {
    //数据库是随便网上下载的，所以没有注释
    [Table("address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int address_id { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string district { get; set; }
        public int city_id { get; set; }
        public string postal_code { get; set; }
        public string phone { get; set; }
        public string location { get; set; }
        public DateTime last_update { get; set; }
    }
}
