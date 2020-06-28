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

        public List<Rol> listarPorRol()
        {
            return (_rolDataAccess.listarPorRol());
        }

        public int guardarRol(Rol _rol)
        {
            return _rolDataAccess.guardarRol(_rol);
        }
    }
}
