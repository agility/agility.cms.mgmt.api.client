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
        options.guid = "<<Provide the GUID>>";
        options.locale = "<<Provide the locale eg: en-us>>";
        options.token = "<<Provide the token>>";

        //Sample code to check for a valid response.
        ContainerMethods containerMethods = new ContainerMethods(options);

        var resp = containerMethods.GetContainerList();

        var result = resp.GetAwaiter().GetResult();
     }

    static void AssetsOperations(Options options)
    {
        Assets assets = new Assets(options);

        Dictionary<string, string> files = new Dictionary<string, string>();
        files.Add("<<File Name>>", @"<<Folder Path>>");
        files.Add("<<File Name>>", @"<<Folder Path>>");

        string agilityFolder = "<<Agility Folder Name>>";

        var medias = assets.Upload(files, agilityFolder);

        string newFolder = "<<Agility Folder where the file(s) needs to be moved>>";

        List<Media> mediaList = new List<Media>();
        foreach (var media in medias)
        {
            mediaList.Add(assets.MoveFile(media.MediaID, newFolder));
        }

        foreach (var item in mediaList)
        {
            assets.GetAssetByID(item.MediaID);
            assets.GetAssetByURL(item.OriginUrl);
        }

        foreach (var media in mediaList)
        {
            assets.DeleteFile(media.MediaID);
        }

        var fileList = assets.GetMediaList();
    }

    static void BatchOperations(Options options)
    {
        Batches batches = new Batches(options);

        var batch = batches.GetBatch(15);
    }

    static void ModelOperations(Options options)
    {
        Models models = new Models(options);

        var createdModel = SaveModel(options);
        var model = models.GetModel((int)createdModel.id);

        var contentModules = models.GetContentModules(true, false);

        var pageModules = models.GetPageModules(true);

        var deleteModel = models.DeleteModel((int)model.id);
    }

    static void ContainerOperations(Options options)
    {
        var model = SaveModel(options);
        Containers containers = new Containers(options);
        Models models = new Models(options);

        var createdContainer = SaveContainer(options, (int)model.id);

        var containerById = containers.GetContainerById((int)createdContainer.ContentViewID);

        var containerByRef = containers.GetContainerByRef(createdContainer.ReferenceName);

        var containerSec = containers.GetContainerSecurity((int)createdContainer.ContentViewID);

        var notifications = containers.GetNotifications((int)createdContainer.ContentViewID);

        var contList = containers.GetContainerList();

        var delCont = containers.DeleteContainer((int)createdContainer.ContentViewID);

        var delModel = models.DeleteModel((int)model.id);
    }

    static Model SaveModel(Options options)
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

        var model = models.SaveModel(modelValues);

        return model;
    }

    static Container SaveContainer(Options options, int modelID)
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

        var cotainer = containers.SaveContainer(container);

        return cotainer;
    }

    static void ContentOperations(Options options)
    {
        
        var model = SaveModel(options);
        var container = SaveContainer(options, (int)model.id);
        Contents contents = new Contents(options);
        Containers containers = new Containers(options);
        Models models = new Models(options);

        var contentItem = GetContentObject(container);

        var contentIdStr = contents.SaveContentItem(contentItem);

        var contentID = Convert.ToInt32(contentIdStr);

        var content = contents.GetContentItem((int)contentID);

        var publishedContent = contents.PublishContent(content.contentID, "Publish Content");

        var unPublishContent = contents.UnPublishContent(content.contentID, "UnPublish Content");

        var contentRequestApproval = contents.ContentRequestApproval(content.contentID, "Request for content approval");

        var approveContent = contents.ApproveContent(content.contentID, "Approve Content");

        var declineContent = contents.DeclineContent(content.contentID, "Decline Content");

        var deleteContent = contents.DeleteContent(content.contentID, "Delete Content");

        var deleteContainer = containers.DeleteContainer((int)container.ContentViewID);

        var deleteModel = models.DeleteModel((int)model.id);
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

    static void UserOperations(Options options)
    {
        Users users = new Users(options);

        var userList = users.GetUsers();


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
        var savedUser = users.SaveUser(email, userRoles, firstName, lastName);

        var userDelete = users.DeleteUser(savedUser.UserID);
    }

    static void PageOperations(Options options)
    {
        var model = SaveModel(options);
        var container = SaveContainer(options, (int)model.id);
        var contentItem = GetContentObject(container);

        Contents contents = new Contents(options);
        Containers containers = new Containers(options);
        Models models = new Models(options);

        var savedContent = contents.SaveContentItem(contentItem);

        var contentID = Convert.ToInt32(savedContent);

        var content = contents.GetContentItem(contentID);

        var pageItem = GetPageObject(model, content.contentID);

        Pages pages = new Pages(options);

        var pageStr = pages.SavePage(pageItem);

        var pageID = Convert.ToInt32(pageStr);

        var page = pages.GetPage(pageID);

        var publishPage = pages.PublishPage((int)page.pageID);

        var unPublishPage = pages.UnPublishPage((int)page.pageID);

        var pageRequestApproval = pages.PageRequestApproval((int)page.pageID);

        var approvePage = pages.ApprovePage((int)page.pageID);

        var declinePage = pages.DeclinePage((int)page.pageID);

        var deletePage = pages.DeletePage((int)page.pageID);

        var deletedContent = contents.DeleteContent(contentID, "Delete Content");

        var containerDel = containers.DeleteContainer((int)container.ContentViewID);

        var modelDel = models.DeleteModel((int)model.id);

        var siteMap = pages.GetSitemap();
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