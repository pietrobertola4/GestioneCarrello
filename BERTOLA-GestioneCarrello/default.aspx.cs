using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using adoNetWebSQlServer;

namespace BERTOLA_GestioneCarrello
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                adoNet.impostaConnessione("App_Data/DBCarrello.mdf");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserMail.Text != string.Empty)
            {
                if (txtPassword.Text != string.Empty)
                {
                    adoNet dbConnection = new adoNet();
                    dbConnection.cmd.Parameters.AddWithValue("@userMail", txtUserMail.Text);
                    DataTable account = dbConnection.eseguiQuery(
                        @"select  * 
                          from Accounts 
                          where Username = @userMail or Mail = @userMail",
                        CommandType.Text
                        );
                    if (account.Rows.Count > 0)
                    {
                        if (account.Rows[0]["Password"].ToString() == txtPassword.Text)
                        {
                            Session["account"] = account.Rows[0];
                            dbConnection.cmd.Parameters.AddWithValue("@username", account.Rows[0]["Username"].ToString());
                            switch (dbConnection.eseguiScalar(
                                @"select TipoProfilo.Nome 
                                  from TipoProfilo inner join Accounts
                                    on TipoProfilo.Id = Accounts.Privilegi
                                    where Accounts.Username = @username
                                  ", CommandType.Text))
                            {
                                case "ADM":
                                    Response.Redirect("adminPage.aspx");
                                    break;
                                case "FOR":
                                    Response.Redirect("FornitoreView.aspx");
                                    break;
                                case "USR":
                                    Session["page"] = 0;
                                    Response.Redirect("homePage.aspx");
                                    break;
                            }
                            Response.Redirect("homePage.aspx");
                        }
                    }
                    else
                    {
                        lblErrore.Text = "errore";
                    }
                }
                else
                    lblErrore.Text = "password mancante";
            }
            else
                lblErrore.Text = "username mancante";
        }
    }
}