using System;
using System.Collections.Generic;

namespace CardNexus
{
    public class CardNexusClient
    {
        public Dictionary<string, object> Clients { get; private set; }

        public CardNexusClient()
        {
            Clients = new Dictionary<string, object>
            {
                { "tcg", new Games.TcgClient() }
            };
        }

        public object GetClient(string tcg)
        {
            if (Clients.ContainsKey(tcg))
            {
                return Clients[tcg];
            }
            else
            {
                throw new ArgumentException($"TCG client '{tcg}' not found");
            }
        }

        public async Task<object> FetchAllTcg()
        {
            if (Clients.ContainsKey("tcg"))
            {
                var client = (Games.TcgClient)Clients["tcg"];
                return await client.GetAllTcg();
            }
            else
            {
                throw new NotImplementedException("The method 'GetAllTcg' is not implemented on the client.");
            }
        }

        public async Task<object> FetchTcgByIdentifier(string identifier)
        {
            if (Clients.ContainsKey("tcg"))
            {
                var client = (Games.TcgClient)Clients["tcg"];
                return await client.GetTcgByIdentifier(identifier);
            }
            else
            {
                throw new NotImplementedException("The method 'GetTcgByIdentifier' is not implemented on the client.");
            }
        }
    }
}
