using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonMana : MonoBehaviour
{
    public int nPlayer;
    PlayerStatsControl stats;

    void OnEnable()
    {
        stats = FindObjectOfType<PlayerStatsControl>();
        switch (nPlayer)
        {
            case 1:
                {
                    if (stats.statsMago.mp == stats.statsMago.mpMax || stats.nPotionMana == 0)
                    {
                        GetComponent<Button>().interactable = false;
                    }
                    else
                        GetComponent<Button>().interactable = true;
                    break;
                }
            case 2:
                {
                    if (stats.statsTank.mp == stats.statsTank.mpMax || stats.nPotionMana == 0)
                    {
                        GetComponent<Button>().interactable = false;
                    }
                    else
                        GetComponent<Button>().interactable = true;
                    break;
                }
            case 3:
                {
                    if (stats.statsDps.mp == stats.statsDps.mpMax || stats.nPotionMana == 0)
                    {
                        GetComponent<Button>().interactable = false;
                    }
                    else
                        GetComponent<Button>().interactable = true;
                    break;
                }
            default:
                break;
        }
        foreach (Transform item in this.transform.parent.transform)
        {
            Button button = item.GetComponent<Button>();
            if (button.IsInteractable())
            {
                button.Select();
            }
        }
    }

    public void Cura()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        UiControlExploration ui = FindObjectOfType<UiControlExploration>();
        stats.nPotionMana--;
        ui.AggiornaPotion();
        switch (nPlayer)
        {
            case 1:
                {
                    int cura = Mathf.RoundToInt(stats.statsMago.mpMax / 2);
                    stats.statsMago.mp += cura;
                    if (stats.statsMago.mp > stats.statsMago.mpMax)
                    {
                        stats.statsMago.mp = stats.statsMago.mpMax;
                    }
                    ui.AggiornaMana();
                    break;
                }
            case 2:
                {
                    int cura = Mathf.RoundToInt(stats.statsTank.mpMax / 2);
                    stats.statsTank.mp += cura;
                    if (stats.statsTank.mp > stats.statsTank.mpMax)
                    {
                        stats.statsTank.mp = stats.statsTank.mpMax;
                    }
                    ui.AggiornaMana();
                    break;
                }
            case 3:
                {
                    int cura = Mathf.RoundToInt(stats.statsDps.mpMax / 2);
                    stats.statsDps.mp += cura;
                    if (stats.statsDps.mp > stats.statsDps.mpMax)
                    {
                        stats.statsDps.mp = stats.statsDps.mpMax;
                    }
                    ui.AggiornaMana();
                    break;
                }
            default:
                break;
        }
    }
}

