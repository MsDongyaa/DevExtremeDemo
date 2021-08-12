using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeDemo.Models {
    //���ݿ�������������صģ�����û��ע��
    [Table("store")]
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte store_id { get; set; }
        public byte manager_staff_id { get; set; }
        public int address_id { get; set; }
        public DateTime last_update { get; set; }
    }
}
