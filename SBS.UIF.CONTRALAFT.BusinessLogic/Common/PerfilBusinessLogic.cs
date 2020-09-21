﻿using System.Collections.Generic;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.DataAccess.Common;

namespace SBS.UIF.CONTRALAFT.BusinessLogic.Common
{
    public class PerfilBusinessLogic
    {
        private readonly PerfilDataAccess _perfilDataAccess;

        public PerfilBusinessLogic()
        {
            _perfilDataAccess = new PerfilDataAccess();
        }

        public List<Perfil> ListarPorPerfil()
        {
            return (_perfilDataAccess.ListarPorPerfil());
        }

        public void GuardarPerfil(Perfil _perfil)
        {
            _perfilDataAccess.GuardarPerfil(_perfil);
        }

        public Perfil PerfilForId(int _idPerfil)
        {
            return _perfilDataAccess.PerfilForId(_idPerfil);
        }

        public void ActualizarPerfil(Perfil _perfil)
        {
            _perfilDataAccess.ActualizarPerfil(_perfil);
        }

        public void InactivarPerfil(Perfil _perfil)
        {
            _perfilDataAccess.InactivarPerfil(_perfil);
        }

        public List<Perfil> ListarPerfirForRol(int _rol)
        {
            return _perfilDataAccess.ListarPerfirForRol(_rol);
        }
    }
}
