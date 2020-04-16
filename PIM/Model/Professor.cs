using PIM.Services;
using System.Collections.Generic;

namespace PIM.Model
{
    public class Professor
    {
        public string Nome { get; set; }
        public long CPF { get; set; }
        public string Matéria { get; set; }

        public List<Aluguel> AlugueisEmAberto { get; set; }
    }
}