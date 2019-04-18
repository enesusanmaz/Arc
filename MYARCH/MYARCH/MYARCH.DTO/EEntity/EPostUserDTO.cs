using System;
namespace MYARCH.DTO.EEntity
{
    public class EPostUserDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        //public int UserId { get; set; }
        //public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ShortDescription { get; set; }
        public string PostImageUrl { get; set; }
        public string UserImageUrl { get; set; }
        public string FullName { get; set; }
        public string Job { get; set; }
        public string Color { get; set; }
    }
}
