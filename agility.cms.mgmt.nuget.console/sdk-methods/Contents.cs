using agility.models;
using management.api.sdk;

namespace NugetTest.sdk_methods
{
    public class Contents
    {
        private Options _options = null;
        ClientInstance _clientInstance = null;

        public Contents(Options options)
        {
            _options = options;
            _clientInstance = new ClientInstance(_options);
        }

        public ContentItem GetContentItem(int id, string guid, string locale)
        {
            var resp = _clientInstance.contentMethods.GetContentItem(id, guid, locale);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public int SaveContentItem(ContentItem contentItem, string guid, string locale)
        {
            var resp = _clientInstance.contentMethods.SaveContentItem(contentItem, guid, locale);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public List<object> SaveContentItems(List<ContentItem> contentItems, string guid, string locale)
        {
            var resp = _clientInstance.contentMethods.SaveContentItems(contentItems, guid, locale);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public int? PublishContent(int contentID, string guid, string locale, string comments)
        {
            var resp = _clientInstance.contentMethods.PublishContent(contentID, guid, locale, comments);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public int? UnPublishContent(int contentID, string guid, string locale, string comments)
        {
            var resp = _clientInstance.contentMethods.UnPublishContent(contentID, guid, locale, comments);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public int? ContentRequestApproval(int contentID, string guid, string locale, string comments)
        {
            var resp = _clientInstance.contentMethods.ContentRequestApproval(contentID, guid, locale, comments);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public int? ApproveContent(int contentID, string guid, string locale, string comments)
        {
            var resp = _clientInstance.contentMethods.ApproveContent(contentID, guid, locale, comments);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public int? DeclineContent(int contentID, string guid, string locale, string comments)
        {
            var resp = _clientInstance.contentMethods.DeclineContent(contentID, guid, locale, comments);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public int? DeleteContent(int contentID, string guid, string locale, string comments)
        {
            var resp = _clientInstance.contentMethods.DeleteContent(contentID, guid, locale, comments);

            var result = resp.GetAwaiter().GetResult();

            return result;
        }

        public ContentList GetContentItems(string referenceName, string guid, string locale,
           string filter = null,
           string fields = null,
           string sortDirection = null,
           string sortField = null,
           int take = 50,
           int skip = 0)
        {
            var resp = _clientInstance.contentMethods.GetContentItems(referenceName, guid, locale, filter, fields, sortDirection, sortField, take, skip);
            var result = resp.GetAwaiter().GetResult();

            return result;
        }
    }
}
