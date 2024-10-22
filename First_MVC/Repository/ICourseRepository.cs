using First_MVC.Models.Entity;

namespace First_MVC.Repository
{
    public interface ICourseRepository
    {
        public void Add(Course obj);


        public void Update(Course obj);


        public void Delete(int id);

        public List<Course> GetAll();

        public Course GetById(int id);

        public void Save();
    }
}
