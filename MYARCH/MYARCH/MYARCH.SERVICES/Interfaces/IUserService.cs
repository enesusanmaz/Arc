using MYARCH.CORE;
using MYARCH.DTO.EEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYARCH.SERVICES.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// kullanıcı bilgilerine güncelle.
        /// </summary>
        /// <param name="user"></param>
        void Update(EUserDTO user);

        /// <summary>
        /// kullanıcı numarasına göre resminin byte degerini getir.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        byte[] GetUserImage(int Id);

        /// <summary>
        /// kullanıcı numarasına göre kullanıcı bilgilerin getir.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        EUserDTO Find(int Id);
        
        /// <summary>
        /// kullanıcı adı ve şifreye göre kullanıcı bilgileri.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        EUserDTO GetUserByUserNameAndPassword(string userName, string password);

    }
}
