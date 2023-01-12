using agility.models;
using management.api.sdk;

namespace NugetTest.sdk_methods
{
    public class Models
    {
        private Options _options = null;
        ClientInstance _clientInstance = null;
        public Models(Options options)
        {
            _options = options;
            _clientInstance = new ClientInstance(_options);
        }

        public Model GetModel(int id, string guid)
        {
            var resp = _clientInstance.modelMethods.GetContentModel(id, guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public Model GetModelByReferenceName(string referenceName, string guid)
        {
            var resp = _clientInstance.modelMethods.GetModelByReferenceName(referenceName, guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public List<Model> GetContentModules(bool includeDefaults, string guid, bool includeModules = false)
        {
            var resp = _clientInstance.modelMethods.GetContentModules(includeDefaults, guid, includeModules);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public List<Model> GetPageModules(string guid,bool includeDefault = false)
        {
            var resp = _clientInstance.modelMethods.GetPageModules(guid, includeDefault);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public Model SaveModel(Model model, string guid)
        {
            var resp = _clientInstance.modelMethods.SaveModel(model, guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string DeleteModel(int id, string guid)
        {
            var resp = _clientInstance.modelMethods.DeleteModel(id, guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }
    }
}
