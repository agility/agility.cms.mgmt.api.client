using agility.models;
using management.api.sdk;

namespace NugetTest.sdk_methods
{
    public class Pages
    {
        private Options _options = null;
        ClientInstance _clientInstance = null;

        public Pages(Options options)
        {
            _options = options;
            _clientInstance = new ClientInstance(_options);
        }

        public List<Sitemap> GetSitemap(string guid, string locale)
        {
            var resp = _clientInstance.pageMethods.GetSiteMap(guid, locale);
            var response = resp.GetAwaiter().GetResult();

            return response;
        }

        public PageItem GetPage(int pageID, string guid, string locale)
        {
            var resp = _clientInstance.pageMethods.GetPage(pageID, guid, locale);
            var response = resp.GetAwaiter().GetResult();

            return response;
        }

        public int PublishPage(int pageID, string guid, string locale, string comments = null)
        {
            var resp = _clientInstance.pageMethods.PublishPage(pageID, guid, locale, comments);
            var response = resp.GetAwaiter().GetResult();

            return (int)response;
        }

        public int UnPublishPage(int? pageID, string guid, string locale, string? comments = null)
        {
            var resp = _clientInstance.pageMethods.UnPublishPage(pageID, guid, locale, comments);
            var response = resp.GetAwaiter().GetResult();

            return (int)response;
        }

        public int PageRequestApproval(int? pageID, string guid, string locale, string? comments = null)
        {
            var resp = _clientInstance.pageMethods.PageRequestApproval(pageID, guid, locale, comments);
            var response = resp.GetAwaiter().GetResult();

            return (int)response;
        }

        public int ApprovePage(int? pageID, string guid, string locale, string? comments = null)
        {
            var resp = _clientInstance.pageMethods.ApprovePage(pageID, guid, locale, comments);
            var response = resp.GetAwaiter().GetResult();

            return (int)response;
        }

        public int DeclinePage(int? pageID, string guid, string locale, string? comments = null)
        {
            var resp = _clientInstance.pageMethods.DeclinePage(pageID, guid, locale, comments);
            var response = resp.GetAwaiter().GetResult();

            return (int)response;
        }

        public int DeletePage(int? pageID, string guid, string locale, string? comments = null)
        {
            var resp = _clientInstance.pageMethods.DeletePage(pageID, guid, locale, comments);
            var response = resp.GetAwaiter().GetResult();

            return (int)response;
        }

        public int? SavePage(PageItem pageItem, string guid, string locale, int? parentPageID = -1, int? placeBeforePageItemID = -1)
        {
            var resp = _clientInstance.pageMethods.SavePage(pageItem,guid, locale, parentPageID, placeBeforePageItemID);
            var response = resp.GetAwaiter().GetResult();

            return response;
        }
    }
}
