using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.BUZ.Entity.Common;
using SBS.UIF.BUZ.DataAccess.Common;

namespace SBS.UIF.BUZ.BusinessLogic.Common
{
    public class PerfilRolBusinessLogic
    {
        private readonly PerfilRolDataAccess _perfilRolDataAccess;

        public PerfilRolBusinessLogic()
        {
            _perfilRolDataAccess = new PerfilRolDataAccess();
        
        }
        public void guardarPerfilRol(PerfilRol _perfilRol)
        {
            _perfilRolDataAccess.guardarPerfilRol(_perfilRol);
        }

    }
}
