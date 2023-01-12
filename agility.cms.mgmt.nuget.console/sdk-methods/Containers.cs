using agility.models;
using management.api.sdk;
namespace NugetTest.sdk_methods
{
    public class Containers
    {
        private Options _options = null;
        ClientInstance _clientInstance = null;

        public Containers(Options options)
        {
            _options = options;
            _clientInstance = new ClientInstance(_options);
        }

        public Container GetContainerById(int id, string guid)
        {
            var resp = _clientInstance.containerMethods.GetContainerById(id, guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public Container GetContainerByRef(string referenceName, string guid)
        {
            var resp = _clientInstance.containerMethods.GetContainerByReferenceName(referenceName, guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public Container GetContainerSecurity(int id, string guid)
        {
            var resp = _clientInstance.containerMethods.GetContainerSecurity(id, guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public List<Container> GetContainerList(string guid)
        {
            var resp = _clientInstance.containerMethods.GetContainerList(guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public List<Notification> GetNotifications(int id, string guid)
        {
            var resp = _clientInstance.containerMethods.GetNotificationList(id, guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public Container SaveContainer(Container container, string guid)
        {
            var resp = _clientInstance.containerMethods.SaveContainer(container, guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string DeleteContainer(int id, string guid)
        {
            var resp = _clientInstance.containerMethods.DeleteContainer(id, guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }
    }
}
