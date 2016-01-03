using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ac968.SystemModuleSetMeal.Utility
{
    public class SetMealPageBase: System.Web.UI.Page
    {
        protected void Success() {
            Response.Write("{\"state\":true}");
            Response.End();
        }

        /// <summary>
        /// 构造分布标签
        /// </summary>
        /// <param name="pageIndex">当前索引</param>
        /// <param name="dataRecord">数据总数</param>
        /// <param name="link">页面地址，不传则为当前页面</param>
        /// <param name="pageSize">单页数据数，默认20</param>
        /// <param name="pageParam">索引传参名称</param>
        protected string InitPageView(int pageIndex, int dataRecord, string link = "", int pageSize = 20, string pageParam = "page")
        {
            int pageTotal = dataRecord / pageSize
                + ((dataRecord % pageSize) > 0 ? 1 : 0);
            string pageHtml = "<ul class=\"Pager\" data-total=\"" + pageTotal + "\" data-pageparemt=\"" + pageParam + "\">";
            if (pageSize < dataRecord)
            {
                if (string.IsNullOrEmpty(link))
                {
                    link = HttpContext.Current.Request.Url.ToString();
                    string[] urlArray = link.Split('?');
                    link = urlArray[0];
                    if (urlArray.Length > 1)
                    {
                        string queryString = urlArray[1];
                        string[] queryArray = queryString.Split('&');
                        queryString = "";
                        foreach (string item in queryArray)
                        {
                            if (!item.Contains("="))
                            {
                                continue;
                            }
                            string key = item.Split('=')[0];
                            string value = item.Split('=')[1];
                            if (key == pageParam)
                            {
                                continue;
                            }
                            queryString += key + "=" + value + "&";
                        }
                        if (queryString != string.Empty)
                        {
                            link += "?" + queryString;
                        }
                        else
                        {
                            link += "?";
                        }
                    }
                    else
                    {
                        link += "?";
                    }
                    link += pageParam + "=";
                }
                if (pageIndex > 1)
                {
                    pageHtml += string.Format("<li onclick=\"window.location = '{0}1'\">首页</li><li onclick=\"window.location = '{0}{1}'\">上一页</li>", link, pageIndex - 1);
                }
                if (pageTotal > 10)
                {
                    if (pageIndex <= 4)
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            pageHtml += GetPageItemHtml(i, pageIndex, link);
                        }
                        pageHtml += "<li class=\"more\">...</li>";
                        for (int i = pageTotal - 3; i <= pageTotal; i++)
                        {
                            pageHtml += GetPageItemHtml(i, pageIndex, link);
                        }
                    }
                    else if (pageTotal - 4 == pageIndex)
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            pageHtml += GetPageItemHtml(i, pageIndex, link);
                        }
                        pageHtml += "<li class=\"more\">...</li>";
                        for (int i = pageTotal - 4; i <= pageTotal; i++)
                        {
                            pageHtml += GetPageItemHtml(i, pageIndex, link);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            pageHtml += GetPageItemHtml(i, pageIndex, link);
                        }
                        pageHtml += "<li class=\"more\">...</li>";
                        pageHtml += GetPageItemHtml(pageIndex, pageIndex, link);
                        pageHtml += "<li class=\"more\">...</li>";
                        for (int i = pageTotal - 3; i <= pageTotal; i++)
                        {
                            pageHtml += GetPageItemHtml(i, pageIndex, link);
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= pageTotal; i++)
                    {
                        pageHtml += GetPageItemHtml(i, pageIndex, link);
                    }
                }
                if (pageIndex < pageTotal)
                {
                    pageHtml += string.Format("<li onclick=\"window.location = '{0}{1}'\">下一页</li><li onclick=\"window.location = '{0}{2}'\">尾页</li>", link, pageIndex + 1, pageTotal);
                }
                pageHtml += "<li class=\"pageInput\"><input /></li><li class=\"btnGoPage\">跳转</li>";
            }
            pageHtml += "</ul>";
            return pageHtml;
        }

        public string GetPageItemHtml(int i, int pageIndex, string link)
        {
            string pageHtml = "";
            if (i == pageIndex)
            {
                pageHtml += string.Format("<li class=\"active\" onclick=\"window.location = '{0}{1}'\">{1}</li>", link, i);
            }
            else
            {
                pageHtml += string.Format("<li onclick=\"window.location = '{0}{1}'\">{1}</li>", link, i);
            }
            return pageHtml;
        }
    }
}
