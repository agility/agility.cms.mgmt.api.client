using agility.models;
using management.api.sdk;
namespace NugetTest.sdk_methods
{
    public class Batches
    {
        private Options _options = null;
        ClientInstance _clientInstance = null;

        public Batches(Options options)
        {
            _options = options;
            _clientInstance = new ClientInstance(_options);
        }

        public Batch GetBatch(int id, string guid)
        {
            var resp = _clientInstance.batchMethods.GetBatch(id, guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }
    }
}
