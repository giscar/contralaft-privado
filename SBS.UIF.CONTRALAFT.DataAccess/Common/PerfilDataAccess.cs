using System;
using System.Collections.Generic;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;

namespace SBS.UIF.CONTRALAFT.DataAccess.Common
{
    public class PerfilDataAccess
    {
        public List<Perfil> ListarPorPerfil()
        {
            return (BaseService<Perfil>.QueryForList("select_perfil", null));
        }

        public List<Perfil> ListarPerfirForRol(int _rol)
        {
            return (BaseService<Perfil>.QueryForList("select_perfil_for_rol", _rol));
        }
        
        public int GuardarPerfil(Perfil _perfil)
        {
            return (Convert.ToInt32(MapperPro.Instance().Insert("insert_perfil", _perfil)));
        }

        public Perfil PerfilForId(int _idPerfil)
        {
            return (BaseService<Perfil>.QueryForObject("select_perfil_id", _idPerfil));
        }

        public void ActualizarPerfil(Perfil _perfil)
        {
            MapperPro.Instance().Update("update_perfil", _perfil);
        }

        public void InactivarPerfil(Perfil _perfil)
        {
            MapperPro.Instance().Update("inactive_perfil", _perfil);
        }

        

    }
}
