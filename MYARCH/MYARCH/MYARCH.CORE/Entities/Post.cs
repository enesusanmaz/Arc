using System;
namespace MYARCH.CORE
{
    public partial class Post : Base
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public byte[] Image { get; set; }
        public string ShortDescription { get; set; }
        public string PostContent { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
