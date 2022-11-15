using agility.models;
using management.api.sdk;
namespace NugetTest.sdk_methods
{
    public class Batches
    {
        private Options _options = null;
        BatchMethods _methods = null;

        public Batches(Options options)
        {
            _options = options;
            _methods = new BatchMethods(_options);
        }

        public Batch GetBatch(int id)
        {
            var resp = _methods.GetBatch(id);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }
    }
}
