<%@ Control Language="C#" EnableViewState="false" AutoEventWireup="false" Inherits="CKFinder.Settings.ConfigFile" %>
<%@ Import Namespace="CKFinder.Settings" %>
<script runat="server">
    public override bool CheckAuthentication()
    {
        return (true);
    }
    public override void SetConfig()
    {
        LicenseName = "";
        LicenseKey = "";
        BaseUrl = "/uploads/";
        BaseDir = Server.MapPath("/uploads/");
        Plugins = new string[] { };
        PluginSettings = new Hashtable();
        PluginSettings.Add("ImageResize_smallThumb", "180x180");
        PluginSettings.Add("ImageResize_mediumThumb", "240x240");
        PluginSettings.Add("ImageResize_largeThumb", "360x360");
        PluginSettings.Add("Watermark_source", "logo.gif");
        PluginSettings.Add("Watermark_marginRight", "5");
        PluginSettings.Add("Watermark_marginBottom", "5");
        PluginSettings.Add("Watermark_quality", "100");
        PluginSettings.Add("Watermark_transparency", "80");
        Thumbnails.Url = BaseUrl + "_thumbs/";
        if (BaseDir != "")
        {
            Thumbnails.Dir = BaseDir + "_thumbs/";
        }
        Thumbnails.Enabled = true;
        Thumbnails.DirectAccess = false;

        // chỉnh kích cỡ của ảnh _thumbs 
        // vào phần scripts\ckfinder\skins\kama/app.css thêm 2 dòng ở dưới đây: ví dụ : v01.vmms.vn

        //.file_entry div.image div{ width:250px !important; height:250px!important}
        //.files_thumbnails.fake.no_list a{ width:250px !important; height:300px!important}

        Thumbnails.MaxWidth = 400;
        Thumbnails.MaxHeight = 400;
        Thumbnails.Quality = 100;
        Images.MaxWidth = 1600;
        Images.MaxHeight = 1200;
        Images.Quality = 100;
        CheckSizeAfterScaling = true;
        DisallowUnsafeCharacters = true;
        CheckDoubleExtension = true;
        ForceSingleExtension = true;
        HtmlExtensions = new string[] { "html", "htm", "xml", "js" };
        HideFolders = new string[] { ".*", "CVS" };
        HideFiles = new string[] { ".*" };
        SecureImageUploads = true;
        RoleSessionVar = "CKFinder_UserRole";
        AccessControl acl = AccessControl.Add();
        acl.Role = "*";
        acl.ResourceType = "*";
        acl.Folder = "/";

        acl.FolderView = true;
        acl.FolderCreate = true;
        acl.FolderRename = true;
        acl.FolderDelete = true;

        acl.FileView = true;
        acl.FileUpload = true;
        acl.FileRename = true;
        acl.FileDelete = true;

        DefaultResourceTypes = "";
        ResourceType type;

        /// khi đăng nhập admin mới được quyền vào
        if (HttpContext.Current.Request.Cookies["URole"] == null)
        {

        }
        else
        {
            type = ResourceType.Add("Files");
            type.Url = BaseUrl + "Files/";
            type.Dir = BaseDir == "" ? "" : BaseDir + "Files/";
            type.MaxSize = 0;
            type.AllowedExtensions = new string[] { "7z", "aiff", "asf", "avi", "bmp", "csv", "doc", "docx", "fla", "flv", "gif", "gz", "gzip", "jpeg", "jpg", "mid", "mov", "mp3", "mp4", "mpc", "mpeg", "mpg", "ods", "odt", "pdf", "png", "ppt", "pptx", "pxd", "qt", "ram", "rar", "rm", "rmi", "rmvb", "rtf", "sdc", "sitd", "swf", "sxc", "sxw", "tar", "tgz", "tif", "tiff", "txt", "vsd", "wav", "wma", "wmv", "xls", "xlsx", "zip", "ico" };
            type.DeniedExtensions = new string[] { };

            type = ResourceType.Add("Adv");
            type.Url = BaseUrl + "Adv/";
            type.Dir = BaseDir == "" ? "" : BaseDir + "Adv/";
            type.MaxSize = 0;
            type.AllowedExtensions = new string[] { "7z", "aiff", "asf", "avi", "bmp", "csv", "doc", "docx", "fla", "flv", "gif", "gz", "gzip", "jpeg", "jpg", "mid", "mov", "mp3", "mp4", "mpc", "mpeg", "mpg", "ods", "odt", "pdf", "png", "ppt", "pptx", "pxd", "qt", "ram", "rar", "rm", "rmi", "rmvb", "rtf", "sdc", "sitd", "swf", "sxc", "sxw", "tar", "tgz", "tif", "tiff", "txt", "vsd", "wav", "wma", "wmv", "xls", "xlsx", "zip", "ico" };
            type.DeniedExtensions = new string[] { };

            type = ResourceType.Add("News");
            type.Url = BaseUrl + "News/";
            type.Dir = BaseDir == "" ? "" : BaseDir + "News/";
            type.MaxSize = 0;
            type.AllowedExtensions = new string[] { "7z", "aiff", "asf", "avi", "bmp", "csv", "doc", "docx", "fla", "flv", "gif", "gz", "gzip", "jpeg", "jpg", "mid", "mov", "mp3", "mp4", "mpc", "mpeg", "mpg", "ods", "odt", "pdf", "png", "ppt", "pptx", "pxd", "qt", "ram", "rar", "rm", "rmi", "rmvb", "rtf", "sdc", "sitd", "swf", "sxc", "sxw", "tar", "tgz", "tif", "tiff", "txt", "vsd", "wav", "wma", "wmv", "xls", "xlsx", "zip", "ico" };
            type.DeniedExtensions = new string[] { };

            type = ResourceType.Add("Products");
            type.Url = BaseUrl + "Products/";
            type.Dir = BaseDir == "" ? "" : BaseDir + "Products/";
            type.MaxSize = 0;
            type.AllowedExtensions = new string[] { "7z", "aiff", "asf", "avi", "bmp", "csv", "doc", "docx", "fla", "flv", "gif", "gz", "gzip", "jpeg", "jpg", "mid", "mov", "mp3", "mp4", "mpc", "mpeg", "mpg", "ods", "odt", "pdf", "png", "ppt", "pptx", "pxd", "qt", "ram", "rar", "rm", "rmi", "rmvb", "rtf", "sdc", "sitd", "swf", "sxc", "sxw", "tar", "tgz", "tif", "tiff", "txt", "vsd", "wav", "wma", "wmv", "xls", "xlsx", "zip", "ico" };
            type.DeniedExtensions = new string[] { };

            type = ResourceType.Add("Images");
            type.Url = BaseUrl + "Images/";
            type.Dir = BaseDir == "" ? "" : BaseDir + "Images/";
            type.MaxSize = 0;
            type.AllowedExtensions = new string[] { "7z", "aiff", "asf", "avi", "bmp", "csv", "doc", "docx", "fla", "flv", "gif", "gz", "gzip", "jpeg", "jpg", "mid", "mov", "mp3", "mp4", "mpc", "mpeg", "mpg", "ods", "odt", "pdf", "png", "ppt", "pptx", "pxd", "qt", "ram", "rar", "rm", "rmi", "rmvb", "rtf", "sdc", "sitd", "swf", "sxc", "sxw", "tar", "tgz", "tif", "tiff", "txt", "vsd", "wav", "wma", "wmv", "xls", "xlsx", "zip", "ico" };
            type.DeniedExtensions = new string[] { };

            type = ResourceType.Add("Flash");
            type.Url = BaseUrl + "Flash/";
            type.Dir = BaseDir == "" ? "" : BaseDir + "Flash/";
            type.MaxSize = 0;
            type.AllowedExtensions = new string[] { "7z", "aiff", "asf", "avi", "bmp", "csv", "doc", "docx", "fla", "flv", "gif", "gz", "gzip", "jpeg", "jpg", "mid", "mov", "mp3", "mp4", "mpc", "mpeg", "mpg", "ods", "odt", "pdf", "png", "ppt", "pptx", "pxd", "qt", "ram", "rar", "rm", "rmi", "rmvb", "rtf", "sdc", "sitd", "swf", "sxc", "sxw", "tar", "tgz", "tif", "tiff", "txt", "vsd", "wav", "wma", "wmv", "xls", "xlsx", "zip", "ico" };
            type.DeniedExtensions = new string[] { };
        }
        //yêu cầu khi đăng ký thành viên tạo foder cho thành viên này với tên user 
        //Uploads/vietdung
        //Uploads/_thumbs/Uploads
        if (MoreAll.MoreAll.GetCookies("Members").ToString() != "")// nếu là thành viên thì được vào fooder của thành viên
        {
            type = ResourceType.Add(MoreAll.MoreAll.GetCookies("Members").ToString());
            type.Url = BaseUrl + "" + MoreAll.MoreAll.GetCookies("Members").ToString() + "/";
            type.Dir = BaseDir == "" ? "" : BaseDir + "" + MoreAll.MoreAll.GetCookies("Members").ToString() + "/";
            type.MaxSize = 0;
            type.AllowedExtensions = new string[] { "7z", "aiff", "asf", "avi", "bmp", "csv", "doc", "docx", "fla", "flv", "gif", "gz", "gzip", "jpeg", "jpg", "mid", "mov", "mp3", "mp4", "mpc", "mpeg", "mpg", "ods", "odt", "pdf", "png", "ppt", "pptx", "pxd", "qt", "ram", "rar", "rm", "rmi", "rmvb", "rtf", "sdc", "sitd", "swf", "sxc", "sxw", "tar", "tgz", "tif", "tiff", "txt", "vsd", "wav", "wma", "wmv", "xls", "xlsx", "zip", "ico" };
            type.DeniedExtensions = new string[] { };
        }
    }

</script>
