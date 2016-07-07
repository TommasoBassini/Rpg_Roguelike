using UnityEngine;
using System.Collections;

public class Tank : Player
{
    public override void TakeStats()
    {
        PlayerStatsControl playerstats = FindObjectOfType<PlayerStatsControl>();

        stats.hpMax = playerstats.statsTank.hpMax;
        stats.hp = playerstats.statsTank.hp;
        stats.mp = playerstats.statsTank.mp;

        stats.attMelee = playerstats.statsTank.attMelee;
        stats.attMagico = playerstats.statsTank.attMagico;
        stats.attDistanza = playerstats.statsTank.attDistanza;

        stats.difFisica = playerstats.statsTank.difFisica;
        stats.difMagica = playerstats.statsTank.difMagica;

        stats.evasione = playerstats.statsTank.evasione;
        stats.precisione = playerstats.statsTank.precisione;
        stats.velocita = playerstats.statsTank.precisione;
    }
}
