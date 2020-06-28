using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.BUZ.Entity.Common;
using SBS.UIF.BUZ.DataAccess.Common;

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
