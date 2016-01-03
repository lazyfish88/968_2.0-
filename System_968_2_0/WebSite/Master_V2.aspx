<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Master_V2.aspx.cs" Inherits="Master_V2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Style/menu_v2.css" rel="stylesheet" />
    <script type="text/javascript" src="http://m.968ch.com/Scripts/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="http://wap.968ch.com/Js/jquery.cookie.js"></script>
    <script>
        $(function () {
            if ($.cookie("__Master_Menu_Url_<%=LoginCompanyId%>_<%=LoginUserId%>")) {
                var boxId = $.cookie("__Master_Menu_Url_<%=LoginCompanyId%>_<%=LoginUserId%>_Box") || "menu_1";
                var moduleId = $.cookie("__Master_Menu_Url_<%=LoginCompanyId%>_<%=LoginUserId%>_Id");
                $(".Level_1 li").removeClass("active");
                $(".Level_1 li[data-for=" + boxId + "]").addClass("active");
                $(".Level_2_Box").hide();
                $("#" + boxId).show();
                $("#" + boxId).find("li[data-id=" + moduleId + "]").addClass("active");
                $("#iframe1").attr("src", $.cookie("__Master_Menu_Url_<%=LoginCompanyId%>_<%=LoginUserId%>"));
            }
            var height = $("#Body").height() - 156;
            console.log(height)
            $(".Level_1,.Level_2_Box").height(height)
            $("#iframe1").height($("#Body").height() - 40)
            $(".Level_1 li").click(function () {
                $(".Level_2_Box").hide();
                $("#" + $(this).attr("data-for")).show();
                $(".Level_1 li").removeClass("active");
                $(this).addClass("active");
            })
            $(".FastMenu .moduletitle").click(function () {
                if ($(this).hasClass("open")) {
                    $(this).removeClass("open");
                    $(this).addClass("close");
                    $(".item[data-module=" + $(this).attr("data-id") + "]").hide();
                }
                else {
                    $(this).removeClass("close");
                    $(this).addClass("open");
                    $(".item[data-module=" + $(this).attr("data-id") + "]").show();
                }
            })
            $(".Level_1 li").each(function () {
                if ($(this).hasClass("menu_1")) {
                    return;
                }
                if ($("#" + $(this).attr("data-for")).find("li").length == 0) {
                    $(this).hide();
                }
            })
            $("#logout").click(function () {
                $.cookie("__Master_Menu_Url_<%=LoginCompanyId%>_<%=LoginUserId%>_Box","");
                $.cookie("__Master_Menu_Url_<%=LoginCompanyId%>_<%=LoginUserId%>_Id", "");
                $.cookie("__Master_Menu_Url_<%=LoginCompanyId%>_<%=LoginUserId%>", "");
                window.location = "LoginOut.ashx";
            })
            $.get("Master_V2.aspx?action=HasNewMsg", function (data) {
                var json = JSON.parse(data);
                if (json.Success) {
                    $("#navMsg").append("<i></i>");
                }
                console.log(data);
            })
            $("#Menu5 li").click(function () {
                $(".Level_2_Box li").removeClass("active");
                $(this).addClass("active");
            })
        })
        function OpenWindow(id, url) {
            $(".Level_2_Box li").removeClass("active");
            $(".Level_2_Box").find("li[data-id=" + id + "]").addClass("active");
            switch (parseInt(id)) {
                default:
                    $("#iframe1").attr("src", url);
                    $.cookie("__Master_Menu_Url_<%=LoginCompanyId%>_<%=LoginUserId%>_Box", $("li[data-id=" + id + "]").parents(".Level_2_Box").attr("id"));
                    $.cookie("__Master_Menu_Url_<%=LoginCompanyId%>_<%=LoginUserId%>_Id", id);
                    $.cookie("__Master_Menu_Url_<%=LoginCompanyId%>_<%=LoginUserId%>", url);
                    break;
            }
        }

        function GoModule(moduleId) {
            var moduleElm = $(".Level_2_Box li[data-id=" + moduleId + "]");
            moduleElm.click();
            //if (moduleElm.parent().hasClass("OpenMenu")) {
            //}
        }
        function GoPayModule(id) {
            if (confirm("您尚未开通此服务，请开通后再试")) {
                $("#iframe1").attr("src", "SystemModule/SystemModule_PaySetMeal.aspx");
            }
        }
    </script>
