namespace Mapper
{
    public interface IMapper<in T, out K> 
        where T: class 
        where K:class 
    {
        K CreateMap(T entity);
    }
}