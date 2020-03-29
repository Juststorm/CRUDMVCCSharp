using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace MVCCrudRefeito
{
    class Operacoes
    {
        public void Inserir(Aluno MeuAluno, Dados MeusDados)
        {
            MeuAluno.LêDados();

            MeusDados.InserirAluno(MeuAluno);
        }

        public void Listar(Dados MeusDados)
        {
            ArrayList Lista;

            Lista = MeusDados.ListarAlunos();

            foreach (Aluno x in Lista)
            {
                x.MostraDados();
            }

            Console.ReadKey();
        }

        public void Pesquisar(string CodPesq, Aluno MeuAluno, Dados MeusDados)
        {
            MeuAluno = MeusDados.PesquisarAluno(CodPesq);

            if (MeuAluno != null)
            {
                MeuAluno.MostraDados();
            }
            else
            {
                Console.Write("\nAluno não foi encontrado no Cadastro de Alunos!");
            }

            Console.ReadKey();

        }

        public void Alterar(string CodPesq, Aluno MeuAluno, Aluno MeuAlunoAlterado, Dados MeusDados)
        {
            MeuAluno = MeusDados.PesquisarAluno(CodPesq);

            if (MeuAluno != null)
            {
                MeuAluno.MostraDados();

                Console.WriteLine("Dados de Atualização:\n");

                MeuAlunoAlterado.LêDados(false);

                MeusDados.AlterarAluno(MeuAluno, MeuAlunoAlterado);

                Console.Write("\nDados atualizados com sucesso!");
                Console.ReadKey();
            }
            else
            {
                Console.Write("\nAluno não encontrado no Cadastro de Alunos!");
                Console.ReadKey();
            }
        }

        public void Excluir(string CodPesq, Aluno MeuAluno, Dados MeusDados)
        {
            MeuAluno = MeusDados.PesquisarAluno(CodPesq);

            if (MeuAluno != null)
            {
                MeuAluno.MostraDados();

                MeusDados.ExcluirAluno(MeuAluno);

                Console.Write("Aluno excluído!");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Aluno não encontrado no Cadastro de Alunos!");
                Console.ReadKey();
            }
        }

        public void Ordenar(Dados MeusDados)
        {
            int Registros;

            Registros = MeusDados.OrdenarAlunos();

            Console.Write("Total de Registros: {0}", Registros);

            Console.ReadKey();
        }

        public void SalvarXML(Dados MeusDados)
        {
            int TotReg;

            TotReg = MeusDados.SalvarArquivo();

            Console.WriteLine("Arquivo XML gerado com sucesso!");
            Console.WriteLine("Total de Registros: {0}", TotReg);

            Console.ReadKey();
        }

        public void LerXML(Dados MeusDados)
        {
            int TotReg;

            TotReg = MeusDados.LerArquivo();

            Console.WriteLine("Arquivo XML carregado com sucesso!");
            Console.WriteLine("Total de Registros: {0}", TotReg);

            Console.ReadKey();
        }
    }
}
