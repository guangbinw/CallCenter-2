﻿
using SoftvMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Softv.Entities;
using Globals;

namespace SoftvMVC.Controllers
{
    /// <summary>
    /// Class                   : SoftvMVC.Controllers.LlamadaController.cs
    /// Generated by            : Class Generator (c) 2015
    /// Description             : LlamadaController
    /// File                    : LlamadaController.cs
    /// Creation date           : 20/05/2016
    /// Creation time           : 06:37 p. m.
    ///</summary>
    public partial class LlamadaController : BaseController, IDisposable
    {
        private SoftvService.LlamadaClient proxy = null;

        private SoftvService.UsuarioClient proxyUsuario = null;

        private SoftvService.TurnoClient proxyTurnos = null;

        private SoftvService.ConexionClient proxyConexion = null;

        private SoftvService.TrabajoClient proxyTrabajo = null;

        private SoftvService.TipServClient proxyTipServ = null;

        private SoftvService.CLIENTEClient proxyCLIENTE = null;

        private SoftvService.QuejaClient proxyQueja = null;

        public LlamadaController()
        {

            proxy = new SoftvService.LlamadaClient();

            proxyUsuario = new SoftvService.UsuarioClient();

            proxyTurnos = new SoftvService.TurnoClient();

            proxyConexion = new SoftvService.ConexionClient();

            proxyTrabajo = new SoftvService.TrabajoClient();

            proxyTipServ = new SoftvService.TipServClient();

            proxyCLIENTE = new SoftvService.CLIENTEClient();

            proxyQueja = new SoftvService.QuejaClient();

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

            proxyUsuario = new SoftvService.UsuarioClient();
            if (proxyUsuario != null)
            {
                if (proxyUsuario.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyUsuario.Close();
                }
            }

            proxyTurnos = new SoftvService.TurnoClient();
            if (proxyTurnos != null)
            {
                if (proxyTurnos.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyTurnos.Close();
                }
            }

            proxyConexion = new SoftvService.ConexionClient();
            if (proxyConexion != null)
            {
                if (proxyConexion.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyConexion.Close();
                }
            }

            proxyTrabajo = new SoftvService.TrabajoClient();
            if (proxyTrabajo != null)
            {
                if (proxyTrabajo.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyTrabajo.Close();
                }
            }

            proxyTipServ = new SoftvService.TipServClient();
            if (proxyTipServ != null)
            {
                if (proxyTipServ.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyTipServ.Close();
                }
            }

            proxyCLIENTE = new SoftvService.CLIENTEClient();
            if (proxyCLIENTE != null)
            {
                if (proxyCLIENTE.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyCLIENTE.Close();
                }
            }

            proxyQueja = new SoftvService.QuejaClient();
            if (proxyQueja != null)
            {
                if (proxyQueja.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyQueja.Close();
                }
            }

        }

