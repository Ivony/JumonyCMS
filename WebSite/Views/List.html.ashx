<%@ WebHandler Language="C#" Class="List_html" %>

using System;
using System.Web;

using Ivony.Fluent;
using Ivony.Html;
using Ivony.Html.Web;
using Ivony.Html.Web.Mvc;

public class List_html : ViewHandler<string[]>
{


  protected override void ProcessDocument()
  {
    Document.Find( ".list tbody tr" ).BindFrom( ViewModel, BindDataItem );
  }

  private void BindDataItem( string virtualPath, IHtmlElement element )
  {
    element.FindSingle( ".virtualpath" ).InnerText( virtualPath );
  }
}