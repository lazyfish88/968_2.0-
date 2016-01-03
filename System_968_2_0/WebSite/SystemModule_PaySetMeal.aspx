﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemModule_PaySetMeal.aspx.cs" Inherits="SystemModule_PaySetMeal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="http://m.968ch.com/Include/main.css?v=1" rel="stylesheet" type="text/css" />
    <link href="http://m.968ch.com/Include/UserCenter.css?v=1.02" rel="stylesheet" type="text/css" />
    <link href="http://m.968ch.com/Include/PagerStyle.css" rel="stylesheet" type="text/css" />
    <link href="http://m.968ch.com/Include/CheckBoxStyle.css?v=1" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://m.968ch.com/Scripts/jquery-1.7.2.min.js"></script>
    <link href="Style/global.css" rel="stylesheet" />
    <style>
        h4 {
            border-left: 5px solid #fd9834;
            padding: 10px;
            font-size: 16px;
            font-weight: normal;
        }

        table {
            border: 1px solid #ddd;
            width: 100%;
            margin-top: 10px;
        }

            table tr {
            }

            table td {
                padding: 20px 0;
                border-bottom: 1px dashed #ddd;
            }

            table tr.item:last-child td {
                border: 0;
            }

            table td .btnShow {
                border: 1px solid #efefef;
                padding: 10px;
                border-radius: 15px;
            }

        .td_checkbox {
            text-align: center;
            padding: 0 21px;
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

        .ModuleList {
            background: #efefef;
            display: none;
        }

            .ModuleList td {
                padding: 0;
            }

            .ModuleList table {
                border: 0;
            }

                .ModuleList table td {
                    border: 0;
                    padding: 10px;
                }

            .ModuleList .name {
                padding-left: 80px;
            }

            .ModuleList .day {
                width: 90px;
            }

            .ModuleList .remark {
                width: 170px;
            }

                .ModuleList .remark a:link, .ModuleList .remark a:hover, .ModuleList .remark a:visited {
                    color: #fd9834;
                    text-decoration: none;
                }

                .ModuleList .remark a:hover {
                    text-decoration: underline;
                }

        #btnPay {
            background: #fd9834;
            border-radius: 15px;
            padding: 10px 20px;
            color: #fff;
            margin-left: 50px;
            text-align: center;
            float: right;
            cursor: pointer;
        }
    </style>
    <script>
        $(function () {
            var __IsCompany = "<%=__IsCompany?"1":"0"%>";
            $("table .btnShow").click(function () {
                var row = $(this).parents("tr");
                var nextRow = row.next();
                if (nextRow.css("display") == "none") {
                    $(this).html("收起")
                    nextRow.show();
                }
                else {
                    $(this).html("查看详情")
                    nextRow.hide();
                }
            })
            $(".checkbox").click(function () {
                if ($(this).hasClass("checked")) {
                    $(this).removeClass("checked");
                }
                else {
                    $(this).addClass("checked");
                }
            })
            $("#btnPay").click(function () {
                var checkElmList = $("table .checkbox.checked");
                var checkIds = ",";
                if (checkElmList.length > 0) {
                    for (var i = 0; i < checkElmList.length; i++) {
                        var item = $(checkElmList.get(i)).parents("tr");
                        var name = item.find(".name").text()
                        if (item.next().find("tr[data-need-company=1]").length > 0 && __IsCompany == "0") {
                            if (confirm("开通“" + name + "”需先升级为企业用户")) {
                                window.location = "/admin/Upgrade.aspx";
                            }
                            return false;
                        }
                        checkIds += item.attr("data-id") + ",";
                    }
                }
                else {
                    alert("请选择要开通的套餐");
                    return false;
                }
                window.location = 'SystemModule_PaySetMeal.aspx?action=pay&id=' + checkIds;
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="frame_width frame_top">
            <h4>请选择套餐</h4>
            <%--<div class="ulist_win">
                <table class="ulist_search_tbl">
                    <tbody>
                        <tr>
                            <th>&nbsp;</th>
                            <td style="text-align: right;">
                                <input style="float: right;" type="button" value="添加" onclick="window.location = 'SystemModule_SetMealDetail.aspx'" class="search_btn box_sizing box_round">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>--%>
            <table>
                <tbody>
                    <%--<tr>
                        <th>选择</th>
                        <th>价格</th>
                        <th>添加时间</th>
                        <th>操作</th>
                    </tr>--%>
                    <%
                        foreach (Ac968.SystemModuleSetMeal.Model.SystemModuleSetMeal item in list)
                        {
                            string setMealState = "";
                            switch (item.CompanyState)
                            {
                                case 0:
                                    setMealState = string.Format("<span style='color:#f00;padding-left:10px;'>（有效期至 {0:yyyy-MM-dd}）</span>", item.OverDate);
                                    break;
                                case 1:
                                    setMealState = string.Format("<span style='color:#999;padding-left:10px;'>（已于 {0:yyyy-MM-dd} 过期）</span>", item.OverDate);
                                    break;
                                default:
                                    break;
                            }
                    %>
                    <tr class="item" data-id="<%=item.id %>">
                        <td class="td_checkbox" style="width: 50px;">
                            <span class="checkbox"></span>
                        </td>
                        <td><span class="name"><%=item.Name %></span><%=setMealState %></td>
                        <td style="width: 100px;">￥<%=item.Price %></td>
                        <td style="width: 180px;">
                            <a href="javascript:;" class="btnShow">查看详情</a>
                        </td>
                    </tr>
                    <tr class="ModuleList">
                        <td colspan="4">
                            <table style="width: 100%;">
                                <%
                                    foreach (Ac968.SystemModuleSetMeal.Model.V_SystemModuleSetMealDetail moduleItem in item.ModuleList)
                                    {
                                %>
                                <tr data-need-company="<%=moduleItem.NeedCompany?"1":"0" %>">
                                    <td class="name">
                                        <%=moduleItem.Name %>
                                        <%=moduleItem.NeedCompany?("<span style='color:#f00'>（需认证成为企业用户）</span>"):("") %>
                                    </td>
                                    <td class="day">
                                        <%=item.Day %>天
                                    </td>
                                    <td class="remark">
                                        <a target="_blank" href="<%=moduleItem.DescriptionUrl %>">详细介绍</a>
                                    </td>
                                </tr>
                                <%
                                    }
                                %>
                            </table>
                        </td>
                    </tr>
                    <% }
                    %>
                </tbody>
            </table>
            <div class="clear" style="text-align: center; margin: 5px auto;">
                <%=Pager %>
            </div>
            <div id="btnPay">确定购买</div>
        </div>
    </form>
</body>
</html>
