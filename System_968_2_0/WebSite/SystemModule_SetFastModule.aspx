<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemModule_SetFastModule.aspx.cs" Inherits="SystemModule_SetFastModule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="http://m.968ch.com/Scripts/jquery-1.7.2.min.js"></script>
    <style>
        ul, li {
            list-style: none;
            margin: 0;
            padding: 0;
        }

        h4 {
            border-left: 5px solid #fd9834;
            padding: 10px;
            font-size: 16px;
            font-weight: normal;
        }

        .checkbox {
            background: url(/img/icon_v2.png) no-repeat 0 -25px;
            display: inline-block;
            width: 17px;
            height: 17px;
            margin: 0 auto;
            cursor: pointer;
        }

            .checkbox.checked {
                background-position: 0 0;
            }

        .moduleItem {
            border-collapse: collapse;
            margin-top: 10px;
            width: 100%;
            border: 1px solid #ddd;
        }

            .moduleItem th {
                color: #fff;
                width: 85px;
            }

            .moduleItem td {
                padding-bottom: 10px;
            }

            .moduleItem .fnItem {
                float: left;
                cursor: pointer;
            }

                .moduleItem .fnItem .name {
                    padding: 10px;
                    background: #efefef;
                    border-radius: 15px;
                    display: inline-block;
                }

            .moduleItem ul li {
                float: left;
                padding-top: 10px;
                margin-left: 10px;
            }

        #btnSubmit {
            background: #fd9834;
            border-radius: 15px;
            padding: 10px 0;
            width: 150px;
            margin: 0 auto;
            color: #fff;
            text-align: center;
            cursor: pointer;
        }
    </style>
    <script>
        $(function () {
            var __FnUrls = "<%=__FnUrls%>".split('|');
            for (var i in __FnUrls) {
                var item = __FnUrls[i];
                console.log(item);
                $(".fnItem[data-url=\"" + item + "\"]").find(".checkbox").addClass("checked");
            }

            $(".moduleItem li").click(function () {
                var inputElm = $(this).find(".checkbox");
                if (inputElm.hasClass("checked")) {
                    inputElm.removeClass("checked");
                }
                else {
                    inputElm.addClass("checked");
                }
            })
            $("#btnSubmit").click(function () {
                var moduleElmList = $(".moduleItem");
                var moduleIds = "|";
                var fnUrls = "|";
                var fnNames = "|";
                for (var i = 0; i < moduleElmList.length; i++) {
                    var moduleElm = $(moduleElmList.get(i));
                    if (moduleElm.find(".checked").length==0) {
                        continue;
                    }
                    var moduleId = moduleElm.find("tr").attr("data-module");
                    moduleIds += moduleId + "|";
                    var fnElmList = moduleElm.find(".fnItem");
                    for (var j = 0; j < fnElmList.length; j++) {
                        var fnElm = $(fnElmList.get(j));
                        if (fnElm.find(".checked").length == 0) {
                            continue;
                        }
                        fnUrls += fnElm.attr("data-url") + ",";
                        fnNames += fnElm.find(".name").html() + ",";
                    }
                    fnUrls += "|";
                    fnNames += "|";
                }
                var postParam = {
                    ModuleIds: moduleIds,
                    FnUrls: fnUrls,
                    FnNames:fnNames
                };
                $.post("SystemModule_SetFastModule.aspx", postParam, function (data) {
                    alert("设置成功")
                    window.parent.location.reload();
                })
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="frame_width frame_top">
            <h4>快速入口设置</h4>
            <%
                if (__HasModuleIds.Contains(",1,"))
                {
                    %>
            <table class="moduleItem" style="" cellspacing="0" cellpadding="0">
                <tr data-module="1">
                    <th style="vertical-align: central; background: #ff8862">产品<br />
                        自媒体</th>
                    <td>
                        <ul>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/ProductMain.aspx?iframe_index=0">
                                <span class="checkbox"></span>
                                <span class="name">产品编辑</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/ProductMain.aspx?iframe_index=1">
                                <span class="checkbox"></span>
                                <span class="name">积分管理</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/ProductMain.aspx?iframe_index=2">
                                <span class="checkbox"></span>
                                <span class="name">品类管理</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/ProductMain.aspx?iframe_index=3">
                                <span class="checkbox"></span>
                                <span class="name">产品属性</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/ProductMain.aspx?iframe_index=4">
                                <span class="checkbox"></span>
                                <span class="name">展示页属性</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/ProductMain.aspx?iframe_index=5">
                                <span class="checkbox"></span>
                                <span class="name">超链管理</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/ProductMain.aspx?iframe_index=6">
                                <span class="checkbox"></span>
                                <span class="name">批量超链管理</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/ProductMain.aspx?iframe_index=7">
                                <span class="checkbox"></span>
                                <span class="name">导入商城产品</span>
                            </li>
                        </ul>
                        <div style="clear: both;"></div>
                    </td>
                </tr>
            </table>
            <%
                }
                %>
            
            <%
                if (__HasModuleIds.Contains(",7,"))
                {
                    %>
            <table class="moduleItem" style="" cellspacing="0" cellpadding="0">
                <tr data-module="7">
                    <th style="vertical-align: central; background: #66b7ef">主题<br />
                        自媒体</th>
                    <td>
                        <ul>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/ThemeMain.aspx?iframe_index=0">
                                <span class="checkbox"></span>
                                <span class="name">主题自媒体</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/ThemeMain.aspx?iframe_index=1">
                                <span class="checkbox"></span>
                                <span class="name">问卷调查</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/ThemeMain.aspx?iframe_index=2">
                                <span class="checkbox"></span>
                                <span class="name">抽奖</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/ThemeMain.aspx?iframe_index=3">
                                <span class="checkbox"></span>
                                <span class="name">批量超链管理</span>
                            </li>
                        </ul>
                        <div style="clear: both;"></div>
                    </td>
                </tr>
            </table>
            <%
                }
                %>
            
            <%
                if (__HasModuleIds.Contains(",8,"))
                {
                    %>
            <table class="moduleItem" style="" cellspacing="0" cellpadding="0">
                <tr data-module="8">
                    <th style="vertical-align: central; background: #a48ad5">场景<br />自媒体</th>
                    <td>
                        <ul>
                            <li class="fnItem" data-url="http://diy.968ch.com/index.php#/main">
                                <span class="checkbox"></span>
                                <span class="name">我的场景</span>
                            </li>
                            <li class="fnItem" data-url="http://diy.968ch.com/index.php#/main/spread/statistics">
                                <span class="checkbox"></span>
                                <span class="name">场景展示</span>
                            </li>
                            <li class="fnItem" data-url="http://diy.968ch.com/index.php#/main/customer">
                                <span class="checkbox"></span>
                                <span class="name">我的客户</span>
                            </li>
                            <li class="fnItem" data-url="http://diy.968ch.com/index.php#/scene">
                                <span class="checkbox"></span>
                                <span class="name">创建场景</span>
                            </li>
                        </ul>
                        <div style="clear: both;"></div>
                    </td>
                </tr>
            </table>
            <%
                }
                %>
            
            <%
                if (__HasModuleIds.Contains(",9,"))
                {
                    %>
            <table class="moduleItem" style="" cellspacing="0" cellpadding="0">
                <tr data-module="9">
                    <th style="vertical-align: central; background: #fbb321">自媒体<br />
                        名片</th>
                    <td>
                        <ul>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Com/User.aspx">
                                <span class="checkbox"></span>
                                <span class="name">自媒体名片列表</span>
                            </li>
                        </ul>
                        <div style="clear: both;"></div>
                    </td>
                </tr>
            </table>
            <%
                }
                %>
            
            <%
                if (__HasModuleIds.Contains(",10,"))
                {
                    %>
            <table class="moduleItem" style="" cellspacing="0" cellpadding="0">
                <tr data-module="10">
                    <th style="vertical-align: central; background: #8cc447">微官网</th>
                    <td>
                        <ul>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Com/Main.aspx?iframe_index=0">
                                <span class="checkbox"></span>
                                <span class="name">系统设置</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Com/Main.aspx?iframe_index=1">
                                <span class="checkbox"></span>
                                <span class="name">信息管理</span>
                            </li>
                        </ul>
                        <div style="clear: both;"></div>
                    </td>
                </tr>
            </table>
            <%
                }
                %>
            
            <%
                if (__HasModuleIds.Contains(",3,"))
                {
                    %>
            <table class="moduleItem" style="" cellspacing="0" cellpadding="0">
                <tr data-module="3">
                    <th style="vertical-align: central; background: #20b4ac">人才招聘</th>
                    <td>
                        <ul>
                            <li class="fnItem" data-url="http://rccom.968ch.com/Main/BaseSetting">
                                <span class="checkbox"></span>
                                <span class="name">基本设置</span>
                            </li>
                            <li class="fnItem" data-url="http://rccom.968ch.com/JobPost/List">
                                <span class="checkbox"></span>
                                <span class="name">职位管理</span>
                            </li>
                            <li class="fnItem" data-url="http://rccom.968ch.com/JobPostApply/List">
                                <span class="checkbox"></span>
                                <span class="name">简历管理</span>
                            </li>
                            <li class="fnItem" data-url="http://rccom.968ch.com/InterviewInvite/List">
                                <span class="checkbox"></span>
                                <span class="name">面试记录</span>
                            </li>
                        </ul>
                        <div style="clear: both;"></div>
                    </td>
                </tr>
            </table>
            <%
                }
                %>
            
            <%
                if (__HasModuleIds.Contains(",4,"))
                {
                    %>
            <table class="moduleItem" style="" cellspacing="0" cellpadding="0">
                <tr data-module="4">
                    <th style="vertical-align: central; background: #252d57">微店系统</th>
                    <td>
                        <ul>
                            <li class="fnItem" data-url="http://968trade.968ch.com/Setting/BaseSet.aspx">
                                <span class="checkbox"></span>
                                <span class="name">基本设置</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/Setting/AdPicture/AdPictureList.aspx">
                                <span class="checkbox"></span>
                                <span class="name">广告轮播设置</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/Setting/FreightTemplate/FreightTemplateList.aspx">
                                <span class="checkbox"></span>
                                <span class="name">运费模版</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/Setting/QQService/QQServiceList.aspx">
                                <span class="checkbox"></span>
                                <span class="name">客服设置</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/Setting/Service/List.aspx">
                                <span class="checkbox"></span>
                                <span class="name">服务列表</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/Setting/ExpressSetting.aspx">
                                <span class="checkbox"></span>
                                <span class="name">常用快递设置</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/Promotion/CouponList.aspx">
                                <span class="checkbox"></span>
                                <span class="name">优惠券管理</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/Product/Type/Index.aspx">
                                <span class="checkbox"></span>
                                <span class="name">类别设置</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/Product/ProductSpec/List.aspx">
                                <span class="checkbox"></span>
                                <span class="name">商品规格</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/Product/Product/Index.aspx">
                                <span class="checkbox"></span>
                                <span class="name">商品列表</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/Order/List/OrderList.aspx">
                                <span class="checkbox"></span>
                                <span class="name">订单管理</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/User/UserList.aspx">
                                <span class="checkbox"></span>
                                <span class="name">会员列表</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/User/UserLevelList.aspx">
                                <span class="checkbox"></span>
                                <span class="name">会员等级列表</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/store/Agent/SetDistribut.aspx">
                                <span class="checkbox"></span>
                                <span class="name">分销设置</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/store/Minivan/wkList.aspx">
                                <span class="checkbox"></span>
                                <span class="name">代理商管理</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/store/Minivan/ProfitList.aspx?t=0">
                                <span class="checkbox"></span>
                                <span class="name">佣金列表</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/Order/OrderCount/CountList.aspx">
                                <span class="checkbox"></span>
                                <span class="name">订单统计</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/ConvRule/PointsConvList.aspx">
                                <span class="checkbox"></span>
                                <span class="name">积分兑换策略</span>
                            </li>
                            <li class="fnItem" data-url="http://968trade.968ch.com/Article/EnterpriseInfo/EnterpriseInfoList.aspx">
                                <span class="checkbox"></span>
                                <span class="name">企业动态</span>
                            </li>
                        </ul>
                        <div style="clear: both;"></div>
                    </td>
                </tr>
            </table>
            <%
                }
                %>

            
            <%
                if (__HasModuleIds.Contains(",2,"))
                {
                    %>
            <table class="moduleItem" style="" cellspacing="0" cellpadding="0">
                <tr data-module="2">
                    <th style="vertical-align: central; background: #71bdd8">产品溯源</th>
                    <td>
                        <ul>
                            <li class="fnItem" data-url="http://trace.968ch.com/Tracebility/List">
                                <span class="checkbox"></span>
                                <span class="name">溯源列表</span>
                            </li>
                        </ul>
                        <div style="clear: both;"></div>
                    </td>
                </tr>
            </table>
            <%
                }
                %>
            
            <%
                if (__HasModuleIds.Contains(",6,"))
                {
                    %>
            <table class="moduleItem" style="" cellspacing="0" cellpadding="0">
                <tr data-module="6">
                    <th style="vertical-align: central; background: #5d6532">圈子</th>
                    <td>
                        <ul>
                            <li class="fnItem" data-url="http://mbbs.968ch.com/Admin/BaseSetting">
                                <span class="checkbox"></span>
                                <span class="name">基本设置</span>
                            </li>
                            <li class="fnItem" data-url="http://mbbs.968ch.com/Admin/ForumList">
                                <span class="checkbox"></span>
                                <span class="name">小组管理</span>
                            </li>
                            <li class="fnItem" data-url="http://mbbs.968ch.com/Admin/UserList">
                                <span class="checkbox"></span>
                                <span class="name">用户管理</span>
                            </li>
                        </ul>
                        <div style="clear: both;"></div>
                    </td>
                </tr>
            </table>
            <%
                }
                %>
            <%
                if (__HasModuleIds.Contains(",5,"))
                {
                    %>
            <table class="moduleItem" style="" cellspacing="0" cellpadding="0">
                <tr data-module="5">
                    <th style="vertical-align: central; background: #dd412b">大众号</th>
                    <td>
                        <ul>
                            <li class="fnItem" data-url="http://mp.968ch.com/PublicNumber/BaseSetting">
                                <span class="checkbox"></span>
                                <span class="name">基本设置</span>
                            </li>
                            <li class="fnItem" data-url="http://mp.968ch.com/PublicNumber/MessageList">
                                <span class="checkbox"></span>
                                <span class="name">消息管理</span>
                            </li>
                        </ul>
                        <div style="clear: both;"></div>
                    </td>
                </tr>
            </table>
            <%
                }
                %>
            
            <%
                if (__HasModuleIds.Contains(",14,"))
                {
                    %>
            <table class="moduleItem" style="" cellspacing="0" cellpadding="0">
                <tr data-module="14">
                    <th style="vertical-align: central; background: #b71981">会员管理</th>
                    <td>
                        <ul>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/UserList.aspx">
                                <span class="checkbox"></span>
                                <span class="name">会员列表</span>
                            </li>
                        </ul>
                        <div style="clear: both;"></div>
                    </td>
                </tr>
            </table>
            <%
                }
                %>
            <%
                if (__HasModuleIds.Contains(",12,"))
                {
                    %>
            <table class="moduleItem" style="" cellspacing="0" cellpadding="0">
                <tr data-module="12">
                    <th style="vertical-align: central; background: #20b4ac">控制台</th>
                    <td>
                        <ul>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Console.aspx?iframe_index=0">
                                <span class="checkbox"></span>
                                <span class="name">积分管理</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Console.aspx?iframe_index=1">
                                <span class="checkbox"></span>
                                <span class="name">信息设置</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Console.aspx?iframe_index=2">
                                <span class="checkbox"></span>
                                <span class="name">订单及用户权限</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Console.aspx?iframe_index=3">
                                <span class="checkbox"></span>
                                <span class="name">系统设置</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Console.aspx?iframe_index=4">
                                <span class="checkbox"></span>
                                <span class="name">用户管理</span>
                            </li>
                        </ul>
                        <div style="clear: both;"></div>
                    </td>
                </tr>
            </table>
            <%
                }
                %>
            
            <%
                if (__HasModuleIds.Contains(",11,"))
                {
                    %>
            <table class="moduleItem" style="" cellspacing="0" cellpadding="0">
                <tr data-module="11">
                    <th style="vertical-align: central; background: #00916f">数据统计</th>
                    <td>
                        <ul>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Count/Main.aspx?iframe_index=0">
                                <span class="checkbox"></span>
                                <span class="name">实时统计</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Count/Main.aspx?iframe_index=1">
                                <span class="checkbox"></span>
                                <span class="name">按日期统计</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Count/Main.aspx?iframe_index=2">
                                <span class="checkbox"></span>
                                <span class="name">地域分布</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Count/Main.aspx?iframe_index=3">
                                <span class="checkbox"></span>
                                <span class="name">系统环境</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Count/Main.aspx?iframe_index=4">
                                <span class="checkbox"></span>
                                <span class="name">客户端类型</span>
                            </li>
                            <li class="fnItem" data-url="http://m.968ch.com/admin/Count/Main.aspx?iframe_index=5">
                                <span class="checkbox"></span>
                                <span class="name">自定义统计</span>
                            </li>
                        </ul>
                        <div style="clear: both;"></div>
                    </td>
                </tr>
            </table>
            <%
                }
                %>
        </div>
        <div style="padding-top:10px;">
            <div id="btnSubmit">保存</div>
        </div>
    </form>
</body>
</html>
