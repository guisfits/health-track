﻿using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Services
{
    public class ExercicioFisicoService : EntityService<ExercicioFisico>, IExercicioFisicoService
    {
        private IExercicioFisicoRepository _repository;

        public ExercicioFisicoService(IExercicioFisicoRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<ExercicioFisico> ObterTodosPorUsuario(Guid id)
        {
            return _repository.ObterTodosPorUsuario(id);
        }
    }
}