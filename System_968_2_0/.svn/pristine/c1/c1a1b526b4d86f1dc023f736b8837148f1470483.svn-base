<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetCompanyModule.aspx.cs" Inherits="SetCompanyModule" %>
<%@ Import Namespace="Ac968.SystemModuleSetMeal.Model" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        企业ID：<input type="text" name="CompanyId" /><br />
    <%
        foreach (SystemModule item in __ModuleList)
        {
            %>
        <input checked="checked" name="module" id="module<%=item.id %>" value="<%=item.id %>" type="checkbox" />
        <label for="module<%=item.id %>"><%=item.Name %></label>
        <%
        }
         %>
        <br />
        <button type="submit">保存</button>
    </div>
    </form>
</body>
</html>
