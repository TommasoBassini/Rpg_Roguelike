using UnityEngine;
using System.Collections;

public class Tank : Player
{
    public override void TakeStats()
    {
        PlayerStatsControl playerstats = FindObjectOfType<PlayerStatsControl>();

        this.stats.hpMax = playerstats.statsTank.hpMax;
        this.stats.hp = playerstats.statsTank.hp;
        this.stats.mpMax = playerstats.statsTank.mpMax;
        this.stats.mp = playerstats.statsTank.mp;

        this.stats.attMelee = playerstats.statsTank.attMelee;
        this.stats.attMagico = playerstats.statsTank.attMagico;
        this.stats.attDistanza = playerstats.statsTank.attDistanza;

        this.stats.difFisica = playerstats.statsTank.difFisica;
        this.stats.difMagica = playerstats.statsTank.difMagica;

        this.stats.evasione = playerstats.statsTank.evasione;
        this.stats.precisione = playerstats.statsTank.precisione;
        this.stats.velocita = playerstats.statsTank.precisione;
        UiController ui = FindObjectOfType<UiController>();
        ui.SetUiPlayer(this.gameObject);
    }

    public override void SubisciDanno(float danni)
    {
        stats.hp = stats.hp - Mathf.RoundToInt(((((danni/stats.difFisica)*100) * (danni /2))/ 100) + (Random.Range(1,1.125f)));
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaVita(stats.hpMax, stats.hp, uiInfo);
    }
}
