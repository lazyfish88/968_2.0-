<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemModule_SystemModuleList.aspx.cs" Inherits="SystemModule_SystemModuleList" %>

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
    <script>
        function Update(id, isDefault) {
            $.get("SystemModule_SystemModuleList.aspx?action=UpdateDefault&id=" + id + "&isDefault=" + isDefault, function () {
                alert("设置成功");
                window.location.reload();
            })
        }
        function UpdateType(id, needCompany) {
            $.get("SystemModule_SystemModuleList.aspx?action=UpdateType&id=" + id + "&needCompany=" + needCompany, function () {
                alert("设置成功");
                window.location.reload();
            })
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="frame_width frame_top">
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
            <table class="lot_sub_tbl">
                <tbody>
                    <tr>
                        <th>名称</th>
                        <th>地址</th>
                        <th>模块类型</th>
                        <th>是否默认</th>
                        <th>操作</th>
                    </tr>
                    <%
                        foreach (Ac968.SystemModuleSetMeal.Model.SystemModule item in list)
                        { %>
                    <tr>
                        <td><%=item.Name %></td>
                        <td><%=item.Url %></td>
                        <td><%=item.NeedCompany?"企业模块":"普通模块" %></td>
                        <td><%=item.IsDefault?"是":"否" %></td>
                        <td>
                            <%
                                if (item.IsDefault)
                                {
                            %>
                            <a href="javascript:;" onclick="Update(<%=item.id %>,0)">取消默认</a>
                            <%
                                }
                                else
                                {
                            %>
                            <a href="javascript:;" onclick="Update(<%=item.id %>,1)">设为默认</a>
                            <%
                                }
                            %>
                            <%
                                if (item.NeedCompany)
                                {
                            %>
                            <a href="javascript:;" onclick="UpdateType(<%=item.id %>,0)">设为普通模块</a>
                            <%
                                }
                                else
                                {
                            %>
                            <a href="javascript:;" onclick="UpdateType(<%=item.id %>,1)">设为企业模块</a>
                            <%
                                }
                            %>
                        </td>
                    </tr>
                    <% }
                    %>
                </tbody>
            </table>
            <div class="clear" style="text-align: center; margin: 5px auto;">
            </div>
        </div>
    </form>
</body>
</html>
