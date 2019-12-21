using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.BUZ.Entity.Common;
using SBS.UIF.BUZ.DataAccess.Mapper;

namespace SBS.UIF.BUZ.DataAccess.Common
{
    public class MenuDataAccess
    {
        public List<Menu> listarPorMenu()
        {
            return (BaseService<Menu>.QueryForList("select_menu", null));
        }
    }
}
