using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.BUZ.Entity.Common;
using SBS.UIF.BUZ.DataAccess.Mapper;

namespace SBS.UIF.BUZ.DataAccess.Common
{
    public class PerfilRolDataAccess
    {

        public int guardarPerfilRol(PerfilRol _perfilRol)
        {
            return (Convert.ToInt32(MapperPro.Instance().Insert("insert_perfilRol", _perfilRol)));
        }

    }
}
