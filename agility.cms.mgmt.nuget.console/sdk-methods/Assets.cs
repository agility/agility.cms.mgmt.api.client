using agility.models;
using management.api.sdk;
namespace NugetTest.sdk_methods
{
    public class Assets
    {
        private Options _options = null;
        AssetMethods _methods = null;
        public Assets(Options options)
        {
            _options = options;
            _methods = new AssetMethods(_options);
        }

        public List<Media> Upload(Dictionary<string, string> files, string agilityFolder)
        {
           

            var resp = _methods.Upload(files, agilityFolder, -1);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string DeleteFile(int mediaID)
        {
            var resp = _methods.DeleteFile(mediaID);
            var result = resp.GetAwaiter().GetResult();
            return result;
        }

        public Media MoveFile(int mediaID, string agilityFolder)
        {
            var resp = _methods.MoveFile(mediaID, agilityFolder);

            var result = resp.GetAwaiter().GetResult();
            return result;
        }

        public AssetMediaList GetMediaList()
        {
            var resp = _methods.GetMediaList(250, 0);
            var result = resp.GetAwaiter().GetResult();
            return result;
        }

        public Media GetAssetByID(int mediaID)
        {
            var resp = _methods.GetAssetByID(mediaID);
            var result = resp.GetAwaiter().GetResult();
            return result;
        }

        public Media GetAssetByURL(string url)
        {
            var resp = _methods.GetAssetByURL(url);
            var result = resp.GetAwaiter().GetResult();
            return result;
        }
    }
}
