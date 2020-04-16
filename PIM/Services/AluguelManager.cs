using PIM.Model;
using System;
using System.Linq;

namespace PIM.Services
{
    public static class AluguelManager
    {
        public static bool Alugar(Professor professor)
        {
            Console.WriteLine("Qual item deseja alugar? 1-Notebook 2-TV com VCR 3-TV com DVD 4-DataShow 5-Sistema de Audio");
            int resposta = int.Parse(Console.ReadLine());
            switch (resposta)
            {
                case 1:
                    if (BaseDeDados.EstoqueNotebook() >= 1)
                    {
                        professor.AlugueisEmAberto.Add(new Aluguel()
                        {
                            DataRetirada = DateTime.Now,
                            Equipamento = BaseDeDados.EstoqueEquipamentos.OfType<Notebook>().First(x => x.Alugado == false)
                        });

                        Equipamento equip = BaseDeDados.EstoqueEquipamentos.OfType<Notebook>().First(x => x.Alugado == false);
                        equip.Alugado = true;

                        return true;
                    }
                    break;

                case 2:
                    if (BaseDeDados.EstoqueTvComVCR() >= 1)
                    {
                        professor.AlugueisEmAberto.Add(new Aluguel()
                        {
                            DataRetirada = DateTime.Now,
                            Equipamento = BaseDeDados.EstoqueEquipamentos.OfType<TvComVCR>().First(x => x.Alugado == false)
                        });
                        Equipamento equip = BaseDeDados.EstoqueEquipamentos.OfType<TvComVCR>().First(x => x.Alugado == false);
                        equip.Alugado = true;
                        return true;
                    }
                    break;

                case 3:
                    if (BaseDeDados.EstoqueTvComDVD() >= 1)
                    {
                        professor.AlugueisEmAberto.Add(new Aluguel()
                        {
                            DataRetirada = DateTime.Now,
                            Equipamento = BaseDeDados.EstoqueEquipamentos.OfType<TvComDVD>().First(x => x.Alugado == false)
                        });
                        Equipamento equip = BaseDeDados.EstoqueEquipamentos.OfType<TvComDVD>().First(x => x.Alugado == false);
                        equip.Alugado = true;
                        return true;
                    }
                    break;

                case 4:
                    if (BaseDeDados.EstoqueDataShow() >= 1)
                    {
                        professor.AlugueisEmAberto.Add(new Aluguel()
                        {
                            DataRetirada = DateTime.Now,
                            Equipamento = BaseDeDados.EstoqueEquipamentos.OfType<DataShow>().First(x => x.Alugado == false)
                        });
                        Equipamento equip = BaseDeDados.EstoqueEquipamentos.OfType<DataShow>().First(x => x.Alugado == false);
                        equip.Alugado = true;
                        return true;
                    }
                    break;

                case 5:
                    if (BaseDeDados.EstoqueSistemaDeAudio() >= 1)
                    {
                        professor.AlugueisEmAberto.Add(new Aluguel()
                        {
                            DataRetirada = DateTime.Now,
                            Equipamento = BaseDeDados.EstoqueEquipamentos.OfType<SistemaDeAudio>().First()
                        });
                        Equipamento equip = BaseDeDados.EstoqueEquipamentos.OfType<SistemaDeAudio>().First(x => x.Alugado == false);
                        equip.Alugado = true;
                        return true;
                    }
                    break;
            };
            return false;
        }

        public static bool Devolver(Professor professor)
        {
            Console.WriteLine("Qual item deseja devolver? 1-Notebook 2-TV com VCR 3-TV com DVD 4-DataShow 5-Sistema de Audio");
            int resposta = int.Parse(Console.ReadLine());
            switch (resposta)
            {
                case 1:
                    if (BaseDeDados.EstoqueEquipamentos.OfType<Notebook>().Count() - BaseDeDados.EstoqueNotebook() >= 1)
                    {
                        var aluguel = professor.AlugueisEmAberto.Where(x => x.Equipamento is Notebook).FirstOrDefault();

                        professor.AlugueisEmAberto.Remove(aluguel);

                        aluguel.Equipamento.Alugado = false;

                        return true;
                    }
                    break;

                case 2:
                    if (BaseDeDados.EstoqueEquipamentos.OfType<TvComVCR>().Count() - BaseDeDados.EstoqueTvComVCR() >= 1)
                    {
                        var aluguel = professor.AlugueisEmAberto.Where(x => x.Equipamento is TvComVCR).FirstOrDefault();

                        professor.AlugueisEmAberto.Remove(aluguel);

                        aluguel.Equipamento.Alugado = false;

                        return true;
                    }
                    break;

                case 3:
                    if (BaseDeDados.EstoqueEquipamentos.OfType<TvComDVD>().Count() - BaseDeDados.EstoqueTvComDVD() >= 1)
                    {
                        var aluguel = professor.AlugueisEmAberto.Where(x => x.Equipamento is TvComDVD).FirstOrDefault();

                        professor.AlugueisEmAberto.Remove(aluguel);

                        aluguel.Equipamento.Alugado = false;

                        return true;
                    }
                    break;

                case 4:
                    if (BaseDeDados.EstoqueEquipamentos.OfType<DataShow>().Count() - BaseDeDados.EstoqueDataShow() >= 1)
                    {
                        var aluguel = professor.AlugueisEmAberto.Where(x => x.Equipamento is DataShow).FirstOrDefault();

                        professor.AlugueisEmAberto.Remove(aluguel);

                        aluguel.Equipamento.Alugado = false;

                        return true;
                    }
                    break;

                case 5:
                    if (BaseDeDados.EstoqueEquipamentos.OfType<SistemaDeAudio>().Count() - BaseDeDados.EstoqueSistemaDeAudio() >= 1)
                    {
                        var aluguel = professor.AlugueisEmAberto.Where(x => x.Equipamento is SistemaDeAudio).FirstOrDefault();

                        professor.AlugueisEmAberto.Remove(aluguel);

                        aluguel.Equipamento.Alugado = false;

                        return true;
                    }
                    break;
            };
            return false;
        }
    }
}