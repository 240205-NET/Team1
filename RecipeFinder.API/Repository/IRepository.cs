
using Model;

namespace Repository;

public interface IRepository
{ 
  Task<IEnumerable<User>> GetAllUsers();
  Task<User?> GetById(int id);
  Task AddUser(User user);
  Task DeleteUser(int id);
  Task MakeMealPlan()
}

