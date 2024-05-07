using Ammatraks_OY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ammatraks_OY.ViewModel
{
    public class ClientManager
    {
        private List<Client> clients;

        public ClientManager()
        {
            clients = new List<Client>();
        }

        public void AddClient(Client client)
        {
            clients.Add(client);
        }
    }
}
