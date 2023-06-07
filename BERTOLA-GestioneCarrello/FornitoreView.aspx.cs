using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Data;
using adoNetWebSQlServer;

namespace BERTOLA_GestioneCarrello
{
    public partial class FornitoreView : System.Web.UI.Page
    {
        private adoNet dbConnection;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["account"] is DataRow account)
            {
                if (!IsPostBack)
                {
                    dbConnection = new adoNet();
                    Session["idFornitore"] = Convert.ToInt32(dbConnection.eseguiScalar($"select Id from Fornitori where Account={((DataRow)Session["account"])["Id"]}", CommandType.Text));
                    if (Session["appenaIscritto"] != null && (bool)Session["appenaIscritto"])
                        lblNavBrand.Text = "Benvenuto " + (account["Cognome"].ToString()).ToUpper() + " " + (account["Nome"].ToString()).ToUpper();
                    else
                        lblNavBrand.Text = (account["Cognome"].ToString()).ToUpper() + " " + (account["Nome"].ToString()).ToUpper();
                }
                if (Session["page"] != null && (int)Session["page"] == 1)
                    inserisciNuovoProdotto();
                else
                    caricaHome();
            }
            else
            {
                Response.Redirect("errorPage.aspx?codErr=1");
            }
        }
        #region home
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Session["page"] = 0;
            caricaHome();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["account"] = null;
            Session["page"] = null;
            Session["idProdotto"] = null;
            Response.Redirect("default.aspx");
        }
        private void caricaHome()
        {
            container.Controls.Clear();
            dbConnection = new adoNet();
            if (Session["account"] is DataRow account)
            {
                dbConnection.cmd.Parameters.AddWithValue("@fornitore", Session["idFornitore"].ToString());
                DataTable prodottiFornitore = dbConnection.eseguiQuery(
                        "select * from Prodotti where Fornitore = @fornitore",
                        CommandType.Text
                    );
                if (prodottiFornitore.Rows.Count > 0)
                {
                    HtmlGenericControl tabellaProdotti = new HtmlGenericControl("table");
                    tabellaProdotti.Attributes.Add("class", "table table-hover text-white");
                    tabellaProdotti.Attributes.Add("id", "tabellaProdotti");
                    container.Controls.Add(tabellaProdotti);
                    HtmlGenericControl thead = new HtmlGenericControl("thead");
                    thead.Attributes.Add("class", "text-white");
                    tabellaProdotti.Controls.Add(thead);
                    HtmlGenericControl tr = new HtmlGenericControl("tr");
                    thead.Controls.Add(tr);
                    HtmlGenericControl th;
                    foreach (DataColumn colonna in prodottiFornitore.Columns)
                    {
                        if (
                            colonna.ColumnName != "Id" &&
                            colonna.ColumnName != "Fornitore" &&
                            colonna.ColumnName != "Valido"
                        )
                        {
                            th = new HtmlGenericControl("th")
                            {
                                InnerText = colonna.ColumnName
                            };
                            if (colonna.ColumnName == "Prezzo")
                                th.InnerText += " (€)";
                            th.Attributes.Add("class", "text-center");
                            tr.Controls.Add(th);
                        }
                    }
                    th = new HtmlGenericControl("th")
                    {
                        InnerText = "Gestione"
                    };
                    th.Attributes.Add("class", "text-center");
                    tr.Controls.Add(th);
                    HtmlGenericControl tbody = new HtmlGenericControl("tbody");
                    tbody.Attributes.Add("class", "text-white");
                    tabellaProdotti.Controls.Add(tbody);
                    HtmlGenericControl td;
                    foreach (DataRow prodotto in prodottiFornitore.Rows)
                    {
                        tr = new HtmlGenericControl("tr");
                        if (!(bool)prodotto["Valido"])
                            tr.Attributes.Add("style", "opacity:0.5");
                        tbody.Controls.Add(tr);
                        foreach (DataColumn colonna in prodottiFornitore.Columns)
                        {
                            if (
                                colonna.ColumnName != "Id" &&
                                colonna.ColumnName != "Fornitore" &&
                                colonna.ColumnName != "Valido"
                            )
                            {
                                if (colonna.ColumnName != "Immagine")
                                {
                                    td = new HtmlGenericControl("td");
                                    if (colonna.ColumnName != "Categoria")
                                        td.InnerText = prodotto[colonna.ColumnName].ToString();
                                    else
                                    {
                                        var nomeCategoria = dbConnection.eseguiScalar(
                                            $@"select Descrizione 
                                               from Categorie 
                                               where Id={prodotto[colonna.ColumnName]}",
                                            CommandType.Text);
                                        td.InnerText = nomeCategoria;
                                    }
                                    td.Attributes.Add("class", "text-center align-middle");
                                    tr.Controls.Add(td);
                                }
                                else
                                {
                                    td = new HtmlGenericControl("td");
                                    tr.Controls.Add(td);
                                    HtmlGenericControl img = new HtmlGenericControl("img");
                                    img.Attributes.Add("src", prodotto[colonna.ColumnName].ToString());
                                    img.Attributes.Add("class", "img-thumbnail");
                                    img.Attributes.Add("style", "height: 200px");
                                    td.Attributes.Add("class", "d-flex justify-content-center");
                                    td.Controls.Add(img);
                                }
                            }
                        }
                        td = new HtmlGenericControl("td");
                        td.Attributes.Add("style", "width: min-content");
                        tr.Controls.Add(td);
                        HtmlGenericControl div = new HtmlGenericControl("div");
                        div.Attributes.Add("class", "btn-group d-flex justify-content-center align-items-center");
                        div.Attributes.Add("style", "margin-top:25%; transform: translate(0, -25%);");
                        td.Controls.Add(div);
                        //bottoni modifica/disponibilità
                        Button btnModifica = new Button()
                        {
                            Text = "Modifica",
                            CssClass = "btn btn-warning  text-white mx-5",
                            ID = "btnModifica_" + prodotto["Id"].ToString()
                        };
                        btnModifica.Click += new EventHandler(btnModificaProdottoFornitore);
                        div.Controls.Add(btnModifica);
                        Button btnElimina = new Button()
                        {
                            
                            CssClass = "btn btn-danger",
                            ID = "btnElimina_" + prodotto["Id"].ToString()
                        };
                        if ((bool)prodotto["Valido"])
                            btnElimina.Text = "Annulla";
                        else
                            btnElimina.Text = "Rendi Disponibile";
                        btnElimina.Click += new EventHandler(btnEliminaProdottoFornitore);
                        div.Controls.Add(btnElimina);
                    }
                }
                else
                {
                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes.Add("class", "alert alert-info");
                    div.InnerHtml = "Non hai ancora inserito nessun prodotto";
                    container.Controls.Add(div);
                }
            }
        }
        protected void btnModificaProdottoFornitore(object sender, EventArgs e)
        {
            Session["page"] = 1;
            inserisciNuovoProdotto();
            dbConnection = new adoNet();
            int idProdotto = int.Parse(((Button)sender).ID.Split('_')[1]);
            Session["idProdotto"] = idProdotto;
            Session["modifica"] = true;
            DataRow prodotto = dbConnection.eseguiQuery($"select * from Prodotti where Id={idProdotto}", CommandType.Text).Rows[0];
            ((TextBox)container.FindControl("txtNomeProdotto")).Text = prodotto["NomeProdotto"].ToString();
            ((TextBox)container.FindControl("txtDescrizione")).Text = prodotto["Descrizione"].ToString();
            ((TextBox)container.FindControl("txtPrezzo")).Text = prodotto["Prezzo"].ToString();
            ((DropDownList)container.FindControl("cmbCategorie")).SelectedValue = prodotto["Categoria"].ToString();
        }
        protected void btnEliminaProdottoFornitore(object sender, EventArgs e)
        {
            Session["page"] = 0;
            dbConnection.cmd.Parameters.AddWithValue("@id", Convert.ToInt32(((Button)sender).ID.Split('_')[1]));
            dbConnection.eseguiNonQuery(
                "update Prodotti set Valido = 1-Valido where Id = @id",
                CommandType.Text
            );
            caricaHome();
        }
        #endregion
        #region inserisciNuovoProdotto
        protected void btnAggiungiProdotto_Click(object sender, EventArgs e)
        {
            Session["page"] = 1;
            inserisciNuovoProdotto();
        }
        private void inserisciNuovoProdotto()
        {
            dbConnection = new adoNet();
            container.Controls.Clear();
            HtmlGenericControl formContainer = new HtmlGenericControl("div");
            formContainer.Attributes.Add("class", "container py-5 h-100");
            container.Controls.Add(formContainer);
            HtmlGenericControl form = new HtmlGenericControl("div");
            form.Attributes.Add("class", "row d-flex justify-content-center align-items-center h-100");
            formContainer.Controls.Add(form);
            HtmlGenericControl formDiv = new HtmlGenericControl("div");
            formDiv.Attributes.Add("class", "col-12 col-md-8 col-lg-6 col-xl-5");
            form.Controls.Add(formDiv);
            HtmlGenericControl formCard = new HtmlGenericControl("div");
            formCard.Attributes.Add("class", "card shadow-2-strong rounded-2");
            formDiv.Controls.Add(formCard);
            HtmlGenericControl formCardBody = new HtmlGenericControl("div");
            formCardBody.Attributes.Add("class", "card-body");
            formCard.Controls.Add(formCardBody);
            //nome prodotto
            HtmlGenericControl formOutline = new HtmlGenericControl("div");
            formOutline.Attributes.Add("class", "form-outline mb-4");
            formCardBody.Controls.Add(formOutline);
            HtmlGenericControl formLabel = new HtmlGenericControl("div");
            formLabel.Attributes.Add("class", "form-label");
            formLabel.Attributes.Add("for", "txtNomeProdotto");
            formOutline.Controls.Add(formLabel);
            TextBox nomeProdotto = new TextBox
            {
                ID = "txtNomeProdotto",
                CssClass = "form-control"
            };
            nomeProdotto.Attributes.Add("placeholder", "Nome prodotto");
            formLabel.Controls.Add(nomeProdotto);
            formOutline = new HtmlGenericControl("div");
            formOutline.Attributes.Add("class", "form-outline mb-4");
            formCardBody.Controls.Add(formOutline);
            //categoria
            formLabel = new HtmlGenericControl("div");
            formLabel.Attributes.Add("class", "form-label");
            formLabel.Attributes.Add("for", "cmbCategorie");
            formLabel.InnerText = "Categoria";
            formOutline.Controls.Add(formLabel);
            DropDownList categorie = new DropDownList
            {
                ID = "cmbCategorie",
                CssClass = "form-control custom-select"
            };
            ListItem[] items = new ListItem[1];
            items[0] = new ListItem(" ", "0");
            foreach (DataRow categoria in dbConnection.eseguiQuery(
                "select * from Categorie",
                CommandType.Text
            ).Rows)
            {
                Array.Resize(ref items, items.Length + 1);
                items[items.Length - 1] = new ListItem
                {
                    Text = categoria["Descrizione"].ToString(),
                    Value = categoria["Id"].ToString()
                };

            }
            categorie.Items.AddRange(items);
            formOutline.Controls.Add(categorie);
            //immagine
            formOutline = new HtmlGenericControl("div");
            formOutline.Attributes.Add("class", "form-outline mb-4");
            formCardBody.Controls.Add(formOutline);
            formLabel = new HtmlGenericControl("div");
            formLabel.Attributes.Add("class", "form-label");
            formLabel.Attributes.Add("for", "imagePicker");
            formLabel.InnerText = "Immagine";
            formOutline.Controls.Add(formLabel);
            FileUpload imagePicker = new FileUpload
            {
                ID = "imagePicker",
                CssClass = "form-control"
            };
            imagePicker.Attributes.Add("accept", "image/*");
            formOutline.Controls.Add(imagePicker);
            //prezzo
            formOutline = new HtmlGenericControl("div");
            formOutline.Attributes.Add("class", "form-outline mb-4");
            formCardBody.Controls.Add(formOutline);
            formLabel = new HtmlGenericControl("div");
            formLabel.Attributes.Add("class", "form-label");
            formLabel.Attributes.Add("for", "txtPrezzo");
            formLabel.InnerText = "Prezzo";
            formOutline.Controls.Add(formLabel);
            TextBox prezzo = new TextBox
            {
                ID = "txtPrezzo",
                CssClass = "form-control",
                Text = "0.00"
            };
            prezzo.TextChanged += new EventHandler(txtPrezzo_TextChanged);
            formLabel.Controls.Add(prezzo);
            //descrizione
            formOutline = new HtmlGenericControl("div");
            formOutline.Attributes.Add("class", "form-outline mb-4");
            formCardBody.Controls.Add(formOutline);
            formLabel = new HtmlGenericControl("div");
            formLabel.Attributes.Add("class", "form-label");
            formLabel.Attributes.Add("for", "txtDescrizione");
            formLabel.InnerText = "Descrizione";
            formOutline.Controls.Add(formLabel);
            TextBox descrizione = new TextBox
            {
                ID = "txtDescrizione",
                CssClass = "form-control",
                TextMode = TextBoxMode.MultiLine
            };
            descrizione.Attributes.Add("placeholder", "Descrizione");
            formLabel.Controls.Add(descrizione);
            //bottone conferma
            HtmlGenericControl formButton = new HtmlGenericControl("div");
            formButton.Attributes.Add("class", "form-button");
            formCardBody.Controls.Add(formButton);
            Button conferma = new Button
            {
                ID = "btnConferma",
                Text = "Conferma",
                CssClass = "btn btn-success btn-lg btn-block px-5"
            };
            conferma.Attributes.Add("style", "margin-left:50%; transform: translate(-50%,0)");
            conferma.Click += new EventHandler(this.confermaProdotto_Click);
            formButton.Controls.Add(conferma);
            Label lblErrore = new Label
            {
                ID = "lblErrore",
                CssClass = "text-danger"
            };
            formButton.Controls.Add(lblErrore);
        }
        protected void txtPrezzo_TextChanged(object sender, EventArgs e)
        {
            TextBox txtPrezzo = (TextBox)sender;
            if (decimal.TryParse(txtPrezzo.Text.Replace(".", ","), out decimal prezzo) || txtPrezzo.Text == string.Empty)
            {
                txtPrezzo.Style.Remove("border-color");
                txtPrezzo.Text = prezzo.ToString("0.00");
                if (txtPrezzo.Text.Length > 0)
                {
                    if (txtPrezzo.Text.Contains(","))
                    {
                        txtPrezzo.Text = txtPrezzo.Text.Replace(",", ".");
                    }
                    if (!txtPrezzo.Text.Contains("."))
                    {
                        txtPrezzo.Text += ".00";
                    }
                }
            }
            else
            {
                txtPrezzo.Style.Add("border-color", "red");
            }
            
        }
        protected void confermaProdotto_Click(object sender, EventArgs e)
        {
            if (controllaCampi())
            {
                dbConnection = new adoNet();
                int idFornitore = int.Parse(
                    dbConnection.eseguiScalar(
                        $"select Id from Fornitori where Account = {((DataRow)Session["account"])["Id"]}",
                        CommandType.Text)
                    );
                ((FileUpload)this.FindControl("imagePicker")).SaveAs(Server.MapPath("~/img/") + ((FileUpload)this.FindControl("imagePicker")).FileName);
                dbConnection.cmd.Parameters.AddWithValue(
                    "@nome",
                    ((TextBox)this.FindControl("txtNomeProdotto")).Text);
                dbConnection.cmd.Parameters.AddWithValue(
                    "@prezzo",
                    Convert.ToDecimal(((TextBox)this.FindControl("txtPrezzo")).Text));
                dbConnection.cmd.Parameters.AddWithValue(
                    "@descrizione",
                    ((TextBox)this.FindControl("txtDescrizione")).Text);
                dbConnection.cmd.Parameters.AddWithValue(
                    "@categoria",
                    int.Parse(((DropDownList)this.FindControl("cmbCategorie")).SelectedValue));
                dbConnection.cmd.Parameters.AddWithValue(
                    "@fornitore",
                    idFornitore);
                dbConnection.cmd.Parameters.AddWithValue(
                    "@immagine",
                    "img/" + ((FileUpload)this.FindControl("imagePicker")).FileName);
                if (Session["modifica"] != null && (bool)Session["modifica"])
                {
                    dbConnection.cmd.Parameters.AddWithValue("@idProdotto", Convert.ToInt32(Session["idProdotto"]));
                    dbConnection.eseguiNonQuery(
                        @"update Prodotti set
                          NomeProdotto=@nome, 
                          Categoria=@gategoria,
                          Prezzo=@prezzo, 
                          Descrizione=@descrizione, 
                          Immagine=@immagine
                          where Id=@idProdotto and Fornitore=@fornitore",
                        CommandType.Text);
                    Session["modifica"] = null;
                }
                else
                {
                    dbConnection.eseguiNonQuery(
                        @"insert into Prodotti (Fornitore, NomeProdotto, Categoria, Prezzo, Descrizione, Immagine) 
                          values (@fornitore, @nome, @categoria, @prezzo, @descrizione, @immagine)",
                        CommandType.Text);
                }
                Session["page"] = 0;
                caricaHome();
            }
        }
        private bool controllaCampi()
        {
            if (((TextBox)this.FindControl("txtNomeProdotto")).Text != string.Empty)
            {
                if (((DropDownList)this.FindControl("cmbCategorie")).SelectedValue != "0")
                {
                    if (((FileUpload)this.FindControl("imagePicker")).HasFile)
                    {
                        if (((TextBox)this.FindControl("txtPrezzo")).Text != string.Empty)
                        {
                            if (((TextBox)this.FindControl("txtDescrizione")).Text != string.Empty)
                            {
                                return true;
                            }
                            else
                                ((Label)this.FindControl("lblErrore")).Text = "Inserisci una descrizione";
                        }
                        else
                            ((Label)this.FindControl("lblErrore")).Text = "Inserisci un prezzo";
                    }
                    else
                        ((Label)this.FindControl("lblErrore")).Text = "Seleziona un'immagine";
                }
                else
                    ((Label)this.FindControl("lblErrore")).Text = "Seleziona una categoria";

            }
            return false;
        }
        #endregion
     

    }
}