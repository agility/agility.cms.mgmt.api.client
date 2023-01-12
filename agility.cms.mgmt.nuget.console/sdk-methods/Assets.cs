using agility.models;
using management.api.sdk;
namespace NugetTest.sdk_methods
{
    public class Assets
    {
        private Options _options = null;
        ClientInstance _clientInstance = null;
        public Assets(Options options)
        {
            _options = options;
            _clientInstance = new ClientInstance(_options);
        }

        public List<Media> Upload(Dictionary<string, string> files, string guid, string agilityFolder)
        {
            var resp = _clientInstance.assetMethods.Upload(files, guid, agilityFolder, -1);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string DeleteFile(int mediaID, string guid)
        {
            var resp = _clientInstance.assetMethods.DeleteFile(mediaID, guid);
            var result = resp.GetAwaiter().GetResult();
            return result;
        }

        public Media MoveFile(int mediaID, string agilityFolder, string guid)
        {
            var resp = _clientInstance.assetMethods.MoveFile(mediaID, agilityFolder, guid);

            var result = resp.GetAwaiter().GetResult();
            return result;
        }

        public AssetMediaList GetMediaList(string guid)
        {
            var resp = _clientInstance.assetMethods.GetMediaList(250, 0, guid);
            var result = resp.GetAwaiter().GetResult();
            return result;
        }

        public Media GetAssetByID(int mediaID, string guid)
        {
            var resp = _clientInstance.assetMethods.GetAssetByID(mediaID, guid);
            var result = resp.GetAwaiter().GetResult();
            return result;
        }

        public Media GetAssetByURL(string url, string guid)
        {
            var resp = _clientInstance.assetMethods.GetAssetByURL(url, guid);
            var result = resp.GetAwaiter().GetResult();
            return result;
        }
    }
}
