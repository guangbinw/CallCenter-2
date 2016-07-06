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
    /// Class                   : Softv.Providers.PermisoProvider
    /// Generated by            : Class Generator (c) 2014
    /// Description             : Permiso Provider
    /// File                    : PermisoProvider.cs
    /// Creation date           : 30/05/2016
    /// Creation time           : 05:17 p. m.
    /// </summary>
    public abstract class PermisoProvider : Globals.DataAccess
    {

        /// <summary>
        /// Instance of Permiso from DB
        /// </summary>
        private static PermisoProvider _Instance = null;

        private static ObjectHandle obj;
        /// <summary>
        /// Generates a Permiso instance
        /// </summary>
        public static PermisoProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    obj = Activator.CreateInstance(
                    SoftvSettings.Settings.Permiso.Assembly,
                    SoftvSettings.Settings.Permiso.DataClass);
                    _Instance = (PermisoProvider)obj.Unwrap();
                }
                return _Instance;
            }
        }

        /// <summary>
        /// Provider's default constructor
        /// </summary>
        public PermisoProvider()
        {
        }
        /// <summary>
        /// Abstract method to add Permiso
        ///  /summary>
        /// <param name="Permiso"></param>
        /// <returns></returns>
        public abstract int AddPermiso(PermisoEntity entity_Permiso);

        /// <summary>
        /// Abstract method to delete Permiso
        /// </summary>
        public abstract int DeletePermiso(int? IdPermiso);

        /// <summary>
        /// Abstract method to update Permiso
        /// </summary>
        public abstract int EditPermiso(PermisoEntity entity_Permiso);

        /// <summary>
        /// Abstract method to get all Permiso
        /// </summary>
        public abstract List<PermisoEntity> GetPermiso();

        /// <summary>
        /// Abstract method to get all Permiso List<int> lid
        /// </summary>
        public abstract List<PermisoEntity> GetPermiso(List<int> lid);

        /// <summary>
        /// Abstract method to get by id
        /// </summary>
        public abstract PermisoEntity GetPermisoById(int? IdPermiso);


        public abstract List<PermisoEntity> GetPermisoByIdRol(int? IdRol);

        public abstract List<PermisoEntity> GetPermisoByIdModule(int? IdModule);





        /// <summary>
        /// Abstract method to Marge Permiso
        ///  /summary>
        public abstract int MargePermiso(String xml);

        /// <summary>
        ///Get Xml Permiso
        ///</summary>
        public abstract SoftvList<PermisoEntity> GetXml(String xml);





















        /// <summary>
        ///Get Permiso
        ///</summary>
        public abstract SoftvList<PermisoEntity> GetPagedList(int pageIndex, int pageSize);

        /// <summary>
        ///Get Permiso
        ///</summary>
        public abstract SoftvList<PermisoEntity> GetPagedList(int pageIndex, int pageSize, String xml);

        /// <summary>
        /// Converts data from reader to entity
        /// </summary>
        protected virtual PermisoEntity GetPermisoFromReader(IDataReader reader)
        {
            PermisoEntity entity_Permiso = null;
            try
            {
                entity_Permiso = new PermisoEntity();
                entity_Permiso.IdPermiso = (int?)(GetFromReader(reader, "IdPermiso"));
                entity_Permiso.IdRol = (int?)(GetFromReader(reader, "IdRol"));
                entity_Permiso.IdModule = (int?)(GetFromReader(reader, "IdModule"));
                entity_Permiso.OptAdd = (bool?)(GetFromReader(reader, "OptAdd"));
                entity_Permiso.OptSelect = (bool?)(GetFromReader(reader, "OptSelect"));
                entity_Permiso.OptUpdate = (bool?)(GetFromReader(reader, "OptUpdate"));
                entity_Permiso.OptDelete = (bool?)(GetFromReader(reader, "OptDelete"));
                entity_Permiso.Rol = (String)(GetFromReader(reader, "Rol", IsString: true));
                entity_Permiso.Modulo = (String)(GetFromReader(reader, "Modulo", IsString: true));

            }
            catch (Exception ex)
            {
                throw new Exception("Error converting Permiso data to entity", ex);
            }
            return entity_Permiso;
        }

    }

    #region Customs Methods

    #endregion
}

