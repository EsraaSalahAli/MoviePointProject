using MoviePoint.Models;

namespace MoviePoint.Repository
{
    public interface ICommentsRepository
    {
        List<Comment> GetAll();
        Comment GetById(int id);
        void Insert(Comment movie);
        void Update(int id, Comment movie);
        void Delete(int id);
    }
}