        public ActionResult Index(int? page, int? pageSize)
        {
            PermisosAcceso("Llamada");
            ViewData["Title"] = "Llamada";
            ViewData["Message"] = "Llamada";
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            int pageNumber = (page ?? 1);
            SoftvList<LlamadaEntity> listResult = proxy.GetLlamadaPagedListXml(pageNumber, pSize, SerializeTool.Serialize<LlamadaEntity>(new LlamadaEntity()));


            List<UsuarioEntity> lstUsuario = new List<UsuarioEntity>();
            lstUsuario.Add(new UsuarioEntity() { IdUsuario = null, Nombre = "Todos" });
            lstUsuario.AddRange(proxyUsuario.GetUsuarioList().OrderBy(x => x.Nombre.Trim()));
            ViewBag.IdUsuariotxt = new SelectList(lstUsuario, "IdUsuario", "Nombre");

            List<TurnoEntity> lstTurnos = new List<TurnoEntity>();
            lstTurnos.Add(new TurnoEntity() { IdTurno = null, Turno = "Todos" });
            lstTurnos.AddRange(proxyTurnos.GetTurnoList().OrderBy(x => x.Turno.Trim()));
            ViewBag.IdTurnotxt = new SelectList(lstTurnos, "IdTurno", "Turno");

            List<ConexionEntity> lstConexion = new List<ConexionEntity>();
            lstConexion.Add(new ConexionEntity() { IdConexion = null, Plaza = "Todos" });
            lstConexion.AddRange(proxyConexion.GetConexionList().OrderBy(x => x.Plaza.Trim()));
            ViewBag.IdConexiontxt = new SelectList(lstConexion, "IdConexion", "Plaza");

            List<TrabajoEntity> lstTrabajo = new List<TrabajoEntity>();
            lstTrabajo.Add(new TrabajoEntity() { Clv_Trabajo = null, TRABAJO = "Todos" });
            lstTrabajo.AddRange(proxyTrabajo.GetTrabajoList().OrderBy(x => x.TRABAJO.Trim()));
            ViewBag.Clv_Trabajotxt = new SelectList(lstTrabajo, "Clv_Trabajo", "TRABAJO");

            List<TipServEntity> lstTipServ = new List<TipServEntity>();
            lstTipServ.Add(new TipServEntity() { Clv_TipSer = null, Concepto = "Todos" });
            lstTipServ.AddRange(proxyTipServ.GetTipServList().OrderBy(x => x.Concepto.Trim()));
            ViewBag.Clv_TipSertxt = new SelectList(lstTipServ, "Clv_TipSer", "Concepto");

            List<CLIENTEEntity> lstCLIENTE = new List<CLIENTEEntity>();
            lstCLIENTE.Add(new CLIENTEEntity() { CONTRATO = null, NOMBRE = "Todos" });
            lstCLIENTE.AddRange(proxyCLIENTE.GetCLIENTEList().OrderBy(x => x.NOMBRE.Trim()));
            ViewBag.Contratotxt = new SelectList(lstCLIENTE, "Contrato", "NOMBRE");

            List<QuejaEntity> lstQueja = new List<QuejaEntity>();
            lstQueja.Add(new QuejaEntity() { Clv_Queja = null, Problema = "Todos" });
            lstQueja.AddRange(proxyQueja.GetQuejaList().OrderBy(x => x.Problema.Trim()));
            ViewBag.Clv_Quejatxt = new SelectList(lstQueja, "Clv_Queja", "Problema");

            CheckNotify();
            ViewBag.CustomScriptsDefault = BuildScriptsDefault("Llamada");
            return View(new StaticPagedList<LlamadaEntity>(listResult.ToList(), pageNumber, pSize, listResult.totalCount));
        }

        public ActionResult Details(int id = 0)
        {
            LlamadaEntity objLlamada = proxy.GetLlamada(id);
            if (objLlamada == null)
            {
                return HttpNotFound();
            }
            return PartialView(objLlamada);
        }

        public ActionResult Create()
        {
            PermisosAccesoDeniedCreate("Llamada");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();

            ViewBag.VBUsuario = new SelectList(proxyUsuario.GetUsuarioList().OrderBy(x => x.Nombre.Trim()).ToList(), "IdUsuario", "Nombre");

            ViewBag.VBTurnos = new SelectList(proxyTurnos.GetTurnoList().OrderBy(x => x.Turno.Trim()).ToList(), "IdTurno", "Turno");

            ViewBag.VBConexion = new SelectList(proxyConexion.GetConexionList().OrderBy(x => x.Plaza.Trim()).ToList(), "IdConexion", "Plaza");

            ViewBag.VBTrabajo = new SelectList(proxyTrabajo.GetTrabajoList().OrderBy(x => x.TRABAJO.Trim()).ToList(), "Clv_Trabajo", "TRABAJO");

            ViewBag.VBTipServ = new SelectList(proxyTipServ.GetTipServList().OrderBy(x => x.Concepto.Trim()).ToList(), "Clv_TipSer", "Concepto");

            ViewBag.VBCLIENTE = new SelectList(proxyCLIENTE.GetCLIENTEList().OrderBy(x => x.NOMBRE.Trim()).ToList(), "Contrato", "NOMBRE");

            ViewBag.VBQueja = new SelectList(proxyQueja.GetQuejaList().OrderBy(x => x.Problema.Trim()).ToList(), "Clv_Queja", "Problema");

            return View();
        }

