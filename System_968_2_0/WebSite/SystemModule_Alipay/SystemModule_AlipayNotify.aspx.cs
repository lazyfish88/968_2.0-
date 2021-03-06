﻿using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using Ac968.SystemModuleSetMeal.Utility.Alipay;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

public partial class SystemModule_Alipay_SystemModule_AlipayNotify : SetMealPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        SortedDictionary<string, string> sPara = GetRequestPost();
        int RechType = 0;
        string types = "1", sn = "";
        if (sPara.Count > 0)//判断是否有带返回参数
        {

            string order_no = Request.Form["out_trade_no"].ToString();     //获取订单号


            Notify aliNotify = new Notify(types);
            bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);


            if (verifyResult)//验证成功
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //请在这里加上商户的业务逻辑程序代码

                //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表
                string trade_no = Request.Form["trade_no"];         //支付宝交易号
                if (string.IsNullOrEmpty(trade_no))
                {
                    HttpContext.Current.Response.Write("参数错误");
                    HttpContext.Current.Response.End();
                }
                string total_fee = Request.Form["total_fee"];       //获取总金额
                string subject = Request.Form["subject"];           //商品名称、订单名称
                string body = Request.Form["body"];                 //商品描述、订单备注、描述
                string buyer_email = Request.Form["buyer_email"];   //买家支付宝账号
                string trade_status = Request.Form["trade_status"]; //交易状态
                Service_PlanAgentOrder.PlanAgentOrderClient bll = new Service_PlanAgentOrder.PlanAgentOrderClient();
                PlanAgentOrder orderInfo = bll.Info(0, order_no);
                if (orderInfo.State == 0)
                {
                    if (orderInfo.Type == 1)
                    {
                        Service_SystemModuleSetMeal.SystemModuleSetMealClient setMealBLl = new Service_SystemModuleSetMeal.SystemModuleSetMealClient();
                        string[] setMealIdArr = orderInfo.RelationId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Service_SystemModuleSetMealValidityLog.SystemModuleSetMealValidityLogClient logBll = new Service_SystemModuleSetMealValidityLog.SystemModuleSetMealValidityLogClient();
                        foreach (string idItem in setMealIdArr)
                        {
                            SystemModuleSetMeal setMealInfo = setMealBLl.Info(Convert.ToInt32(idItem));
                            string moduleIds = "",moduleNames="";
                            Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient setMealDetailBll = new Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient();
                            V_SystemModuleSetMealDetail[] detailList = setMealDetailBll.List(setMealInfo.id);
                            Service_CompanyModule.CompanyModuleClient companyModuleBll = new Service_CompanyModule.CompanyModuleClient();
                            foreach (V_SystemModuleSetMealDetail item in detailList)
                            {
                                moduleIds += item.SystemModuleId+",";
                                moduleNames += Enum.GetName(typeof(ModuleType), item.SystemModuleId)+"，";
                                CompanyModule moduleInfo = companyModuleBll.InfoByModule(orderInfo.CompanyId, item.SystemModuleId);
                                if (moduleInfo == null)
                                {
                                    moduleInfo = new CompanyModule()
                                    {
                                        CompanyId = orderInfo.CompanyId,
                                        ModuleId = item.SystemModuleId,
                                        ValidityDateStart = DateTime.Now,
                                        ValidityDateEnd = DateTime.Now.AddDays(setMealInfo.Day)
                                    };
                                }
                                else
                                {
                                    if (moduleInfo.ValidityDateEnd.CompareTo(DateTime.Now) == -1)//已过期
                                    {
                                        moduleInfo.ValidityDateStart = DateTime.Now;
                                        moduleInfo.ValidityDateEnd = DateTime.Now.AddDays(setMealInfo.Day);
                                    }
                                    else
                                    {
                                        if (moduleInfo.ValidityDateEnd.CompareTo(DateTime.Now.AddDays(setMealInfo.Day)) == -1)
                                        {
                                            moduleInfo.ValidityDateEnd = DateTime.Now.AddDays(setMealInfo.Day);
                                        }
                                    }
                                }
                                companyModuleBll.Edit(moduleInfo);
                            }
                            logBll.Add(new SystemModuleSetMealValidityLog() {
                                CompanyId = orderInfo.CompanyId,
                                ModuleIds= moduleIds,
                                ModuleNames = moduleNames,
                                SetMealName = setMealInfo.Name,
                                OrderId = orderInfo.id,
                                SetMealId = setMealInfo.id,
                                ValidityDateEnd = DateTime.Now.AddDays(setMealInfo.Day),
                                ValidityDateStart = DateTime.Now
                            });
                        }
                        logBll.Abort();
                        logBll.Close();
                        setMealBLl.Abort();
                        setMealBLl.Close();
                    }
                    bll.UpdateState(order_no, 1);
                    bll.Abort();
                    bll.Close();
                }

                Response.Write("success");  //请不要修改或删除

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            else//验证失败
            {
                Response.Write("fail");
            }
        }
        else
        {
            Response.Write("无通知参数");
        }
        //context.Response.Write("Hello World");
    }

    /// <summary>
    /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
    /// </summary>
    /// <returns>request回来的信息组成的数组</returns>
    public SortedDictionary<string, string> GetRequestPost()
    {
        int i = 0;
        SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.Form;

        // Get names of all forms into a string array.
        String[] requestItem = coll.AllKeys;

        for (i = 0; i < requestItem.Length; i++)
        {
            sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
        }

        return sArray;
    }
}