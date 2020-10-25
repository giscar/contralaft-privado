using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;

namespace SBS.UIF.CONTRALAFT.DataAccess.Core
{
    public class AccionDataAccess
    {
        public List<Accion> ListarPorAccion()
        {
            return BaseService<Accion>.QueryForList("select_acciones", null);
        }

        public List<Accion> ListarAccionPorEntidad(int idEntidad)
        {
            return BaseService<Accion>.QueryForList("select_accion_entidad", idEntidad);
        }
        
        public void GuardarAccion(Accion _accion)
        {
            MapperPro.Instance().Insert("insert_accion", _accion);
        }

        public Accion BuscarAccionForID(int idAccion)
        {
            return BaseService<Accion>.QueryForObject("select_accion", idAccion);
        }

        public void ActualizarAccion(Accion _accion)
        {
            MapperPro.Instance().Update("update_accion", _accion);
        }

        public void InactivarAccion(Accion _accion)
        {
            MapperPro.Instance().Update("inactive_accion", _accion);
        }

    }
}
