<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Wellcome.aspx.cs" Inherits="Wellcome" %>

<%@ Import Namespace="Ac968.SystemModuleSetMeal.Model" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/Style/Wellcome.css" rel="stylesheet" />
    <title></title>
    <script type="text/javascript" src="http://m.968ch.com/Scripts/jquery-1.7.2.min.js"></script>
    <script src='http://rccom.968ch.com/js/Dialog/jquery.artDialog.js?skin=chrome'></script>
    <script src="http://rccom.968ch.com/js/Dialog/iframeTools.js"></script>

    <script>
        var __submitState = false;
        $(function () {
            $(".section_2 li[not]").remove();
            var moduleCount = $(".section_2 li").length;
            if (moduleCount > 7) {
                $(".left_number .two").css("margin-top", "175px");
            }
            $(".module .item").each(function(){
                $(this).find(".icon").height($(this).height()).find("span").css("margin-top",($(this).height()-30)/2);
                var hotElm = $(this).find(".hot");
                console.log(hotElm.html())
                if (hotElm.html()!=null) {
                }
            })
            $(".left_number .three").css("margin-top", $(".module").height());
            $("#btnCustomApply").click(function () {
                var html = "";
                html += '<div class="applyform">';
                html += '    <table style="border:0;" cellpadding="0" cellspacing="0">';
                html += '        <tr>';
                html += '            <th>联系姓名</th>';
                html += '            <td><input id="apply_name" /></td>';
                html += '        </tr>';
                html += '        <tr>';
                html += '            <th>联系电话</th>';
                html += '            <td><input id="apply_tel" /></td>';
                html += '        </tr>';
                html += '        <tr>';
                html += '            <th>申请备注</th>';
                html += '            <td>';
                html += '                <textarea id="apply_remark"></textarea>';
                html += '            </td>';
                html += '        </tr>';
                html += '    </table>';
                html += '</div>';
                var dialogform = art.dialog({
                    title: '填写申请信息',
                    content: html,
                    ok: function () {
                        if (__submitState) {
                            return false;
                        }
                        var param = {
                            Name: $("#apply_name").val(),
                            Tel: $("#apply_tel").val(),
                            Remark: $("#apply_remark").val() || $("#apply_remark").html(),
                            Action:"apply"
                        };
                        if (!param.Name) {
                            alert("请填写姓名")
                            return false;
                        }
                        if (!param.Tel || !/(\(\d{3,4}\)|\d{3,4}-|\s)?\d{7,14}/g.test(param.Tel)) {
                            alert("请填写联系电话")
                            return false;
                        }
                        __submitState = true;
                        $.post("wellcome.aspx", param, function (data) {
                            __submitState = false;
                            if (data=="ok") {
                                alert("提交成功");
                            }
                            else {
                                alert("网络错误，请重试");
                            }
                            dialogform.close();
                        })
                        return false;
                    }
                });
                dialogform.show()
            })
        })
        function GoModule(moduleId){
            window.parent.GoModule(moduleId);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h4>
            <span class="title1">本系统导航：</span>
            <span class="title2">当前左边菜单是您的个人中心！</span>
        </h4>
        <div class="main">
            <div class="left_number">
                <div class="one"></div>
                <div class="two"></div>
                <div class="three"></div>
            </div>
            <div class="module_section">
                <div class="section_1">
                    <span class="icon" style="padding:6px 2px 5px 2px;"><span style="background-position: 3px -347px"></span></span>
                    <span class="text">免费服务区为您提供基础应用，您还可以自主设置</span>
                    <span class="icon" style="padding: 2px;"><span style="height: 34px; background-position: 4px -214px;"></span></span>
                    <span class="text">快速通道，欢迎使用！</span>
                </div>
                <div class="section_2">
                    <ul>
                        <li onclick="GoModule(1)" <%=__ModuleIds.Contains(",1,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -426px"></span>
                            <span class="name">产品自媒体</span>
                        </li>
                        <li onclick="GoModule(4)" <%=__ModuleIds.Contains(",4,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -671px"></span>
                            <span class="name">微店系统</span>
                        </li>
                        <li onclick="GoModule(3)" <%=__ModuleIds.Contains(",3,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -569px"></span>
                            <span class="name">人才招聘</span>
                        </li>
                        <li onclick="GoModule(2)" <%=__ModuleIds.Contains(",2,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -386px"></span>
                            <span class="name">产品溯源</span>
                        </li>
                        <li onclick="GoModule(8)" <%=__ModuleIds.Contains(",8,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -342px"></span>
                            <span class="name">场景自媒体</span>
                        </li>
                        <li onclick="GoModule(7)" <%=__ModuleIds.Contains(",7,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -777px"></span>
                            <span class="name">主题自媒体</span>
                        </li>
                        <li onclick="GoModule(6)" <%=__ModuleIds.Contains(",6,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -635px"></span>
                            <span class="name">圈子</span>
                        </li>
                        <li onclick="GoModule(5)" <%=__ModuleIds.Contains(",5,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -461px"></span>
                            <span class="name">大众号</span>
                        </li>
                        <li onclick="GoModule(14)" <%=__ModuleIds.Contains(",14,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -495px"></span>
                            <span class="name">会员管理</span>
                        </li>
                        <li onclick="GoModule(13)" <%=__ModuleIds.Contains(",13,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -64px"></span>
                            <span class="name">自媒体列表</span>
                        </li>
                        <li onclick="GoModule(12)" <%=__ModuleIds.Contains(",12,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -533px"></span>
                            <span class="name">控制台</span>
                        </li>
                        <li onclick="GoModule(11)" <%=__ModuleIds.Contains(",11,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -816px"></span>
                            <span class="name">数据统计</span>
                        </li>
                        <li onclick="GoModule(10)" <%=__ModuleIds.Contains(",10,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -703px"></span>
                            <span class="name">微官网</span>
                        </li>
                        <li onclick="GoModule(9)" <%=__ModuleIds.Contains(",9,")?"":"not" %>>
                            <span class="icon" style="background-position: -120px -739px"></span>
                            <span class="name">自媒体名片</span>
                        </li>
                    </ul>
                </div>
                <div class="section_3">
                    <h5><i></i><span>左边菜单图标注解</span></h5>
                    <div class="module">
                        <div class="item">
                            <div class="icon"><span style="background-position: 4px -218px;"></span></div>
                            <div class="list">
                                <div class="top"></div>
                                <h6 style="margin-top: 10px;"><span class="title">快速通道：</span><span class="remark">灵活自定义模块，快速访问常用操作。</span></h6>
                            </div>
                        </div>
                        <div class="item">
                            <div class="icon"><span style="background-position:2px -258px"></span></div>
                            <div class="list">
                                <div class="top"></div>
                                <h6><span class="title">主功能区：</span><span class="remark">企业必备的入口创建工具，直达消费者手中的服务中心。</span></h6>
                                <ul>
                                    <li><a target="_blank" href="http://www.968ch.com/detail.html?0-0">产品自媒体</a></li>
                                    <li><a target="_blank" href="http://www.968ch.com/detail.html?0-3">产品溯源</a></li>
                                    <li><a target="_blank" href="http://www.968ch.com/detail.html?0-2">人才招聘</a></li>
                                    <li><a target="_blank" href="http://www.968ch.com/detail.html?0-1">微店系统</a></li>
                                </ul>
                            </div>
                            <div class="hot" style="left:123px;"></div>
                        </div>
                        <div class="item">
                            <div class="icon"><span style="background-position: 2px -306px"></span></div>
                            <div class="list">
                                <div class="top"></div>
                                <h6><span class="title">推广工具区：</span><span class="remark">移动营销人的必备武器，传播、互动营销的有效工具。</span></h6>
                                <ul>
                                    <li><a target="_blank" href="http://www.968ch.com/detail.html?1-0">主题自媒体</a></li>
                                    <li><a target="_blank" href="http://www.968ch.com/detail.html?1-1">场景自媒体</a></li>
                                    <li><a target="_blank" href="http://www.968ch.com/detail.html?1-2">大众号</a></li>
                                    <li><a target="_blank" href="http://www.968ch.com/detail.html?1-4">圈子</a></li>
                                </ul>
                            </div>
                            <div class="hot" style="left:139px"></div>
                        </div>
                        <div class="item">
                            <div class="icon"><span style="background-position:  3px -347px;"></span></div>
                            <div class="list">
                                <div class="top"></div>
                                <h6><span class="title">免费服务区：</span><span class="remark">常用的免费应用工具，方便、快捷管理自媒体内容。</span></h6>
                                <ul>
                                    <li><a target="_blank" href="http://www.968ch.com/detail.html?2-0">自媒体名片</a></li>
                                    <li><a target="_blank" href="http://www.968ch.com/detail.html?2-1">微官网</a></li>
                                    <li><a target="_blank" href="http://www.968ch.com/detail.html?2-3">数据统计</a></li>
                                    <li><a target="_blank" href="http://www.968ch.com/detail.html?2-3">控制台</a></li>
                                    <li><a target="_blank" href="http://www.968ch.com/detail.html?2-2">会员管理</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="item">
                            <div class="icon"><span style="background-position: 2px -387px;"></span></div>
                            <div class="list">
                                <div class="top"></div>
                                <h6 style="margin-top: 10px;"><span class="title">个人中心：</span><span class="remark">个人用户PC端操作后台。</span></h6>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="section_4">
                    <div class="title"><i></i><span>定制开发申请</span></div>
                    <div class="remark">
                        <span class="text">本公司还提供各种软件/APP定制开发服务,如有需求请与我们联系吧!</span>
                        <span class="btnApply" id="btnCustomApply">定制开发申请</span>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
