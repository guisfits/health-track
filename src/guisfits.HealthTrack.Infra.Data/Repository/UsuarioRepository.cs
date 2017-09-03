﻿using guisfits.HealthTrack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Infra.Data.Context;

namespace guisfits.HealthTrack.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(HealthTrackContext context) : base(context) { }

        public override Usuario ObterPorId(Guid id)
        {
            var sql = @"SELECT * FROM Usuarios u " +
                    "JOIN Pesos p ON u.Id = p.UsuarioId " +
                    "JOIN PressoesArteriais pr ON u.Id = pr.UsuarioId " +
                    "WHERE u.Id = @uid " +
                    "ORDER BY p.DataHora DESC";

            return Db.Database.Connection.Query<Usuario, Peso, PressaoArterial, Usuario>(sql,
                (u, p, pr) =>
                {
                    u.Pesos.Add(p);
                    u.PressoesArteriais.Add(pr);
                    return u;
                }, new { uid = id }).FirstOrDefault();
        }

        public override IEnumerable<Usuario> ObterTodos()
        {
            var sql = @"SELECT * FROM Usuarios u " +
                        "LEFT JOIN Pesos p " +
                        "ON p.UsuarioId = u.Id " +
                        "WHERE u.Excluido = 0";

            return Db.Database.Connection.Query<Usuario, Peso, Usuario>(sql, 
                (u, p) => 
                {
                    u.Pesos.Add(p);
                    return u;
                });
        }

        public override void Remover(Guid id)
        {
            Usuario obj = ObterPorId(id);
            obj.Excluir();

            Atualizar(obj);
        }

        public Guid ObterIdPeloIdentity(string idIdentity)
        {
            var sql = "SELECT * FROM Usuarios u " +
                      "WHERE u.IdentityId = @uid";

            var user = Db.Database.Connection.Query<Usuario>(sql, new {uid = idIdentity}).FirstOrDefault();
            return user.Id;
        }
    }
}
