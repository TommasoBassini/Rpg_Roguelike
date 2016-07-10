using UnityEngine;
using System.Collections;

public class Mage : Player
{
    void Prova()
    {
        UiController ui = FindObjectOfType<UiController>();
    }

    public override void TakeStats()
    {
        PlayerStatsControl playerstats = FindObjectOfType<PlayerStatsControl>();

        this.stats.hpMax = playerstats.statsMago.hpMax;
        this.stats.hp = playerstats.statsMago.hp;
        this.stats.mpMax = playerstats.statsMago.mpMax;
        this.stats.mp = playerstats.statsMago.mp;

        this.stats.attMelee = playerstats.statsMago.attMelee;
        this.stats.attMagico = playerstats.statsMago.attMagico;
        this.stats.attDistanza = playerstats.statsMago.attDistanza;

        this.stats.difFisica = playerstats.statsMago.difFisica;
        this.stats.difMagica = playerstats.statsMago.difMagica;

        this.stats.evasione = playerstats.statsMago.evasione;
        this.stats.precisione = playerstats.statsMago.precisione;
        this.stats.velocita = playerstats.statsMago.precisione;
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
