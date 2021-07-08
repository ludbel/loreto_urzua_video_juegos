using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api_video_juegos.Models;

namespace web_video_juegos.Controllers
{
    public class MandosController : Controller
    {
        video_juegos_bd bd = new video_juegos_bd();

        // INDEX
        // GET: Mandos
        public ActionResult Index()
        {
            return View(bd.mandos);
        }

        // DETAIL
        // GET: Mandos/Details/5
        public ActionResult Details(int id)
        {
            mando ma_buscado = bd.mandos.Find(id);

            return View(ma_buscado);
        }

        // MOSTRAR LA PANTALLA DE CREAR
        // GET: Mandos/Create
        public ActionResult Create()
        {
            return View();
        }

        // REALIZA EL REGISTRO
        // POST: Mandos/Create
        [HttpPost]
        public ActionResult Create(mando new_ma)
        {
            try
            {
                bd.mandos.Add(new_ma);
                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // MUESTRA LA PANTALLA DE EDITAR
        // GET: Mandos/Edit/5
        public ActionResult Edit(int id)
        {
            mando ma_buscado = bd.mandos.Find(id);

            return View();
        }

        // REALIZA LA EDICIÓN
        // POST: Mandos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, mando ma)
        {
            try
            {
                mando ma_buscado = bd.mandos.Find(id);
                ma_buscado.marca = ma.marca;
                ma_buscado.modelo = ma.modelo;
                ma_buscado.compatibilidad = ma.compatibilidad;
                ma_buscado.precio = ma.precio;
                ma_buscado.stock = ma.stock;

                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // MUESTRA LA PANTALLA DE ELIMINAR
        // GET: Mandos/Delete/5
        public ActionResult Delete(int id)
        {
            mando ma_buscado = bd.mandos.Find(id);

            return View(ma_buscado);
        }

        // REALIZA LA ACCIÓN DE ELIMINAR
        // POST: Mandos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                mando ma_buscado = bd.mandos.Find(id);
                bd.mandos.Remove(ma_buscado);
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