        [HttpPost]
        public ActionResult Create(LlamadaEntity objLlamada)
        {
            if (ModelState.IsValid)
            {

                objLlamada.BaseRemoteIp = RemoteIp;
                objLlamada.BaseIdUser = LoggedUserName;
                int result = proxy.AddLlamada(objLlamada);
                if (result == -1)
                {

                    ViewBag.VBUsuario = new SelectList(proxyUsuario.GetUsuarioList().OrderBy(x => x.Nombre.Trim()).ToList(), "IdUsuario", "Nombre", objLlamada.IdUsuario);

                    ViewBag.VBTurnos = new SelectList(proxyTurnos.GetTurnoList().OrderBy(x => x.Turno.Trim()).ToList(), "IdTurno", "Turno", objLlamada.IdTurno);

                    ViewBag.VBConexion = new SelectList(proxyConexion.GetConexionList().OrderBy(x => x.Plaza.Trim()).ToList(), "IdConexion", "Plaza", objLlamada.IdConexion);

                    ViewBag.VBTrabajo = new SelectList(proxyTrabajo.GetTrabajoList().OrderBy(x => x.TRABAJO.Trim()).ToList(), "Clv_Trabajo", "TRABAJO", objLlamada.Clv_Trabajo);

                    ViewBag.VBTipServ = new SelectList(proxyTipServ.GetTipServList().OrderBy(x => x.Concepto.Trim()).ToList(), "Clv_TipSer", "Concepto", objLlamada.Clv_TipSer);

                    ViewBag.VBCLIENTE = new SelectList(proxyCLIENTE.GetCLIENTEList().OrderBy(x => x.NOMBRE.Trim()).ToList(), "Contrato", "NOMBRE", objLlamada.Contrato);

                    ViewBag.VBQueja = new SelectList(proxyQueja.GetQuejaList().OrderBy(x => x.Problema.Trim()).ToList(), "Clv_Queja", "Problema", objLlamada.Clv_Queja);

                    AssingMessageScript("El Llamada ya existe en el sistema.", "error", "Error", true);
                    CheckNotify();
                    return View(objLlamada);
                }
                if (result > 0)
                {
                    AssingMessageScript("Se dio de alta el Llamada en el sistema.", "success", "Éxito", true);
                    return RedirectToAction("Index");
                }

            }
            return View(objLlamada);
        }

        public ActionResult nueva()
        {
            return View("nueva_llamada");
        }

        public ActionResult Edit(int id = 0)
        {
            PermisosAccesoDeniedEdit("Llamada");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();
            LlamadaEntity objLlamada = proxy.GetLlamada(id);

            ViewBag.VBUsuario = new SelectList(proxyUsuario.GetUsuarioList().OrderBy(x => x.Nombre.Trim()).ToList(), "IdUsuario", "Nombre");

            ViewBag.VBTurnos = new SelectList(proxyTurnos.GetTurnoList().OrderBy(x => x.Turno.Trim()).ToList(), "IdTurno", "Turno");

            ViewBag.VBConexion = new SelectList(proxyConexion.GetConexionList().OrderBy(x => x.Plaza.Trim()).ToList(), "IdConexion", "Plaza");

            ViewBag.VBTrabajo = new SelectList(proxyTrabajo.GetTrabajoList().OrderBy(x => x.TRABAJO.Trim()).ToList(), "Clv_Trabajo", "TRABAJO");

            ViewBag.VBTipServ = new SelectList(proxyTipServ.GetTipServList().OrderBy(x => x.Concepto.Trim()).ToList(), "Clv_TipSer", "Concepto");

            ViewBag.VBCLIENTE = new SelectList(proxyCLIENTE.GetCLIENTEList().OrderBy(x => x.NOMBRE.Trim()).ToList(), "Contrato", "NOMBRE");

            ViewBag.VBQueja = new SelectList(proxyQueja.GetQuejaList().OrderBy(x => x.Problema.Trim()).ToList(), "Clv_Queja", "Problema");

            if (objLlamada == null)
            {
                return HttpNotFound();
            }
            return View(objLlamada);
        }

