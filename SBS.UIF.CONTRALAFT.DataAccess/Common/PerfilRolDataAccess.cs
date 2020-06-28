using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.BUZ.Entity.Common;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;

namespace SBS.UIF.CONTRALAFT.DataAccess.Common
{
    public class PerfilRolDataAccess
    {

        public int guardarPerfilRol(PerfilRol _perfilRol)
        {
            return (Convert.ToInt32(MapperPro.Instance().Insert("insert_perfilRol", _perfilRol)));
        }

    }
}
