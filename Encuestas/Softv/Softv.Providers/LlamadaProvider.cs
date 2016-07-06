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
    /// Class                   : Softv.Providers.LlamadaProvider
    /// Generated by            : Class Generator (c) 2014
    /// Description             : Llamada Provider
    /// File                    : LlamadaProvider.cs
    /// Creation date           : 20/05/2016
    /// Creation time           : 06:37 p. m.
    /// </summary>
    public abstract class LlamadaProvider : Globals.DataAccess
    {

        /// <summary>
        /// Instance of Llamada from DB
        /// </summary>
        private static LlamadaProvider _Instance = null;

        private static ObjectHandle obj;
        /// <summary>
        /// Generates a Llamada instance
        /// </summary>
        public static LlamadaProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    obj = Activator.CreateInstance(
                    SoftvSettings.Settings.Llamada.Assembly,
                    SoftvSettings.Settings.Llamada.DataClass);
                    _Instance = (LlamadaProvider)obj.Unwrap();
                }
                return _Instance;
            }
        }

        /// <summary>
        /// Provider's default constructor
        /// </summary>
        public LlamadaProvider()
        {
        }
        /// <summary>
        /// Abstract method to add Llamada
        ///  /summary>
        /// <param name="Llamada"></param>
        /// <returns></returns>
        public abstract int AddLlamada(LlamadaEntity entity_Llamada);

        /// <summary>
        /// Abstract method to delete Llamada
        /// </summary>
        public abstract int DeleteLlamada(int? IdLlamada);

        /// <summary>
        /// Abstract method to update Llamada
        /// </summary>
        public abstract int EditLlamada(LlamadaEntity entity_Llamada);

        /// <summary>
        /// Abstract method to get all Llamada
        /// </summary>
        public abstract List<LlamadaEntity> GetLlamada();

        /// <summary>
        /// Abstract method to get all Llamada List<int> lid
        /// </summary>
        public abstract List<LlamadaEntity> GetLlamada(List<int> lid);

        /// <summary>
        /// Abstract method to get by id
        /// </summary>
        public abstract LlamadaEntity GetLlamadaById(int? IdLlamada);


        public abstract List<LlamadaEntity> GetLlamadaByIdUsuario(int? IdUsuario);

        public abstract List<LlamadaEntity> GetLlamadaByIdTurno(int? IdTurno);

        public abstract List<LlamadaEntity> GetLlamadaByIdConexion(int? IdConexion);

        public abstract List<LlamadaEntity> GetLlamadaByClv_Trabajo(int? Clv_Trabajo);

        public abstract List<LlamadaEntity> GetLlamadaByClv_TipSer(int? Clv_TipSer);

        public abstract List<LlamadaEntity> GetLlamadaByContrato(long? Contrato);

        public abstract List<LlamadaEntity> GetLlamadaByClv_Queja(long? Clv_Queja);


        /// <summary>
        ///Get Llamada
        ///</summary>
        public abstract SoftvList<LlamadaEntity> GetPagedList(int pageIndex, int pageSize);

        /// <summary>
        ///Get Llamada
        ///</summary>
        public abstract SoftvList<LlamadaEntity> GetPagedList(int pageIndex, int pageSize, String xml);

        /// <summary>
        /// Converts data from reader to entity
        /// </summary>
        protected virtual LlamadaEntity GetLlamadaFromReader(IDataReader reader)
        {
            LlamadaEntity entity_Llamada = null;
            try
            {
                entity_Llamada = new LlamadaEntity();
                entity_Llamada.IdLlamada = (int?)(GetFromReader(reader, "IdLlamada"));
                entity_Llamada.IdUsuario = (int?)(GetFromReader(reader, "IdUsuario"));
                entity_Llamada.Tipo_Llamada = (bool?)(GetFromReader(reader, "Tipo_Llamada"));
                entity_Llamada.Contrato = (long?)(GetFromReader(reader, "Contrato"));
                entity_Llamada.Detalle = (String)(GetFromReader(reader, "Detalle", IsString: true));
                entity_Llamada.Solucion = (String)(GetFromReader(reader, "Solucion", IsString: true));
                entity_Llamada.Fecha = (String)(GetFromReader(reader, "Fecha"));
                entity_Llamada.HoraInicio = (String)(GetFromReader(reader, "HoraInicio", IsString: true));
                entity_Llamada.HoraFin = (String)(GetFromReader(reader, "HoraFin", IsString: true));
                entity_Llamada.IdTurno = (int?)(GetFromReader(reader, "IdTurno"));
                entity_Llamada.Clv_Queja = (long?)(GetFromReader(reader, "Clv_Queja"));
                entity_Llamada.IdConexion = (int?)(GetFromReader(reader, "IdConexion"));
                entity_Llamada.Clv_Trabajo = (int?)(GetFromReader(reader, "Clv_Trabajo"));
                entity_Llamada.Clv_TipSer = (int?)(GetFromReader(reader, "Clv_TipSer"));
                entity_Llamada.Clv_Problema = (int?)(GetFromReader(reader, "Clv_Problema"));
                entity_Llamada.ProblemaSolucion = (bool?)(GetFromReader(reader, "ProblemaSolucion"));
                entity_Llamada.Clv_Motivo = (int?)(GetFromReader(reader, "Clv_Motivo"));

            }
            catch (Exception ex)
            {
                throw new Exception("Error converting Llamada data to entity", ex);
            }
            return entity_Llamada;
        }

    }

    #region Customs Methods

    #endregion
}

