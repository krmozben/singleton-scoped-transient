namespace singleton_scoped_transient
{
    public class Example
    {
        SingletonService _singletonService;
        ScopedService _scopedService;
        TransientService _transientService;

        public Example(SingletonService singletonService, ScopedService scopedService, TransientService transientService)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
        }

        public void olustur()
        {
            _singletonService.Liste.Add("singleton test 1");
            _scopedService.Liste.Add("scoped test 1");
            _transientService.Liste.Add("transient test 1");
        }
    }
}
