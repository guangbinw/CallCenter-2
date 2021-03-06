﻿
using SoftvMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Softv.Entities;
using System.Data.SqlClient;
using Globals;

namespace SoftvMVC.Controllers
{
    /// <summary>
    /// Class                   : SoftvMVC.Controllers.UniversoEncuestaController.cs
    /// Generated by            : Class Generator (c) 2015
    /// Description             : UniversoEncuestaController
    /// File                    : UniversoEncuestaController.cs
    /// Creation date           : 12/08/2016
    /// Creation time           : 12:44 p. m.
    ///</summary>
    public partial class UniversoEncuestaController : BaseController, IDisposable
    {
        private SoftvService.UniversoEncuestaClient proxy = null;

        private SoftvService.ProcesoEncuestaClient proxyProcesoEncuesta = null;
        private SoftvService.EncuestaClient proxyEncuesta = null;
        private SoftvService.ClienteNoContestoClient proxyNo = null;

        public UniversoEncuestaController()
        {

            proxy = new SoftvService.UniversoEncuestaClient();

            proxyProcesoEncuesta = new SoftvService.ProcesoEncuestaClient();
            proxyEncuesta = new SoftvService.EncuestaClient();
            proxyNo = new SoftvService.ClienteNoContestoClient();
        }

        new public void Dispose()
        {
            if (proxy != null)
            {
                if (proxy.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxy.Close();
                }
            }

            proxyProcesoEncuesta = new SoftvService.ProcesoEncuestaClient();
            if (proxyProcesoEncuesta != null)
            {
                if (proxyProcesoEncuesta.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyProcesoEncuesta.Close();
                }
            }

        }

        public ActionResult Index(int? page, int? pageSize)
        {
            //PermisosAcceso("UniversoEncuesta");
            //ViewData["Title"] = "UniversoEncuesta";
            //ViewData["Message"] = "UniversoEncuesta";
            //int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            //int pageNumber = (page ?? 1);
            //SoftvList<UniversoEncuestaEntity> listResult = proxy.GetUniversoEncuestaPagedListXml(pageNumber, pSize, SerializeTool.Serialize<UniversoEncuestaEntity>(new UniversoEncuestaEntity()));


            //List<ProcesoEncuestaEntity> lstProcesoEncuesta = new List<ProcesoEncuestaEntity>();
            //lstProcesoEncuesta.Add(new ProcesoEncuestaEntity() { IdProcesoEnc = null, NombreProceso = "Todos" });
            //lstProcesoEncuesta.AddRange(proxyProcesoEncuesta.GetProcesoEncuestaList().OrderBy(x => x.NombreProceso.Trim()));
            //ViewBag.IdProcesoEnctxt = new SelectList(lstProcesoEncuesta, "IdProcesoEnc", "NombreProceso");

            //CheckNotify();
            //ViewBag.CustomScriptsDefault = BuildScriptsDefault("UniversoEncuesta");
            return View();
        }

        public ActionResult Details(int id = 0)
        {
            UniversoEncuestaEntity objUniversoEncuesta = proxy.GetUniversoEncuesta(id);
            if (objUniversoEncuesta == null)
            {
                return HttpNotFound();
            }
            return PartialView(objUniversoEncuesta);
        }

        public ActionResult Create()
        {
            PermisosAccesoDeniedCreate("UniversoEncuesta");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();

            ViewBag.VBProcesoEncuesta = new SelectList(proxyProcesoEncuesta.GetProcesoEncuestaList().OrderBy(x => x.NombreProceso.Trim()).ToList(), "IdProcesoEnc", "NombreProceso");

            return View();
        }

        [HttpPost]
        public ActionResult Create(UniversoEncuestaEntity objUniversoEncuesta)
        {
            if (ModelState.IsValid)
            {

                objUniversoEncuesta.BaseRemoteIp = RemoteIp;
                objUniversoEncuesta.BaseIdUser = LoggedUserName;
                int result = proxy.AddUniversoEncuesta(objUniversoEncuesta);
                if (result == -1)
                {

                    ViewBag.VBProcesoEncuesta = new SelectList(proxyProcesoEncuesta.GetProcesoEncuestaList().OrderBy(x => x.NombreProceso.Trim()).ToList(), "IdProcesoEnc", "NombreProceso", objUniversoEncuesta.IdProcesoEnc);

                    AssingMessageScript("El UniversoEncuesta ya existe en el sistema.", "error", "Error", true);
                    CheckNotify();
                    return View(objUniversoEncuesta);
                }
                if (result > 0)
                {
                    AssingMessageScript("Se dio de alta el UniversoEncuesta en el sistema.", "success", "Éxito", true);
                    return RedirectToAction("Index");
                }

            }
            return View(objUniversoEncuesta);
        }

