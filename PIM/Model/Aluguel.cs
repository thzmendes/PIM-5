using PIM.Model;
using System;
using System.Collections.Generic;

namespace PIM.Services
{
    public class Aluguel
    {
        public Equipamento Equipamento { get; set; }
        public DateTime DataRetirada { get; set; }

        public bool EstaAtrasado()
        {
            bool result = false;

            if (DateTime.Now.Day - DataRetirada.Day > 5 && DateTime.Now.Month <= DateTime.Now.Month && DateTime.Now.Year <= DateTime.Now.Year)
            {
                result = true;
            }

            return result;
        }
    }
}