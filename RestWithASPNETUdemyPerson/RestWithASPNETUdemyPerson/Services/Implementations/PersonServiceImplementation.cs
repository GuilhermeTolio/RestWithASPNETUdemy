using RestWithASPNETUdemyPerson.Model;

namespace RestWithASPNETUdemyPerson.Services.Implementations;

public class PersonServiceImplementation : IPersonService
{
    private volatile int count;

    public Person Create(Person person)
    {
        return person;
    }

    public Person Update(Person person)
    {
        return person;
    }

    public List<Person> FindAll()
    {
        List<Person> persons = new List<Person>();
        for (int i = 0; i < 8; i++)
        {
            Person person = MockPerson(i);
            persons.Add(person);
        }
        return persons;
    }

    private Person MockPerson(int i)
    {
        return new Person
        {
            Id = IncrementAndGet(),
            FirstName = "Person Name" + i,
            LastName = "Person Last Name" + i,
            Address = "Person Address" + i,
            Gender = "Person Gender" + i
        };
    }

    public Person FindById(long id)
    {
        return new Person
        {
            Id = IncrementAndGet(),
            FirstName = "John",
            LastName = "Doe",
            Address = "123 Main Street",
            Gender = "Male"
        };
    }

    private long IncrementAndGet()
    {
        return Interlocked.Increment(ref count);
    }

    public void Delete(long id)
    {
 
    }
}