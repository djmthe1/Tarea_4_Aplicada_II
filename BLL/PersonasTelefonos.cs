﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class PersonasTelefonos
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string TipoTelefono { get; set; }
        public string Telefono { get; set; }

        public PersonasTelefonos(string tipoTelefono, string telefono)
        {
            this.TipoTelefono = tipoTelefono;
            this.Telefono = telefono;
        }

        public PersonasTelefonos()
        {

        }
    }
}
