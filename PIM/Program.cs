using PIM.Model;
using PIM.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PIM
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Sistema de administração de aluguel");
            Console.WriteLine("Favor realizar o login");
            Console.WriteLine("Usuário:");
            string user = Console.ReadLine();
            Console.WriteLine("Senha:");
            string password = Console.ReadLine();

            if (AluguelManager.Login(user, password))
            {
                int opcao = 0;
                while (opcao != 6)
                {
                    Console.WriteLine("Menu - 1-Novo Aluguel 2- Devolver Equipamento 3-Professores com atraso de aluguel\n 4- Cadastrar Professor 5- Verificar Estoque 6- Sair");
                    opcao = int.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            bool sucesso = false;

                            Console.WriteLine("Insira CPF do professor sem pontuação:");
                            long cpf = long.Parse(Console.ReadLine());

                            Professor professor = BaseDeDados.Professores.FirstOrDefault(prof => prof.CPF == cpf);

                            if (professor != null)
                            {
                                Console.WriteLine("Quantidade de items que vai alugar:");
                                int qntd = int.Parse(Console.ReadLine());

                                for (int i = 0; i < qntd; i++)
                                    sucesso = AluguelManager.Alugar(professor);

                                if (!sucesso) Console.WriteLine("Falha ao alugar por falta de estoque");
                                else Console.WriteLine("Alugado com sucesso");
                            }
                            else
                            {
                                Console.WriteLine("Professor não cadastrado, favor realizar novo cadastro.");
                            }
                            break;

                        case 2:
                            bool sucessoDevolucao = false;

                            Console.WriteLine("Insira CPF do professor sem pontuação:");
                            long cpfDevolucao = long.Parse(Console.ReadLine());

                            Professor professorDevolvendo = BaseDeDados.Professores.FirstOrDefault(prof => prof.CPF == cpfDevolucao);

                            if (professorDevolvendo != null)
                            {
                                Console.WriteLine("Quantidade de items que vai devolver:");
                                int qntd = int.Parse(Console.ReadLine());

                                for (int i = 0; i < qntd; i++)
                                    sucessoDevolucao = AluguelManager.Devolver(professorDevolvendo);

                                if (!sucessoDevolucao) Console.WriteLine("Falha ao devolver");
                                else Console.WriteLine("Devolvido com sucesso");
                            }
                            else
                            {
                                Console.WriteLine("Professor não cadastrado, favor realizar novo cadastro.");
                            }
                            break;

                        case 3:
                            var Professores = BaseDeDados.Professores;
                            foreach (var profe in Professores)
                            {
                                if (profe.AlugueisEmAberto.Any(x => x.EstaAtrasado()))
                                {
                                    Console.WriteLine(profe.Nome + " contem aluguel em atraso.");
                                    var atrasos = profe.AlugueisEmAberto.Where(x => x.EstaAtrasado() == true).ToList();
                                    foreach (var item in atrasos)
                                    {
                                        Console.WriteLine(item.Equipamento.GetType().ToString().Split('.')[2]);
                                    }
                                }
                            }
                            break;

                        case 4:
                            Professor prof = new Professor();
                            Console.WriteLine("Insira o nome :");
                            prof.Nome = Console.ReadLine();
                            Console.WriteLine("Insira o CPF :");
                            prof.CPF = long.Parse(Console.ReadLine());
                            Console.WriteLine("Insira a Matéria:");
                            prof.Matéria = Console.ReadLine();
                            prof.AlugueisEmAberto = new List<Aluguel>();
                            BaseDeDados.Professores.Add(prof);
                            Console.WriteLine("Lista Professores:");
                            foreach (var p in BaseDeDados.Professores)
                            {
                                Console.WriteLine("Nome:" + p.Nome + " CPF:" + p.CPF + " Matéria:" + p.Matéria);
                            }
                            break;

                        case 5:
                            Console.WriteLine("Disponivel:");
                            Console.WriteLine("Notebooks :" + BaseDeDados.EstoqueNotebook());
                            Console.WriteLine("DataShows :" + BaseDeDados.EstoqueDataShow());
                            Console.WriteLine("Tv com DVD :" + BaseDeDados.EstoqueTvComDVD());
                            Console.WriteLine("Tv com VCR :" + BaseDeDados.EstoqueTvComVCR());
                            Console.WriteLine("Sistema Audio :" + BaseDeDados.EstoqueSistemaDeAudio());
                            Console.WriteLine("Estoque Original:");
                            Console.WriteLine("Notebook:" + BaseDeDados.EstoqueEquipamentos.OfType<Notebook>().Count().ToString());
                            Console.WriteLine("DataShows:" + BaseDeDados.EstoqueEquipamentos.OfType<DataShow>().Count().ToString());
                            Console.WriteLine("Tv com DVD:" + BaseDeDados.EstoqueEquipamentos.OfType<TvComDVD>().Count().ToString());
                            Console.WriteLine("Tv com VCR:" + BaseDeDados.EstoqueEquipamentos.OfType<TvComVCR>().Count().ToString());
                            Console.WriteLine("Sistema Audio:" + BaseDeDados.EstoqueEquipamentos.OfType<SistemaDeAudio>().Count().ToString());

                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Usuario ou senha inválidos.");
            }
        }
    }
}