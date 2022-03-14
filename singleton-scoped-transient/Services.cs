namespace singleton_scoped_transient
{
    public class SingletonService
    {
        public int Counter;

        public SingletonService()
        {
            Liste = new List<string>();
        }

        public List<string> Liste { get; set; }

    }
    public class ScopedService
    {
        public int Counter;
        public List<string> Liste { get; set; }
        public ScopedService()
        {
            Liste = new List<string>();
        }
    }
    public class TransientService
    {
        public TransientService()
        {
            Liste = new List<string>();
        }
        public int Counter;
        public List<string> Liste { get; set; }

    }
}