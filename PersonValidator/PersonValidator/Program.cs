using PersonRepository.Interfaces;
using PersonRepository;

namespace PersonValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            var va = new ValidatorTest();
            va.Validate(new Agustin());
        }
    }
}
