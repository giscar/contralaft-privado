using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.BUZ.Entity.Common;
using SBS.UIF.BUZ.DataAccess.Common;

namespace SBS.UIF.BUZ.BusinessLogic.Common
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

    }
}