        //
        // POST: /Llamada/Edit/5
        [HttpPost]
        public ActionResult Edit(LlamadaEntity objLlamada)
        {
            if (ModelState.IsValid)
            {
                objLlamada.BaseRemoteIp = RemoteIp;
                objLlamada.BaseIdUser = LoggedUserName;
                int result = proxy.UpdateLlamada(objLlamada);
                if (result == -1)
                {
                    LlamadaEntity objLlamadaOld = proxy.GetLlamada(objLlamada.IdLlamada);

                    ViewBag.VBUsuario = new SelectList(proxyUsuario.GetUsuarioList().Where(x => x.IdUsuario == objLlamadaOld.IdUsuario).OrderBy(x => x.Nombre.Trim()).ToList(), "IdUsuario", "Nombre", objLlamada.IdUsuario);

                    ViewBag.VBTurnos = new SelectList(proxyTurnos.GetTurnoList().Where(x => x.IdTurno == objLlamadaOld.IdTurno).OrderBy(x => x.Turno.Trim()).ToList(), "IdTurno", "Turno", objLlamada.IdTurno);

                    ViewBag.VBConexion = new SelectList(proxyConexion.GetConexionList().Where(x => x.IdConexion == objLlamadaOld.IdConexion).OrderBy(x => x.Plaza.Trim()).ToList(), "IdConexion", "Plaza", objLlamada.IdConexion);

                    ViewBag.VBTrabajo = new SelectList(proxyTrabajo.GetTrabajoList().Where(x => x.Clv_Trabajo == objLlamadaOld.Clv_Trabajo).OrderBy(x => x.TRABAJO.Trim()).ToList(), "Clv_Trabajo", "TRABAJO", objLlamada.Clv_Trabajo);

                    ViewBag.VBTipServ = new SelectList(proxyTipServ.GetTipServList().Where(x => x.Clv_TipSer == objLlamadaOld.Clv_TipSer).OrderBy(x => x.Concepto.Trim()).ToList(), "Clv_TipSer", "Concepto", objLlamada.Clv_TipSer);

                    ViewBag.VBCLIENTE = new SelectList(proxyCLIENTE.GetCLIENTEList().Where(x => x.CONTRATO == objLlamadaOld.Contrato).OrderBy(x => x.NOMBRE.Trim()).ToList(), "Contrato", "NOMBRE", objLlamada.Contrato);

                    ViewBag.VBQueja = new SelectList(proxyQueja.GetQuejaList().Where(x => x.Clv_Queja == objLlamadaOld.Clv_Queja).OrderBy(x => x.Problema.Trim()).ToList(), "Clv_Queja", "Problema", objLlamada.Clv_Queja);

                    AssingMessageScript("El Llamada ya existe en el sistema, .", "error", "Error", true);
                    CheckNotify();
                    return View(objLlamada);
                }
                if (result > 0)
                {
                    AssingMessageScript("El Llamada se modifico en el sistema.", "success", "Éxito", true);
                    CheckNotify();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(objLlamada);
        }

        public ActionResult QuickIndex(int? page, int? pageSize, bool? Tipo_Llamada, String Detalle, String Solucion, DateTime? Fecha, DateTime? HoraInicio, DateTime? HoraFin, int? IdUsuario, int? IdTurno, int? IdConexion, int? Clv_Trabajo, int? Clv_TipSer, int? Contrato, int? Clv_Queja)
        {
            int pageNumber = (page ?? 1);
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            SoftvList<LlamadaEntity> listResult = null;
            List<LlamadaEntity> listLlamada = new List<LlamadaEntity>();
            LlamadaEntity objLlamada = new LlamadaEntity();
            LlamadaEntity objGetLlamada = new LlamadaEntity();


            if ((Tipo_Llamada != null))
            {
                objLlamada.Tipo_Llamada = Tipo_Llamada;
            }

            if ((Detalle != null && Detalle.ToString() != ""))
            {
                objLlamada.Detalle = Detalle;
            }

            if ((Solucion != null && Solucion.ToString() != ""))
            {
                objLlamada.Solucion = Solucion;
            }

            if ((Fecha != null))
            {
                objLlamada.Fecha = Fecha;
            }

            if ((HoraInicio != null))
            {
                objLlamada.HoraInicio = HoraInicio;
            }

            if ((HoraFin != null))
            {
                objLlamada.HoraFin = HoraFin;
            }

            if ((IdUsuario != null))
            {
                objLlamada.IdUsuario = IdUsuario;
            }

            if ((IdTurno != null))
            {
                objLlamada.IdTurno = IdTurno;
            }

            if ((IdConexion != null))
            {
                objLlamada.IdConexion = IdConexion;
            }

            if ((Clv_Trabajo != null))
            {
                objLlamada.Clv_Trabajo = Clv_Trabajo;
            }

            if ((Clv_TipSer != null))
            {
                objLlamada.Clv_TipSer = Clv_TipSer;
            }

            if ((Contrato != null))
            {
                objLlamada.Contrato = Contrato;
            }

            if ((Clv_Queja != null))
            {
                objLlamada.Clv_Queja = Clv_Queja;
            }

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            listResult = proxy.GetLlamadaPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objLlamada));
            if (listResult.Count == 0)
            {
                int tempPageNumber = (int)(listResult.totalCount / pSize);
                pageNumber = (int)(listResult.totalCount / pSize) == 0 ? 1 : tempPageNumber;
                listResult = proxy.GetLlamadaPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objLlamada));
            }
            listResult.ToList().ForEach(x => listLlamada.Add(x));

