using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardNexus
{
    public class CardNexusClient
    {
        public object Client { get; private set; }
        private string NotImplementedMessage = "This method is not supported for the selected game.";

        public CardNexusClient(string game)
        {
            if (game == "tcg")
            {
                Client = new Games.TcgClient();
            }
            else if (game == "pokemon")
            {
                Client = new Games.PokemonClient();
            }
            else
            {
                throw new ArgumentException("Unsupported game type.");
            }
        }

        public async Task<object> FetchAllTcg()
        {
            if (Client is Games.TcgClient tcgClient && tcgClient.GetType().GetMethod("GetAllTcg") != null)
            {
                return await tcgClient.GetAllTcg();
            }
            else
            {
                throw new NotImplementedException(NotImplementedMessage);
            }
        }

        public async Task<object> FetchTcgByIdentifier(string identifier)
        {
            if (Client is Games.TcgClient tcgClient && tcgClient.GetType().GetMethod("GetTcgByIdentifier") != null)
            {
                return await tcgClient.GetTcgByIdentifier(identifier);
            }
            else
            {
                throw new NotImplementedException(NotImplementedMessage);
            }
        }

        public async Task<object> FetchAllEras()
        {
            if (Client is Games.PokemonClient pokemonClient && pokemonClient.GetType().GetMethod("GetAllEras") != null)
            {
                return await pokemonClient.GetAllEras();
            }
            else
            {
                throw new NotImplementedException(NotImplementedMessage);
            }
        }

        public async Task<object> FetchEraByIdentifier(string identifier)
        {
            if (Client is Games.PokemonClient pokemonClient && pokemonClient.GetType().GetMethod("GetEraByIdentifier") != null)
            {
                return await pokemonClient.GetEraByIdentifier(identifier);
            }
            else
            {
                throw new NotImplementedException(NotImplementedMessage);
            }
        }

        public async Task<object> FetchSets()
        {
            if (Client is Games.PokemonClient pokemonClient && pokemonClient.GetType().GetMethod("GetAllSets") != null)
            {
                return await pokemonClient.GetAllSets();
            }
            else
            {
                throw new NotImplementedException(NotImplementedMessage);
            }
        }

        public async Task<object> FetchSetByIdentifier(string identifier)
        {
            if (Client is Games.PokemonClient pokemonClient && pokemonClient.GetType().GetMethod("GetSetByIdentifier") != null)
            {
                return await pokemonClient.GetSetByIdentifier(identifier);
            }
            else
            {
                throw new NotImplementedException(NotImplementedMessage);
            }
        }

        public async Task<object> FetchAllCards(int limit = 20, int offset = 0, Dictionary<string, string> filters = null)
        {
            if (Client is Games.PokemonClient pokemonClient && pokemonClient.GetType().GetMethod("GetAllCards") != null)
            {
                return await pokemonClient.GetAllCards(limit, offset, filters);
            }
            else
            {
                throw new NotImplementedException(NotImplementedMessage);
            }
        }

        public async Task<object> FetchCardByIdentifier(string identifier)
        {
            if (Client is Games.PokemonClient pokemonClient && pokemonClient.GetType().GetMethod("GetCardByIdentifier") != null)
            {
                return await pokemonClient.GetCardByIdentifier(identifier);
            }
            else
            {
                throw new NotImplementedException(NotImplementedMessage);
            }
        }
    }
}
