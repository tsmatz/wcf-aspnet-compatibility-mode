using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;

namespace AspNetCompatiClient
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ChannelFactory<AspNetCompatiSvc.ICalcService> factory = new ChannelFactory<AspNetCompatiSvc.ICalcService>("CustomBinding_ICalcService");
            factory.Open();
            AspNetCompatiSvc.ICalcService channel = factory.CreateChannel();

            // ヘッダーを操作できるようにコンテキストスコープを設定
            using (OperationContextScope scope = new OperationContextScope(channel as IContextChannel))
            {
                channel.SetValue(int.Parse(TextBox1.Text));

                // Response ヘッダーの SetCookie の内容をセッションにコピー
                HttpResponseMessageProperty httpResponseProp = OperationContext.Current.IncomingMessageProperties[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
                Session["WCF_SessionID"] = httpResponseProp.Headers[HttpResponseHeader.SetCookie];
            }

            factory.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ChannelFactory<AspNetCompatiSvc.ICalcService> factory = new ChannelFactory<AspNetCompatiSvc.ICalcService>("CustomBinding_ICalcService");
            factory.Open();
            AspNetCompatiSvc.ICalcService channel = factory.CreateChannel();

            // コンテキストスコープを設定
            using (OperationContextScope scope = new OperationContextScope(channel as IContextChannel))
            {
                // セッションから Cookie を取り出し Request ヘッダーに設定
                if (Session["WCF_SessionID"] != null)
                {
                    HttpRequestMessageProperty httpRequestProp = new HttpRequestMessageProperty();
                    httpRequestProp.Headers.Add(HttpRequestHeader.Cookie, Session["WCF_SessionID"] as string);
                    OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, httpRequestProp);
                }

                channel.AddValue(int.Parse(TextBox2.Text));
            }

            factory.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ChannelFactory<AspNetCompatiSvc.ICalcService> factory = new ChannelFactory<AspNetCompatiSvc.ICalcService>("CustomBinding_ICalcService");
            factory.Open();
            AspNetCompatiSvc.ICalcService channel = factory.CreateChannel();

            // コンテキストスコープを設定
            using (OperationContextScope scope = new OperationContextScope(channel as IContextChannel))
            {
                // セッションから Cookie を取り出し Request ヘッダーに設定
                if (Session["WCF_SessionID"] != null)
                {
                    HttpRequestMessageProperty httpRequestProp = new HttpRequestMessageProperty();
                    httpRequestProp.Headers.Add(HttpRequestHeader.Cookie, Session["WCF_SessionID"] as string);
                    OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, httpRequestProp);
                }

                TextBox3.Text = channel.GetValue().ToString();
            }

            factory.Close();
        }
    }
}
