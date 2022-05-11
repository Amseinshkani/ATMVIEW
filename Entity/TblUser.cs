using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class TblUser
    {
        [Key]
        public int Id { get; set; }
        public string HolderName { get; set; }

        public long cash { get; set; }

        public int PassWord { get; set; }

        public string NameBank { get; set; }

        public long CardNumber { get; set; }
    }
}