</head>
<body>
    <div id="Body">
        <div class="BodyLeft">
            <div class="LogoBox" style="background-color: <%=__OEMInfo.TitleBackColor2%>; background-image: url(http://<%=__OEMInfo.AgentUrl + __OEMInfo.MediaBackLogo%>)">
            </div>
            <div class="MenuBox">
                <ul class="Level_1">
                    <li class="menu_1 item <%=__FastModule.Length>0?"active":"" %>" data-for="Menu1"><span></span></li>
                    <li class="menu_2 item" data-for="Menu2"><span></span></li>
                    <li class="menu_3 item" data-for="Menu3"><span></span></li>
                    <li class="menu_4 item" data-for="Menu4"><span></span></li>
                    <li class="menu_5 item <%=__FastModule.Length>0?"":"active" %>" data-for="Menu5"><span></span></li>
                </ul>
                <div id="Menu1" class="Level_2_Box" style="<%=__FastModule.Length>0?"display:block;": "" %>">
                    <h4 id="FastTitle"><span class="title">快速入口</span><span class="setting" onclick="OpenWindow(0,'SystemModule/SystemModule_SetFastModule.aspx')"></span></h4>
                    <div class="Level_2" style="clear: both;">
                        <ul class="FastMenu">
                            <%
                                for (int i = 0; i < __FastModule.Length; i++)
                                {
                                    Ac968.SystemModuleSetMeal.Model.CompanyFastModule item = __FastModule[i];
                                    if (i == 0 || (i > 0 && item.ModuleId != __FastModule[i - 1].ModuleId))
                                    {
                            %>
                            <li class="moduletitle open" data-id="<%=item.ModuleId %>"><i></i><span><%=GetModuleName(item.ModuleId) %></span></li>
                            <%
                                }
                            %>

                            <li class="item" data-module="<%=item.ModuleId %>"><a href="<%=item.Url %>" target="<%=(item.ModuleId == 4?"__blank":"iframe1") %>"><%=item.Name %></a></li>
                            <%
                                }
                            %>
                        </ul>
                    </div>
                </div>
                <div id="Menu2" class="Level_2_Box">
                    <h4>主功能区</h4>
                    <div class="Level_2">
                        <ul class="OpenMenu">
                            <%
                                foreach (Ac968.SystemModuleSetMeal.Model.SystemModule item in __OpenModule_1)
                                {
                                    if (item.id == 4)
                                    {
                            %>
                            <li data-id="<%=item.id %>"><a href="<%=item.Url %>" target="_blank"><%=item.Name %></a></li>
                            <%
                                }
                                else
                                {
                            %>
                            <li data-id="<%=item.id %>" onclick="OpenWindow(<%=item.id %>,'<%=item.Url %>')"><%=item.Name %></li>
                            <%
                                    }
                                }
                            %>
                        </ul>
                        <%
                            if (__userInfo.RoleTypeId == 1 && __NotOpenModule_1.Count > 0)
                            {
                        %>
                        <div class="NotOpenMenu">
                            <h5>未开通</h5>
                            <ul>
                                <%
                                    foreach (Ac968.SystemModuleSetMeal.Model.SystemModule item in __NotOpenModule_1)
                                    {
                                %>
                                <li data-id="<%=item.id %>" onclick="GoPayModule(<%=item.id %>)"><%=item.Name %></li>
                                <%
                                    }
                                %>
                            </ul>
                        </div>
                        <%
                            }
                        %>
                    </div>
                </div>

                <div id="Menu3" class="Level_2_Box">
                    <h4>推广工具区</h4>
                    <div class="Level_2">
                        <ul class="OpenMenu">
                            <%
                                foreach (Ac968.SystemModuleSetMeal.Model.SystemModule item in __OpenModule_2)
                                {
                            %>
                            <li data-id="<%=item.id %>" onclick="OpenWindow(<%=item.id %>,'<%=item.Url %>')"><%=item.Name %></li>
                            <%
                                }
                            %>
                        </ul>
                        <%if (__userInfo.RoleTypeId == 1 && __NotOpenModule_2.Count > 0)
                            {
                        %>
                        <div class="NotOpenMenu">
                            <h5>未开通</h5>
                            <ul>
                                <%
                                    foreach (Ac968.SystemModuleSetMeal.Model.SystemModule item in __NotOpenModule_2)
                                    {
                                %>
                                <li data-id="<%=item.id %>" onclick="GoPayModule(<%=item.id %>)"><%=item.Name %></li>
                                <%
                                    }
                                %>
                            </ul>
                        </div>
                        <%} %>
                    </div>
                </div>

                <div id="Menu4" class="Level_2_Box">
                    <h4>免费服务区</h4>
                    <div class="Level_2">
                        <ul class="OpenMenu">
                            <%
                                foreach (Ac968.SystemModuleSetMeal.Model.SystemModule item in __OpenModule_3)
                                {
                                    if (__IsCompany && item.NeedCompany)
                                    {
                                        continue;
                                    }
                            %>
                            <li data-id="<%=item.id %>" onclick="OpenWindow(<%=item.id %>,'<%=item.Url %>')"><%=item.Name %></li>
                            <%
                                }
                            %>
                        </ul>
                        <%if (__userInfo.RoleTypeId == 1 && __NotOpenModule_3.Count > 0)
                            {
                        %>
                        <div class="NotOpenMenu">
                            <h5>未开通</h5>
                            <ul>
                                <%
                                    foreach (Ac968.SystemModuleSetMeal.Model.SystemModule item in __NotOpenModule_3)
                                    {
                                %>
                                <li data-id="<%=item.id %>" onclick="GoPayModule(<%=item.id %>)"><%=item.Name %></li>
                                <%
                                    }
                                %>
                            </ul>
                        </div>
                        <%} %>
                    </div>
                </div>

                <div id="Menu5" class="Level_2_Box" style="<%=__FastModule.Length>0?"": "display:block;" %>">
                    <h4>用户基本信息</h4>
                    <div class="Level_2">
                        <ul class="OpenMenu">
                            <li><a href="http://personpc.968ch.com/Setting/BaseSetting" target="iframe1">基本设置</a></li>
                            <li><a href="http://personpc.968ch.com/Card/CardList" target="iframe1">我的名片</a></li>
                            <li><a href="http://personpc.968ch.com/Friend/List" target="iframe1">我的好友</a></li>
                            <li><a href="http://personpc.968ch.com/Account/Index" target="iframe1">我的帐户</a></li>
                            <li><a href="http://personpc.968ch.com/Order/List?s=0" target="iframe1">订单管理</a></li>
                            <li><a href="http://personpc.968ch.com/Agent/BaseSetting" target="iframe1">品牌代理</a></li>
                            <li><a href="http://personpc.968ch.com/Dis/BaseSetting" target="iframe1">我要分销</a></li>
                            <li><a href="http://personpc.968ch.com/Favorite/List" target="iframe1">我的收藏</a></li>
                            <li><a href="http://personpc.968ch.com/Coupon/List" target="iframe1">优惠券</a></li>
                            <li id="navMsg" class="msg"><a href="http://personpc.968ch.com/Message/List?state=1" class="" target="iframe1">消息</a></li>
                            <li><a href="http://m.968ch.com/admin/Secure/UserSecureList.aspx" target="iframe1">帐户安全</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="BodyMain">
            <div class="tool">
                <div class="name">欢迎您，<%=__Company.Name %></div>
                <div class="button">
                    <a href="http://www.968ch.com" class="home"><i></i>首页</a>
                    <a href="systemmodule/Wellcome.aspx" target="iframe1" class="guide"><i></i>引导</a>
                    <a href="/admin/Upgrade.aspx" target="iframe1" class="check"><i></i><%=__IsCompany?"已认证企业":"企业认证" %></a>
                    <%
                        if (__HasMoreCompany)
                        {
                    %>
                    <a href="ComCenter.aspx" class="change"><i></i>切换企业</a>
                    <%
                        }
                    %>
                    <%
                        if (__userInfo.RoleTypeId == 1)
                        {
                    %>
                    <a target="iframe1" href="/admin/systemmodule/SystemModule_PaySetMeal.aspx" class="module_pay"><i></i>开通套餐</a>
                    <%
                        }
                    %>
                    <a target="iframe1" href="/admin/GenCard.aspx" class="qr"><i></i>二维码生成器</a>
                    <a target="iframe1" href="/admin/ModiPass.aspx" class="pwd"><i></i>密码修改</a>
                    <a href="javascript:;" class="logout" id="logout"><i></i>退出</a>
                </div>
            </div>
            <iframe id="iframe1" name="iframe1" style="width: 100%;" frameborder="0" src="systemmodule/Wellcome.aspx"></iframe>
        </div>
    </div>
</body>
</html>
