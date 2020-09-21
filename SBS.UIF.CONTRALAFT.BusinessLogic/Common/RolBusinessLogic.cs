using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.DataAccess.Common;

namespace SBS.UIF.CONTRALAFT.BusinessLogic.Common
{
    public class RolBusinessLogic
    {
        private readonly RolDataAccess _rolDataAccess;

        public RolBusinessLogic()
        {
            _rolDataAccess = new RolDataAccess();
        }

        public List<Rol> ListarPorRol()
        {
            return (_rolDataAccess.ListarPorRol());
        }

        public Rol RolForId(int idRol)
        {
            return (_rolDataAccess.RolForId(idRol));
        }

        public int GuardarRol(Rol _rol)
        {
            return _rolDataAccess.GuardarRol(_rol);
        }

        public int ActualizarRol(Rol _rol)
        {
            return _rolDataAccess.ActualizarRol(_rol);
        }

        public void InactivarRol(Rol _rol)
        {
            _rolDataAccess.InactivarRol(_rol);
        }
    }
}
