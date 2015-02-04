using System;
using Log4NetFramework.BusinessLibTwo;
using Log4NetLibrary;

namespace Log4NetFramework.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ILogService logService = new FileLogService(typeof(Default));
            logService.Info("Just an information from web app");
            ltrStatus.Text = "Log is written successfully";
            //Call business library as well
            new Business();
        }
    }
}