using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDeIntegracao
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Por favor informe o nome da Conta");
            var nomeconta = Console.ReadLine();

            Console.WriteLine("Por favor informe o Numero do local");
            var numero = Console.ReadLine();
            int numeroint = Int32.Parse(numero);

            Console.WriteLine("Por favor informe o Total de Produtos");
            var produtos = Console.ReadLine();
            int produtosint = Int32.Parse(produtos);

            Console.WriteLine("Por favor informe o porte da empresa");
            Console.WriteLine("Pequena digite:0");
            Console.WriteLine("Media digite:1");
            Console.WriteLine("Grande digite:2");
            var port = Console.ReadLine();

            int porte = 0;

            switch (port)
                {
                case "0":
                    porte = 868430000;
                break;
                case "1":
                    porte = 868430001;
                break;
                case "2":
                    porte = 868430002;
                break;
            }


            Console.WriteLine("Você deseja criar um contato para essa conta? (S/N)");
            var resposta = Console.ReadLine();


            IOrganizationService service = ConnectionFactory.GetService();

            if (resposta == "S")
            {
                Console.WriteLine("Por favor informe o Primeiro Nome da Conta");
                var pnome = Console.ReadLine();

                Console.WriteLine("Por favor informe o Sobrenome da Conta");
                var sobrenome = Console.ReadLine();

                Console.WriteLine("Por favor informe o Cargo");
                var cargo = Console.ReadLine();


                Entity contato = new Entity("contact");
                contato["firstname"] = pnome;
                contato["lastname"] = sobrenome;
                contato["jobtitle"] = cargo;

                Guid contactId = service.Create(contato);


                Entity conta = new Entity("account");
                conta["name"] = nomeconta;
                conta["myw_portedaempresa"] = new OptionSetValue(porte);
                conta["myw_numerodolocal"] = numeroint;
                conta["myw_totaldeprodutos"] = new decimal(produtosint);
                conta["primarycontactid"] = new EntityReference("contact", contactId);

                service.Create(conta);
            }
            else
            {
                Entity conta = new Entity("account");
                conta["name"] = nomeconta;
                conta["myw_portedaempresa"] = new OptionSetValue(porte);
                conta["myw_numerodolocal"] = numeroint;
                conta["myw_totaldeprodutos"] = new decimal(produtosint);

                service.Create(conta);

            }

        }
    }
}
