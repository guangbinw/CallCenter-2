﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Linq;
using Softv.Providers;
using Softv.Entities;
using Globals;

/// <summary>
/// Class                   : Softv.BAL.Client.cs
/// Generated by            : Class Generator (c) 2014
/// Description             : EstadisticaBussines
/// File                    : EstadisticaBussines.cs
/// Creation date           : 24/06/2016
/// Creation time           : 01:55 p. m.
///</summary>
namespace Softv.BAL
{

    [DataObject]
    [Serializable]
    public class Estadistica
    {

        #region Constructors
        public Estadistica() { }
        #endregion


        /// <summary>
        ///Get Estadistica
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<EstadisticaEntity> GetAll(int plaza, int idencuesta, DateTime finicio, DateTime ffin)
        {
            List<EstadisticaEntity> entities = new List<EstadisticaEntity>();
            entities = ProviderSoftv.Estadistica.GetEstadistica(plaza, idencuesta, finicio, ffin);

            return entities ?? new List<EstadisticaEntity>();
        }




        //[DataObjectMethod(DataObjectMethodType.Select, true)]
        //public static List<EstadisticaEntity> GetEstadisticasEncuestas(int plaza, int idencuesta, DateTime finicio, DateTime ffin)
        //{
        //    List<EstadisticaEntity> result = new List<EstadisticaEntity>();
        //    result = ProviderSoftv.Estadistica.GetEstadisticasEncuestas(plaza, idencuesta, finicio, ffin);
        //    return result;
        //}
        

    }




    #region Customs Methods

    #endregion
}