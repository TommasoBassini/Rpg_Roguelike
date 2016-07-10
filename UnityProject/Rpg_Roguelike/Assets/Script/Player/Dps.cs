using UnityEngine;
using System.Collections;



public class Dps : Player
{
    public override void TakeStats()
    {
        PlayerStatsControl playerstats = FindObjectOfType<PlayerStatsControl>();

        this.stats.hpMax = playerstats.statsDps.hpMax;
        this.stats.hp = playerstats.statsDps.hp;
        this.stats.mp = playerstats.statsDps.mp;
        this.stats.mpMax = playerstats.statsDps.mpMax;

        this.stats.attMelee = playerstats.statsDps.attMelee;
        this.stats.attMagico = playerstats.statsDps.attMagico;
        this.stats.attDistanza = playerstats.statsDps.attDistanza;

        this.stats.difFisica = playerstats.statsDps.difFisica;
        this.stats.difMagica = playerstats.statsDps.difMagica;

        this.stats.evasione = playerstats.statsDps.evasione;
        this.stats.precisione = playerstats.statsDps.precisione;
        this.stats.velocita = playerstats.statsDps.precisione;

        UiController ui = FindObjectOfType<UiController>();
        ui.SetUiPlayer(this.gameObject);

    }

    public override void SubisciDanno(float danni)
    {
        stats.hp = stats.hp - Mathf.RoundToInt(((((danni / stats.difFisica) * 100) * (danni / 2)) / 100) + (Random.Range(1, 1.125f)));
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaVita(stats.hpMax, stats.hp, uiInfo);
    }
}
