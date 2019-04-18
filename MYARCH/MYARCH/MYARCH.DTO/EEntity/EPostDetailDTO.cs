using System;
namespace MYARCH.DTO.EEntity
{
    public class EPostDetailDTO
    {  
        public string Title { get; set; }
        public string PostContent { get; set; }
        public string PostImageUrl { get; set; }
        public string UserImageUrl { get; set; }
        public string FullName { get; set; }
        public string Job { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedOnString { get; set; }
    }
}
