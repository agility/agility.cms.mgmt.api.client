using agility.models;
using management.api.sdk;

namespace NugetTest.sdk_methods
{
    public class Users
    {
        private Options _options = null;
        InstanceUserMethods _instanceUserMethods = null;

        public Users(Options options)
        {
            _options = options;
            _instanceUserMethods = new InstanceUserMethods(_options);
        }

        public List<WebsiteUser> GetUsers()
        {
            var resp = _instanceUserMethods.GetUsers();
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public InstanceUser SaveUser(string emailAddress, List<InstanceRole> roles, string? firstName = null, string? lastName = null)
        {
            var resp = _instanceUserMethods.SaveUser(emailAddress, roles, firstName, lastName);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string DeleteUser(int userID)
        {
            var resp = _instanceUserMethods.DeleteUser(userID);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }
    }
}
