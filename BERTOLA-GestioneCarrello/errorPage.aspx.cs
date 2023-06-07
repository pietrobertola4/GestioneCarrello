using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BERTOLA_GestioneCarrello
{
    public partial class errorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string codErr = string.Empty;
            if (!IsPostBack)
            {
                if (Request.QueryString["codErr"] != null)
                    codErr = Request.QueryString["codErr"];
                switch (codErr)
                {
                    case "1":
                        lblErrore.Text = "Fare il login!";
                        break;
                    case "2":
                        lblErrore.Text = "Internal Server Error";
                        break;
                    case "3":
                        break;
                    default:
                        lblErrore.Text = "";
                        break;
                }
            }
        }

        protected void btnContinua_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["codErr"] != null && Request.QueryString["codErr"] == "2")
                Response.Redirect("homePage.aspx");
            else
                Response.Redirect("default.aspx");
        }
    }
}