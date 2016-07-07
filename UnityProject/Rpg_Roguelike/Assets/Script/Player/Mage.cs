using UnityEngine;
using System.Collections;

public class Mage : Player
{

    new void Start()
    {
        Invoke("Prova", 3);
        
    }
    void Prova()
    {
        UiController ui = FindObjectOfType<UiController>();
       StartCoroutine (ui.AggiornaVita(35, 15, uiInfo));
    }
    public override void TakeStats()
    {
        PlayerStatsControl playerstats = FindObjectOfType<PlayerStatsControl>();

        stats.hpMax = playerstats.statsMago.hpMax;
        stats.hp = playerstats.statsMago.hp;
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
}
