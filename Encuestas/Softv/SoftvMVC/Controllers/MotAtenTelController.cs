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
    /// Class                   : SoftvMVC.Controllers.MotAtenTelController.cs
    /// Generated by            : Class Generator (c) 2015
    /// Description             : MotAtenTelController
    /// File                    : MotAtenTelController.cs
    /// Creation date           : 27/07/2016
    /// Creation time           : 10:21 a. m.
    ///</summary>
    public partial class MotAtenTelController : BaseController, IDisposable
    {
        private SoftvService.MotAtenTelClient proxy = null;

        public MotAtenTelController()
        {

            proxy = new SoftvService.MotAtenTelClient();

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

        }

        public ActionResult Index(int? page, int? pageSize)
        {
            //PermisosAcceso("MotAtenTel");
            //ViewData["Title"] = "MotAtenTel";
            //ViewData["Message"] = "MotAtenTel";
            //int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            //int pageNumber = (page ?? 1);
            //SoftvList<MotAtenTelEntity> listResult = proxy.GetMotAtenTelPagedListXml(pageNumber, pSize, SerializeTool.Serialize<MotAtenTelEntity>(new MotAtenTelEntity()));


            //CheckNotify();
            //ViewBag.CustomScriptsDefault = BuildScriptsDefault("MotAtenTel");
            //return View(new StaticPagedList<MotAtenTelEntity>(listResult.ToList(), pageNumber, pSize, listResult.totalCount));
            List<MotAtenTelEntity> MonAtenTel = proxy.GetMotAtenTelList();
            return View();
        }

        public ActionResult Details(int id = 0)
        {
            MotAtenTelEntity objMotAtenTel = proxy.GetMotAtenTel(id);
            if (objMotAtenTel == null)
            {
                return HttpNotFound();
            }
            return PartialView(objMotAtenTel);
        }

        public ActionResult Create()
        {
            PermisosAccesoDeniedCreate("MotAtenTel");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();

            return View();
        }

        [HttpPost]
        public ActionResult Create(MotAtenTelEntity objMotAtenTel)
        {
            if (ModelState.IsValid)
            {

                objMotAtenTel.BaseRemoteIp = RemoteIp;
                objMotAtenTel.BaseIdUser = LoggedUserName;
                int result = proxy.AddMotAtenTel(objMotAtenTel);
                if (result == -1)
                {

                    AssingMessageScript("El MotAtenTel ya existe en el sistema.", "error", "Error", true);
                    CheckNotify();
                    return View(objMotAtenTel);
                }
                if (result > 0)
                {
                    AssingMessageScript("Se dio de alta el MotAtenTel en el sistema.", "success", "Éxito", true);
                    return RedirectToAction("Index");
                }

            }
            return View(objMotAtenTel);
        }

        public ActionResult Edit(int id = 0)
        {
            PermisosAccesoDeniedEdit("MotAtenTel");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();
            MotAtenTelEntity objMotAtenTel = proxy.GetMotAtenTel(id);

            if (objMotAtenTel == null)
            {
                return HttpNotFound();
            }
            return View(objMotAtenTel);
        }

        //
        // POST: /MotAtenTel/Edit/5
        [HttpPost]
        public ActionResult Edit(MotAtenTelEntity objMotAtenTel)
        {
            if (ModelState.IsValid)
            {
                objMotAtenTel.BaseRemoteIp = RemoteIp;
                objMotAtenTel.BaseIdUser = LoggedUserName;
                int result = proxy.UpdateMotAtenTel(objMotAtenTel);
                if (result == -1)
                {
                    MotAtenTelEntity objMotAtenTelOld = proxy.GetMotAtenTel(objMotAtenTel.Clv_Motivo);

                    AssingMessageScript("El MotAtenTel ya existe en el sistema, .", "error", "Error", true);
                    CheckNotify();
                    return View(objMotAtenTel);
                }
                if (result > 0)
                {
                    AssingMessageScript("El MotAtenTel se modifico en el sistema.", "success", "Éxito", true);
                    CheckNotify();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(objMotAtenTel);
        }

        public ActionResult QuickIndex(int? page, int? pageSize, String Descripcion)
        {
            int pageNumber = (page ?? 1);
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            SoftvList<MotAtenTelEntity> listResult = null;
            List<MotAtenTelEntity> listMotAtenTel = new List<MotAtenTelEntity>();
            MotAtenTelEntity objMotAtenTel = new MotAtenTelEntity();
            MotAtenTelEntity objGetMotAtenTel = new MotAtenTelEntity();


            if ((Descripcion != null && Descripcion.ToString() != ""))
            {
                objMotAtenTel.Descripcion = Descripcion;
            }

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            listResult = proxy.GetMotAtenTelPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objMotAtenTel));
            if (listResult.Count == 0)
            {
                int tempPageNumber = (int)(listResult.totalCount / pSize);
                pageNumber = (int)(listResult.totalCount / pSize) == 0 ? 1 : tempPageNumber;
                listResult = proxy.GetMotAtenTelPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objMotAtenTel));
            }
            listResult.ToList().ForEach(x => listMotAtenTel.Add(x));

            var MotAtenTelAsIPagedList = new StaticPagedList<MotAtenTelEntity>(listMotAtenTel, pageNumber, pSize, listResult.totalCount);
            if (MotAtenTelAsIPagedList.Count > 0)
            {
                return PartialView(MotAtenTelAsIPagedList);
            }
            else
            {
                var result = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "No se encontraron registros con los criterios de búsqueda ingresados." };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id = 0)
        {
            int result = proxy.DeleteMotAtenTel(RemoteIp, LoggedUserName, id);
            if (result > 0)
            {
                var resultOk = new { tipomsj = "success", titulomsj = "Aviso", Success = "True", Message = "Registro de MotAtenTel Eliminado." };
                return Json(resultOk, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var resultNg = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "El Registro de MotAtenTel No puede ser Eliminado validar dependencias." };
                return Json(resultNg, JsonRequestBehavior.AllowGet);
            }
        }










        public ActionResult GetList(string cadena, int draw, int start, int length)
        {
            DataTableData dataTableData = new DataTableData();
            dataTableData.draw = draw;
            dataTableData.recordsTotal = 0;
            int recordsFiltered = 0;
            if (cadena == null)
            {
                dataTableData.data = FiltrarContenido(ref recordsFiltered, start, length);
            }
            else if (cadena != null)
            {
                try
                {
                    dataTableData.data = FiltrarContenido(ref recordsFiltered, start, length).Where(o => o.Clv_Motivo == int.Parse(cadena)).ToList();

                }
                catch
                {
                    dataTableData.data = FiltrarContenido(ref recordsFiltered, start, length).Where(o => o.Descripcion.ToUpper().Contains(cadena.ToUpper())).ToList();
                }
            }

            dataTableData.recordsFiltered = recordsFiltered;

            return Json(dataTableData, JsonRequestBehavior.AllowGet);
        }

        private List<MotAtenTelEntity> FiltrarContenido(ref int recordFiltered, int start, int length)
        {

            List<MotAtenTelEntity> lista = proxy.GetMotAtenTelList();
            recordFiltered = lista.Count;
            int rango = start + length;
            return lista.Skip(start).Take(length).ToList();
        }

        public class DataTableData
        {
            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<MotAtenTelEntity> data { get; set; }
        }











    }

}
