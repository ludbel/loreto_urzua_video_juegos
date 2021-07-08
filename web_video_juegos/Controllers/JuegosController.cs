using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api_video_juegos.Models;

namespace web_video_juegos.Controllers
{
    public class JuegosController : Controller
    {
        video_juegos_bd bd = new video_juegos_bd();

        // INDEX
        // GET: Juegos
        public ActionResult Index()
        {
            return View(bd.juegos);
        }

        // DETAIL
        // GET: Juegos/Details/5
        public ActionResult Details(int id)
        {
            juego ju_buscado = bd.juegos.Find(id);

            return View(ju_buscado);
        }

        // MOSTRAR LA PANTALLA DE CREAR
        // GET: Juegos/Create
        public ActionResult Create()
        {
            return View();
        }

        // REALIZA EL REGISTRO
        // POST: Juegos/Create
        [HttpPost]
        public ActionResult Create(juego new_ju)
        {
            try
            {
                bd.juegos.Add(new_ju);
                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // MUESTRA LA PANTALLA DE EDITAR
        // GET: Juegos/Edit/5
        public ActionResult Edit(int id)
        {
            juego ju_buscado = bd.juegos.Find(id);

            return View();
        }

        // REALIZA LA EDICIÓN
        // POST: Juegos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, juego ju)
        {
            try
            {
                juego ju_buscado = bd.juegos.Find(id);
                ju_buscado.nombre = ju.nombre;
                ju_buscado.plataforma = ju.plataforma;
                ju_buscado.anio = ju.anio;
                ju_buscado.precio = ju.precio;
                ju_buscado.stock = ju.stock;
                ju_buscado.restriccion = ju.restriccion;

                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // MUESTRA LA PANTALLA DE ELIMINAR
        // GET: Juegos/Delete/5
        public ActionResult Delete(int id)
        {
            juego ju_buscado = bd.juegos.Find(id);

            return View(ju_buscado);
        }

        // REALIZA LA ACCIÓN DE ELIMINAR
        // POST: Juegos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                juego ju_buscado = bd.juegos.Find(id);
                bd.juegos.Remove(ju_buscado);
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
