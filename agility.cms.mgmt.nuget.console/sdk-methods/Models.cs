using agility.models;
using management.api.sdk;

namespace NugetTest.sdk_methods
{
    public class Models
    {
        private Options _options = null;
        ModelMethods _modelMethods = null;
        public Models(Options options)
        {
            _options = options;
            _modelMethods = new ModelMethods(_options);
        }

        public Model GetModel(int id)
        {
            var resp = _modelMethods.GetContentModel(id);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public List<Model> GetContentModules(bool includeDefaults, bool includeModules = false)
        {
            var resp = _modelMethods.GetContentModules(includeDefaults, includeModules);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public List<Model> GetPageModules(bool includeDefault = false)
        {
            var resp = _modelMethods.GetPageModules(includeDefault);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public Model SaveModel(Model model)
        {
            var resp = _modelMethods.SaveModel(model);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string DeleteModel(int id)
        {
            var resp = _modelMethods.DeleteModel(id);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }
    }
}
