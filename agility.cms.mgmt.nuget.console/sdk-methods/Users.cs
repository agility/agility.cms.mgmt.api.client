using agility.models;
using management.api.sdk;

namespace NugetTest.sdk_methods
{
    public class Users
    {
        private Options _options = null;
        ClientInstance _clientInstance = null;

        public Users(Options options)
        {
            _options = options;
            _clientInstance = new ClientInstance(_options);
        }

        public List<WebsiteUser> GetUsers(string guid)
        {
            var resp = _clientInstance.instanceUserMethods.GetUsers(guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public InstanceUser SaveUser(string emailAddress, List<InstanceRole> roles, string guid, string? firstName = null, string? lastName = null)
        {
            var resp = _clientInstance.instanceUserMethods.SaveUser(emailAddress, roles, guid, firstName, lastName);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string DeleteUser(int userID, string guid)
        {
            var resp = _clientInstance.instanceUserMethods.DeleteUser(userID,guid);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }
    }
}
