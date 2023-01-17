using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cine
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JavilesCineContext context = new DL.JavilesCineContext())
                {
                    var query = context.Cines.FromSqlRaw("GetAll").ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Cine cine = new ML.Cine();
                            cine.IdCine = obj.IdCine.Value;
                            cine.Nombre = obj.Nombre;
                            cine.Direccion = obj.Direccion;
                            cine.Venta = obj.Venta.Value;

                            cine.Zona = new ML.Zona();
                            cine.Zona.IdZona = obj.IdZona.Value;
                            cine.Zona.Descripcion = obj.Zonas;

                            result.Objects.Add(cine);
                        }
                        result.Correct = true;
                    }
                    else { result.Correct = false; }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int IdCine)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JavilesCineContext context = new DL.JavilesCineContext())
                {
                    var query = context.Cines.FromSqlRaw($"CineGetById {IdCine}").AsEnumerable().FirstOrDefault();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        ML.Cine cine = new ML.Cine();

                        cine.IdCine = query.IdCine.Value;
                        cine.Nombre = query.Nombre;
                        cine.Direccion = query.Direccion;
                        cine.Venta = query.Venta.Value;

                        cine.Zona = new ML.Zona();
                        cine.Zona.IdZona = query.IdZona.Value;
                        cine.Zona.Descripcion = query.Zonas;

                        result.Object = cine;

                        result.Correct = true;
                    }
                    else { result.Correct = false; }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Add(ML.Cine cine)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JavilesCineContext context = new DL.JavilesCineContext())
                {
                    var query = context.Database.ExecuteSql($"CineAdd {cine.Nombre},{cine.Direccion},{cine.Venta},{cine.Zona.IdZona}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Cine cine)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JavilesCineContext context = new DL.JavilesCineContext())
                {
                    var query = context.Database.ExecuteSql($"CineUpdate {cine.IdCine}, {cine.Nombre},{cine.Direccion},{cine.Venta},{cine.Zona.IdZona}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int IdCine)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JavilesCineContext context = new DL.JavilesCineContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"CineDelete {IdCine}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result SumTotal()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JavilesCineContext context = new DL.JavilesCineContext())
                {
                    var query = context.Cines.FromSqlRaw("[PuntosDeVentaGetAll]").ToList();
                    result.Objects = new List<object>();

                    
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Cine cine = new ML.Cine();
                            cine.IdCine = obj.IdCine.Value;
                            cine.Nombre = obj.Nombre;
                            cine.Direccion = obj.Direccion;
                            cine.Venta = obj.Venta.Value;

                            cine.Zona = new ML.Zona();
                            cine.Zona.IdZona = obj.IdZona.Value;
                            cine.Zona.Descripcion = obj.Zonas;
                            if (cine.Zona.Descripcion == "Norte")
                            {
                                cine.VentaN =  cine.Venta;
                            }
                            else if (cine.Zona.Descripcion == "Sur")
                            {
                                cine.VentaS =  cine.Venta;
                            }
                            else if (cine.Zona.Descripcion == "Este")
                            {
                                cine.VentaE = cine.Venta;
                            }
                            else
                            {
                                cine.VentaO = cine.Venta;
                            }
                            
                           
                            result.Objects.Add(cine);

                        }
                        result.Correct = true;
                    }
                    else { result.Correct = false; }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
