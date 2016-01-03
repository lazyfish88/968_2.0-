<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomDevList.aspx.cs" Inherits="CustomDevList" %>

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
        function update(id,state) {
            $.get("CustomeDevList.aspx?id=" + id + "&state=" + state, function () {

            })

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="frame_width frame_top">
            <table class="lot_sub_tbl">
                <tbody>
                    <tr>
                        <th>姓名</th>
                        <th>联系电话</th>
                        <th>申请说明</th>
                        <th>状态</th>
                        <th>操作</th>
                    </tr>
                    <%
                        foreach (Ac968.SystemModuleSetMeal.Model.CustomApply item in list)
                        { %>
                    <tr>
                        <td><%=item.UserName %></td>
                        <td><%=item.Tel %></td>
                        <td><%=item.Remark %></td>
                        <td><%=item.State == 0?"未处理":"已处理" %></td>
                        <td>
                            <%if (item.State==0)
	{
                                    %>
                            <a href="javascript:;" onclick="update(<%=item.id %>,1)">处理完成</a>
                            <%
	} %>
                        </td>
                    </tr>
                    <% }
                    %>
                </tbody>
            </table>
            <div class="clear" style="text-align: center; margin: 5px auto;">
                <%=Pager %>
            </div>
        </div>
    </form>
</body>
</html>
