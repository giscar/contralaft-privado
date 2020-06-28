using SBS.UIF.BUZ.Entity.Common;
using SBS.UIF.CONTRALAFT.DataAccess.Common;

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
            _perfilRolDataAccess.guardarPerfilRol(_perfilRol);
        }

    }
}
