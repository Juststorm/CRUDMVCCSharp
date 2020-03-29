using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MVCCrudRefeito
{
    class Menu
    {
        private string CodPesq;

        private Operacoes MinhaOperacao;
        private Dados MeusDados;

        public Menu(Operacoes O, Dados D)
        {
            MinhaOperacao = O;
            MeusDados = D;
        }

        public void MostraMenu()
        {
            int Opção;

            do
            {
                Console.Clear();

                Console.WriteLine("Sistema de Cadastro de Alunos");
                Console.WriteLine("=============================\n");

                Console.WriteLine("1 - Inserir");
                Console.WriteLine("2 - Alterar");
                Console.WriteLine("3 - Excluir");
                Console.WriteLine("4 - Pesquisar");
                Console.WriteLine("5 - Listar");
                Console.WriteLine("6 - Ordenar");
                Console.WriteLine("7 - Salvar Dados em Arquivo XML");
                Console.WriteLine("8 - Ler Dados de Arquivo XML");
                Console.WriteLine("9 - Sair");

                Console.Write("\nOpção: ");
                Opção = int.Parse(Console.ReadLine());

                switch (Opção)
                {
                    case 1:
                        do
                        {
                            Console.Clear();

                            Console.WriteLine("Cadastramento de Aluno");
                            Console.WriteLine("======================\n");

                            MinhaOperacao.Inserir(new Aluno(), MeusDados);

                            Console.WriteLine("\nInserir outro Registro? (ESC para Cancelar...)");

                        } while (Console.ReadKey().Key != ConsoleKey.Escape);

                        break;
                    case 2:
                        Console.Clear();

                        Console.WriteLine("Alteração de Dados de Aluno no Cadastro");
                        Console.WriteLine("=======================================\n");

                        Console.Write("Código..........: ");
                        CodPesq = Console.ReadLine();

                        MinhaOperacao.Alterar(CodPesq, new Aluno(), new Aluno(), MeusDados);

                        break;
                    case 3:
                        Console.Clear();

                        Console.WriteLine("Exclusão de Aluno no Cadastro");
                        Console.WriteLine("=============================\n");

                        Console.Write("Código..........: ");
                        CodPesq = Console.ReadLine();

                        MinhaOperacao.Excluir(CodPesq, new Aluno(), MeusDados);

                        break;
                    case 4:
                        Console.Clear();

                        Console.WriteLine("Pesquisa no Cadastro de Alunos");
                        Console.WriteLine("==============================\n");

                        Console.Write("Código........: ");
                        CodPesq = Console.ReadLine();

                        MinhaOperacao.Pesquisar(CodPesq, new Aluno(), MeusDados);

                        break;
                    case 5:
                        Console.Clear();

                        Console.WriteLine("Listagem Geral do Cadastro de Alunos");
                        Console.WriteLine("====================================\n");

                        MinhaOperacao.Listar(MeusDados);

                        break;
                    case 6:
                        Console.Clear();

                        Console.WriteLine("Ordenação de Registro do Cadastro de Alunos");
                        Console.WriteLine("===========================================\n");

                        MinhaOperacao.Ordenar(MeusDados);

                        break;
                    case 7:
                        Console.Clear();

                        Console.WriteLine("Salvar Cadastro em Arquivo XML");
                        Console.WriteLine("==============================\n");

                        MinhaOperacao.SalvarXML(MeusDados);

                        break;
                    case 8:
                        Console.Clear();

                        Console.WriteLine("Ler Arquivo XML");
                        Console.WriteLine("===============\n");

                        MinhaOperacao.LerXML(MeusDados);

                        break;
                    case 9:
                        Console.Write("\nSaída do Sistema...");
                        Thread.Sleep(1000);

                        break;
                    default:
                        Console.Write("\nOpção Inválida!!!");
                        Thread.Sleep(1000);

                        break;
                }

            } while (Opção != 9);
        }
    }
}
