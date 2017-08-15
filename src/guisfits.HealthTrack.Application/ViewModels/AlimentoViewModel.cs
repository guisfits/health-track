﻿using guisfits.HealthTrack.Domain.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace guisfits.HealthTrack.Application.ViewModels
{
    public class AlimentoViewModel : EntityViewModel
    {
        [Required(ErrorMessage = "O campo Tipo de Alimento é requerido")]
        [DisplayName("Tipo de Alimento")]
        public TipoAlimento Tipo { get; set; }

        [MaxLength(300, ErrorMessage = "O tamanho máximo de caracteres é {0}")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo de caracteres é {0}")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Calorias Ingeridas é requerido")]
        [DisplayName("Calorias Ingeridas")]
        public double Calorias { get; set; }

        [Required(ErrorMessage = "O campo Data e Hora é requerido")]
        [DisplayName("Data e Hora")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd H:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Data e Hora em formato inválido")]
        public DateTime DataHora { get; set; }

        [ScaffoldColumn(false)]
        public Guid UsuarioId { get; set; }
    }
}