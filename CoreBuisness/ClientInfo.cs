using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBuisness
{
    public class ClientInfo
    {
        public Guid ClientId { get; }

        public ClientInfo()
        {
            ClientId = Guid.NewGuid();
        }
    }

}
