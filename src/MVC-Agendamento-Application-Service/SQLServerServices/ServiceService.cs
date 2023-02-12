﻿using MVC_Agendamento_Domain.Contract.Repositories;
using MVC_Agendamento_Domain.Contracts.Services;
using MVC_Agendamento_Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Agendamento_Application_Service.SQLServerServices
{
    public class ServiceService : IServiceService {

        private readonly IServiceRepository _repository;

        public ServiceService(IServiceRepository repository) {
            _repository = repository;
        }

        public async Task<int> Delete(int id) {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }

        public List<ServiceDTO> FindAll() {
            return _repository.FindAll()
                              .Select(c => new ServiceDTO() {
                                  id = c.Id,
                                  idSchedule = c.IdSchedule,
                                  idPatient = c.IdPatient,
                                  idDoctor = c.IdDoctor,
                                  patient = c.Patient,
                                  doctor = c.Doctor,
                                  serviceNumbe = c.ServiceNumbe,
                                  status = c.Status,
                                  evaluation = c.Evaluation,
                                  medicalRecord = c.MedicalRecord,
                              }).ToList();
        }

        public async Task<ServiceDTO> FindById(int id) {
            var dto = new ServiceDTO();
            return dto.mapToDTO(await _repository.FindById(id));
        }

        public List<ServiceDTO> GetAll() {
            throw new NotImplementedException(); //To pensando em criar um novo  IBaseService
        }

        public Task<ServiceDTO> GetById(int id) {
            throw new NotImplementedException(); //To pensando em criar um novo  IBaseService
        }

        public Task<int> Save(ServiceDTO dto) {
            if (dto.id > 0) {
                return _repository.Update(dto.mapToEntity());
            }
            else {
                return _repository.Save(dto.mapToEntity());
            }
        }
    }
}
