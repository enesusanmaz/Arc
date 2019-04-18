using System;
using System.Collections.Generic;
namespace MYARCH.DTO.EEntity
{
    public class EPostDetailPageDTO
    {
        public EPostDetailDTO PostDetail { get; set; }
        public List<EPostUserDTO> PostList { get; set; } 
    }
}
