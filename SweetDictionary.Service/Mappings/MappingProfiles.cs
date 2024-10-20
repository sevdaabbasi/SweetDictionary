using AutoMapper;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using SweetDictionary.Models.Comments;
using SweetDictionary.Models.Categories;

namespace SweetDictionary.Service.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Post Mapping
            CreateMap<CreatePostRequestDto, Post>();
            CreateMap<Post, PostResponseDto>();

            // Comment Mapping
            CreateMap<CreateCommentRequestDto, Comment>();
            CreateMap<Comment, CommentResponseDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));

            // Category Mapping
            CreateMap<CreateCategoryRequestDto, Category>();
            CreateMap<Category, CategoryResponseDto>();
        }
    }
}