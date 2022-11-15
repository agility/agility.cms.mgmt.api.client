using agility.models;
using management.api.sdk;

namespace NugetTest.sdk_methods
{
    public class Contents
    {
        private Options _options = null;
        ContentMethods _contentMethods = null;

        public Contents(Options options)
        {
            _options = options;
            _contentMethods = new ContentMethods(_options);
        }

        public ContentItem GetContentItem(int id)
        {
            var resp = _contentMethods.GetContentItem(id);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string SaveContentItem(ContentItem contentItem)
        {
            var resp = _contentMethods.SaveContentItem(contentItem);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public List<string> SaveContentItems(List<ContentItem> contentItems)
        {
            var resp = _contentMethods.SaveContentItems(contentItems);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string PublishContent(int contentID, string comments)
        {
            var resp = _contentMethods.PublishContent(contentID, comments);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string UnPublishContent(int contentID, string comments)
        {
            var resp = _contentMethods.UnPublishContent(contentID, comments);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string ContentRequestApproval(int contentID, string comments)
        {
            var resp = _contentMethods.ContentRequestApproval(contentID, comments);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string ApproveContent(int contentID, string comments)
        {
            var resp = _contentMethods.ApproveContent(contentID, comments);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string DeclineContent(int contentID, string comments)
        {
            var resp = _contentMethods.DeclineContent(contentID, comments);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public string DeleteContent(int contentID, string comments)
        {
            var resp = _contentMethods.DeleteContent(contentID, comments);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public ContentList GetContentItems(string referenceName,
           string filter = null,
           string fields = null,
           string sortDirection = null,
           string sortField = null,
           int take = 50,
           int skip = 0)
        {
            var resp = _contentMethods.GetContentItems(referenceName, filter, fields, sortDirection, sortField, take, skip);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }
    }
}
