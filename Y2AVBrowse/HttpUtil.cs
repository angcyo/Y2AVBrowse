using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using System.Collections;
using System.IO;
using System.Net;

namespace Y2AVBrowse
{
    class HttpUtil
    {
        public static string index = @"http://www.911zy.com";//首 页

        public static string index_0 = @"http://www.911zy.com";
        public static string index_1 = @"http://www.611zy.la/";
        public static string index_2 = @"http://www.411zy.com/";
        public static string index_3 = @"http://www.811zy.com/";

        public static string index1 = @"/list/index1.html";//亚洲电影
        public static string index2 = @"/list/index2.html";//欧美电影
        public static string index3 = @"/list/index3.html";//国产电影
        public static string index4 = @"/list/index4.html";//经典三级
        public static string index5 = @"/list/index5.html";//成人动漫
        public static string index6 = @"/list/index6.html";//强奸乱伦
        public static string index7 = @"/list/index7.html";//制服丝袜
        public static string index8 = @"/list/index8.html";//变态另类

        public static string VerifyUrl = @"http://angcyo.github.io/verify/index.html";//验证码获取地址

        public static Encoding GB2312 = Encoding.GetEncoding("gb2312");

        //load最主要的方法
        public static ArrayList Load(string url)
        {
            var list = new ArrayList();
            try
            {
                var rootnode = getRootNodeFromUrl(url, GB2312);
                var nodes = rootnode.SelectNodes("//div[@class='list1']/a[@href]");//链接
                foreach (var node in nodes)
                {
                    var item = new AVItem();
                    item.Title = node.InnerText;
                    item.HttpUrl = index + node.GetAttributeValue("href", "");

                    var urlNode = getRootNodeFromUrl(item.HttpUrl, GB2312);
                    var imgNode = urlNode.SelectNodes("//div[@class='vpic']/img[@src]");//vpic 图片链接
                    item.ImgUrl = index + imgNode[0].GetAttributeValue("src", "");

                    var vplNode = urlNode.SelectNodes("//div[@class='vpl']");//vpl 第一个vpl 下载链接
                    var downNode = vplNode[0].SelectNodes("./*");

                    item.DownUrl = downNode[1].InnerText;//
                    item.Type = GetTypeFromUrl(url);//类型
                    list.Add(item);
                }
                //list.RemoveAt(0);//移除第一个元素,因为第一个元素是标题

                //list.Add(html);
                //list.Add(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                list.Add(e.Message);
            }

            return list;
        }

        //从url中, 得到当前第几页
        public static int GetPageFromUrl(string url)
        {
            var page = 1;
            try
            {
                var urls = url.Split(new char[] { '_' });
                if (urls.Length == 2)
                {
                    var pages = urls[1].Split(new char[] { '.' });
                    page = Int32.Parse(pages[0]);
                }
                else
                {
                    page = 1;
                }
            }
            catch (Exception e)
            {
                return page;
            }
            return page;
        }

        //根据提供index的,返回指定的第page页
        public static string GetPageUrl(string index, int page)
        {
            if (page > 1)
            {
                return index.Replace(".html", "_" + page + ".html");
            }
            return index;
        }

        //根据url,得到类别
        public static string GetTypeFromUrl(string url)
        {
            var type = "未知分类";
            var types = new string[] { "亚洲电影", "欧美电影", "国产电影", "经典三级", "成人动漫", "强奸乱伦", "制服丝袜", "变态另类" };
            var index = 0;
            try
            {
                var urls = url.Split(new char[] { '_' });//首先判断是否是第一个页面
                string pages;
                if (urls.Length == 2)
                {
                    pages = urls[0].Replace("index", "^");
                }
                else
                {
                    pages = urls[0].Replace("index", "^");
                }
                var page = pages.Split('^')[1].Split('.')[0];
                index = Int32.Parse(page);

                type = types[index - 1];
            }
            catch (Exception e) { return type; }

            return type;
        }

        //转转编码格式,不可用
        public static string Convert(string src, Encoding rEncode, Encoding wEncode)
        {
            var bytes = Encoding.Convert(rEncode, wEncode, rEncode.GetBytes(src));
            var chars = wEncode.GetChars(bytes);

            return new String(chars);
        }

        //从url中,得到文档根node
        public static HtmlNode getRootNodeFromUrl(string url, Encoding en)
        {
            var doc = new HtmlDocument();
            var pageSource = getSourceFromUrl(url, en);

            doc.LoadHtml(pageSource);
            return doc.DocumentNode;
        }

        public static string getSourceFromUrl(string url, Encoding en)
        {
            var wc = new WebClient();
            var pageSourceBytes = wc.DownloadData(new Uri(url));
            var pageSource = en.GetString(pageSourceBytes);
            wc.Dispose();
            return pageSource;
        }


    }

    class AVItem
    {
        public int Count { get; set; }//保存添加item的数量
        public string Type { get; set; }//类型
        public string ImgUrl { get; set; }//图片url
        public string Title { get; set; }//标题
        public string HttpUrl { get; set; }//详细页面网址
        public string DownUrl { get; set; }//下载地址
    }
}
