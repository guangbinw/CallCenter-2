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
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

namespace SoftvMVC.Controllers
{
    /// <summary>
    /// Class                   : SoftvMVC.Controllers.EncuestaController.cs
    /// Generated by            : Class Generator (c) 2015
    /// Description             : EncuestaController
    /// File                    : EncuestaController.cs
    /// Creation date           : 29/04/2016
    /// Creation time           : 05:28 p. m.
    ///</summary>
    public partial class EncuestaController : BaseController, IDisposable
    {
        private SoftvService.EncuestaClient proxy = null;

        private SoftvService.PreguntaClient preguntasService = null;
        private SoftvService.TipoPreguntasClient TipoPreguntasService = null;
        private SoftvService.UsuarioClient proxyUsuario = null;
        private SoftvService.ResOpcMultsClient Respuestas = null;
        private SoftvService.RelPreguntaOpcMultsClient relpregunta_resp=null;

        public EncuestaController()
        {
            preguntasService = new SoftvService.PreguntaClient();

            proxy = new SoftvService.EncuestaClient();

            proxyUsuario = new SoftvService.UsuarioClient();

            Respuestas = new SoftvService.ResOpcMultsClient();

            relpregunta_resp = new SoftvService.RelPreguntaOpcMultsClient();
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

        }


   


        public ActionResult Index(int? page, int? pageSize)
        {
            PermisosAcceso("Encuesta");
            ViewData["Title"] = "Encuesta";
            ViewData["Message"] = "Encuesta";
            
            


            List<UsuarioEntity> lstUsuario = new List<UsuarioEntity>();
            lstUsuario.Add(new UsuarioEntity() { IdUsuario = null, Nombre = "Todos" });
            lstUsuario.AddRange(proxyUsuario.GetUsuarioList().OrderBy(x => x.Nombre.Trim()));
            ViewBag.IdUsuariotxt = new SelectList(lstUsuario, "IdUsuario", "Nombre");

            CheckNotify();
            ViewBag.CustomScriptsDefault = BuildScriptsDefault("Encuesta");
            return View();
        }

        public class DataTableData
        {
            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<EncuestaEntity> data { get; set; }
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

        private List<EncuestaEntity> FiltrarContenido(ref int recordFiltered, int start, int length)
        {

            List<EncuestaEntity> lista = proxy.GetEncuestaList();
            recordFiltered = lista.Count;
            int rango = start + length;
            return lista.Skip(start).Take(length).ToList();
        }


        private List<TipoPreguntasEntity> TipoPreguntas()
        {
            List<TipoPreguntasEntity> lista = TipoPreguntasService.GetTipoPreguntasList();
            return lista;
        }


        public class Detalle_encuesta
        {
            public EncuestaEntity Encuesta { get; set; }
            public List<Detalle_pregunta> Preguntas { get; set; }
        }

        public class Detalle_pregunta
        {
           public PreguntaEntity Pregunta { get; set; }
          public  List<ResOpcMultsEntity> Respuestas{get; set;}
            
        }





        public ActionResult DeepDetails(int id)
        {
            Detalle_encuesta Encuesta = new Detalle_encuesta();
            List<Detalle_pregunta> Lista_de_preguntas = new List<Detalle_pregunta>();



            EncuestaEntity objEncuesta = proxy.GetEncuesta(id);
            Encuesta.Encuesta = objEncuesta;
            List<PreguntaEntity> preguntas = preguntasService.GetPreguntaList().Where(o => o.RelPreguntaEncuestas.IdEncuesta == objEncuesta.IdEncuesta).ToList();

            foreach (var a in preguntas)
            {

                Detalle_pregunta pregunta = new Detalle_pregunta();
                List<ResOpcMultsEntity> r = new List<ResOpcMultsEntity>();
                pregunta.Pregunta = a;

                List<RelPreguntaOpcMultsEntity> relaciones = relpregunta_resp.GetRelPreguntaOpcMultsList().Where(x => x.IdPregunta == a.IdPregunta).ToList();

                foreach (var resp in relaciones)
                {

                    ResOpcMultsEntity respuestas = Respuestas.GetResOpcMultsList().Where(o => o.Id_ResOpcMult == resp.Id_ResOpcMult).Select(o => o).First();

                    r.Add(respuestas);
                }


                pregunta.Respuestas = r;




                Lista_de_preguntas.Add(pregunta);



            }


            Encuesta.Preguntas = Lista_de_preguntas;


            if (objEncuesta == null)
            {
                return HttpNotFound();
            }


           

            return Json(Encuesta,JsonRequestBehavior.AllowGet);
        }



