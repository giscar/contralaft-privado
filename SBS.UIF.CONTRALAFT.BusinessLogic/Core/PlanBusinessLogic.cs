using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Core;
using SBS.UIF.CONTRALAFT.Util;

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

        public Plan BuscarPlanVigente()
        {
            return _planDataAccess.BuscarPlanVigente();
        }

        public Plan BuscarPlanBorrador()
        {
            return _planDataAccess.BuscarPlanBorrador();
        }

        public List<Plan> BuscarTodos()
        {
            List<Plan> lista = _planDataAccess.BuscarTodos();
            foreach (Plan item in lista)
            {
                if (item.Vigente == (int)Constantes.EstadoVigencia.NOVIGENTE)
                {
                    item.VigenteDetalle = Constantes.estadoNoVigente;
                }
                if (item.Vigente == (int)Constantes.EstadoVigencia.VIGENTE)
                {
                    item.VigenteDetalle = Constantes.estadoVigente;
                }
            }
            return lista;
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

        public void VigenciaPlan(Plan _plan)
        {
            _planDataAccess.VigenciaPlan(_plan);
        }

    }
}
