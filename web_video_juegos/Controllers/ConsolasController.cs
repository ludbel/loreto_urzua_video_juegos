using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api_video_juegos.Models;

namespace web_video_juegos.Controllers
{
    public class ConsolasController : Controller
    {
        video_juegos_bd bd = new video_juegos_bd();

        // INDEX
        // GET: Consolas
        public ActionResult Index()
        {
            return View(bd.consolas);
        }

        // DETAIL
        // GET: Consolas/Details/5
        public ActionResult Details(int id)
        {
            consola co_buscado = bd.consolas.Find(id);

            return View(co_buscado);
        }

        // MOSTRAR LA PANTALLA DE CREAR
        // GET: Consolas/Create
        public ActionResult Create()
        {
            return View();
        }

        // REALIZA EL REGISTRO
        // POST: Consolas/Create
        [HttpPost]
        public ActionResult Create(consola new_co)
        {
            try
            {
                bd.consolas.Add(new_co);
                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // MUESTRA LA PANTALLA DE EDITAR
        // GET: Consolas/Edit/5
        public ActionResult Edit(int id)
        {
            consola co_buscado = bd.consolas.Find(id);

            return View(co_buscado);
        }

        // REALIZA LA EDICIÓN
        // POST: Consolas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, consola co)
        {
            try
            {
                consola co_buscado = bd.consolas.Find(id);
                co_buscado.marca = co.marca;
                co_buscado.modelo = co.modelo;
                co_buscado.anio = co.anio;
                co_buscado.nueva = co.nueva;
                co_buscado.precio = co.precio;
                co_buscado.stock = co.stock;

                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // MUESTRA LA PANTALLA DE ELIMINAR
        // GET: Consolas/Delete/5
        public ActionResult Delete(int id)
        {
            consola co_buscado = bd.consolas.Find(id);

            return View(co_buscado);
        }

        // REALIZA LA ACCIÓN DE ELIMINAR
        // POST: Consolas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                consola co_buscado = bd.consolas.Find(id);
                bd.consolas.Remove(co_buscado);
                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
