using System; 
namespace MYARCH.DTO.EEntity
{
    public class EGetPostsByUserIdDTO
    {
        public int PostId { get; set; } 
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedOnString { get; set; } 
        public bool IsActive { get; set; }
    }
}
