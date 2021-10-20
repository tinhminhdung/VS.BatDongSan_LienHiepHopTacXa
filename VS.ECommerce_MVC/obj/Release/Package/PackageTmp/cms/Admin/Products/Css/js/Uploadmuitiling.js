    $('[id*=btnBrowseImage]').each(function () {
        $(this).click(function () {
            BrowseServerNew(<%=txtMImage.ClientID%>, '');
        });
    });
    $("#container-img").sortable({
        stop: function (event, ui) {
            $('#<%=txtMImage.ClientID%>').val(GetStringImg());
        }
    });
    function delall() {
        $("#container-img").html('') ;
        $('#<%=txtMImage.ClientID%>').val(GetStringImg());
    }
    function BrowseServerNew(functionData, startupPath) {
        var finder = new CKFinder();
        finder.basePath = '~/scripts/ckfinder/';
        finder.startupPath = startupPath;
        finder.selectActionFunction = SetFileFieldNew;
        finder.selectActionData = functionData;
        finder.popup();
    }
    function SetFileFieldNew(fileUrl, data, allFiles) {
        var str = "";
        var strimg =""
        allFiles.forEach(function(item) {
            strimg += "<li class='ui-state-default'><div class='box-img'><a href='javascript:void(0)' onclick=\"delimg($(this),'" + data["selectActionData"].id.toString() + "');\" class='btn-close'>x</a> <img src='" + item.url + "' /> </div></li>";
        })
        $("#container-img").html($("#container-img").html() + strimg);
        $("#container-img").sortable({
            stop: function (event, ui) {
                data["selectActionData"].value = GetStringImg().toString();
            }
        });
        $("#container-img").disableSelection();
        data["selectActionData"].value = GetStringImg().toString();
    }
    function LoadStringImg(strImg, inputimg) {
        var arr = strImg.split(',');
        var strimg="";
        arr.forEach(function(item) {
            strimg += "<li class='ui-state-default'><div class='box-img'><a href='javascript:void(0)' onclick=\"delimg($(this),'" + inputimg + "');\" class='btn-close'>x</a> <img src='" + item + "' /> </div></li>";
        })
        $("#container-img").html($("#container-img").html() + strimg);
    }
    function GetStringImg() {
        var str = "";
        $(".box-img img").each(function () {
            str += $(this).attr('src') + ',';
        })
        return str;
    }
    function delimg(img, inputimg)
    {
        img.parent().parent().remove();
        $('#'+ inputimg).val(GetStringImg());
    }
