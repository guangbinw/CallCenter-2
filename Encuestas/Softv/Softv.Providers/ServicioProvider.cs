﻿
using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Remoting;
using Softv.Entities;
using SoftvConfiguration;
using Globals;

namespace Softv.Providers
{
    /// <summary>
    /// Class                   : Softv.Providers.ServicioProvider
    /// Generated by            : Class Generator (c) 2014
    /// Description             : Servicio Provider
    /// File                    : ServicioProvider.cs
    /// Creation date           : 14/06/2016
    /// Creation time           : 11:09 a. m.
    /// </summary>
    public abstract class ServicioProvider : Globals.DataAccess
    {

        /// <summary>
        /// Instance of Servicio from DB
        /// </summary>
        private static ServicioProvider _Instance = null;

        private static ObjectHandle obj;
        /// <summary>
        /// Generates a Servicio instance
        /// </summary>
        public static ServicioProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    obj = Activator.CreateInstance(
                    SoftvSettings.Settings.Servicio.Assembly,
                    SoftvSettings.Settings.Servicio.DataClass);
                    _Instance = (ServicioProvider)obj.Unwrap();
                }
                return _Instance;
            }
        }

        /// <summary>
        /// Provider's default constructor
        /// </summary>
        public ServicioProvider()
        {
        }
        /// <summary>
        /// Abstract method to add Servicio
        ///  /summary>
        /// <param name="Servicio"></param>
        /// <returns></returns>
        public abstract int AddServicio(ServicioEntity entity_Servicio);

        /// <summary>
        /// Abstract method to delete Servicio
        /// </summary>
        public abstract int DeleteServicio(int? Clv_Servicio);

        /// <summary>
        /// Abstract method to update Servicio
        /// </summary>
        public abstract int EditServicio(ServicioEntity entity_Servicio);

        /// <summary>
        /// Abstract method to get all Servicio
        /// </summary>
        public abstract List<ServicioEntity> GetServicio();

        /// <summary>
        /// Abstract method to get all Servicio List<int> lid
        /// </summary>
        public abstract List<ServicioEntity> GetServicio(List<int> lid);

        /// <summary>
        /// Abstract method to get by id
        /// </summary>
        public abstract ServicioEntity GetServicioById(int? Clv_Servicio);



        /// <summary>
        ///Get Servicio
        ///</summary>
        public abstract SoftvList<ServicioEntity> GetPagedList(int pageIndex, int pageSize);

        /// <summary>
        ///Get Servicio
        ///</summary>
        public abstract SoftvList<ServicioEntity> GetPagedList(int pageIndex, int pageSize, String xml);

        /// <summary>
        /// Converts data from reader to entity
        /// </summary>
        protected virtual ServicioEntity GetServicioFromReader(IDataReader reader)
        {
            ServicioEntity entity_Servicio = null;
            try
            {
                entity_Servicio = new ServicioEntity();
                entity_Servicio.Clv_Servicio = (int?)(GetFromReader(reader, "Clv_Servicio"));
                entity_Servicio.Clv_TipSer = (int?)(GetFromReader(reader, "Clv_TipSer"));
                entity_Servicio.Descripcion = (String)(GetFromReader(reader, "Descripcion", IsString: true));
                entity_Servicio.Clv_Txt = (String)(GetFromReader(reader, "Clv_Txt", IsString: true));
                entity_Servicio.AplicanCom = (bool?)(GetFromReader(reader, "AplicanCom"));
                entity_Servicio.Sale_en_Cartera = (bool?)(GetFromReader(reader, "Sale_en_Cartera"));
                entity_Servicio.Precio = (Decimal?)(GetFromReader(reader, "Precio"));
                entity_Servicio.Genera_Orden = (bool?)(GetFromReader(reader, "Genera_Orden"));
                entity_Servicio.Es_Principal = (bool?)(GetFromReader(reader, "Es_Principal"));
                entity_Servicio.Clv_Trabajo = (int?)(GetFromReader(reader, "Clv_Trabajo"));

            }
            catch (Exception ex)
            {
                throw new Exception("Error converting Servicio data to entity", ex);
            }
            return entity_Servicio;
        }

    }

    #region Customs Methods

    #endregion
}

