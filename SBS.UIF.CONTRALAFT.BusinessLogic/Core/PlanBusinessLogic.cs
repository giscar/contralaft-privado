using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Core;

namespace SBS.UIF.CONTRALAFT.BusinessLogic.Core
{
    public class PlanBusinessLogic
    {
        private readonly PlanDataAccess _planDataAccess;

        public PlanBusinessLogic()
        {
            _planDataAccess = new PlanDataAccess();
        }

        public int GuardarPlan(Plan _plan)
        {
            return _planDataAccess.GuardarPlan(_plan);
        }

        public Plan BuscarPlanForID(int idPlan)
        {
            return _planDataAccess.BuscarPlanForID(idPlan);
        }

        public Plan BuscarPlanPublicado()
        {
            return _planDataAccess.BuscarPlanPublicado();
        }
        

        public List<Plan> BuscarTodos()
        {
            return _planDataAccess.BuscarTodos();
        }

        public int BuscarVersion()
        {
            return _planDataAccess.BuscarVersion();
        }
        

        public void ActualizarPlan(Plan _plan)
        {
            _planDataAccess.ActualizarPlan(_plan);
        }

        public void InactivarPlan(Plan _plan)
        {
            _planDataAccess.InactivarPlan(_plan);
        }

        public void EstadoPlan(Plan _plan)
        {
            _planDataAccess.EstadoPlan(_plan);
        }

    }
}
