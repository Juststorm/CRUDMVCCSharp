using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrudRefeito
{
    public class Aluno
    {
        public string Código { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Mail { get; set; }

        public Aluno()      //Construtor
        {
            Código = Guid.NewGuid().ToString().Substring(9, 4).ToUpper();       //Usando GUID
        }

        public void LêDados(bool MostraCódigo = true)
        {
            if (MostraCódigo)
                Console.WriteLine("Código........: {0}", Código);

            Console.Write("Nome do Aluno: ");
            Nome = Console.ReadLine();

            Console.Write("Telefone.....: ");
            Telefone = Console.ReadLine();

            Console.Write("E-mail.......: ");
            Mail = Console.ReadLine();
        }

        public void MostraDados()
        {
            Console.WriteLine("Nome do Aluno: {0} ({1})", Nome, Código);

            Console.WriteLine("Telefone.....: {0}", Telefone);
            Console.WriteLine("E-mail.......: {0}\n", Mail);
        }

    }
}
