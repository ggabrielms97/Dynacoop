using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWork1
{
    public class ConnectionFactory
    {
        public static IOrganizationService GetService()
        {
            string connectionString =
                "AuthType=OAuth;" +
                "Username=admin@gmdossantos.onmicrosoft.com;" +
                "Password=Ga91048235;" +
                "Url=https://orgda534cfb.crm2.dynamics.com/;" +
                "AppId=62d7bdc0-2144-4829-8e05-00b5fa638c13;" +
                "RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);

            return crmServiceClient.OrganizationWebProxyClient;
        }
    }
}
