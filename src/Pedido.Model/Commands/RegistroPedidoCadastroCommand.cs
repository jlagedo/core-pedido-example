﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Model.Commands
{
    public class RegistroPedidoCadastroCommand
    {
        public string Nome { get; set; }
        public int CPF { get; set; }
    }
}
