﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Softv.Entities
{
    /// <summary>
    /// Class                   : Softv.Entities.DatosLlamadaEntity.cs
    /// Generated by            : Class Generator (c) 2014
    /// Description             : DatosLlamada entity
    /// File                    : DatosLlamadaEntity.cs
    /// Creation date           : 21/06/2016
    /// Creation time           : 10:18 a. m.
    ///</summary>
    [DataContract]
    [Serializable]
    public class DatosLlamadaEntity : BaseEntity
    {
        #region Attributes

        /// <summary>
        /// Property Id
        /// </summary>
        [DataMember]
        public int? Id { get; set; }
        /// <summary>
        /// Property IdLlamada
        /// </summary>
        [DataMember]
        public int? IdConexion { get; set; }
        /// <summary>
        /// Property IdLlamada
        /// </summary>
        [DataMember]
        public long? IdLlamada { get; set; }
        /// <summary>
        /// Property Contrato
        /// </summary>
        [DataMember]
        public long? Contrato { get; set; }
        /// <summary>
        /// Property Fecha
        /// </summary>
        [DataMember]
        public String Fecha { get; set; }
        /// <summary>
        /// Property Nombre
        /// </summary>
        [DataMember]
        public String Nombre { get; set; }
        /// <summary>
        /// Property Usuario
        /// </summary>
        [DataMember]
        public String Usuario { get; set; }


        [DataMember]
        public bool TipoLlamada { get; set; }
        [DataMember]
        public String Ciudad { get; set; }

        #endregion
    }
}

