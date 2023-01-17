using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Zona
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JavilesCineContext context = new DL.JavilesCineContext())
                {
                    var query = context.Zonas.FromSqlRaw("ZonaGetAll").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Zona zona = new ML.Zona();
                            zona.IdZona = obj.IdZona;
                            zona.Descripcion = obj.Descripcion;
                            result.Objects.Add(zona);

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