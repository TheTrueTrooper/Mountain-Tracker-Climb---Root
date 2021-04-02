using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace RazorToAngularExtentions.HTMLHelperExtentions
{
    public static class AngularExtentions
    {
        //private static string _GenerateHTMLAtributes(object HTMLAtributes = null)
        //{
        //    Type OType = HTMLAtributes.GetType();
        //    PropertyInfo[] Properties = OType.GetProperties();
        //    string Return = "";
        //    foreach (PropertyInfo Property in Properties)
        //    {
        //        Return += $"{Property.Name}={Property.GetValue(HTMLAtributes)} ";
        //    }

        //    return Return;
        //}

        //public static MvcHtmlString GenerateHTMLAtributes(object HTMLAtributes = null)
        //{
        //    return new MvcHtmlString(_GenerateHTMLAtributes(HTMLAtributes));
        //}

        //public static MvcHtmlString GenerateHTMLAtributes(this HtmlHelper This, object HTMLAtributes = null)
        //{
        //    return new MvcHtmlString(_GenerateHTMLAtributes(HTMLAtributes));
        //}

        //public static MvcHtmlString CreateAngularInputFor<TModel, TProperty>(this HtmlHelper<TModel> This, Expression<Func<TModel, TProperty>> Expression, string NgOnUpdate, string AngularObjectPath = null, object HTMLAtributes = null, bool Disabled = false)
        //{
        //    Type type = typeof(TModel);
        //    MemberExpression Member = Expression.Body as MemberExpression;
        //    if (Member == null)
        //        throw new ArgumentException($"Expression '{Expression}' refers to a method, not a property.");
        //    string InputType = "text";

        //    if (Member.Type == typeof(string))
        //    {
        //        Type MemberType = Member.Type;
        //        Attribute.IsDefined(MemberType, );
        //    }

        //    //PropertyInfo Property = Member.Member as PropertyInfo;
        //    //if (Property == null)
        //    //    throw new ArgumentException($"Expression '{Expression}' refers to a field, not a property.");
        //    StringBuilder HTMLString = new StringBuilder($"<input type=\"{InputType}\" ng-model=\"{(AngularObjectPath ?? "") + Member.Member.Name}\" ");
        //    if (Disabled)
        //        HTMLString.Append($"Disabled ");
        //    HTMLString.Append(_GenerateHTMLAtributes(HTMLAtributes));
        //    HTMLString.Append("/>\n");
        //    return new MvcHtmlString(HTMLString.ToString());
        //}

        //public static MvcHtmlString CreateAngularButton(this HtmlHelper This, string ButtonWords, string NGOnClick =null, string AngularObjectPath = null, object HTMLAtributes = null, string HTMLModalEnvoke = null, bool HTMLModalDismis = false, bool Disabled = false)
        //{
        //    StringBuilder HTMLString = new StringBuilder($"<button type=\"button\" ");
        //    if(ButtonFunction != null)
        //        HTMLString.Append($"ng-click=\"{(AngularObjectPath ?? "") + NGOnClick}\" ");
        //    if (HTMLModalEnvoke != null)
        //        HTMLString.Append($"data-toggle=\"modal\" data-target=\"{HTMLModalEnvoke}\" ");
        //    if (HTMLModalDismis)
        //        HTMLString.Append($"data-dismiss=\"modal\" ");
        //    if (Disabled)
        //        HTMLString.Append($"Disabled ");
        //    HTMLString.Append(_GenerateHTMLAtributes(HTMLAtributes));
        //    HTMLString.Append($">{ButtonWords}</button>");
        //    return new MvcHtmlString(HTMLString.ToString());
        //}
    }
}
