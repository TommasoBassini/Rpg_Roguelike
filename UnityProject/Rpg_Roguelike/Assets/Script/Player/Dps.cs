﻿using UnityEngine;
using System.Collections;



public class Dps : Player
{
    public override void TakeStats()
    {
        PlayerStatsControl playerstats = FindObjectOfType<PlayerStatsControl>();

        stats.hpMax = playerstats.statsDps.hpMax;
        stats.hp = playerstats.statsDps.hp;
        stats.mp = playerstats.statsDps.mp;
        stats.mpMax = playerstats.statsDps.mpMax;

        stats.attMelee = playerstats.statsDps.attMelee;
        stats.attMagico = playerstats.statsDps.attMagico;
        stats.attDistanza = playerstats.statsDps.attDistanza;

        stats.difFisica = playerstats.statsDps.difFisica;
        stats.difMagica = playerstats.statsDps.difMagica;

        stats.evasione = playerstats.statsDps.evasione;
        stats.precisione = playerstats.statsDps.precisione;
        stats.velocita = playerstats.statsDps.precisione;
    }

    public override void SubisciDanno(int danni)
    {
        stats.hp = stats.hp - Mathf.RoundToInt(((((danni / stats.difFisica) * 100) * (danni / 2)) / 100) + (Random.Range(1, 1.125f)));
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaVita(stats.hpMax, stats.hp, uiInfo);
    }
}
