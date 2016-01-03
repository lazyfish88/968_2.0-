<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemModule_SetMealDetail.aspx.cs" Inherits="SystemModule_SetMealDetail" %>

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
    <style>
        .sub_edit_tbl .item3 label{
            float:initial;
        }
        strong{
            display:block;
            margin:0;
            padding:0;
        }
        .moduleList{
            padding:10px;
            border:1px solid #efefef;
        }
    </style>
    <script>
        $(function () {
            $("#form1").submit(function () {

                if (!$("input[name=Name]").val()) {
                    alert("名称不能为空")
                    return false;
                }
                if (!$("input[name=Price]").val() || !parseFloat($("input[name=Price]").val())) {
                    alert("请填写正确的价格")
                    return false;
                }
                $.post("SystemModule_SetMealDetail.aspx", $(this).serialize(), function () {
                    alert("提交成功")
                    window.location = "SystemModule_SetMealList.aspx";
                })
                return false;
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="frame_width frame_top">
                <div class="con_score_title box_sizing">编辑套餐</div>
                <table class="sub_edit_tbl">
                    <tbody>
                        <tr>
                            <td class="item1">名称:</td>
                            <td class="item3">
                                <input name="Name" value="<%=__SetMeal.Name %>" type="text" class="aspNetDisabled InputText box_sizing box_round">
                            </td>
                        </tr>
                        <tr>
                            <td class="item1">价格:</td>
                            <td class="item3">
                                <input name="Price" value="<%=__SetMeal.Price %>" type="text" class="aspNetDisabled InputText box_sizing box_round">
                            </td>
                        </tr>
                        <tr>
                            <td class="item1">使用天数:</td>
                            <td class="item3">
                                <input name="Day" value="<%=__SetMeal.Day %>" type="text" class="aspNetDisabled InputText box_sizing box_round">
                            </td>
                        </tr>
                        <tr>
                            <td class="item1">启用状态:</td>
                            <td class="item3">
                                <input type="radio" <%=__SetMeal.Enable?"":"checked=\"checked\"" %> name="Enable" id="Enable0" value="0" />
                                <label for="Enable0">未启用</label>
                                <input type="radio" <%=__SetMeal.Enable?"checked=\"checked\"":"" %> name="Enable" id="Enable1" value="1" />
                                <label for="Enable1">启用</label>
                            </td>
                        </tr>
                        <tr>
                            <td class="item1">套餐模块</td>
                            <td class="item3">
                                <%foreach (Ac968.SystemModuleSetMeal.Model.SystemModule item in __ModuleList)
                                    {
                                        %>
                                <input type="checkbox" <%=__setMealIds.Contains(","+item.id+",")?"checked='checked'":"" %>  name="Module" value="<%=item.id %>" id="Module<%=item.id %>" />
                                <label for="Module<%=item.id %>"><%=item.Name %></label>
                                <%
                                    } %>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <span id="lblErrorName" style="color: Red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <input type="submit" name="btnSave" value="提交" id="btnSave" class="save100 h_marginl10 box_sizing box_round" />
                                <a href="SystemModule_SetMealList.aspx" class="ret100 h_marginl10 box_sizing box_round">返回</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <input name="id" value="<%=__SetMeal.id %>" type="hidden" />
    </form>
</body>
</html>
