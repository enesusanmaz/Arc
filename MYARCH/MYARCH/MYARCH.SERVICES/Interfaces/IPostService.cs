using MYARCH.CORE;
using MYARCH.DTO.EEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYARCH.SERVICES.Interfaces
{
    public interface IPostService
    {
        /// <summary>
        /// makale sayısını getir.
        /// </summary>
        /// <returns></returns>
        int GetPostCount();
        /// <summary>
        /// makale numarasına göre makaleyi sil
        /// </summary>
        /// <param name="Id"></param>
        void Delete(int Id);

        /// <summary>
        /// makale bilgilerine güncelle.
        /// </summary>
        /// <param name="post"></param>
        void Update(EPostDTO post);

        /// <summary>
        ///  makale kaydı gerkçekleştir.
        /// </summary>
        /// <param name="post"></param>
        void Insert(EPostDTO post);

        /// <summary>
        /// kullanıcı id sine göre makale listesi getir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<EGetPostsByUserIdDTO> GetPostsByFilterParams(int userId, int pageNumber, string title, int? categoryId);

        /// <summary>
        /// post numarasına göre detayını getir.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        EPostDTO GetPostDetailByPostId(int postId);

        /// <summary>
        /// aynı url koduna sahip ise url kodunu değiştir.
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        string GetSlugAnyPost(string slug);

        /// <summary>
        /// kategori numarasina göre makale var mı ?
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        bool AnyPostByCategoryId(int categoryId);

        /// <summary>
        /// makale numarasına göre resmi getir.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        byte[] GetPostImageById(int Id);

        /// <summary>
        /// tüm makaleleri getir.
        /// </summary>
        /// <returns></returns>
        List<EPostUserDTO> GetPostAll(int? categoryId,int pageNumber);
        
        /// <summary>
        /// url koduna göre makale getir.
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        EPostDetailDTO GetPostDetailBySlug(string slug);
    }
}
