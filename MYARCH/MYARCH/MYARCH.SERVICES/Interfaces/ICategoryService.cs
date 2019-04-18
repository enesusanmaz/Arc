using MYARCH.CORE;
using MYARCH.DTO.EEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYARCH.SERVICES.Interfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// kategori numarasına göre kategoriyi sil
        /// </summary>
        /// <param name="Id"></param>
        void Delete(int Id);

        /// <summary>
        /// kategori bilgilerine güncelle.
        /// </summary>
        /// <param name="category"></param>
        void Update(ECategoryDTO category);

        /// <summary>
        ///  kategori kaydı gerkçekleştir.
        /// </summary>
        /// <param name="category"></param>
        void Insert(ECategoryDTO category);

        /// <summary>
        /// kategori numarsına göre detayını getir.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        ECategoryDTO GetCategoryDetailByCategoryId(int categoryId);

        /// <summary>
        /// tüm kategorileri getir.
        /// </summary>
        /// <returns></returns>
        List<ECategoryDTO> GetCategories();
    }
}
