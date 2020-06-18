namespace Kolokwium2.Model
{
    public class ChampionshipTeam
    {
        public int IdTeam { get; set; }
        public int IdChampionship { get; set; }
        public float Score { get; set; }

        public Team Team { get; set; }
        public Championship Championship { get; set; }
        
    }
}