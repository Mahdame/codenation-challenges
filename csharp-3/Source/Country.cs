using System.Linq;

namespace Codenation.Challenge
{
    public class Country
    {
        public State[] Top10StatesByArea()
        {
            State[] states = new State[27]
            {
                new State("Amazonas", "AM", 1559159148),
                new State("Pará", "PA", 1247954666),
                new State("Mato Grosso", "MT", 903366192),
                new State("Minas Gerais", "MG", 586522122),
                new State("Bahia", "BA", 564733177),
                new State("Mato Grosso do Sul", "MS", 357145532),
                new State("Goiás", "GO", 340111783),
                new State("Maranhão", "MA", 331937450),
                new State("Rio Grande do Sul", "RS", 281730223),
                new State("Tocantins", "TO", 277720520),
                new State("Piauí", "PI", 251577738),
                new State("São Paulo", "SP", 248222362),
                new State("Rondônia", "RO", 237590547),
                new State("Roraima", "RR", 224300506),
                new State("Paraná", "PN", 199307922),
                new State("Acre", "AC", 164123040),
                new State("Ceará", "CE", 148920472),
                new State("Amapá", "AP", 142828521),
                new State("Pernambuco", "PE", 98311616),
                new State("Santa Catarina", "SC", 95736165),
                new State("Paraíba", "PB", 56585000),
                new State("Rio Grande do Norte", "RN", 52811047),
                new State("Espírito  Santo", "ES", 46095583),
                new State("Rio de Janeiro", "RJ", 43780172),
                new State("Alagoas", "AL", 2778506),
                new State("Sergipe", "SE", 21915116),
                new State("Distrito Federal", "DF", 5779999),
            };

            foreach (var areakm in states)
            {
                return states.OrderByDescending(i => i.Area).Take(10).ToArray();
            }

            return states;

        }

    }
}