            var LlamadaAsIPagedList = new StaticPagedList<LlamadaEntity>(listLlamada, pageNumber, pSize, listResult.totalCount);
            if (LlamadaAsIPagedList.Count > 0)
            {
                return PartialView(LlamadaAsIPagedList);
            }
            else
            {
                var result = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "No se encontraron registros con los criterios de búsqueda ingresados." };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id = 0)
        {
            int result = proxy.DeleteLlamada(RemoteIp, LoggedUserName, id);
            if (result > 0)
            {
                var resultOk = new { tipomsj = "success", titulomsj = "Aviso", Success = "True", Message = "Registro de Llamada Eliminado." };
                return Json(resultOk, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var resultNg = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "El Registro de Llamada No puede ser Eliminado validar dependencias." };
                return Json(resultNg, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetList(string data, int draw, int start, int length)
        {
            DataTableData dataTableData = new DataTableData();
            dataTableData.draw = draw;
            dataTableData.recordsTotal = 0;
            int recordsFiltered = 0;
            dataTableData.data = FiltrarContenido(ref recordsFiltered, start, length);
            dataTableData.recordsFiltered = recordsFiltered;

            return Json(dataTableData, JsonRequestBehavior.AllowGet);
        }

        private List<LlamadaEntity> FiltrarContenido(ref int recordFiltered, int start, int length)
        {

            List<LlamadaEntity> lista = proxy.GetLlamadaList();
            recordFiltered = lista.Count;
            int rango = start + length;
            return lista.Skip(start).Take(length).ToList();
        }

        public class DataTableData
        {
            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<LlamadaEntity> data { get; set; }
        }


    }

}

