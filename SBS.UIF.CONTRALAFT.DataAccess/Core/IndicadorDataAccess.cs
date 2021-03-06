﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;

namespace SBS.UIF.CONTRALAFT.DataAccess.Core
{
    public class IndicadorDataAccess
    {
        public Indicador ListarIndicadorForId(int idIndicador)
        {
            return BaseService<Indicador>.QueryForObject("select_indicador_id", idIndicador);
        }

        public List<Indicador> ListarIndicadorAll()
        {
            return BaseService<Indicador>.QueryForList("select_indicador_all", null);
        }

        public List<Indicador> ListarIndicadorForAccionEntidad(Indicador indicador)
        {
            return BaseService<Indicador>.QueryForList("select_indicador_accion_entidad", indicador);
        }

        public List<Indicador> ListarIndicadorForAccion(int idAccion)
        {
            return BaseService<Indicador>.QueryForList("select_indicador_accion", idAccion);
        }
        
        public int GuardarIndicador(Indicador _indicador)
        {
            return Convert.ToInt32(MapperPro.Instance().Insert("insert_indicador", _indicador));
        }

        public void ActualizarIndicador(Indicador _indicador)
        {
            MapperPro.Instance().Update("update_indicador", _indicador);
        }

        public void InactivarIndicador(Indicador _indicador)
        {
            MapperPro.Instance().Update("inactive_indicador", _indicador);
        }
    }
}
