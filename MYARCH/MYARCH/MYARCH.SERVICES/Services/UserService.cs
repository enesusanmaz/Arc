using MYARCH.CORE;
using MYARCH.CORE.Constants;
using MYARCH.DATA.GenericRepository;
using MYARCH.DATA.UnitofWork;
using MYARCH.DTO.EEntity;
using MYARCH.SERVICES.Interfaces;
using MYARCH.UTILITIES.PassOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYARCH.SERVICES.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IUnitofWork _uow;
        private EUserDTO _userDTO;
        public UserService(UnitofWork uow)
        {
            _uow = uow;
            _userRepository = _uow.GetRepository<User>();
            _userDTO = new EUserDTO();
        }

        public void Update(EUserDTO user)
        {
            var entity = _userRepository.Find(user.Id);
            if (user.WhichUpdate == "UP")
            {
                entity.UserName = user.UserName;
                entity.Password = user.Password;
            }
            if (user.WhichUpdate == "FJ")
            {
                entity.FullName = user.FullName;
                entity.Job = user.Job;
            }
            if (user.WhichUpdate == "I")
            {
                entity.Image = user.value;
            }
            //AutoMapper.Mapper.DynamicMap(user, entity);
            _userRepository.Update(entity);
        }

        public byte[] GetUserImage(int Id)
        {
            var result = _userRepository.GetAll().Where(p => p.Id == Id).SingleOrDefault();
            return result == null ? null : result.Image;
        }

        public EUserDTO Find(int Id)
        {
            var user = (from u in _userRepository.GetAll()
                        where u.Id == Id
                        select new EUserDTO
                        {
                            FullName = u.FullName,
                            Id = u.Id,
                            ImageUrl = u.Image != null ? "/ProfileImageView/" + u.Id : ConstanTypes.profileImage,
                            Job = u.Job,
                            Password = u.Password,
                            UserName = u.UserName
                        }).SingleOrDefault();
            user.Password = PassManager.Base64Decrypt(user.Password);
            return user;

        }

        public EUserDTO GetUserByUserNameAndPassword(string userName, string password)
        {
            var control = (from u in _userRepository.GetAll()
                           where u.UserName == userName &&
                           u.Password == password
                           select new EUserDTO
                           {
                               FullName = u.FullName,
                               Id = u.Id,
                               ImageUrl = u.Image != null ? "/ProfileImageView/" + u.Id : ConstanTypes.profileImage,
                               Job = u.Job,
                           }).SingleOrDefault();
            return control;
        }
    }
}
