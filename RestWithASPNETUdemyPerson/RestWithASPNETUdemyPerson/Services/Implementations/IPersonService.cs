using RestWithASPNETUdemyPerson.Model;

namespace RestWithASPNETUdemyPerson.Services.Implementations;

public interface IPersonService
{
    Person Create(Person person);
    Person Update(Person person);
    List<Person> FindAll();
    Person FindById(long id);
    void Delete(long id);
}