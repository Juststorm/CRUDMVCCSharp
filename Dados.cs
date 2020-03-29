using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MVCCrudRefeito
{
    class Dados
    {
        private ArrayList Cadastro;

        public Dados()
        {
            Cadastro = new ArrayList();
        }

        public void InserirAluno(Aluno x)
        {
            Cadastro.Add(x);
        }

        public ArrayList ListarAlunos()
        {
            return Cadastro;
        }

        public int OrdenarAlunos()
        {
            Cadastro.Sort(new MinhaOrdenacao());

            return Cadastro.Count;
        }

        public Aluno PesquisarAluno(string Cod)
        {
            foreach (Aluno x in Cadastro)
            {
                if (x.Código.ToUpper() == Cod.ToUpper())
                {
                    return x;
                }
            }

            return null;
        }

        public void AlterarAluno(Aluno x, Aluno y)
        {
            int Posicao;

            Posicao = Cadastro.IndexOf(x);

            y.Código = x.Código;

            Cadastro.Remove(x);
            Cadastro.Insert(Posicao, y);
        }

        public void ExcluirAluno(Aluno x)
        {
            Cadastro.Remove(x);
        }

        public class MinhaOrdenacao : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                return ((Aluno)x).Nome.CompareTo(((Aluno)y).Nome);
            }
        }

        public int SalvarArquivo()
        {
            TextWriter MeuWriter = new StreamWriter(@"C:\Users\lucas\OneDrive\source\repos\MVCCrudRefeito\gravacacoesxml\CadastroAlunos.xml");

            Aluno[] ListaAlunoVetor = (Aluno[])Cadastro.ToArray(typeof(Aluno));

            //Serialização
            XmlSerializer Serialização = new XmlSerializer(ListaAlunoVetor.GetType());

            //Serializa usando o TextWriter
            Serialização.Serialize(MeuWriter, ListaAlunoVetor);

            MeuWriter.Close();

            return Cadastro.Count;
        }

        public int LerArquivo()
        {
            int Reg;

            FileStream Arquivo = new FileStream(@"C:\Users\lucas\OneDrive\source\repos\MVCCrudRefeito\gravacacoesxml\CadastroAlunos.xml", FileMode.Open);

            Aluno[] ListaAlunoVetor = (Aluno[])Cadastro.ToArray(typeof(Aluno));

            XmlSerializer Serialização = new XmlSerializer(ListaAlunoVetor.GetType());

            ListaAlunoVetor = (Aluno[])Serialização.Deserialize(Arquivo);

            Cadastro.Clear();
            Cadastro.AddRange(ListaAlunoVetor);

            Reg = Cadastro.Count;

            Arquivo.Close();

            return Reg;
        }

    }
}
