\<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemModule_PlanAgentLevelList.aspx.cs" Inherits="SystemModule_PlanAgentLevelList" %>

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
    <script>
        function del(id) {
            if (confirm("确定删除此等级？")) {
                $.get("SystemModule_PlanAgentLevelList.aspx?action=del&id=" + id, function () {
                    alert("删除成功");
                    window.location.reload();
                })
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="frame_width frame_top">
            <div class="ulist_win">
                <table class="ulist_search_tbl">
                    <tbody>
                        <tr>
                            <th>&nbsp;</th>
                            <td style="text-align: right;">
                                <input style="float: right;" type="button" value="添加" onclick="window.location = 'SystemModule_PlanAgentLevelEdit.aspx'" class="add_btn box_sizing box_round">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <table class="lot_sub_tbl">
                <tbody>
                    <tr>
                        <th>名称</th>
                        <th>操作</th>
                    </tr>
                    <%
                        foreach (Ac968.SystemModuleSetMeal.Model.PlanAgentLevel item in list)
                        { %>
                    <tr>
                        <td><%=item.Name %></td>
                        <td>
                            <a href="SystemModule_PlanAgentLevelEdit.aspx?id=<%=item.id %>">编辑</a>
                            <a href="javascript:;" onclick="del(<%=item.id %>)">删除</a>
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
