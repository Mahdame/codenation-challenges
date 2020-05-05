namespace Codenation.Challenge
{
    public class State
    {
        public State(string name, string acronym, int areakm)
        {
            Name = name;
            Acronym = acronym;
            Area = areakm;

        }

        public string Name { get; set; }
        public string Acronym { get; set; }
        public int Area { get; set; }
    }

}
