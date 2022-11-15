using agility.models;
using management.api.sdk;
namespace NugetTest.sdk_methods
{
    public class Containers
    {
        private Options _options = null;
        ContainerMethods _containerMethods = null;

        public Containers(Options options)
        {
            _options = options;
            _containerMethods = new ContainerMethods(_options);
        }

        public Container GetContainerById(int id)
        {
            var resp = _containerMethods.GetContainerById(id);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public Container GetContainerByRef(string referenceName)
        {
            var resp = _containerMethods.GetContainerByReferenceName(referenceName);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public Container GetContainerSecurity(int id)
        {
            var resp = _containerMethods.GetContainerSecurity(id);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public List<Container> GetContainerList()
        {
            var resp = _containerMethods.GetContainerList();
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public List<Notification> GetNotifications(int id)
        {
            var resp = _containerMethods.GetNotificationList(id);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public Container SaveContainer(Container container)
        {
            var resp = _containerMethods.SaveContainer(container);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string DeleteContainer(int id)
        {
            var resp = _containerMethods.DeleteContainer(id);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }
    }
}
