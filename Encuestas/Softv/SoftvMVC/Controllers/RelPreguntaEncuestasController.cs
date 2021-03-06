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
    /// Class                   : SoftvMVC.Controllers.RelPreguntaEncuestasController.cs
    /// Generated by            : Class Generator (c) 2015
    /// Description             : RelPreguntaEncuestasController
    /// File                    : RelPreguntaEncuestasController.cs
    /// Creation date           : 27/04/2016
    /// Creation time           : 05:18 p. m.
    ///</summary>
    public partial class RelPreguntaEncuestasController : BaseController, IDisposable
    {
        private SoftvService.RelPreguntaEncuestasClient proxy = null;

        private SoftvService.PreguntaClient proxyPregunta = null;

        private SoftvService.EncuestaClient proxyEncuesta = null;

        public RelPreguntaEncuestasController()
        {


            proxy = new SoftvService.RelPreguntaEncuestasClient();

            proxyPregunta = new SoftvService.PreguntaClient();

            proxyEncuesta = new SoftvService.EncuestaClient();

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

            proxyPregunta = new SoftvService.PreguntaClient();
            if (proxyPregunta != null)
            {
                if (proxyPregunta.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyPregunta.Close();
                }
            }

            proxyEncuesta = new SoftvService.EncuestaClient();
            if (proxyEncuesta != null)
            {
                if (proxyEncuesta.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyEncuesta.Close();
                }
            }

        }

        public ActionResult Index(int? page, int? pageSize)
        {
            PermisosAcceso("RelPreguntaEncuestas");
            ViewData["Title"] = "RelPreguntaEncuestas";
            ViewData["Message"] = "RelPreguntaEncuestas";
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            int pageNumber = (page ?? 1);
            SoftvList<RelPreguntaEncuestasEntity> listResult = proxy.GetRelPreguntaEncuestasPagedListXml(pageNumber, pSize, SerializeTool.Serialize<RelPreguntaEncuestasEntity>(new RelPreguntaEncuestasEntity()));


            List<PreguntaEntity> lstPregunta = new List<PreguntaEntity>();
            lstPregunta.Add(new PreguntaEntity() { IdPregunta = null, Pregunta = "Todos" });
            lstPregunta.AddRange(proxyPregunta.GetPreguntaList().OrderBy(x => x.Pregunta.Trim()));
            ViewBag.IdPreguntatxt = new SelectList(lstPregunta, "IdPregunta", "Pregunta");

            List<EncuestaEntity> lstEncuesta = new List<EncuestaEntity>();
            lstEncuesta.Add(new EncuestaEntity() { IdEncuesta = null, Descripcion = "Todos" });
            lstEncuesta.AddRange(proxyEncuesta.GetEncuestaList().OrderBy(x => x.Descripcion.Trim()));
            ViewBag.IdEncuestatxt = new SelectList(lstEncuesta, "IdEncuesta", "Descripcion");

            CheckNotify();
            ViewBag.CustomScriptsDefault = BuildScriptsDefault("RelPreguntaEncuestas");
            return View(new StaticPagedList<RelPreguntaEncuestasEntity>(listResult.ToList(), pageNumber, pSize, listResult.totalCount));
        }

        public ActionResult Details(int id = 0)
        {
            RelPreguntaEncuestasEntity objRelPreguntaEncuestas = proxy.GetRelPreguntaEncuestas(id);
            if (objRelPreguntaEncuestas == null)
            {
                return HttpNotFound();
            }
            return PartialView(objRelPreguntaEncuestas);
        }

        public ActionResult Create()
        {
            PermisosAccesoDeniedCreate("RelPreguntaEncuestas");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();

            ViewBag.VBPregunta = new SelectList(proxyPregunta.GetPreguntaList().OrderBy(x => x.Pregunta.Trim()).ToList(), "IdPregunta", "Pregunta");

            ViewBag.VBEncuesta = new SelectList(proxyEncuesta.GetEncuestaList().OrderBy(x => x.Descripcion.Trim()).ToList(), "IdEncuesta", "Descripcion");

            return View();
        }

        [HttpPost]
        public ActionResult Create(RelPreguntaEncuestasEntity objRelPreguntaEncuestas)
        {
            if (ModelState.IsValid)
            {

                objRelPreguntaEncuestas.BaseRemoteIp = RemoteIp;
                objRelPreguntaEncuestas.BaseIdUser = LoggedUserName;
                int result = proxy.AddRelPreguntaEncuestas(objRelPreguntaEncuestas);
                if (result == -1)
                {

                    ViewBag.VBPregunta = new SelectList(proxyPregunta.GetPreguntaList().OrderBy(x => x.Pregunta.Trim()).ToList(), "IdPregunta", "Pregunta", objRelPreguntaEncuestas.IdPregunta);

                    ViewBag.VBEncuesta = new SelectList(proxyEncuesta.GetEncuestaList().OrderBy(x => x.Descripcion.Trim()).ToList(), "IdEncuesta", "Descripcion", objRelPreguntaEncuestas.IdEncuesta);

                    AssingMessageScript("El RelPreguntaEncuestas ya existe en el sistema.", "error", "Error", true);
                    CheckNotify();
                    return View(objRelPreguntaEncuestas);
                }
                if (result > 0)
                {
                    AssingMessageScript("Se dio de alta el RelPreguntaEncuestas en el sistema.", "success", "Éxito", true);
                    return RedirectToAction("Index");
                }

            }
            return View(objRelPreguntaEncuestas);
        }

        public ActionResult Edit(int id = 0)
        {
            PermisosAccesoDeniedEdit("RelPreguntaEncuestas");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();
            RelPreguntaEncuestasEntity objRelPreguntaEncuestas = proxy.GetRelPreguntaEncuestas(id);

            ViewBag.VBPregunta = new SelectList(proxyPregunta.GetPreguntaList().OrderBy(x => x.Pregunta.Trim()).ToList(), "IdPregunta", "Pregunta");

            ViewBag.VBEncuesta = new SelectList(proxyEncuesta.GetEncuestaList().OrderBy(x => x.Descripcion.Trim()).ToList(), "IdEncuesta", "Descripcion");

            if (objRelPreguntaEncuestas == null)
            {
                return HttpNotFound();
            }
            return View(objRelPreguntaEncuestas);
        }

        //
        // POST: /RelPreguntaEncuestas/Edit/5
        [HttpPost]
        public ActionResult Edit(RelPreguntaEncuestasEntity objRelPreguntaEncuestas)
        {
            if (ModelState.IsValid)
            {
                objRelPreguntaEncuestas.BaseRemoteIp = RemoteIp;
                objRelPreguntaEncuestas.BaseIdUser = LoggedUserName;
                int result = proxy.UpdateRelPreguntaEncuestas(objRelPreguntaEncuestas);
                if (result == -1)
                {
                    RelPreguntaEncuestasEntity objRelPreguntaEncuestasOld = proxy.GetRelPreguntaEncuestas(objRelPreguntaEncuestas.IdPregunta);

                    ViewBag.VBPregunta = new SelectList(proxyPregunta.GetPreguntaList().Where(x => x.IdPregunta == objRelPreguntaEncuestasOld.IdPregunta).OrderBy(x => x.Pregunta.Trim()).ToList(), "IdPregunta", "Pregunta", objRelPreguntaEncuestas.IdPregunta);

                    ViewBag.VBEncuesta = new SelectList(proxyEncuesta.GetEncuestaList().Where(x => x.IdEncuesta == objRelPreguntaEncuestasOld.IdEncuesta).OrderBy(x => x.Descripcion.Trim()).ToList(), "IdEncuesta", "Descripcion", objRelPreguntaEncuestas.IdEncuesta);

                    AssingMessageScript("El RelPreguntaEncuestas ya existe en el sistema, .", "error", "Error", true);
                    CheckNotify();
                    return View(objRelPreguntaEncuestas);
                }
                if (result > 0)
                {
                    AssingMessageScript("El RelPreguntaEncuestas se modifico en el sistema.", "success", "Éxito", true);
                    CheckNotify();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(objRelPreguntaEncuestas);
        }

        public ActionResult QuickIndex(int? page, int? pageSize, int? IdPregunta, int? IdEncuesta)
        {
            int pageNumber = (page ?? 1);
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            SoftvList<RelPreguntaEncuestasEntity> listResult = null;
            List<RelPreguntaEncuestasEntity> listRelPreguntaEncuestas = new List<RelPreguntaEncuestasEntity>();
            RelPreguntaEncuestasEntity objRelPreguntaEncuestas = new RelPreguntaEncuestasEntity();
            RelPreguntaEncuestasEntity objGetRelPreguntaEncuestas = new RelPreguntaEncuestasEntity();


            if ((IdPregunta != null))
            {
                objRelPreguntaEncuestas.IdPregunta = IdPregunta;
            }

            if ((IdEncuesta != null))
            {
                objRelPreguntaEncuestas.IdEncuesta = IdEncuesta;
            }

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            listResult = proxy.GetRelPreguntaEncuestasPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objRelPreguntaEncuestas));
            if (listResult.Count == 0)
            {
                int tempPageNumber = (int)(listResult.totalCount / pSize);
                pageNumber = (int)(listResult.totalCount / pSize) == 0 ? 1 : tempPageNumber;
                listResult = proxy.GetRelPreguntaEncuestasPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objRelPreguntaEncuestas));
            }
            listResult.ToList().ForEach(x => listRelPreguntaEncuestas.Add(x));

            var RelPreguntaEncuestasAsIPagedList = new StaticPagedList<RelPreguntaEncuestasEntity>(listRelPreguntaEncuestas, pageNumber, pSize, listResult.totalCount);
            if (RelPreguntaEncuestasAsIPagedList.Count > 0)
            {
                return PartialView(RelPreguntaEncuestasAsIPagedList);
            }
            else
            {
                var result = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "No se encontraron registros con los criterios de búsqueda ingresados." };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id = 0)
        {
            int result = proxy.DeleteRelPreguntaEncuestas(RemoteIp, LoggedUserName, id);
            if (result > 0)
            {
                var resultOk = new { tipomsj = "success", titulomsj = "Aviso", Success = "True", Message = "Registro de RelPreguntaEncuestas Eliminado." };
                return Json(resultOk, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var resultNg = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "El Registro de RelPreguntaEncuestas No puede ser Eliminado validar dependencias." };
                return Json(resultNg, JsonRequestBehavior.AllowGet);
            }
        }


    }

}

