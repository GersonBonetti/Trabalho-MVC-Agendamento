﻿using MVC_Agendamento_Domain.DTO;
using MVC_Agendamento_Domain.IRepositories;
using MVC_Agendamento_Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Agendamento_Application_Service.SQLServerServices
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public List<AgendaDTO> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<AgendaDTO> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(AgendaDTO entityDTO)
        {
            return _agendaRepository.Save(entityDTO.mapToEntity());
        }

        public Task<int> Update(AgendaDTO entityDTO)
        {
            return _agendaRepository.Update(entityDTO.mapToEntity());
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _agendaRepository.FindById(id);
            return await _agendaRepository.Delete(entity);
        }
    }
}
