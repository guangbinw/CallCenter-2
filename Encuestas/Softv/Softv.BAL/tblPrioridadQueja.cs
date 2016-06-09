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
    /// Description             : tblPrioridadQuejaBussines
    /// File                    : tblPrioridadQuejaBussines.cs
    /// Creation date           : 08/06/2016
    /// Creation time           : 10:53 a. m.
    ///</summary>
    namespace Softv.BAL
    {

    [DataObject]
    [Serializable]
    public class tblPrioridadQueja
    {

    #region Constructors
    public tblPrioridadQueja(){}
    #endregion

    /// <summary>
    ///Adds tblPrioridadQueja
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public static int Add(tblPrioridadQuejaEntity objtblPrioridadQueja)
  {
  int result = ProviderSoftv.tblPrioridadQueja.AddtblPrioridadQueja(objtblPrioridadQueja);
    return result;
    }

    /// <summary>
    ///Delete tblPrioridadQueja
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public static int Delete(int? clvPrioridadQueja)
    {
    int resultado = ProviderSoftv.tblPrioridadQueja.DeletetblPrioridadQueja(clvPrioridadQueja);
    return resultado;
    }

    /// <summary>
    ///Update tblPrioridadQueja
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static int Edit(tblPrioridadQuejaEntity objtblPrioridadQueja)
    {
    int result = ProviderSoftv.tblPrioridadQueja.EdittblPrioridadQueja(objtblPrioridadQueja);
    return result;
    }

    /// <summary>
    ///Get tblPrioridadQueja
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static List<tblPrioridadQuejaEntity> GetAll()
    {
    List<tblPrioridadQuejaEntity> entities = new List<tblPrioridadQuejaEntity> ();
    entities = ProviderSoftv.tblPrioridadQueja.GettblPrioridadQueja();
    
    return entities ?? new List<tblPrioridadQuejaEntity>();
    }

    /// <summary>
    ///Get tblPrioridadQueja List<lid>
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static List<tblPrioridadQuejaEntity> GetAll(List<int> lid)
    {
    List<tblPrioridadQuejaEntity> entities = new List<tblPrioridadQuejaEntity> ();
    entities = ProviderSoftv.tblPrioridadQueja.GettblPrioridadQueja(lid);    
    return entities ?? new List<tblPrioridadQuejaEntity>();
    }

    /// <summary>
    ///Get tblPrioridadQueja By Id
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static tblPrioridadQuejaEntity GetOne(int? clvPrioridadQueja)
    {
    tblPrioridadQuejaEntity result = ProviderSoftv.tblPrioridadQueja.GettblPrioridadQuejaById(clvPrioridadQueja);
    
    return result;
    }

    /// <summary>
    ///Get tblPrioridadQueja By Id
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static tblPrioridadQuejaEntity GetOneDeep(int? clvPrioridadQueja)
    {
    tblPrioridadQuejaEntity result = ProviderSoftv.tblPrioridadQueja.GettblPrioridadQuejaById(clvPrioridadQueja);
    
    return result;
    }
    

    
      /// <summary>
      ///Get tblPrioridadQueja
      ///</summary>
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static SoftvList<tblPrioridadQuejaEntity> GetPagedList(int pageIndex, int pageSize)
    {
    SoftvList<tblPrioridadQuejaEntity> entities = new SoftvList<tblPrioridadQuejaEntity>();
    entities = ProviderSoftv.tblPrioridadQueja.GetPagedList(pageIndex, pageSize);
    
    return entities ?? new SoftvList<tblPrioridadQuejaEntity>();
    }

    /// <summary>
    ///Get tblPrioridadQueja
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static SoftvList<tblPrioridadQuejaEntity> GetPagedList(int pageIndex, int pageSize,String xml)
    {
    SoftvList<tblPrioridadQuejaEntity> entities = new SoftvList<tblPrioridadQuejaEntity>();
    entities = ProviderSoftv.tblPrioridadQueja.GetPagedList(pageIndex, pageSize,xml);
    
    return entities ?? new SoftvList<tblPrioridadQuejaEntity>();
    }


    }




    #region Customs Methods
    
    #endregion
    }
  