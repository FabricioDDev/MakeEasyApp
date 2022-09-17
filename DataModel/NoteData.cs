﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DB;

namespace DataModel
{
    public class NoteData
    {
        public NoteData()
        {
            data = new DataAccess();
        }
        public DataAccess data;
        public List<Note> Listing()
        {
            List<Note> list = new List<Note>();
            try
            {
                data.Query("select Id, IdTheme, Title, Description from Note");
                data.Read();
                while (data.readerProp.Read())
                {
                    Note aux = new Note();
                    aux.Id = (int)data.readerProp["Id"];
                    aux.IdTheme = (int)data.readerProp["IdTheme"];
                    aux.Title = (string)data.readerProp["Title"];
                    aux.Description = (string)data.readerProp["Description"];
                    list.Add(aux);
                }
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { data.Close();}
        }
    }
}
