﻿using System;

namespace guisfits.HealthTrack.Models
{
    public enum TipoAlimento { CafeDaManha, Almoco, Jantar, Lanche, Fruta }

    public class Alimento
    {
        public TipoAlimento Tipo { get; set; }
        public string Descricao { get; set; }
        public double Calorias { get; set; }
        public DateTime DataHora { get; set; }

        public Alimento(TipoAlimento tipo, string descricao, double calorias, DateTime dataHora)
        {
            this.Tipo = tipo;
            this.Descricao = descricao;
            this.Calorias = calorias;
            this.DataHora = dataHora;
        }
    }
}