using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsLvlUp : MonoBehaviour
{

    public void ForzaUp()
    {
        UiControlExploration ui = FindObjectOfType<UiControlExploration>();
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        Text costo = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Costo").GetComponent<Text>();
        Text statistica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/Titolo/Text").GetComponent<Text>();
        statistica.text = "Forza";

        Text hpMax = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/HpMax/Text").GetComponent<Text>();
        Text mpMax = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/MpMax/Text").GetComponent<Text>();
        Text attFisico = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/AttFisico/Text").GetComponent<Text>();
        Text attRanged = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/AttRanged/Text").GetComponent<Text>();
        Text attMagico = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/AttMagico/Text").GetComponent<Text>();
        Text difFisica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/DifFisica/Text").GetComponent<Text>();
        Text difMagica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/DifMagica/Text").GetComponent<Text>();
        Text velocita = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/Velocita/Text").GetComponent<Text>();

        switch (ui.nCharacter)
        {
            case 1:
                {
                    costo.text = stats.statsMago.costoForza.ToString();

                    hpMax.text = (stats.statsMago.hpMax + stats.incrementiMago.hpPerForza).ToString();
                    if (stats.statsMago.hpMax + stats.incrementiMago.hpPerForza == stats.statsMago.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = Color.green;

                    mpMax.text = (stats.statsMago.mpMax + stats.incrementiMago.mpPerForza).ToString();
                    if (stats.statsMago.mpMax + stats.incrementiMago.mpPerForza == stats.statsMago.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = Color.green;

                    attFisico.text = (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerForza).ToString();
                    if (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerForza == stats.statsMago.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = Color.green;

                    attRanged.text = (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerForza).ToString();
                    if (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerForza == stats.statsMago.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = Color.green;

                    attMagico.text = (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerForza).ToString();
                    if (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerForza == stats.statsMago.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = Color.green;

                    difFisica.text = (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerForza).ToString();
                    if (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerForza == stats.statsMago.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = Color.green;

                    difMagica.text = (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerForza).ToString();
                    if (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerForza == stats.statsMago.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = Color.green;

                    velocita.text = (stats.statsMago.velocita + stats.incrementiMago.velocitaPerForza).ToString();
                    if (stats.statsMago.velocita + stats.incrementiMago.velocitaPerForza == stats.statsMago.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = Color.green;

                    break;
                }
            case 2:
                {
                    costo.text = stats.statsTank.costoForza.ToString();

                    hpMax.text = (stats.statsTank.hpMax + stats.incrementiTank.hpPerForza).ToString();
                    if (stats.statsTank.hpMax + stats.incrementiTank.hpPerForza == stats.statsTank.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = Color.green;

                    mpMax.text = (stats.statsTank.mpMax + stats.incrementiTank.mpPerForza).ToString();
                    if (stats.statsTank.mpMax + stats.incrementiTank.mpPerForza == stats.statsTank.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = Color.green;

                    attFisico.text = (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerForza).ToString();
                    if (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerForza == stats.statsTank.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = Color.green;

                    attRanged.text = (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerForza).ToString();
                    if (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerForza == stats.statsTank.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = Color.green;

                    attMagico.text = (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerForza).ToString();
                    if (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerForza == stats.statsTank.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = Color.green;

                    difFisica.text = (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerForza).ToString();
                    if (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerForza == stats.statsTank.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = Color.green;

                    difMagica.text = (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerForza).ToString();
                    if (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerForza == stats.statsTank.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = Color.green;

                    velocita.text = (stats.statsTank.velocita + stats.incrementiTank.velocitaPerForza).ToString();
                    if (stats.statsTank.velocita + stats.incrementiTank.velocitaPerForza == stats.statsTank.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = Color.green;

                    break;
                }
            case 3:
                {
                    costo.text = stats.statsDps.costoForza.ToString();

                    hpMax.text = (stats.statsDps.hpMax + stats.incrementiDps.hpPerForza).ToString();
                    if (stats.statsDps.hpMax + stats.incrementiDps.hpPerForza == stats.statsDps.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = Color.green;

                    mpMax.text = (stats.statsDps.mpMax + stats.incrementiDps.mpPerForza).ToString();
                    if (stats.statsDps.mpMax + stats.incrementiDps.mpPerForza == stats.statsDps.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = Color.green;

                    attFisico.text = (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerForza).ToString();
                    if (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerForza == stats.statsDps.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = Color.green;

                    attRanged.text = (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerForza).ToString();
                    if (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerForza == stats.statsDps.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = Color.green;

                    attMagico.text = (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerForza).ToString();
                    if (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerForza == stats.statsDps.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = Color.green;

                    difFisica.text = (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerForza).ToString();
                    if (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerForza == stats.statsDps.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = Color.green;

                    difMagica.text = (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerForza).ToString();
                    if (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerForza == stats.statsDps.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = Color.green;

                    velocita.text = (stats.statsDps.velocita + stats.incrementiDps.velocitaPerForza).ToString();
                    if (stats.statsDps.velocita + stats.incrementiDps.velocitaPerForza == stats.statsDps.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = Color.green;

                    break;
                }
            default:
                break;
        }
    }

    public void DestrezzaUp()
    {
        UiControlExploration ui = FindObjectOfType<UiControlExploration>();
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        Text costo = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Costo").GetComponent<Text>();
        Text statistica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/Titolo/Text").GetComponent<Text>();
        statistica.text = "Destrezza";

        Text hpMax = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/HpMax/Text").GetComponent<Text>();
        Text mpMax = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/MpMax/Text").GetComponent<Text>();
        Text attFisico = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/AttFisico/Text").GetComponent<Text>();
        Text attRanged = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/AttRanged/Text").GetComponent<Text>();
        Text attMagico = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/AttMagico/Text").GetComponent<Text>();
        Text difFisica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/DifFisica/Text").GetComponent<Text>();
        Text difMagica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/DifMagica/Text").GetComponent<Text>();
        Text velocita = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/Velocita/Text").GetComponent<Text>();

        switch (ui.nCharacter)
        {
            case 1:
                {
                    costo.text = stats.statsMago.costoDestrezza.ToString();

                    hpMax.text = (stats.statsMago.hpMax + stats.incrementiMago.hpPerDestrezza).ToString();
                    if (stats.statsMago.hpMax + stats.incrementiMago.hpPerDestrezza == stats.statsMago.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = Color.green;

                    mpMax.text = (stats.statsMago.mpMax + stats.incrementiMago.mpPerDestrezza).ToString();
                    if (stats.statsMago.mpMax + stats.incrementiMago.mpPerDestrezza == stats.statsMago.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = Color.green;

                    attFisico.text = (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerDestrezza).ToString();
                    if (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerDestrezza == stats.statsMago.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = Color.green;

                    attRanged.text = (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerDestrezza).ToString();
                    if (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerDestrezza == stats.statsMago.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = Color.green;

                    attMagico.text = (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerDestrezza).ToString();
                    if (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerDestrezza == stats.statsMago.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = Color.green;

                    difFisica.text = (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerDestrezza).ToString();
                    if (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerDestrezza == stats.statsMago.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = Color.green;

                    difMagica.text = (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerDestrezza).ToString();
                    if (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerDestrezza == stats.statsMago.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = Color.green;

                    velocita.text = (stats.statsMago.velocita + stats.incrementiMago.velocitaPerDestrezza).ToString();
                    if (stats.statsMago.velocita + stats.incrementiMago.velocitaPerDestrezza == stats.statsMago.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = Color.green;

                    break;
                }
            case 2:
                {
                    costo.text = stats.statsTank.costoForza.ToString();

                    hpMax.text = (stats.statsTank.hpMax + stats.incrementiTank.hpPerDestrezza).ToString();
                    if (stats.statsTank.hpMax + stats.incrementiTank.hpPerDestrezza == stats.statsTank.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = Color.green;

                    mpMax.text = (stats.statsTank.mpMax + stats.incrementiTank.mpPerDestrezza).ToString();
                    if (stats.statsTank.mpMax + stats.incrementiTank.mpPerDestrezza == stats.statsTank.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = Color.green;

                    attFisico.text = (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerDestrezza).ToString();
                    if (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerDestrezza == stats.statsTank.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = Color.green;

                    attRanged.text = (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerDestrezza).ToString();
                    if (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerDestrezza == stats.statsTank.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = Color.green;

                    attMagico.text = (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerDestrezza).ToString();
                    if (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerDestrezza == stats.statsTank.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = Color.green;

                    difFisica.text = (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerDestrezza).ToString();
                    if (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerDestrezza == stats.statsTank.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = Color.green;

                    difMagica.text = (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerDestrezza).ToString();
                    if (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerDestrezza == stats.statsTank.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = Color.green;

                    velocita.text = (stats.statsTank.velocita + stats.incrementiTank.velocitaPerDestrezza).ToString();
                    if (stats.statsTank.velocita + stats.incrementiTank.velocitaPerDestrezza == stats.statsTank.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = Color.green;

                    break;
                }
            case 3:
                {
                    costo.text = stats.statsDps.costoForza.ToString();

                    hpMax.text = (stats.statsDps.hpMax + stats.incrementiDps.hpPerDestrezza).ToString();
                    if (stats.statsDps.hpMax + stats.incrementiDps.hpPerDestrezza == stats.statsDps.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = Color.green;

                    mpMax.text = (stats.statsDps.mpMax + stats.incrementiDps.mpPerDestrezza).ToString();
                    if (stats.statsDps.mpMax + stats.incrementiDps.mpPerDestrezza == stats.statsDps.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = Color.green;

                    attFisico.text = (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerDestrezza).ToString();
                    if (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerDestrezza == stats.statsDps.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = Color.green;

                    attRanged.text = (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerDestrezza).ToString();
                    if (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerDestrezza == stats.statsDps.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = Color.green;

                    attMagico.text = (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerDestrezza).ToString();
                    if (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerDestrezza == stats.statsDps.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = Color.green;

                    difFisica.text = (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerDestrezza).ToString();
                    if (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerDestrezza == stats.statsDps.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = Color.green;

                    difMagica.text = (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerDestrezza).ToString();
                    if (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerDestrezza == stats.statsDps.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = Color.green;

                    velocita.text = (stats.statsDps.velocita + stats.incrementiDps.velocitaPerDestrezza).ToString();
                    if (stats.statsDps.velocita + stats.incrementiDps.velocitaPerDestrezza == stats.statsDps.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = Color.green;

                    break;
                }
            default:
                break;
        }
    }

    public void SpiritoUp()
    {
        UiControlExploration ui = FindObjectOfType<UiControlExploration>();
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        Text costo = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Costo").GetComponent<Text>();
        Text statistica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/Titolo/Text").GetComponent<Text>();
        statistica.text = "Spirito";

        Text hpMax = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/HpMax/Text").GetComponent<Text>();
        Text mpMax = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/MpMax/Text").GetComponent<Text>();
        Text attFisico = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/AttFisico/Text").GetComponent<Text>();
        Text attRanged = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/AttRanged/Text").GetComponent<Text>();
        Text attMagico = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/AttMagico/Text").GetComponent<Text>();
        Text difFisica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/DifFisica/Text").GetComponent<Text>();
        Text difMagica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/DifMagica/Text").GetComponent<Text>();
        Text velocita = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/Velocita/Text").GetComponent<Text>();

        switch (ui.nCharacter)
        {
            case 1:
                {
                    costo.text = stats.statsMago.costoSpirito.ToString();

                    hpMax.text = (stats.statsMago.hpMax + stats.incrementiMago.hpPerSpirito).ToString();
                    if (stats.statsMago.hpMax + stats.incrementiMago.hpPerSpirito == stats.statsMago.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = Color.green;

                    mpMax.text = (stats.statsMago.mpMax + stats.incrementiMago.mpPerSpirito).ToString();
                    if (stats.statsMago.mpMax + stats.incrementiMago.mpPerSpirito == stats.statsMago.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = Color.green;

                    attFisico.text = (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerSpirito).ToString();
                    if (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerSpirito == stats.statsMago.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = Color.green;

                    attRanged.text = (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerForza).ToString();
                    if (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerForza == stats.statsMago.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = Color.green;

                    attMagico.text = (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerSpirito).ToString();
                    if (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerSpirito == stats.statsMago.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = Color.green;

                    difFisica.text = (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerSpirito).ToString();
                    if (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerSpirito == stats.statsMago.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = Color.green;

                    difMagica.text = (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerSpirito).ToString();
                    if (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerSpirito == stats.statsMago.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = Color.green;

                    velocita.text = (stats.statsMago.velocita + stats.incrementiMago.velocitaPerSpirito).ToString();
                    if (stats.statsMago.velocita + stats.incrementiMago.velocitaPerSpirito == stats.statsMago.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = Color.green;

                    break;
                }
            case 2:
                {
                    costo.text = stats.statsTank.costoForza.ToString();

                    hpMax.text = (stats.statsTank.hpMax + stats.incrementiTank.hpPerSpirito).ToString();
                    if (stats.statsTank.hpMax + stats.incrementiTank.hpPerSpirito == stats.statsTank.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = Color.green;

                    mpMax.text = (stats.statsTank.mpMax + stats.incrementiTank.mpPerSpirito).ToString();
                    if (stats.statsTank.mpMax + stats.incrementiTank.mpPerSpirito == stats.statsTank.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = Color.green;

                    attFisico.text = (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerSpirito).ToString();
                    if (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerSpirito == stats.statsTank.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = Color.green;

                    attRanged.text = (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerForza).ToString();
                    if (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerForza == stats.statsTank.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = Color.green;

                    attMagico.text = (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerSpirito).ToString();
                    if (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerSpirito == stats.statsTank.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = Color.green;

                    difFisica.text = (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerSpirito).ToString();
                    if (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerSpirito == stats.statsTank.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = Color.green;

                    difMagica.text = (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerSpirito).ToString();
                    if (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerSpirito == stats.statsTank.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = Color.green;

                    velocita.text = (stats.statsTank.velocita + stats.incrementiTank.velocitaPerSpirito).ToString();
                    if (stats.statsTank.velocita + stats.incrementiTank.velocitaPerSpirito == stats.statsTank.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = Color.green;

                    break;
                }
            case 3:
                {
                    costo.text = stats.statsDps.costoForza.ToString();

                    hpMax.text = (stats.statsDps.hpMax + stats.incrementiDps.hpPerSpirito).ToString();
                    if (stats.statsDps.hpMax + stats.incrementiDps.hpPerSpirito == stats.statsDps.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = Color.green;

                    mpMax.text = (stats.statsDps.mpMax + stats.incrementiDps.mpPerSpirito).ToString();
                    if (stats.statsDps.mpMax + stats.incrementiDps.mpPerSpirito == stats.statsDps.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = Color.green;

                    attFisico.text = (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerSpirito).ToString();
                    if (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerSpirito == stats.statsDps.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = Color.green;

                    attRanged.text = (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerForza).ToString();
                    if (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerForza == stats.statsDps.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = Color.green;

                    attMagico.text = (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerSpirito).ToString();
                    if (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerSpirito == stats.statsDps.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = Color.green;

                    difFisica.text = (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerSpirito).ToString();
                    if (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerSpirito == stats.statsDps.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = Color.green;

                    difMagica.text = (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerSpirito).ToString();
                    if (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerSpirito == stats.statsDps.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = Color.green;

                    velocita.text = (stats.statsDps.velocita + stats.incrementiDps.velocitaPerSpirito).ToString();
                    if (stats.statsDps.velocita + stats.incrementiDps.velocitaPerSpirito == stats.statsDps.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = Color.green;

                    break;
                }
            default:
                break;
        }
    }

    public void ClearStats()
    {
        UiControlExploration ui = FindObjectOfType<UiControlExploration>();
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        Text costo = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Costo").GetComponent<Text>();
        Text statistica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/Titolo/Text").GetComponent<Text>();

        Text hpMax = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/HpMax/Text").GetComponent<Text>();
        Text mpMax = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/MpMax/Text").GetComponent<Text>();
        Text attFisico = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/AttFisico/Text").GetComponent<Text>();
        Text attRanged = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/AttRanged/Text").GetComponent<Text>();
        Text attMagico = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/AttMagico/Text").GetComponent<Text>();
        Text difFisica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/DifFisica/Text").GetComponent<Text>();
        Text difMagica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/DifMagica/Text").GetComponent<Text>();
        Text velocita = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/Velocita/Text").GetComponent<Text>();

        switch (ui.nCharacter)
        {
            case 1:
                {
                    costo.text = "";

                    hpMax.text = (stats.statsMago.hpMax).ToString();
                    hpMax.color = Color.black;

                    mpMax.text = (stats.statsMago.mpMax).ToString();
                    mpMax.color = Color.black;

                    attFisico.text = (stats.statsMago.attMelee).ToString();
                    attFisico.color = Color.black;

                    attRanged.text = (stats.statsMago.attDistanza).ToString();
                    attRanged.color = Color.black;

                    attMagico.text = (stats.statsMago.attMagico).ToString();
                    attMagico.color = Color.black;

                    difFisica.text = (stats.statsMago.difFisica).ToString();
                    difFisica.color = Color.black;

                    difMagica.text = (stats.statsMago.difMagica).ToString();
                    difMagica.color = Color.black;

                    velocita.text = (stats.statsMago.velocita).ToString();
                    velocita.color = Color.black;

                    break;
                }
            case 2:
                {
                    costo.text = "";

                    hpMax.text = (stats.statsTank.hpMax).ToString();
                    hpMax.color = Color.black;

                    mpMax.text = (stats.statsTank.mpMax).ToString();
                    mpMax.color = Color.black;

                    attFisico.text = (stats.statsTank.attMelee).ToString();
                    attFisico.color = Color.black;

                    attRanged.text = (stats.statsTank.attDistanza).ToString();
                    attRanged.color = Color.black;

                    attMagico.text = (stats.statsTank.attMagico).ToString();
                    attMagico.color = Color.black;

                    difFisica.text = (stats.statsTank.difFisica).ToString();
                    difFisica.color = Color.black;

                    difMagica.text = (stats.statsTank.difMagica).ToString();
                    difMagica.color = Color.black;

                    velocita.text = (stats.statsTank.velocita).ToString();
                    velocita.color = Color.black;

                    break;
                }
            case 3:
                {
                    costo.text = "";

                    hpMax.text = (stats.statsDps.hpMax).ToString();
                    hpMax.color = Color.black;

                    mpMax.text = (stats.statsDps.mpMax).ToString();
                    mpMax.color = Color.black;

                    attFisico.text = (stats.statsDps.attMelee).ToString();
                    attFisico.color = Color.black;

                    attRanged.text = (stats.statsDps.attDistanza).ToString();
                    attRanged.color = Color.black;

                    attMagico.text = (stats.statsDps.attMagico).ToString();
                    attMagico.color = Color.black;

                    difFisica.text = (stats.statsDps.difFisica).ToString();
                    difFisica.color = Color.black;

                    difMagica.text = (stats.statsDps.difMagica).ToString();
                    difMagica.color = Color.black;

                    velocita.text = (stats.statsDps.velocita).ToString();
                    velocita.color = Color.black;

                    break;
                }
            default:
                break;
        }
    }
}
