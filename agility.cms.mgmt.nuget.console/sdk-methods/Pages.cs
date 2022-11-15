using agility.models;
using management.api.sdk;

namespace NugetTest.sdk_methods
{
    public class Pages
    {
        private Options _options = null;
        PageMethods _pageMethods = null;

        public Pages(Options options)
        {
            _options = options;
            _pageMethods = new PageMethods(options);
        }

        public List<Sitemap> GetSitemap()
        {
            var resp = _pageMethods.GetSiteMap();
            var response = resp.GetAwaiter().GetResult();

            return response;
        }

        public PageItem GetPage(int pageID)
        {
            var resp = _pageMethods.GetPage(pageID);
            var response = resp.GetAwaiter().GetResult();

            return response;
        }

        public int PublishPage(int pageID, string comments = null)
        {
            var resp = _pageMethods.PublishPage(pageID, comments);
            var response = resp.GetAwaiter().GetResult();

            return (int)response;
        }

        public int UnPublishPage(int? pageID, string? comments = null)
        {
            var resp = _pageMethods.UnPublishPage(pageID, comments);
            var response = resp.GetAwaiter().GetResult();

            return (int)response;
        }

        public int PageRequestApproval(int? pageID, string? comments = null)
        {
            var resp = _pageMethods.PageRequestApproval(pageID, comments);
            var response = resp.GetAwaiter().GetResult();

            return (int)response;
        }

        public int ApprovePage(int? pageID, string? comments = null)
        {
            var resp = _pageMethods.ApprovePage(pageID, comments);
            var response = resp.GetAwaiter().GetResult();

            return (int)response;
        }

        public int DeclinePage(int? pageID, string? comments = null)
        {
            var resp = _pageMethods.DeclinePage(pageID, comments);
            var response = resp.GetAwaiter().GetResult();

            return (int)response;
        }

        public int DeletePage(int? pageID, string? comments = null)
        {
            var resp = _pageMethods.DeletePage(pageID, comments);
            var response = resp.GetAwaiter().GetResult();

            return (int)response;
        }

        public string SavePage(PageItem pageItem, int? parentPageID = -1, int? placeBeforePageItemID = -1)
        {
            var resp = _pageMethods.SavePage(pageItem, parentPageID, placeBeforePageItemID);
            var response = resp.GetAwaiter().GetResult();

            return response;
        }
    }
}
