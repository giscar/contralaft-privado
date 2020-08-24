using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.DataAccess.Common;
using System.Collections.Generic;

namespace SBS.UIF.CONTRALAFT.BusinessLogic.Common
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
            _perfilRolDataAccess.GuardarPerfilRol(_perfilRol);
        }

        public void GuardarActualizarPerfilRol(PerfilRol _perfilRol)
        {
            List<PerfilRol> lista = _perfilRolDataAccess.ValidarPerfilRol(_perfilRol);
            if (lista.Count > 0) {
                _perfilRolDataAccess.ActualizarPerfilRol(_perfilRol);
            }
            else {
                _perfilRolDataAccess.GuardarPerfilRol(_perfilRol);
            }
            
        }

    }
}
