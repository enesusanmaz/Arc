using System;
namespace MYARCH.DTO.EEntity
{
    public class EUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Job { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
        public string WhichUpdate { get; set; }
        public byte[] value { get; set; }
    }
}
