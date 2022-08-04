using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWork1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOrganizationService service = ConnectionFactory.GetService();

            Entity conta = new Entity("account");
            conta["name"] = "Nova Conta - Campos personalizados";
            conta["telephone1"] = "(22)99928-6332";
            conta["fax"] = "13516848864";
            conta["websiteurl"] = "dynacoop.com.br";

            conta["dyp_portedaempresa"] = new OptionSetValue(781870000);
            conta["dyp_totaldeoportunidades"] = new Money(150);
            conta["dyp_totaldeprodutos"] = new decimal(100.56);

            Guid accontId = service.Create(conta);

            //Entity contato = new Entity("contact");
            //contato["firstname"] = "Gabriel";
            //contato["lastname"] = "Dos Santos";
            //contato["jobtitle"] = "Desenvolvedor Junior";
            //contato["parentcustomerid"] = new EntityReference("account", accontId);
            //service.Create(contato);

        }
    }
}
