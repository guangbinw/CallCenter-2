﻿
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.Serialization;

    namespace Softv.Entities
    {
    /// <summary>
    /// Class                   : Softv.Entities.ClienteNoContestoEntity.cs
    /// Generated by            : Class Generator (c) 2014
    /// Description             : ClienteNoContesto entity
    /// File                    : ClienteNoContestoEntity.cs
    /// Creation date           : 18/08/2016
    /// Creation time           : 10:58 a. m.
    ///</summary>
    [DataContract]
    [Serializable]
    public class ClienteNoContestoEntity : BaseEntity
    {
    #region Attributes
    
      /// <summary>
      /// Property IdNoContesto
      /// </summary>
      [DataMember]
      public int? IdNoContesto { get; set; }
      /// <summary>
      /// Property IdProcesoEnc
      /// </summary>
      [DataMember]
      public int? IdProcesoEnc { get; set; }
      /// <summary>
      /// Property IdEncuesta
      /// </summary>
      [DataMember]
      public int? IdEncuesta { get; set; }
      /// <summary>
      /// Property Contrato
      /// </summary>
      [DataMember]
      public long? Contrato { get; set; }
      /// <summary>
      /// Property FechaApli
      /// </summary>
      [DataMember]
      public DateTime? FechaApli { get; set; }
      /// <summary>
      /// Property IdPlaza
      /// </summary>
      [DataMember]
      public int? IdPlaza { get; set; }
    #endregion
    }
    }

  