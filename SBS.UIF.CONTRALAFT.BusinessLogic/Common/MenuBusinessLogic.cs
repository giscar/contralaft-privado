using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.DataAccess.Common;

namespace SBS.UIF.CONTRALAFT.BusinessLogic.Common
{
    public class MenuBusinessLogic
    {
        private readonly MenuDataAccess _menuDataAccess;

        public MenuBusinessLogic()
        {
            _menuDataAccess = new MenuDataAccess();
        
        }

        public List<Menu> listarPorMenu(int id)
        {
            return (_menuDataAccess.listarPorMenu(id));
        }

    }
}
