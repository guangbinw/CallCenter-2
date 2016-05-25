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
    /// Class                   : Softv.Providers.CALLEProvider
    /// Generated by            : Class Generator (c) 2014
    /// Description             : CALLE Provider
    /// File                    : CALLEProvider.cs
    /// Creation date           : 20/05/2016
    /// Creation time           : 06:40 p. m.
    /// </summary>
    public abstract class CALLEProvider : Globals.DataAccess
    {

        /// <summary>
        /// Instance of CALLE from DB
        /// </summary>
        private static CALLEProvider _Instance = null;

        private static ObjectHandle obj;
        /// <summary>
        /// Generates a CALLE instance
        /// </summary>
        public static CALLEProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    obj = Activator.CreateInstance(
                    SoftvSettings.Settings.CALLE.Assembly,
                    SoftvSettings.Settings.CALLE.DataClass);
                    _Instance = (CALLEProvider)obj.Unwrap();
                }
                return _Instance;
            }
        }

        /// <summary>
        /// Provider's default constructor
        /// </summary>
        public CALLEProvider()
        {
        }
        /// <summary>
        /// Abstract method to add CALLE
        ///  /summary>
        /// <param name="CALLE"></param>
        /// <returns></returns>
        public abstract int AddCALLE(CALLEEntity entity_CALLE);

        /// <summary>
        /// Abstract method to delete CALLE
        /// </summary>
        public abstract int DeleteCALLE(int? Clv_Calle);

        /// <summary>
        /// Abstract method to update CALLE
        /// </summary>
        public abstract int EditCALLE(CALLEEntity entity_CALLE);

        /// <summary>
        /// Abstract method to get all CALLE
        /// </summary>
        public abstract List<CALLEEntity> GetCALLE();

        /// <summary>
        /// Abstract method to get all CALLE List<int> lid
        /// </summary>
        public abstract List<CALLEEntity> GetCALLE(List<int> lid);

        /// <summary>
        /// Abstract method to get by id
        /// </summary>
        public abstract CALLEEntity GetCALLEById(int? Clv_Calle);


        public abstract List<CALLEEntity> GetCALLEByClv_Calle(int? Clv_Calle);


        public abstract List<CALLEEntity> GetCALLEByIdCalle(int? Clv_Calle);


        /// <summary>
        ///Get CALLE
        ///</summary>
        public abstract SoftvList<CALLEEntity> GetPagedList(int pageIndex, int pageSize);

        /// <summary>
        ///Get CALLE
        ///</summary>
        public abstract SoftvList<CALLEEntity> GetPagedList(int pageIndex, int pageSize, String xml);

        /// <summary>
        /// Converts data from reader to entity
        /// </summary>
        protected virtual CALLEEntity GetCALLEFromReader(IDataReader reader)
        {
            CALLEEntity entity_CALLE = null;
            try
            {
                entity_CALLE = new CALLEEntity();
                entity_CALLE.Clv_Calle = (int?)(GetFromReader(reader, "Clv_Calle"));
                entity_CALLE.Nombre = (String)(GetFromReader(reader, "Nombre", IsString: true));

            }
            catch (Exception ex)
            {
                throw new Exception("Error converting CALLE data to entity", ex);
            }
            return entity_CALLE;
        }

    }

    #region Customs Methods

    #endregion
}
