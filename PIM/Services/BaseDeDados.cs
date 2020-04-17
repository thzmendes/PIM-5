using PIM.Model;
using System.Collections.Generic;
using System.Linq;

namespace PIM.Services
{
    public static class BaseDeDados
    {
        public static List<Administrador> Admins = new List<Administrador>()
        {
            new Administrador(){Nome = "Thomas",Usuario = "tmendes",Senha="senha123"}
        };
        public static List<Professor> Professores = new List<Professor>()
        {
            new Professor(){CPF= 00000000000, AlugueisEmAberto = new List<Aluguel>(){ new Aluguel() {DataRetirada= new System.DateTime(1999,1,02) ,Equipamento = new Notebook()} } ,Matéria= "Matematica",Nome = "Rogério"},
            new Professor(){CPF= 11111111111, AlugueisEmAberto = new List<Aluguel>() ,Matéria= "Português",Nome = "Rosana"}
        };

        public static Professor BuscarCadastro(int cpf)
        {
            return Professores.FirstOrDefault(prof => prof.CPF == cpf);
        }

        public static List<Equipamento> EstoqueEquipamentos = new List<Equipamento>()
        {
             new Notebook(){Alugado = false },
             new Notebook(){Alugado = false },
             new Notebook(){Alugado = false },
             new Notebook(){Alugado = false },
             new TvComDVD(){Alugado = false },
             new TvComDVD(){Alugado = false },
             new TvComDVD(){Alugado = false },
             new TvComVCR(){Alugado = false },
             new TvComVCR(){Alugado = false },
             new TvComVCR(){Alugado = false },
             new DataShow(){Alugado = false },
             new DataShow(){Alugado = false },
             new DataShow(){Alugado = false },
             new SistemaDeAudio(){Alugado = false },
             new SistemaDeAudio(){Alugado = false }
        };

        public static int EstoqueNotebook()
        {
            return EstoqueEquipamentos.OfType<Notebook>().Where(x => x.Alugado == false).Count();
        }

        public static int EstoqueTvComDVD()
        {
            return EstoqueEquipamentos.OfType<TvComDVD>().Where(x => x.Alugado == false).Count();
        }

        public static int EstoqueTvComVCR()
        {
            return EstoqueEquipamentos.OfType<TvComVCR>().Where(x => x.Alugado == false).Count();
        }

        public static int EstoqueDataShow()
        {
            return EstoqueEquipamentos.OfType<DataShow>().Where(x => x.Alugado == false).Count();
        }

        public static int EstoqueSistemaDeAudio()
        {
            return EstoqueEquipamentos.OfType<SistemaDeAudio>().Where(x => x.Alugado == false).Count();
        }
        public static int TotalEquipamentos()
        {
            return EstoqueEquipamentos.Where(x => x.Alugado == false).Count();
        }
    }
}