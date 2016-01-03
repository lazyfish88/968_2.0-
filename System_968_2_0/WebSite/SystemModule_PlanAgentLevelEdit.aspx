<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemModule_PlanAgentLevelEdit.aspx.cs" Inherits="SystemModule_PlanAgentLevelEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="http://m.968ch.com/Include/main.css?v=1" rel="stylesheet" type="text/css" />
    <link href="http://m.968ch.com/Include/UserCenter.css?v=1.02" rel="stylesheet" type="text/css" />
    <link href="http://m.968ch.com/Include/PagerStyle.css" rel="stylesheet" type="text/css" />
    <link href="http://m.968ch.com/Include/CheckBoxStyle.css?v=1" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://m.968ch.com/Scripts/jquery-1.7.2.min.js"></script>
    <script>
        $(function () {
            $("#form1").submit(function () {
                if (!$("input[name=Name]").val()) {
                    alert("名称不能为空")
                    return false;
                }

                $.post("SystemModule_PlanAgentLevelEdit.aspx", $(this).serialize(), function () {
                    alert("提交成功")
                    window.location = "SystemModule_PlanAgentLevelList.aspx";
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
                <div class="con_score_title box_sizing">编辑OEM等级</div>
                <table class="sub_edit_tbl">
                    <tbody>
                        <tr>
                            <td class="item1">名称:</td>
                            <td class="item3">
                                <input name="Name" value="<%=__Model.Name %>" type="text" class="aspNetDisabled InputText box_sizing box_round">
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
                                <a href="SystemModule_PlanAgentLevelList.aspx" class="ret100 h_marginl10 box_sizing box_round">返回</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <input name="id" value="<%=__Model.id %>" type="hidden" />
    </form>
</body>
</html>
