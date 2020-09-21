using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;

namespace SBS.UIF.CONTRALAFT.DataAccess.Common
{
    public class MenuDataAccess
    {
        public List<Menu> listarPorMenu(int id)
        {
            return (BaseService<Menu>.QueryForList("select_menu", id));
        }
    }
}
