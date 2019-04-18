using MYARCH.CORE;
using MYARCH.CORE.Constants;
using MYARCH.DATA.GenericRepository;
using MYARCH.DATA.UnitofWork;
using MYARCH.DTO.EEntity;
using MYARCH.SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYARCH.SERVICES.Services
{
    public class PostService : IPostService
    {
        private readonly IGenericRepository<Post> _postRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IUnitofWork _uow;

        public PostService(UnitofWork uow)
        {
            _uow = uow;
            _postRepository = uow.GetRepository<Post>();
            _userRepository = uow.GetRepository<User>();
            _categoryRepository = uow.GetRepository<Category>();
        }

        public EPostDTO GetPostDetailByPostId(int postId)
        {
            var post = (from p in _postRepository.GetAll()
                        where p.Id == postId
                        select new EPostDTO
                        {
                            Id = p.Id,
                            CategoryId = p.CategoryId,
                            IsActive = p.IsActive,
                            ModifiedOn = p.ModifiedOn,
                            PostContent = p.PostContent,
                            ShortDescription = p.ShortDescription,
                            Slug = p.Slug,
                            Title = p.Title,
                            ImageUrl = "/postimageview/" + p.Id + "/60/60"
                        }).SingleOrDefault();
            post.ModifiedOnString = post.ModifiedOn.ToString("yyyy-MM-ddThh:mm");

            return post;
        }

        public List<EPostUserDTO> GetPostAll(int? categoryId,int pageNumber)
        {
            var post = (from p in _postRepository.GetAll()
                        join u in _userRepository.GetAll() on p.UserId equals u.Id
                        join c in _categoryRepository.GetAll() on p.CategoryId equals c.Id
                        where p.IsActive == true
                        && (categoryId != null ? p.CategoryId == categoryId : 1 == 1)
                        orderby p.CreatedOn descending
                        select new EPostUserDTO
                        {
                            CategoryId = p.CategoryId,
                            CategoryName = c.Name,
                            Title = p.Title,
                            Slug = p.Slug,
                            ShortDescription = p.ShortDescription,
                            PostImageUrl = "/postimageview/" + p.Id,
                            UserImageUrl = "/profileimageview/" + u.Id,
                            FullName = u.FullName,
                            Job = u.Job,
                            Color = c.Color
                        }).Skip(pageNumber * ConstanTypes.SitePostCount).Take(ConstanTypes.SitePostCount).ToList();

            return post;
        }
        public EPostDetailDTO GetPostDetailBySlug(string slug)
        {
            var post = (from p in _postRepository.GetAll()
                        join u in _userRepository.GetAll() on p.UserId equals u.Id
                        join c in _categoryRepository.GetAll() on p.CategoryId equals c.Id
                        where p.IsActive == true
                        && p.Slug == slug
                        select new EPostDetailDTO
                        {
                            Title = p.Title,
                            PostImageUrl = "/postimageview/" + p.Id,
                            UserImageUrl = "/profileimageview/" + u.Id,
                            FullName = u.FullName,
                            Job = u.Job,
                            PostContent = p.PostContent,
                            CreatedOn = p.CreatedOn,
                        }).SingleOrDefault();
            post.CreatedOnString = post.CreatedOn.ToString("dd MMMM yyyy hh:mm");
            return post;
        }
        public string GetSlugAnyPost(string slug)
        {
            int count = 0;
            string orgSlug = slug;
            while (_postRepository.GetAll().Where(p => p.Slug == slug).SingleOrDefault() != null)
            {
                count++;
                var result = _postRepository.GetAll().Where(p => p.Slug == slug).SingleOrDefault();
                slug = orgSlug + "-" + count;
            }
            return slug;
        }

        public bool AnyPostByCategoryId(int categoryId)
        {
            return _postRepository.GetAll().Any(p => p.CategoryId == categoryId);
        }

        public byte[] GetPostImageById(int Id)
        {
            var result = _postRepository.GetAll().Where(p => p.Id == Id).SingleOrDefault();
            return result == null ? null : result.Image;
        }


        public List<EGetPostsByUserIdDTO> GetPostsByFilterParams(int userId, int pageNumber, string title, int? categoryId)
        {
            var List = (from p in _postRepository.GetAll()
                        where p.UserId == userId
                        && (categoryId != null ? (p.CategoryId == categoryId.Value) : true)
                        && (title != null ? (p.Title.Contains(title)) : true)
                        orderby p.Id descending
                        select new EGetPostsByUserIdDTO
                        {
                            PostId = p.Id,
                            Title = p.Title,
                            CreatedOn = p.CreatedOn,
                            IsActive = p.IsActive,
                        }).Skip(pageNumber * ConstanTypes.listCount).Take(ConstanTypes.listCount).ToList();
            foreach (var item in List)
            {
                item.CreatedOnString = item.CreatedOn.ToString("dd.MM.yyyy hh:mm");
            }
            return List;
        }
        public int GetPostCount()
        {
            var count = _postRepository.GetAll().Count();
            var result = count / ConstanTypes.listCount;
            if (count % ConstanTypes.listCount == 0)
                return Convert.ToInt32(result);
            else
                return Convert.ToInt32(result + 1);
        }
        public void Insert(EPostDTO post)
        {
            var postEntity = AutoMapper.Mapper.DynamicMap<Post>(post);
            postEntity.CreatedOn = DateTime.Now;
            _postRepository.Insert(postEntity);
        }

        public void Update(EPostDTO post)
        {
            var postEntity = _postRepository.Find(post.Id);
            AutoMapper.Mapper.DynamicMap(post, postEntity);
            _postRepository.Update(postEntity);
        }
        public void Delete(int Id)
        {
            var postEntity = _postRepository.Find(Id);
            _postRepository.Delete(postEntity);
        }
    }
}
