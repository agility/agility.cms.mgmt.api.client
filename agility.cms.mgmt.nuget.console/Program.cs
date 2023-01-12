using agility.models;
using management.api.sdk;
using NugetTest.sdk_methods;

/// <summary>
/// The Main method has a sample call to get containers. You can also use the other operation methods present in this class which will call the API methods to the new management api.
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        Options options = new Options();
        options.token = "<<Provide the token>>";
        var guid = "<<Provide the guid>>";
        var locale = "<<Provide the locale>>";

        ClientInstance client = new ClientInstance(options);

        //Sample code to check for a valid response.
 
        var resp = client.containerMethods.GetContainerList(guid);

        var result = resp.GetAwaiter().GetResult();
     }

    static void AssetsOperations(Options options, string guid)
    {
        Assets assets = new Assets(options);

        Dictionary<string, string> files = new Dictionary<string, string>();
        files.Add("<<File Name>>", @"<<Folder Path>>");
        files.Add("<<File Name>>", @"<<Folder Path>>");

        string agilityFolder = "<<Agility Folder Name>>";

        var medias = assets.Upload(files, guid, agilityFolder);

        string newFolder = "<<Agility Folder where the file(s) needs to be moved>>";

        List<Media> mediaList = new List<Media>();
        foreach (var media in medias)
        {
            mediaList.Add(assets.MoveFile(media.MediaID, guid, newFolder));
        }

        foreach (var item in mediaList)
        {
            assets.GetAssetByID(item.MediaID, guid);
            assets.GetAssetByURL(item.OriginUrl, guid);
        }

        foreach (var media in mediaList)
        {
            assets.DeleteFile(media.MediaID, guid);
        }

        var fileList = assets.GetMediaList(guid);
    }

    static void BatchOperations(Options options, string guid, int batchID)
    {
        Batches batches = new Batches(options);

        var batch = batches.GetBatch(batchID, guid);
    }

    static void ModelOperations(Options options, string guid)
    {
        Models models = new Models(options);

        var createdModel = SaveModel(options, guid);
        var model = models.GetModel((int)createdModel.id, guid);

        var contentModules = models.GetContentModules(true, guid, false);

        var pageModules = models.GetPageModules(guid, true);

        var deleteModel = models.DeleteModel((int)model.id, guid);
    }

    static void ContainerOperations(Options options, string guid)
    {
        var model = SaveModel(options, guid);
        Containers containers = new Containers(options);
        Models models = new Models(options);

        var createdContainer = SaveContainer(options, (int)model.id, guid);

        var containerById = containers.GetContainerById((int)createdContainer.ContentViewID, guid);

        var containerByRef = containers.GetContainerByRef(createdContainer.ReferenceName, guid);

        var containerSec = containers.GetContainerSecurity((int)createdContainer.ContentViewID, guid);

        var notifications = containers.GetNotifications((int)createdContainer.ContentViewID, guid);

        var contList = containers.GetContainerList(guid);

        var delCont = containers.DeleteContainer((int)createdContainer.ContentViewID, guid);

        var delModel = models.DeleteModel((int)model.id, guid);
    }

    static Model SaveModel(Options options, string guid)
    {
        Models models = new Models(options);
        Containers containers = new Containers(options);

        var modelValues = new Model();
        modelValues.id = 0;
        modelValues.lastModifiedDate = DateTime.Now;
        string format = "Mddyyyyhhmmsstt";
        string modelDate = DateTime.Now.ToString(format);
        modelValues.displayName = $"Test_Model {modelDate}";
        modelValues.referenceName = $"TestModel{modelDate}";
        modelValues.description = "Model created to test Nuget Package";
        modelValues.allowTagging = false;
        modelValues.contentDefinitionTypeName = null;

        var modelField = new ModelField();
        modelField.name = "TypeText";
        modelField.label = "Type Text";
        modelField.type = "Text";
        modelField.description = "Exclusive model for the Test project on SDK";
        modelField.labelHelpDescription = "Field Type Text";
        modelField.itemOrder = 0;
        modelField.designerOnly = false;
        modelField.isDataField = true;
        modelField.editable = true;
        modelField.hiddenField = false;
        modelField.settings.Add("Required", "False");
        modelField.settings.Add("Length", "");
        modelField.settings.Add("DefaultValue", "");
        modelField.settings.Add("Unique", "False");
        modelField.settings.Add("CopyAcrossAllLanguages", "False");
        modelField.settings.Add("DefaultValue-en-us", "");

        modelValues.fields = new List<ModelField?>();
        modelValues.fields.Add(modelField);

        var model = models.SaveModel(modelValues, guid);

        return model;
    }

    static Container SaveContainer(Options options, int modelID, string guid)
    {
        Containers containers = new Containers(options);
        var container = new Container();

        container.ContentViewID = 0;
        container.ContentDefinitionID = modelID;
        container.ContentDefinitionTypeID = 1;
        string format = "Mddyyyyhhmmsstt";
        string modelDate = DateTime.Now.ToString(format);
        container.ContentViewName = $"Test_Container {modelDate}";
        container.ReferenceName = $"TestContainer{modelDate}";
        container.IsShared = false;
        container.IsDynamicPageList = true;
        container.ContentViewCategoryID = null;

        var cotainer = containers.SaveContainer(container, guid);

        return cotainer;
    }

    static void ContentOperations(Options options, string guid, string locale)
    {
        
        var model = SaveModel(options, guid);
        var container = SaveContainer(options, (int)model.id, guid);
        Contents contents = new Contents(options);
        Containers containers = new Containers(options);
        Models models = new Models(options);

        var contentItem = GetContentObject(container);

        var contentIdStr = contents.SaveContentItem(contentItem, guid, locale);

        var contentID = Convert.ToInt32(contentIdStr);

        var content = contents.GetContentItem((int)contentID, guid, locale);

        var publishedContent = contents.PublishContent(content.contentID, guid, locale, "Publish Content");

        var unPublishContent = contents.UnPublishContent(content.contentID, guid, locale, "UnPublish Content");

        var contentRequestApproval = contents.ContentRequestApproval(content.contentID, guid, locale, "Request for content approval");

        var approveContent = contents.ApproveContent(content.contentID, guid, locale, "Approve Content");

        var declineContent = contents.DeclineContent(content.contentID, guid, locale, "Decline Content");

        var deleteContent = contents.DeleteContent(content.contentID, guid, locale, "Delete Content");

        var deleteContainer = containers.DeleteContainer((int)container.ContentViewID, guid);

        var deleteModel = models.DeleteModel((int)model.id, guid);
    }

    static ContentItem GetContentObject(Container container)
    {
        var contentItem = new ContentItem();
        contentItem.contentID = -1;

        ContentItemProperties properties = new ContentItemProperties();
        properties.state = 1;
        properties.modified = DateTime.Now;
        properties.versionID = 0;
        properties.referenceName = container.ReferenceName;
        properties.definitionName = container.ContentDefinitionName;
        properties.itemOrder = 0;
        contentItem.properties = properties;

        Dictionary<string, object> fields = new Dictionary<string, object>();
        fields.Add("typetext", "Test text for Content: From SDK");
        contentItem.fields = fields;

        return contentItem;
    }

    static void UserOperations(Options options, string guid)
    {
        Users users = new Users(options);

        var userList = users.GetUsers(guid);


        var userRole = new InstanceRole
        {
            RoleID = 7,
            IsGlobalRole = true,
            Sort = 0,
            Role = "Administrator",
            Name = "Administrator"
        };

        List<InstanceRole> userRoles = new List<InstanceRole>();
        userRoles.Add(userRole);
        var firstName = $"FirstName{DateTime.Now.Ticks}";
        var lastName = $"LastName{DateTime.Now.Ticks}";
        var email = $"{firstName}.{lastName}@mail.com";
        var savedUser = users.SaveUser(email, userRoles, guid, firstName, lastName);

        var userDelete = users.DeleteUser(savedUser.UserID, guid);
    }

    static void PageOperations(Options options, string guid, string locale)
    {
        var model = SaveModel(options, guid);
        var container = SaveContainer(options, (int)model.id, guid);
        var contentItem = GetContentObject(container);

        Contents contents = new Contents(options);
        Containers containers = new Containers(options);
        Models models = new Models(options);

        var savedContent = contents.SaveContentItem(contentItem, guid, locale);

        var contentID = Convert.ToInt32(savedContent);

        var content = contents.GetContentItem(contentID, guid, locale);

        var pageItem = GetPageObject(model, content.contentID);

        Pages pages = new Pages(options);

        var pageStr = pages.SavePage(pageItem, guid, locale);

        var pageID = Convert.ToInt32(pageStr);

        var page = pages.GetPage(pageID, guid, locale);

        var publishPage = pages.PublishPage((int)page.pageID, guid, locale);

        var unPublishPage = pages.UnPublishPage((int)page.pageID, guid, locale);

        var pageRequestApproval = pages.PageRequestApproval((int)page.pageID, guid, locale);

        var approvePage = pages.ApprovePage((int)page.pageID, guid, locale);

        var declinePage = pages.DeclinePage((int)page.pageID, guid, locale);

        var deletePage = pages.DeletePage((int)page.pageID, guid, locale);

        var deletedContent = contents.DeleteContent(contentID, guid, locale, "Delete Content");

        var containerDel = containers.DeleteContainer((int)container.ContentViewID, guid);

        var modelDel = models.DeleteModel((int)model.id, guid);

        var siteMap = pages.GetSitemap(guid, locale);
    }

    static PageItem GetPageObject(Model model, int contentID)
    {
        var pageItem = new PageItem();
        pageItem.pageID = -1;
        pageItem.channelID = 1;
        pageItem.releaseDate = null;
        pageItem.pullDate = null;
        var guid = Guid.NewGuid();
        pageItem.name = $"sdk-page-{guid}";
        pageItem.path = string.Empty;
        pageItem.title = "Page for SDK";
        pageItem.menuText = "Page Menu for SDK";
        pageItem.pageType = "static";
        pageItem.templateName = "Main Template";
        pageItem.redirectUrl = string.Empty;
        pageItem.securePage = false;
        pageItem.excludeFromOutputCache = false;
        pageItem.visible = new PageVisible();
        pageItem.visible.menu = true;
        pageItem.visible.sitemap = true;
        pageItem.seo = new SeoProperties();
        pageItem.seo.metaDescription = "Just to test SDK";
        pageItem.seo.metaKeywords = "SDK";
        pageItem.seo.metaHTML = String.Empty;
        pageItem.seo.menuVisible = true;
        pageItem.seo.sitemapVisible = true;
        pageItem.scripts = new PageScripts();
        pageItem.scripts.excludedFromGlobal = false;
        pageItem.scripts.top = null;
        pageItem.scripts.bottom = null;

        pageItem.zones = new Dictionary<string?, List<PageModule?>>();

        PageModule pageModule = new PageModule();
        pageModule.module = model.referenceName;
        dynamic content = new System.Dynamic.ExpandoObject();
        content.contentId = contentID;
        pageModule.item = content;

        List<PageModule> pageModules = new List<PageModule>();
        pageModules.Add(pageModule);

        pageItem.zones.Add("MainContentZone", pageModules);
        return pageItem;
    }
}