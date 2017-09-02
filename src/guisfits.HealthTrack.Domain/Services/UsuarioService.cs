﻿using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Services
{
    public class UsuarioService : EntityService<Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository) 
            : base(repository)
        {
        }
    }
}
