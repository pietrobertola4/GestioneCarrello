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
    public partial class subscribePage : System.Web.UI.Page
    {
        private adoNet sqlConnection;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                adoNet.impostaConnessione("App_Data/DBCarrello.mdf");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (controllaCampi())
            {
                sqlConnection.cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                sqlConnection.cmd.Parameters.AddWithValue("@cognome", txtCognome.Text);
                sqlConnection.cmd.Parameters.AddWithValue("@mail", txtMail.Text);
                sqlConnection.cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                sqlConnection.cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                sqlConnection.cmd.Parameters.AddWithValue("@indirizzo", txtIndirizzo.Text);
                sqlConnection.cmd.Parameters.AddWithValue("@telefono", Convert.ToDecimal(txtTelefono.Text));
                if (Convert.ToBoolean(
                    sqlConnection.eseguiNonQuery(
                        @"insert into Accounts(Nome, Cognome, Mail, Username, Password, Indirizzo, Telefono) 
                          values (@nome, @cognome, @mail, @username, @password, @indirizzo, @telefono)",
                        CommandType.Text)
                    )
                )
                {
                    sqlConnection.cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    sqlConnection.cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    DataRow account = sqlConnection.eseguiQuery("select * from Accounts where Username = @username and Password = @password", CommandType.Text).Rows[0];
                    Session["account"] = account;
                    Session["appenaIscritto"] = true;
                    Response.Redirect("homePage.aspx");
                }
                else
                    lblErrore.Text = "Warning: Internal Server Error";
            }
        }

        private bool controllaCampi()
        {
            txtPassword.Attributes["value"] = txtPassword.Text;
            txtConfermaPassword.Attributes["value"] = txtConfermaPassword.Text;
            if (txtUsername.Text != string.Empty)
            {
                sqlConnection = new adoNet();
                sqlConnection.cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                if (!Convert.ToBoolean(
                        Convert.ToInt32(
                            sqlConnection.eseguiScalar(
                            "select count(*) from Accounts where Username = @username",
                            CommandType.Text)
                            )
                        )
                    )
                {
                    if (txtNome.Text != string.Empty)
                    {
                        if (txtCognome.Text != string.Empty)
                        {
                            if (txtIndirizzo.Text != string.Empty)
                            {
                                sqlConnection.cmd.Parameters.AddWithValue("@mail", txtMail.Text);
                                if (txtMail.Text != string.Empty)
                                {
                                    if (!Convert.ToBoolean(
                                        Convert.ToInt32(
                                            sqlConnection.eseguiScalar(
                                            "select count(*) from Accounts where Mail = @mail",
                                            CommandType.Text)
                                            )
                                        )
                                    )
                                    {
                                        if (txtTelefono.Text != string.Empty)
                                        {
                                            if (txtPassword.Text != string.Empty)
                                            {
                                                if (txtConfermaPassword.Text != string.Empty)
                                                {
                                                    if (txtPassword.Text == txtConfermaPassword.Text)
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        lblErrore.Text = "Le password non corrispondono";
                                                        txtConfermaPassword.Focus();
                                                    }
                                                }
                                                else
                                                {
                                                    lblErrore.Text = "Conferma la password";
                                                    txtConfermaPassword.Focus();
                                                }
                                            }
                                            else
                                            {
                                                lblErrore.Text = "Inserisci una Password";
                                                txtPassword.Focus();
                                            }
                                        }
                                        else
                                        {
                                            lblErrore.Text = "Inserisci il numero di telefono";
                                            txtTelefono.Focus();
                                        }
                                    }
                                    else
                                    {
                                        lblErrore.Text = "L'E-Mail inserita esiste già";
                                        txtMail.Focus();
                                    }
                                }
                                else
                                {
                                    lblErrore.Text = "Iserisci un' E-Mail";
                                    txtMail.Focus();
                                }
                            }
                            else
                            {
                                lblErrore.Text = "Iserisci un Indirizzo";
                                txtIndirizzo.Focus();
                            }
                        }
                        else
                        {
                            lblErrore.Text = "Iserisci un Cognome";
                            txtCognome.Focus();
                        }

                    }
                    else
                    {
                        lblErrore.Text = "Iserisci un Nome";
                        txtNome.Focus();
                    }
                }
                else
                {
                    lblErrore.Text = "L' Username inserito esiste già";
                    txtUsername.Focus();
                }
            }
            else
            {
                lblErrore.Text = "Iserisci un Username";
                txtUsername.Focus();
            }

            return false;
        }

        
    }
}