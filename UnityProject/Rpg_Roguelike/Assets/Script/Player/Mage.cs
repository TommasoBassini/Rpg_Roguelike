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

        stats.hpMax = playerstats.statsMago.hpMax;
        stats.hp = playerstats.statsMago.hp;
        stats.mpMax = playerstats.statsMago.mpMax;
        stats.mp = playerstats.statsMago.mp;

        stats.attMelee = playerstats.statsMago.attMelee;
        stats.attMagico = playerstats.statsMago.attMagico;
        stats.attDistanza = playerstats.statsMago.attDistanza;

        stats.difFisica = playerstats.statsMago.difFisica;
        stats.difMagica = playerstats.statsMago.difMagica;

        stats.evasione = playerstats.statsMago.evasione;
        stats.precisione = playerstats.statsMago.precisione;
        stats.velocita = playerstats.statsMago.precisione;
    }

    public override void SubisciDanno(int danni)
    {
        stats.hp = stats.hp - Mathf.RoundToInt(((((danni / stats.difFisica) * 100) * (danni / 2)) / 100) + (Random.Range(1, 1.125f)));
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaVita(stats.hpMax, stats.hp, uiInfo);
    }
}
