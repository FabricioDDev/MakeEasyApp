﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using DataModel;


namespace DoEasyWebProyect.ClientForms
{
    public partial class FrmHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int Id = int.Parse(Request.QueryString["Id"]);
            List<Theme> CardList = new List<Theme>();
            ThemeData themeD = new ThemeData();
            CardList = themeD.Listing().FindAll(x => x.IdUser == Id);
            if (CardList.Count() > 0)
            {
                RptThemeCard.DataSource = CardList;
                RptThemeCard.DataBind();
            }
                
            
        }
    }
}