using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsLvlUp : MonoBehaviour
{

    public void ForzaUp()
    {

        UiControlExploration ui = FindObjectOfType<UiControlExploration>();
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        ui.abilityBox.SetActive(false);
        ui.loaderBox.SetActive(true);
        Text costo = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Costo").GetComponent<Text>();
        Text statistica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/Titolo/Text").GetComponent<Text>();
        statistica.text = "Forza";

        Text help = ui.menuStats.transform.Find("Info").GetComponent<Text>();
        help.text = "Aumenta Statistica";

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
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsMago.mpMax + stats.incrementiMago.mpPerForza).ToString();
                    if (stats.statsMago.mpMax + stats.incrementiMago.mpPerForza == stats.statsMago.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerForza).ToString();
                    if (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerForza == stats.statsMago.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerForza).ToString();
                    if (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerForza == stats.statsMago.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerForza).ToString();
                    if (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerForza == stats.statsMago.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerForza).ToString();
                    if (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerForza == stats.statsMago.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerForza).ToString();
                    if (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerForza == stats.statsMago.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsMago.velocita + stats.incrementiMago.velocitaPerForza).ToString();
                    if (stats.statsMago.velocita + stats.incrementiMago.velocitaPerForza == stats.statsMago.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

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
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsTank.mpMax + stats.incrementiTank.mpPerForza).ToString();
                    if (stats.statsTank.mpMax + stats.incrementiTank.mpPerForza == stats.statsTank.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerForza).ToString();
                    if (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerForza == stats.statsTank.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerForza).ToString();
                    if (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerForza == stats.statsTank.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerForza).ToString();
                    if (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerForza == stats.statsTank.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerForza).ToString();
                    if (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerForza == stats.statsTank.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerForza).ToString();
                    if (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerForza == stats.statsTank.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsTank.velocita + stats.incrementiTank.velocitaPerForza).ToString();
                    if (stats.statsTank.velocita + stats.incrementiTank.velocitaPerForza == stats.statsTank.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

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
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsDps.mpMax + stats.incrementiDps.mpPerForza).ToString();
                    if (stats.statsDps.mpMax + stats.incrementiDps.mpPerForza == stats.statsDps.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerForza).ToString();
                    if (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerForza == stats.statsDps.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerForza).ToString();
                    if (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerForza == stats.statsDps.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerForza).ToString();
                    if (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerForza == stats.statsDps.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerForza).ToString();
                    if (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerForza == stats.statsDps.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerForza).ToString();
                    if (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerForza == stats.statsDps.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsDps.velocita + stats.incrementiDps.velocitaPerForza).ToString();
                    if (stats.statsDps.velocita + stats.incrementiDps.velocitaPerForza == stats.statsDps.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

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

        ui.abilityBox.SetActive(false);
        ui.loaderBox.SetActive(true);
        Text costo = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Costo").GetComponent<Text>();
        Text statistica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/Titolo/Text").GetComponent<Text>();
        statistica.text = "Destrezza";

        Text help = ui.menuStats.transform.Find("Info").GetComponent<Text>();
        help.text = "Aumenta Statistica";

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
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsMago.mpMax + stats.incrementiMago.mpPerDestrezza).ToString();
                    if (stats.statsMago.mpMax + stats.incrementiMago.mpPerDestrezza == stats.statsMago.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerDestrezza).ToString();
                    if (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerDestrezza == stats.statsMago.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerDestrezza).ToString();
                    if (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerDestrezza == stats.statsMago.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerDestrezza).ToString();
                    if (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerDestrezza == stats.statsMago.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerDestrezza).ToString();
                    if (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerDestrezza == stats.statsMago.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerDestrezza).ToString();
                    if (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerDestrezza == stats.statsMago.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsMago.velocita + stats.incrementiMago.velocitaPerDestrezza).ToString();
                    if (stats.statsMago.velocita + stats.incrementiMago.velocitaPerDestrezza == stats.statsMago.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    break;
                }
            case 2:
                {
                    costo.text = stats.statsTank.costoDestrezza.ToString();

                    hpMax.text = (stats.statsTank.hpMax + stats.incrementiTank.hpPerDestrezza).ToString();
                    if (stats.statsTank.hpMax + stats.incrementiTank.hpPerDestrezza == stats.statsTank.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsTank.mpMax + stats.incrementiTank.mpPerDestrezza).ToString();
                    if (stats.statsTank.mpMax + stats.incrementiTank.mpPerDestrezza == stats.statsTank.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerDestrezza).ToString();
                    if (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerDestrezza == stats.statsTank.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerDestrezza).ToString();
                    if (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerDestrezza == stats.statsTank.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerDestrezza).ToString();
                    if (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerDestrezza == stats.statsTank.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerDestrezza).ToString();
                    if (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerDestrezza == stats.statsTank.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerDestrezza).ToString();
                    if (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerDestrezza == stats.statsTank.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsTank.velocita + stats.incrementiTank.velocitaPerDestrezza).ToString();
                    if (stats.statsTank.velocita + stats.incrementiTank.velocitaPerDestrezza == stats.statsTank.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    break;
                }
            case 3:
                {
                    costo.text = stats.statsDps.costoDestrezza.ToString();

                    hpMax.text = (stats.statsDps.hpMax + stats.incrementiDps.hpPerDestrezza).ToString();
                    if (stats.statsDps.hpMax + stats.incrementiDps.hpPerDestrezza == stats.statsDps.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsDps.mpMax + stats.incrementiDps.mpPerDestrezza).ToString();
                    if (stats.statsDps.mpMax + stats.incrementiDps.mpPerDestrezza == stats.statsDps.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerDestrezza).ToString();
                    if (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerDestrezza == stats.statsDps.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerDestrezza).ToString();
                    if (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerDestrezza == stats.statsDps.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerDestrezza).ToString();
                    if (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerDestrezza == stats.statsDps.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerDestrezza).ToString();
                    if (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerDestrezza == stats.statsDps.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerDestrezza).ToString();
                    if (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerDestrezza == stats.statsDps.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsDps.velocita + stats.incrementiDps.velocitaPerDestrezza).ToString();
                    if (stats.statsDps.velocita + stats.incrementiDps.velocitaPerDestrezza == stats.statsDps.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

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
        ui.abilityBox.SetActive(false);
        ui.loaderBox.SetActive(true);
        Text costo = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Costo").GetComponent<Text>();
        Text statistica = ui.menuStats.transform.Find("LoaderBox/LoaderBox/Stats/Titolo/Text").GetComponent<Text>();
        statistica.text = "Spirito";

        Text help = ui.menuStats.transform.Find("Info").GetComponent<Text>();
        help.text = "Aumenta Statistica";

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
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsMago.mpMax + stats.incrementiMago.mpPerSpirito).ToString();
                    if (stats.statsMago.mpMax + stats.incrementiMago.mpPerSpirito == stats.statsMago.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerSpirito).ToString();
                    if (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerSpirito == stats.statsMago.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerForza).ToString();
                    if (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerForza == stats.statsMago.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerSpirito).ToString();
                    if (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerSpirito == stats.statsMago.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerSpirito).ToString();
                    if (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerSpirito == stats.statsMago.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerSpirito).ToString();
                    if (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerSpirito == stats.statsMago.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsMago.velocita + stats.incrementiMago.velocitaPerSpirito).ToString();
                    if (stats.statsMago.velocita + stats.incrementiMago.velocitaPerSpirito == stats.statsMago.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    break;
                }
            case 2:
                {
                    costo.text = stats.statsTank.costoSpirito.ToString();

                    hpMax.text = (stats.statsTank.hpMax + stats.incrementiTank.hpPerSpirito).ToString();
                    if (stats.statsTank.hpMax + stats.incrementiTank.hpPerSpirito == stats.statsTank.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsTank.mpMax + stats.incrementiTank.mpPerSpirito).ToString();
                    if (stats.statsTank.mpMax + stats.incrementiTank.mpPerSpirito == stats.statsTank.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerSpirito).ToString();
                    if (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerSpirito == stats.statsTank.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerForza).ToString();
                    if (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerForza == stats.statsTank.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerSpirito).ToString();
                    if (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerSpirito == stats.statsTank.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerSpirito).ToString();
                    if (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerSpirito == stats.statsTank.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerSpirito).ToString();
                    if (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerSpirito == stats.statsTank.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsTank.velocita + stats.incrementiTank.velocitaPerSpirito).ToString();
                    if (stats.statsTank.velocita + stats.incrementiTank.velocitaPerSpirito == stats.statsTank.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    break;
                }
            case 3:
                {
                    costo.text = stats.statsDps.costoSpirito.ToString();

                    hpMax.text = (stats.statsDps.hpMax + stats.incrementiDps.hpPerSpirito).ToString();
                    if (stats.statsDps.hpMax + stats.incrementiDps.hpPerSpirito == stats.statsDps.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsDps.mpMax + stats.incrementiDps.mpPerSpirito).ToString();
                    if (stats.statsDps.mpMax + stats.incrementiDps.mpPerSpirito == stats.statsDps.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerSpirito).ToString();
                    if (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerSpirito == stats.statsDps.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerForza).ToString();
                    if (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerForza == stats.statsDps.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerSpirito).ToString();
                    if (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerSpirito == stats.statsDps.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerSpirito).ToString();
                    if (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerSpirito == stats.statsDps.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerSpirito).ToString();
                    if (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerSpirito == stats.statsDps.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsDps.velocita + stats.incrementiDps.velocitaPerSpirito).ToString();
                    if (stats.statsDps.velocita + stats.incrementiDps.velocitaPerSpirito == stats.statsDps.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

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

    public void LvlForza()
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
                    stats.esperience -= stats.statsMago.costoForza;
                    ui.AggiornaAveri();
                    stats.statsMago.livello++;
                    stats.statsMago.forza++;
                    stats.statsMago.hpMax += stats.incrementiMago.hpPerForza;
                    stats.statsMago.hp += stats.incrementiMago.hpPerForza;
                    stats.statsMago.mpMax += stats.incrementiMago.mpPerForza;
                    stats.statsMago.mp += stats.incrementiMago.mpPerForza;
                    stats.statsMago.attMelee += stats.incrementiMago.attMeleePerForza;
                    stats.statsMago.attDistanza += stats.incrementiMago.attDistanzaPerForza;
                    stats.statsMago.attMagico += stats.incrementiMago.attMagicoPerForza;
                    stats.statsMago.difFisica += stats.incrementiMago.difFisicaPerForza;
                    stats.statsMago.difMagica += stats.incrementiMago.difMagicaPerForza;
                    stats.statsMago.velocita += stats.incrementiMago.velocitaPerForza;

                    stats.statsMago.costoForza = 100 + (stats.statsMago.forza * 50) + (stats.statsMago.forza * 10 * stats.statsMago.livello);

                    Text Forzalvl = ui.menuStats.transform.Find("Button/Forza/ForzaText/Value/Text").GetComponent<Text>();
                    Forzalvl.text = (stats.statsMago.forza + 1).ToString();
                    Text textLvl = ui.menuStats.transform.Find("Character/BaseLivello/Text").GetComponent<Text>();
                    int livello = stats.statsMago.forza + stats.statsMago.Spirito + stats.statsMago.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();
                    ui.CheckButton();
                    ui.AggiornaMana();
                    ui.AggiornaVita();
                    CheckCostForza();
                    CheckCostDestrezza();
                    CheckCostSpirito();
                    //Ricalcolo gli upgrade
                    costo.text = stats.statsMago.costoForza.ToString();
                    hpMax.text = (stats.statsMago.hpMax + stats.incrementiMago.hpPerForza).ToString();
                    if (stats.statsMago.hpMax + stats.incrementiMago.hpPerForza == stats.statsMago.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsMago.mpMax + stats.incrementiMago.mpPerForza).ToString();
                    if (stats.statsMago.mpMax + stats.incrementiMago.mpPerForza == stats.statsMago.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerForza).ToString();
                    if (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerForza == stats.statsMago.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerForza).ToString();
                    if (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerForza == stats.statsMago.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);
                    attMagico.text = (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerForza).ToString();
                    if (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerForza == stats.statsMago.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerForza).ToString();
                    if (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerForza == stats.statsMago.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);
                    difMagica.text = (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerForza).ToString();
                    if (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerForza == stats.statsMago.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsMago.velocita + stats.incrementiMago.velocitaPerForza).ToString();
                    if (stats.statsMago.velocita + stats.incrementiMago.velocitaPerForza == stats.statsMago.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    break;
                }
            case 2:
                {
                    stats.esperience -= stats.statsTank.costoForza;
                    ui.AggiornaAveri();
                    stats.statsTank.livello++;
                    stats.statsTank.forza++;
                    stats.statsTank.hpMax += stats.incrementiTank.hpPerForza;
                    stats.statsTank.hp += stats.incrementiTank.hpPerForza;
                    stats.statsTank.mpMax += stats.incrementiTank.mpPerForza;
                    stats.statsTank.mp += stats.incrementiTank.mpPerForza;
                    stats.statsTank.attMelee += stats.incrementiTank.attMeleePerForza;
                    stats.statsTank.attDistanza += stats.incrementiTank.attDistanzaPerForza;
                    stats.statsTank.attMagico += stats.incrementiTank.attMagicoPerForza;
                    stats.statsTank.difFisica += stats.incrementiTank.difFisicaPerForza;
                    stats.statsTank.difMagica += stats.incrementiTank.difMagicaPerForza;
                    stats.statsTank.velocita += stats.incrementiTank.velocitaPerForza;

                    stats.statsTank.costoForza = 100 + (stats.statsTank.forza * 50) + (stats.statsTank.forza * 10 * stats.statsTank.livello);

                    Text Forzalvl = ui.menuStats.transform.Find("Button/Forza/ForzaText/Value/Text").GetComponent<Text>();
                    Forzalvl.text = (stats.statsTank.forza + 1).ToString();
                    Text textLvl = ui.menuStats.transform.Find("Character/BaseLivello/Text").GetComponent<Text>();
                    int livello = stats.statsTank.forza + stats.statsTank.Spirito + stats.statsTank.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();
                    ui.CheckButton();
                    ui.AggiornaMana();
                    ui.AggiornaVita();
                    CheckCostForza();
                    CheckCostDestrezza();
                    CheckCostSpirito();
                    //Ricalcolo gli upgrade
                    costo.text = stats.statsTank.costoForza.ToString();

                    hpMax.text = (stats.statsTank.hpMax + stats.incrementiTank.hpPerForza).ToString();
                    if (stats.statsTank.hpMax + stats.incrementiTank.hpPerForza == stats.statsTank.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsTank.mpMax + stats.incrementiTank.mpPerForza).ToString();
                    if (stats.statsTank.mpMax + stats.incrementiTank.mpPerForza == stats.statsTank.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerForza).ToString();
                    if (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerForza == stats.statsTank.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerForza).ToString();
                    if (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerForza == stats.statsTank.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerForza).ToString();
                    if (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerForza == stats.statsTank.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerForza).ToString();
                    if (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerForza == stats.statsTank.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerForza).ToString();
                    if (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerForza == stats.statsTank.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsTank.velocita + stats.incrementiTank.velocitaPerForza).ToString();
                    if (stats.statsTank.velocita + stats.incrementiTank.velocitaPerForza == stats.statsTank.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    break;
                }
            case 3:
                {

                    stats.esperience -= stats.statsDps.costoForza;
                    ui.AggiornaAveri();
                    stats.statsDps.livello++;
                    stats.statsDps.forza++;
                    stats.statsDps.hpMax += stats.incrementiDps.hpPerForza;
                    stats.statsDps.hp += stats.incrementiDps.hpPerForza;
                    stats.statsDps.mpMax += stats.incrementiDps.mpPerForza;
                    stats.statsDps.mp += stats.incrementiDps.mpPerForza;
                    stats.statsDps.attMelee += stats.incrementiDps.attMeleePerForza;
                    stats.statsDps.attDistanza += stats.incrementiDps.attDistanzaPerForza;
                    stats.statsDps.attMagico += stats.incrementiDps.attMagicoPerForza;
                    stats.statsDps.difFisica += stats.incrementiDps.difFisicaPerForza;
                    stats.statsDps.difMagica += stats.incrementiDps.difMagicaPerForza;
                    stats.statsDps.velocita += stats.incrementiDps.velocitaPerForza;

                    stats.statsDps.costoForza = 100 + (stats.statsDps.forza * 50) + (stats.statsDps.forza * 10 * stats.statsDps.livello);

                    Text Forzalvl = ui.menuStats.transform.Find("Button/Forza/ForzaText/Value/Text").GetComponent<Text>();
                    Forzalvl.text = (stats.statsDps.forza + 1).ToString();
                    Text textLvl = ui.menuStats.transform.Find("Character/BaseLivello/Text").GetComponent<Text>();
                    int livello = stats.statsDps.forza + stats.statsDps.Spirito + stats.statsDps.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();
                    ui.CheckButton();
                    ui.AggiornaMana();
                    ui.AggiornaVita();
                    CheckCostForza();
                    CheckCostDestrezza();
                    CheckCostSpirito();
                    //Ricalcolo gli upgrade
                    costo.text = stats.statsDps.costoForza.ToString();

                    hpMax.text = (stats.statsDps.hpMax + stats.incrementiDps.hpPerForza).ToString();
                    if (stats.statsDps.hpMax + stats.incrementiDps.hpPerForza == stats.statsDps.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsDps.mpMax + stats.incrementiDps.mpPerForza).ToString();
                    if (stats.statsDps.mpMax + stats.incrementiDps.mpPerForza == stats.statsDps.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerForza).ToString();
                    if (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerForza == stats.statsDps.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerForza).ToString();
                    if (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerForza == stats.statsDps.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerForza).ToString();
                    if (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerForza == stats.statsDps.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerForza).ToString();
                    if (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerForza == stats.statsDps.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerForza).ToString();
                    if (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerForza == stats.statsDps.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsDps.velocita + stats.incrementiDps.velocitaPerForza).ToString();
                    if (stats.statsDps.velocita + stats.incrementiDps.velocitaPerForza == stats.statsDps.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    break;
                }
            default:
                break;
        }

    }

    public void LvlDestrezza()
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
                    stats.esperience -= stats.statsMago.costoDestrezza;
                    ui.AggiornaAveri();
                    stats.statsMago.livello++;
                    stats.statsMago.destrezza++;
                    stats.statsMago.hpMax += stats.incrementiMago.hpPerDestrezza;
                    stats.statsMago.hp += stats.incrementiMago.hpPerDestrezza;
                    stats.statsMago.mpMax += stats.incrementiMago.mpPerDestrezza;
                    stats.statsMago.mp += stats.incrementiMago.mpPerDestrezza;
                    stats.statsMago.attMelee += stats.incrementiMago.attMeleePerDestrezza;
                    stats.statsMago.attDistanza += stats.incrementiMago.attDistanzaPerDestrezza;
                    stats.statsMago.attMagico += stats.incrementiMago.attMagicoPerDestrezza;
                    stats.statsMago.difFisica += stats.incrementiMago.difFisicaPerDestrezza;
                    stats.statsMago.difMagica += stats.incrementiMago.difMagicaPerDestrezza;
                    stats.statsMago.velocita += stats.incrementiMago.velocitaPerDestrezza;

                    stats.statsMago.costoDestrezza = 100 + (stats.statsMago.destrezza * 50) + (stats.statsMago.destrezza * 10 * stats.statsMago.livello);

                    Text Destrezzalvl = ui.menuStats.transform.Find("Button/Destrezza/DestrezzaText/Value/Text").GetComponent<Text>();
                    Destrezzalvl.text = (stats.statsMago.destrezza + 1).ToString();
                    Text textLvl = ui.menuStats.transform.Find("Character/BaseLivello/Text").GetComponent<Text>();
                    int livello = stats.statsMago.forza + stats.statsMago.Spirito + stats.statsMago.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();
                    ui.CheckButton();
                    ui.AggiornaMana();
                    ui.AggiornaVita();
                    CheckCostForza();
                    CheckCostDestrezza();
                    CheckCostSpirito();
                    //Ricalcolo gli upgrade
                    costo.text = stats.statsMago.costoDestrezza.ToString();

                    hpMax.text = (stats.statsMago.hpMax + stats.incrementiMago.hpPerDestrezza).ToString();
                    if (stats.statsMago.hpMax + stats.incrementiMago.hpPerDestrezza == stats.statsMago.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsMago.mpMax + stats.incrementiMago.mpPerDestrezza).ToString();
                    if (stats.statsMago.mpMax + stats.incrementiMago.mpPerDestrezza == stats.statsMago.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerDestrezza).ToString();
                    if (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerDestrezza == stats.statsMago.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerDestrezza).ToString();
                    if (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerDestrezza == stats.statsMago.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerDestrezza).ToString();
                    if (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerDestrezza == stats.statsMago.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerDestrezza).ToString();
                    if (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerDestrezza == stats.statsMago.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerDestrezza).ToString();
                    if (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerDestrezza == stats.statsMago.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsMago.velocita + stats.incrementiMago.velocitaPerDestrezza).ToString();
                    if (stats.statsMago.velocita + stats.incrementiMago.velocitaPerDestrezza == stats.statsMago.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    break;
                }
            case 2:
                {
                    stats.esperience -= stats.statsTank.costoDestrezza;
                    ui.AggiornaAveri();
                    stats.statsTank.livello++;
                    stats.statsTank.destrezza++;
                    stats.statsTank.hpMax += stats.incrementiTank.hpPerDestrezza;
                    stats.statsTank.hp += stats.incrementiTank.hpPerDestrezza;
                    stats.statsTank.mpMax += stats.incrementiTank.mpPerDestrezza;
                    stats.statsTank.mp += stats.incrementiTank.mpPerDestrezza;
                    stats.statsTank.attMelee += stats.incrementiTank.attMeleePerDestrezza;
                    stats.statsTank.attDistanza += stats.incrementiTank.attDistanzaPerDestrezza;
                    stats.statsTank.attMagico += stats.incrementiTank.attMagicoPerDestrezza;
                    stats.statsTank.difFisica += stats.incrementiTank.difFisicaPerDestrezza;
                    stats.statsTank.difMagica += stats.incrementiTank.difMagicaPerDestrezza;
                    stats.statsTank.velocita += stats.incrementiTank.velocitaPerDestrezza;

                    stats.statsTank.costoDestrezza = 100 + (stats.statsTank.destrezza * 50) + (stats.statsTank.destrezza * 10 * stats.statsTank.livello);

                    Text Destrezzalvl = ui.menuStats.transform.Find("Button/Destrezza/DestrezzaText/Value/Text").GetComponent<Text>();
                    Destrezzalvl.text = (stats.statsTank.destrezza + 1).ToString();
                    Text textLvl = ui.menuStats.transform.Find("Character/BaseLivello/Text").GetComponent<Text>();
                    int livello = stats.statsTank.forza + stats.statsTank.Spirito + stats.statsTank.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();
                    ui.CheckButton();
                    ui.AggiornaMana();
                    ui.AggiornaVita();
                    CheckCostForza();
                    CheckCostDestrezza();
                    CheckCostSpirito();
                    //Ricalcolo gli upgrade
                    costo.text = stats.statsTank.costoDestrezza.ToString();

                    hpMax.text = (stats.statsTank.hpMax + stats.incrementiTank.hpPerDestrezza).ToString();
                    if (stats.statsTank.hpMax + stats.incrementiTank.hpPerDestrezza == stats.statsTank.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsTank.mpMax + stats.incrementiTank.mpPerDestrezza).ToString();
                    if (stats.statsTank.mpMax + stats.incrementiTank.mpPerDestrezza == stats.statsTank.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerDestrezza).ToString();
                    if (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerDestrezza == stats.statsTank.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerDestrezza).ToString();
                    if (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerDestrezza == stats.statsTank.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerDestrezza).ToString();
                    if (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerDestrezza == stats.statsTank.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerDestrezza).ToString();
                    if (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerDestrezza == stats.statsTank.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerDestrezza).ToString();
                    if (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerDestrezza == stats.statsTank.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsTank.velocita + stats.incrementiTank.velocitaPerDestrezza).ToString();
                    if (stats.statsTank.velocita + stats.incrementiTank.velocitaPerDestrezza == stats.statsTank.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    break;
                }
            case 3:
                {
                    stats.esperience -= stats.statsDps.costoDestrezza;
                    ui.AggiornaAveri();
                    stats.statsDps.livello++;
                    stats.statsDps.destrezza++;
                    stats.statsDps.hpMax += stats.incrementiDps.hpPerDestrezza;
                    stats.statsDps.hp += stats.incrementiDps.hpPerDestrezza;
                    stats.statsDps.mpMax += stats.incrementiDps.mpPerDestrezza;
                    stats.statsDps.mp += stats.incrementiDps.mpPerDestrezza;
                    stats.statsDps.attMelee += stats.incrementiDps.attMeleePerDestrezza;
                    stats.statsDps.attDistanza += stats.incrementiDps.attDistanzaPerDestrezza;
                    stats.statsDps.attMagico += stats.incrementiDps.attMagicoPerDestrezza;
                    stats.statsDps.difFisica += stats.incrementiDps.difFisicaPerDestrezza;
                    stats.statsDps.difMagica += stats.incrementiDps.difMagicaPerDestrezza;
                    stats.statsDps.velocita += stats.incrementiDps.velocitaPerDestrezza;

                    stats.statsDps.costoDestrezza = 100 + (stats.statsDps.destrezza * 50) + (stats.statsDps.destrezza * 10 * stats.statsDps.livello);

                    Text Destrezzalvl = ui.menuStats.transform.Find("Button/Destrezza/DestrezzaText/Value/Text").GetComponent<Text>();
                    Destrezzalvl.text = (stats.statsDps.destrezza + 1).ToString();
                    Text textLvl = ui.menuStats.transform.Find("Character/BaseLivello/Text").GetComponent<Text>();
                    int livello = stats.statsDps.forza + stats.statsDps.Spirito + stats.statsDps.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();
                    ui.CheckButton();
                    ui.AggiornaMana();
                    ui.AggiornaVita();
                    CheckCostForza();
                    CheckCostDestrezza();
                    CheckCostSpirito();
                    //Ricalcolo gli upgrade
                    costo.text = stats.statsDps.costoDestrezza.ToString();

                    hpMax.text = (stats.statsDps.hpMax + stats.incrementiDps.hpPerDestrezza).ToString();
                    if (stats.statsDps.hpMax + stats.incrementiDps.hpPerDestrezza == stats.statsDps.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsDps.mpMax + stats.incrementiDps.mpPerDestrezza).ToString();
                    if (stats.statsDps.mpMax + stats.incrementiDps.mpPerDestrezza == stats.statsDps.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerDestrezza).ToString();
                    if (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerDestrezza == stats.statsDps.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerDestrezza).ToString();
                    if (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerDestrezza == stats.statsDps.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerDestrezza).ToString();
                    if (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerDestrezza == stats.statsDps.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerDestrezza).ToString();
                    if (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerDestrezza == stats.statsDps.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerDestrezza).ToString();
                    if (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerDestrezza == stats.statsDps.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsDps.velocita + stats.incrementiDps.velocitaPerDestrezza).ToString();
                    if (stats.statsDps.velocita + stats.incrementiDps.velocitaPerDestrezza == stats.statsDps.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    break;
                }
            default:
                break;
        }
    }

    public void LvlSpirito()
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
                    stats.esperience -= stats.statsMago.costoSpirito;
                    ui.AggiornaAveri();
                    stats.statsMago.livello++;
                    stats.statsMago.Spirito++;
                    stats.statsMago.hpMax += stats.incrementiMago.hpPerSpirito;
                    stats.statsMago.hp += stats.incrementiMago.hpPerSpirito;
                    stats.statsMago.mpMax += stats.incrementiMago.mpPerSpirito;
                    stats.statsMago.mp += stats.incrementiMago.mpPerSpirito;
                    stats.statsMago.attMelee += stats.incrementiMago.attMeleePerSpirito;
                    stats.statsMago.attDistanza += stats.incrementiMago.attDistanzaPerSpirito;
                    stats.statsMago.attMagico += stats.incrementiMago.attMagicoPerSpirito;
                    stats.statsMago.difFisica += stats.incrementiMago.difFisicaPerSpirito;
                    stats.statsMago.difMagica += stats.incrementiMago.difMagicaPerSpirito;
                    stats.statsMago.velocita += stats.incrementiMago.velocitaPerSpirito;

                    stats.statsMago.costoSpirito = 100 + (stats.statsMago.Spirito * 50) + (stats.statsMago.Spirito * 10 * stats.statsMago.livello);

                    Text Spiritolvl = ui.menuStats.transform.Find("Button/Spirito/SpiritoText/Value/Text").GetComponent<Text>();
                    Spiritolvl.text = (stats.statsMago.Spirito + 1).ToString();
                    Text textLvl = ui.menuStats.transform.Find("Character/BaseLivello/Text").GetComponent<Text>();
                    int livello = stats.statsMago.forza + stats.statsMago.Spirito + stats.statsMago.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();
                    ui.CheckButton();
                    ui.AggiornaMana();
                    ui.AggiornaVita();
                    CheckCostForza();
                    CheckCostDestrezza();
                    CheckCostSpirito();
                    //Ricalcolo gli upgrade
                    costo.text = stats.statsMago.costoSpirito.ToString();

                    hpMax.text = (stats.statsMago.hpMax + stats.incrementiMago.hpPerSpirito).ToString();
                    if (stats.statsMago.hpMax + stats.incrementiMago.hpPerSpirito == stats.statsMago.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsMago.mpMax + stats.incrementiMago.mpPerSpirito).ToString();
                    if (stats.statsMago.mpMax + stats.incrementiMago.mpPerSpirito == stats.statsMago.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerSpirito).ToString();
                    if (stats.statsMago.attMelee + stats.incrementiMago.attMeleePerSpirito == stats.statsMago.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerForza).ToString();
                    if (stats.statsMago.attDistanza + stats.incrementiMago.attDistanzaPerForza == stats.statsMago.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerSpirito).ToString();
                    if (stats.statsMago.attMagico + stats.incrementiMago.attMagicoPerSpirito == stats.statsMago.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerSpirito).ToString();
                    if (stats.statsMago.difFisica + stats.incrementiMago.difFisicaPerSpirito == stats.statsMago.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerSpirito).ToString();
                    if (stats.statsMago.difMagica + stats.incrementiMago.difMagicaPerSpirito == stats.statsMago.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsMago.velocita + stats.incrementiMago.velocitaPerSpirito).ToString();
                    if (stats.statsMago.velocita + stats.incrementiMago.velocitaPerSpirito == stats.statsMago.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    break;
                }
            case 2:
                {
                    stats.esperience -= stats.statsTank.costoSpirito;
                    ui.AggiornaAveri();
                    stats.statsTank.livello++;
                    stats.statsTank.Spirito++;
                    stats.statsTank.hpMax += stats.incrementiTank.hpPerSpirito;
                    stats.statsTank.hp += stats.incrementiTank.hpPerSpirito;
                    stats.statsTank.mpMax += stats.incrementiTank.mpPerSpirito;
                    stats.statsTank.mp += stats.incrementiTank.mpPerSpirito;
                    stats.statsTank.attMelee += stats.incrementiTank.attMeleePerSpirito;
                    stats.statsTank.attDistanza += stats.incrementiTank.attDistanzaPerSpirito;
                    stats.statsTank.attMagico += stats.incrementiTank.attMagicoPerSpirito;
                    stats.statsTank.difFisica += stats.incrementiTank.difFisicaPerSpirito;
                    stats.statsTank.difMagica += stats.incrementiTank.difMagicaPerSpirito;
                    stats.statsTank.velocita += stats.incrementiTank.velocitaPerSpirito;

                    stats.statsTank.costoSpirito = 100 + (stats.statsTank.Spirito * 50) + (stats.statsTank.Spirito * 10 * stats.statsTank.livello);

                    Text Spiritolvl = ui.menuStats.transform.Find("Button/Spirito/SpiritoText/Value/Text").GetComponent<Text>();
                    Spiritolvl.text = (stats.statsTank.Spirito + 1).ToString();
                    Text textLvl = ui.menuStats.transform.Find("Character/BaseLivello/Text").GetComponent<Text>();
                    int livello = stats.statsTank.forza + stats.statsTank.Spirito + stats.statsTank.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();
                    ui.CheckButton();
                    ui.AggiornaMana();
                    ui.AggiornaVita();
                    CheckCostForza();
                    CheckCostDestrezza();
                    CheckCostSpirito();
                    //Ricalcolo gli upgrade
                    costo.text = stats.statsTank.costoSpirito.ToString();

                    hpMax.text = (stats.statsTank.hpMax + stats.incrementiTank.hpPerSpirito).ToString();
                    if (stats.statsTank.hpMax + stats.incrementiTank.hpPerSpirito == stats.statsTank.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsTank.mpMax + stats.incrementiTank.mpPerSpirito).ToString();
                    if (stats.statsTank.mpMax + stats.incrementiTank.mpPerSpirito == stats.statsTank.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerSpirito).ToString();
                    if (stats.statsTank.attMelee + stats.incrementiTank.attMeleePerSpirito == stats.statsTank.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerForza).ToString();
                    if (stats.statsTank.attDistanza + stats.incrementiTank.attDistanzaPerForza == stats.statsTank.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerSpirito).ToString();
                    if (stats.statsTank.attMagico + stats.incrementiTank.attMagicoPerSpirito == stats.statsTank.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerSpirito).ToString();
                    if (stats.statsTank.difFisica + stats.incrementiTank.difFisicaPerSpirito == stats.statsTank.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerSpirito).ToString();
                    if (stats.statsTank.difMagica + stats.incrementiTank.difMagicaPerSpirito == stats.statsTank.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsTank.velocita + stats.incrementiTank.velocitaPerSpirito).ToString();
                    if (stats.statsTank.velocita + stats.incrementiTank.velocitaPerSpirito == stats.statsTank.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    break;
                }
            case 3:
                {
                    stats.esperience -= stats.statsDps.costoSpirito;
                    ui.AggiornaAveri();
                    stats.statsDps.livello++;
                    stats.statsDps.Spirito++;
                    stats.statsDps.hpMax += stats.incrementiDps.hpPerSpirito;
                    stats.statsDps.hp += stats.incrementiDps.hpPerSpirito;
                    stats.statsDps.mpMax += stats.incrementiDps.mpPerSpirito;
                    stats.statsDps.mp += stats.incrementiDps.mpPerSpirito;
                    stats.statsDps.attMelee += stats.incrementiDps.attMeleePerSpirito;
                    stats.statsDps.attDistanza += stats.incrementiDps.attDistanzaPerSpirito;
                    stats.statsDps.attMagico += stats.incrementiDps.attMagicoPerSpirito;
                    stats.statsDps.difFisica += stats.incrementiDps.difFisicaPerSpirito;
                    stats.statsDps.difMagica += stats.incrementiDps.difMagicaPerSpirito;
                    stats.statsDps.velocita += stats.incrementiDps.velocitaPerSpirito;

                    stats.statsDps.costoSpirito = 100 + (stats.statsDps.Spirito * 50) + (stats.statsDps.Spirito * 10 * stats.statsDps.livello);

                    Text Spiritolvl = ui.menuStats.transform.Find("Button/Spirito/SpiritoText/Value/Text").GetComponent<Text>();
                    Spiritolvl.text = (stats.statsDps.Spirito + 1).ToString();
                    Text textLvl = ui.menuStats.transform.Find("Character/BaseLivello/Text").GetComponent<Text>();
                    int livello = stats.statsDps.forza + stats.statsDps.Spirito + stats.statsDps.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();
                    ui.CheckButton();
                    ui.AggiornaMana();
                    ui.AggiornaVita();
                    CheckCostForza();
                    CheckCostDestrezza();
                    CheckCostSpirito();
                    //Ricalcolo gli upgrade
                    costo.text = stats.statsDps.costoSpirito.ToString();

                    hpMax.text = (stats.statsDps.hpMax + stats.incrementiDps.hpPerSpirito).ToString();
                    if (stats.statsDps.hpMax + stats.incrementiDps.hpPerSpirito == stats.statsDps.hpMax)
                    {
                        hpMax.color = Color.black;
                    }
                    else
                        hpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    mpMax.text = (stats.statsDps.mpMax + stats.incrementiDps.mpPerSpirito).ToString();
                    if (stats.statsDps.mpMax + stats.incrementiDps.mpPerSpirito == stats.statsDps.mp)
                    {
                        mpMax.color = Color.black;
                    }
                    else
                        mpMax.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attFisico.text = (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerSpirito).ToString();
                    if (stats.statsDps.attMelee + stats.incrementiDps.attMeleePerSpirito == stats.statsDps.attMelee)
                    {
                        attFisico.color = Color.black;
                    }
                    else
                        attFisico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attRanged.text = (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerForza).ToString();
                    if (stats.statsDps.attDistanza + stats.incrementiDps.attDistanzaPerForza == stats.statsDps.attDistanza)
                    {
                        attRanged.color = Color.black;
                    }
                    else
                        attRanged.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    attMagico.text = (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerSpirito).ToString();
                    if (stats.statsDps.attMagico + stats.incrementiDps.attMagicoPerSpirito == stats.statsDps.attMagico)
                    {
                        attMagico.color = Color.black;
                    }
                    else
                        attMagico.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difFisica.text = (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerSpirito).ToString();
                    if (stats.statsDps.difFisica + stats.incrementiDps.difFisicaPerSpirito == stats.statsDps.difFisica)
                    {
                        difFisica.color = Color.black;
                    }
                    else
                        difFisica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    difMagica.text = (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerSpirito).ToString();
                    if (stats.statsDps.difMagica + stats.incrementiDps.difMagicaPerSpirito == stats.statsDps.difMagica)
                    {
                        difMagica.color = Color.black;
                    }
                    else
                        difMagica.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    velocita.text = (stats.statsDps.velocita + stats.incrementiDps.velocitaPerSpirito).ToString();
                    if (stats.statsDps.velocita + stats.incrementiDps.velocitaPerSpirito == stats.statsDps.velocita)
                    {
                        velocita.color = Color.black;
                    }
                    else
                        velocita.color = new Color(0.11764f, 0.5098f, 0.2980f);

                    break;
                }
            default:
                break;
        }
    }

    public void CheckCostForza()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        UiControlExploration ui = FindObjectOfType<UiControlExploration>();
        Text help = ui.menuStats.transform.Find("Info").GetComponent<Text>();
        Image infoSprite = ui.menuStats.transform.Find("InfoSprite").GetComponent<Image>();
        //infoSprite.rectTransform.localPosition = new Vector3(-27.1f, infoSprite.rectTransform.localPosition.y, infoSprite.rectTransform.localPosition.z);
        infoSprite.gameObject.SetActive(true);
        switch (ui.nCharacter)
        {
            case 1:
                {
                    if (stats.statsMago.costoForza > stats.esperience)
                    {
                        infoSprite.gameObject.SetActive(false);
                        help.text = "Hai poca esperienza!";
                    }
                    break;
                }
            case 2:
                {
                    if (stats.statsTank.costoForza > stats.esperience)
                    {
                        infoSprite.gameObject.SetActive(false);
                        help.text = "Hai poca esperienza!";
                    }
                    break;
                }
            case 3:
                {
                    if (stats.statsDps.costoForza > stats.esperience)
                    {
                        infoSprite.gameObject.SetActive(false);
                        help.text = "Hai poca esperienza!";
                    }
                    break;
                }
            default:
                break;
        }
    }

    public void CheckCostDestrezza()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        UiControlExploration ui = FindObjectOfType<UiControlExploration>();
        Text help = ui.menuStats.transform.Find("Info").GetComponent<Text>();
        Image infoSprite = ui.menuStats.transform.Find("InfoSprite").GetComponent<Image>();
        //infoSprite.rectTransform.localPosition = new Vector3 (-27.1f, infoSprite.rectTransform.localPosition.y, infoSprite.rectTransform.localPosition.z);
        infoSprite.gameObject.SetActive(true);
        switch (ui.nCharacter)
        {
            case 1:
                {
                    if (stats.statsMago.costoDestrezza > stats.esperience)
                    {
                        infoSprite.gameObject.SetActive(false);
                        help.text = "Hai poca esperienza!";
                    }
                    break;
                }
            case 2:
                {
                    if (stats.statsTank.costoDestrezza > stats.esperience)
                    {
                        infoSprite.gameObject.SetActive(false);
                        help.text = "Hai poca esperienza!";
                    }
                    break;
                }
            case 3:
                {
                    if (stats.statsDps.costoDestrezza > stats.esperience)
                    {
                        infoSprite.gameObject.SetActive(false);
                        help.text = "Hai poca esperienza!";
                    }
                    break;
                }
            default:
                break;
        }
    }

    public void CheckCostSpirito()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        UiControlExploration ui = FindObjectOfType<UiControlExploration>();
        Text help = ui.menuStats.transform.Find("Info").GetComponent<Text>();
        Image infoSprite = ui.menuStats.transform.Find("InfoSprite").GetComponent<Image>();
        //infoSprite.rectTransform.localPosition = new Vector3(-27.1f, infoSprite.rectTransform.localPosition.y, infoSprite.rectTransform.localPosition.z);
        infoSprite.gameObject.SetActive(true);
        switch (ui.nCharacter)
        {
            case 1:
                {
                    if (stats.statsMago.costoSpirito > stats.esperience)
                    {
                        infoSprite.gameObject.SetActive(false);
                        help.text = "Hai poca esperienza!";
                    }
                    break;
                }
            case 2:
                {
                    if (stats.statsTank.costoSpirito > stats.esperience)
                    {
                        infoSprite.gameObject.SetActive(false);
                        help.text = "Hai poca esperienza!";
                    }
                    break;
                }
            case 3:
                {
                    if (stats.statsDps.costoSpirito > stats.esperience)
                    {
                        infoSprite.gameObject.SetActive(false);
                        help.text = "Hai poca esperienza!";
                    }
                    break;
                }
            default:
                break;
        }
    }
}