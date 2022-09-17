﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using DomainModel;

namespace DataModel
{
    public class ThemeData
    {
        public ThemeData()
        {
            data = new DataAccess();
        }
        private DataAccess data;
        public List<Theme> Listing()
        {
            List<Theme> list = new List<Theme>();
            try
            {
                data.Query("select Id, Title, IdIcon, IdUser from Theme");
                data.Read();
                while (data.readerProp.Read())
                {
                    Theme aux = new Theme();
                    aux.Id = (int)data.readerProp["Id"];
                    aux.Title = (string)data.readerProp["Title"];
                    aux.IdIcon = (int)data.readerProp["Icon"];
                    aux.IdUser = (int)data.readerProp["IdUser"];
                    list.Add(aux);
                }
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }
        }

        public void AddTheme(Theme NewTheme)
        {
            try
            {
                data.Query("insert into Theme ( Title, IdIcon, IdUser) values (@Id, @Title, @Icon, @IdUser)");
                data.Parameters("@Title", NewTheme.Title);
                data.Parameters("@Icon", NewTheme.IdIcon);
                data.Parameters("@IdUser", NewTheme.IdUser);
                data.Execute();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }
        }
        public void ModificateThem(Theme theme)
        {
            try{
                data.Query("update Theme set Title = @Title, IdIcon = @IdIcon");
                data.Parameters("@Title", theme.Title);
                data.Parameters("@IdIcon", theme.IdIcon);
                data.Execute();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }

        }
    
    }
}
