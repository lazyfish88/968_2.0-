<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemModule_PaySuccess.aspx.cs" Inherits="SystemModule_Alipay_SystemModule_PaySuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        body {
            background: #fff;
        }

        ul, li {
            margin: 0;
            padding: 0;
            list-style: none;
        }

        h4 {
            border-left: 5px solid #fd9834;
            padding: 10px;
            text-align: left;
            font-size: 16px;
            font-weight: normal;
        }

        .frame_width {
            text-align: center;
        }

            .frame_width .msg_box {
                margin: 0 auto;
                width: 250px;
                text-align: center;
            }

                .frame_width .msg_box .icon {
                    background: url(/img/icon_v2.png) no-repeat -167px 0;
                    width: 205px;
                    height: 205px;
                    margin: 0 auto;
                    margin-bottom: 10px;
                }

                .frame_width .msg_box .pay_detail {
                    text-align: left;
                    padding-top: 20px;
                }

        .price {
            color: #fd9834;
        }

        .frame_width .msg_box .pay_detail .fn_list {
            border: 1px solid #ddd;
            padding: 10px;
            line-height: 30px;
            background: #efefef;
            margin-top: 10px;
            color: #666;
        }

            .frame_width .msg_box .pay_detail .fn_list li {
            }

            .frame_width .msg_box .pay_detail .fn_list .day {
                color: #fd9834;
            }

        #btnRefresh {
            background: #fd9834;
            border-radius: 15px;
            padding: 10px 0;
            width:120px;
            color: #fff;
            margin:10px auto;
            text-align: center;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="frame_width frame_top">
            <h4>购买成功</h4>
            <div class="msg_box">
                <div class="icon"></div>
                <div>恭喜您支付成功，支付金额<span class="price">￥<%=__OrderInfo.Price %></span></div>
                <div class="pay_detail">
                    <div>购买套餐：<%=__SetMealNames %></div>
                    <ul class="fn_list">
                        <%
                            foreach (Ac968.SystemModuleSetMeal.Model.V_SystemModuleSetMealDetail item in __ModuleList)
                            {
                        %>
                        <li><%=item.Name %>（<span class="day"><%=item.Day %>天</span>）</li>
                        <%
                            }
                        %>
                    </ul>
                </div>
                <div id="btnRefresh" onclick="window.parent.location.reload()">刷新菜单</div>
            </div>
        </div>
    </form>
</body>
</html>