        public ActionResult Edit(int id = 0)
        {
            PermisosAccesoDeniedEdit("UniversoEncuesta");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();
            UniversoEncuestaEntity objUniversoEncuesta = proxy.GetUniversoEncuesta(id);

            ViewBag.VBProcesoEncuesta = new SelectList(proxyProcesoEncuesta.GetProcesoEncuestaList().OrderBy(x => x.NombreProceso.Trim()).ToList(), "IdProcesoEnc", "NombreProceso");

            if (objUniversoEncuesta == null)
            {
                return HttpNotFound();
            }
            return View(objUniversoEncuesta);
        }

        //
        // POST: /UniversoEncuesta/Edit/5
        [HttpPost]
        public ActionResult Editar(int id)
        {
            if (ModelState.IsValid)
            {
                UniversoEncuestaEntity objUniversoEncuestaOld = proxy.GetUniversoEncuesta(id);
                objUniversoEncuestaOld.Aplicada = true;
                int result = proxy.UpdateUniversoEncuesta(objUniversoEncuestaOld);

                ProcesoEncuestaEntity aux = proxyProcesoEncuesta.GetProcesoEncuesta(objUniversoEncuestaOld.IdProcesoEnc);
                int total = proxy.GetUniversoEncuestaList().Where(o=>o.IdProcesoEnc == aux.IdProcesoEnc && o.Aplicada == true).Count();
                if(total == aux.Total){
                    aux.StatusEncuesta = "Terminada";
                    DateTime thisDay = DateTime.Today;
                    aux.FechaFin = thisDay.ToString();
                    var editar = proxyProcesoEncuesta.UpdateProcesoEncuesta(aux);
                }
            }
            return Json(1,JsonRequestBehavior.AllowGet);
        }

