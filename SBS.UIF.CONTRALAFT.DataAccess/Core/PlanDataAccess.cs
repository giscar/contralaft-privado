using System;

using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;
using System.Collections.Generic;

namespace SBS.UIF.CONTRALAFT.DataAccess.Core
{

    public class PlanDataAccess {

        public int GuardarPlan(Plan _plan)
        {
            return (Convert.ToInt32(MapperPro.Instance().Insert("insert_plan", _plan)));
        }

        public Plan BuscarPlanForID(int idPlan)
        {
            return (BaseService<Plan>.QueryForObject("select_plan", idPlan));
        }

        public List<Plan> BuscarTodos()
        {
            return (BaseService<Plan>.QueryForList("select_planes", null));
        }

        public void ActualizarPlan(Plan _plan)
        {
            MapperPro.Instance().Update("update_plan", _plan);
        }

        public void InactivarPlan(Plan _plan)
        {
            MapperPro.Instance().Update("inactive_plan", _plan);
        }

        public void EstadoPlan(Plan _plan)
        {
            MapperPro.Instance().Update("estado_plan", _plan);
        }

    }
}
