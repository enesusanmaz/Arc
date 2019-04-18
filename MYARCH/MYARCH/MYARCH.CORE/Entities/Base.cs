using System.ComponentModel.DataAnnotations;
namespace MYARCH.CORE
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }
    }
}