        public ActionResult QuickIndex(int? page, int? pageSize, long? Contrato, String Nombre, String Tel, String Cel, bool? Aplicada, int? IdProcesoEnc)
        {
            int pageNumber = (page ?? 1);
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            SoftvList<UniversoEncuestaEntity> listResult = null;
            List<UniversoEncuestaEntity> listUniversoEncuesta = new List<UniversoEncuestaEntity>();
            UniversoEncuestaEntity objUniversoEncuesta = new UniversoEncuestaEntity();
            UniversoEncuestaEntity objGetUniversoEncuesta = new UniversoEncuestaEntity();


            if ((Contrato != null))
            {
                objUniversoEncuesta.Contrato = Contrato;
            }

            if ((Nombre != null && Nombre.ToString() != ""))
            {
                objUniversoEncuesta.Nombre = Nombre;
            }

            if ((Tel != null && Tel.ToString() != ""))
            {
                objUniversoEncuesta.Tel = Tel;
            }

            if ((Cel != null && Cel.ToString() != ""))
            {
                objUniversoEncuesta.Cel = Cel;
            }

            if ((Aplicada != null))
            {
                objUniversoEncuesta.Aplicada = Aplicada;
            }

            if ((IdProcesoEnc != null))
            {
                objUniversoEncuesta.IdProcesoEnc = IdProcesoEnc;
            }

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            listResult = proxy.GetUniversoEncuestaPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objUniversoEncuesta));
            if (listResult.Count == 0)
            {
                int tempPageNumber = (int)(listResult.totalCount / pSize);
                pageNumber = (int)(listResult.totalCount / pSize) == 0 ? 1 : tempPageNumber;
                listResult = proxy.GetUniversoEncuestaPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objUniversoEncuesta));
            }
            listResult.ToList().ForEach(x => listUniversoEncuesta.Add(x));

            var UniversoEncuestaAsIPagedList = new StaticPagedList<UniversoEncuestaEntity>(listUniversoEncuesta, pageNumber, pSize, listResult.totalCount);
            if (UniversoEncuestaAsIPagedList.Count > 0)
            {
                return PartialView(UniversoEncuestaAsIPagedList);
            }
            else
            {
                var result = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "No se encontraron registros con los criterios de búsqueda ingresados." };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id = 0)
        {
            int result = proxy.DeleteUniversoEncuesta(RemoteIp, LoggedUserName, id);
            if (result > 0)
            {
                var resultOk = new { tipomsj = "success", titulomsj = "Aviso", Success = "True", Message = "Registro de UniversoEncuesta Eliminado." };
                return Json(resultOk, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var resultNg = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "El Registro de UniversoEncuesta No puede ser Eliminado validar dependencias." };
                return Json(resultNg, JsonRequestBehavior.AllowGet);
            }
        }
       
        

        public ActionResult todasEncuestas()
        {
            List<EncuestaEntity> lista = proxyEncuesta.GetEncuestaList().Where(o=>o.Activa == true).ToList();

            return Json(lista,JsonRequestBehavior.AllowGet);
        }
        public class DataTableData
        {
            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<UniversoEncuestaEntity> data { get; set; }
        }

        public ActionResult GetList(string cadena, int draw, int start, int length, int proceso, int ? filtro)
        {
            int total = 0;
            List<UniversoEncuestaEntity> lista = new List<UniversoEncuestaEntity>();
            if (filtro == 1)
            {
                total = proxy.GetUniversoEncuestaList().Where(o => o.IdProcesoEnc == proceso && o.Aplicada == true).ToList().Count;
                lista = proxy.GetUniversoEncuestaList().Where(o => o.IdProcesoEnc == proceso && o.Aplicada == true).Skip(start).Take(length).ToList();
            }
            else if (filtro == 2)
            {
                total = proxy.GetUniversoEncuestaList().Where(o => o.IdProcesoEnc == proceso && o.Aplicada == false).ToList().Count;
                lista = proxy.GetUniversoEncuestaList().Where(o => o.IdProcesoEnc == proceso && o.Aplicada == false).Skip(start).Take(length).ToList();
            }
            else
            {
                if (cadena != "" && cadena != null)
                {
                    try
                    {
                        int contrato = Int32.Parse(cadena);
                        total = proxy.GetUniversoEncuestaList().Where(o => o.IdProcesoEnc == proceso && o.Contrato == Int32.Parse(cadena)).ToList().Count;
                        lista = proxy.GetUniversoEncuestaList().Where(o => o.IdProcesoEnc == proceso && o.Contrato == Int32.Parse(cadena)).Skip(start).Take(length).ToList();
                    }
                    catch
                    {
                        total = proxy.GetUniversoEncuestaList().Where(o => o.IdProcesoEnc == proceso && o.Nombre.ToLower().Contains(cadena.ToLower())).ToList().Count;
                        lista = proxy.GetUniversoEncuestaList().Where(o => o.IdProcesoEnc == proceso && o.Nombre.ToLower().Contains(cadena.ToLower())).Skip(start).Take(length).ToList();
                    }

                }

                if (cadena == null || cadena == "")
                {
                    total = proxy.GetUniversoEncuestaList().Where(o => o.IdProcesoEnc == proceso).ToList().Count;
                    lista = proxy.GetUniversoEncuestaList().Where(o => o.IdProcesoEnc == proceso).Skip(start).Take(length).ToList();
                }
            }
            
            
            int recordFiltered = total;
            DataTableData dataTableData = new DataTableData();
            dataTableData.draw = draw;
            dataTableData.recordsTotal = 0;
            dataTableData.data = lista;
            dataTableData.recordsFiltered = recordFiltered;

            return Json(dataTableData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TerminarProceso(int id_proceso)
        {
            int result = proxy.ActualizarUniverso(id_proceso);
            ProcesoEncuestaEntity proceso = proxyProcesoEncuesta.GetProcesoEncuesta(id_proceso);
            proceso.StatusEncuesta = "Terminada";
            int aux = proxyProcesoEncuesta.UpdateProcesoEncuesta(proceso);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public ActionResult TerminarEncuesta(int id_proceso, int contrato)
        {
            UniversoEncuestaEntity objUniversoEncuestaOld = proxy.GetUniversoEncuesta(id_proceso);
            objUniversoEncuestaOld.Aplicada = true;
            int result = proxy.UpdateUniversoEncuesta(objUniversoEncuestaOld);

            ProcesoEncuestaEntity aux = proxyProcesoEncuesta.GetProcesoEncuesta(objUniversoEncuestaOld.IdProcesoEnc);
            int total = proxy.GetUniversoEncuestaList().Where(o => o.IdProcesoEnc == aux.IdProcesoEnc && o.Aplicada == true).Count();
            ClienteNoContestoEntity cl = new ClienteNoContestoEntity();
            cl.IdEncuesta = aux.IdEncuesta;
            cl.IdProcesoEnc = aux.IdProcesoEnc;
            DateTime thisDay = DateTime.Today;
            cl.FechaApli = thisDay;
            cl.Contrato = contrato;
            cl.IdPlaza = objUniversoEncuestaOld.IdPlaza;
            int res = proxyNo.AddClienteNoContesto(cl);
            if (total == aux.Total)
            {
                aux.StatusEncuesta = "Terminada";
                aux.FechaFin = thisDay.ToString();
                var editar = proxyProcesoEncuesta.UpdateProcesoEncuesta(aux);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }

}