        public ActionResult Details(int id)
        {
            Detalle_encuesta Encuesta = new Detalle_encuesta();
            List<Detalle_pregunta> Lista_de_preguntas = new List<Detalle_pregunta>();

            

            EncuestaEntity objEncuesta = proxy.GetEncuesta(id);
            Encuesta.Encuesta = objEncuesta;
            List<PreguntaEntity> preguntas = preguntasService.GetPreguntaList().Where(o=>o.RelPreguntaEncuestas.IdEncuesta==objEncuesta.IdEncuesta).ToList();          

             foreach (var a in preguntas)
            {

                Detalle_pregunta pregunta = new Detalle_pregunta();
                List<ResOpcMultsEntity> r = new List<ResOpcMultsEntity>();
                 pregunta.Pregunta = a;

               List<RelPreguntaOpcMultsEntity> relaciones=relpregunta_resp.GetRelPreguntaOpcMultsList().Where(x=>x.IdPregunta==a.IdPregunta).ToList();

                foreach(var resp in relaciones){

                    ResOpcMultsEntity respuestas  = Respuestas.GetResOpcMultsList().Where(o=>o.Id_ResOpcMult==resp.Id_ResOpcMult).Select(o=>o).First();

                    r.Add(respuestas);
                }


                pregunta.Respuestas = r;




                Lista_de_preguntas.Add(pregunta);
                

              
            }


            
           

            if (objEncuesta == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdEncuesta = Encuesta.Encuesta.IdEncuesta;
            ViewBag.NombreEncuesta = Encuesta.Encuesta.TituloEncuesta;
            ViewBag.Descripcion = Encuesta.Encuesta.Descripcion;
            ViewBag.FechaCreacion = Encuesta.Encuesta.FechaCreacion;
            ViewData["preguntas"] = Lista_de_preguntas;

            return View("PreView");
        }

        public class PreguntaEntity1
        {
        
            public string IdPregunta { get; set; }

            public string IdPregunta2 { get; set; }

            
          
            public String Pregunta { get; set; }
         
            public int IdTipoPregunta { get; set; }

           
           
        }

        public class ResOpcMultsEntity1
        {
            public string  Id_ResOpcMult { get; set; }           
            public String ResOpcMult { get; set; }

            public string Id_ResOpcMult2 { get; set; }
        }

        public ActionResult Create(EncuestaEntity encuesta, List<PreguntaEntity1> Preguntas, List<ResOpcMultsEntity1> respuestas,string usuario)
        {
            UsuarioEntity user = proxyUsuario.GetUsuarioList().Where(o=>o.Usuario.ToLower()==usuario.ToLower()).FirstOrDefault();
            encuesta.FechaCreacion = DateTime.Now.ToShortDateString();
            encuesta.IdUsuario = user.IdUsuario.Value;
            
            XElement xe = XElement.Parse(Globals.SerializeTool.Serialize<EncuestaEntity>(encuesta));

            XElement xmll = XElement.Parse(Globals.SerializeTool.SerializeList<PreguntaEntity1>(Preguntas));

            XElement fg = XElement.Parse(Globals.SerializeTool.SerializeList<ResOpcMultsEntity1>(respuestas));
            


            xe.Add(xmll,fg);
            int d = 0;
            // int result = proxy.AddEncuesta(xe.ToString());
            return null;
        }

      

   




        public JsonResult Delete(int id)
        {
            proxy.DeleteEncuesta(id);

            String mensaje = "{mensaje:'Se ha eliminado la Encuesta'}";
            return Json(mensaje, JsonRequestBehavior.AllowGet);
        }


        public class ObjEncuesta
        {
            public  int cliente{get; set; }

            public List<preguntas> pregunta { get; set; }

            public List<respuestas> respuestas { get; set; }

        }

        public class respuestas
        {
            public string id_pregunta { get; set; }
            public string respuesta { get; set; }
        }


        public class preguntas
        {
            public string id_pregunta { get; set; }
            public string nombre { get; set; }
        }


        public ActionResult DatosEncuesta(ObjEncuesta encuesta)
        {
            return Json(encuesta,JsonRequestBehavior.AllowGet);
        }


    }

}

