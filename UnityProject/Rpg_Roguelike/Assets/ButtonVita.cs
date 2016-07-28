using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonVita : MonoBehaviour
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
                    if (stats.statsMago.hp == stats.statsMago.hpMax || stats.nPotionHealth == 0)
                    {
                        GetComponent<Button>().interactable = false;
                    }
                    else
                        GetComponent<Button>().interactable = true;
                    break;
                }
            case 2:
                {
                    if (stats.statsTank.hp == stats.statsTank.hpMax || stats.nPotionHealth == 0)
                    {
                        GetComponent<Button>().interactable = false;
                    }
                    else
                        GetComponent<Button>().interactable = true;
                    break;
                }
            case 3:
                {
                    if (stats.statsDps.hp == stats.statsDps.hpMax || stats.nPotionHealth == 0)
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
        stats.nPotionHealth--;
        ui.AggiornaPotion();
        switch (nPlayer)
        {
            case 1:
                {
                    int cura = Mathf.RoundToInt(stats.statsMago.hpMax / 2);
                    stats.statsMago.hp += cura;
                    if (stats.statsMago.hp > stats.statsMago.hpMax)
                    {
                        stats.statsMago.hp = stats.statsMago.hpMax;
                    }
                    ui.AggiornaVita();
                    break;
                }
            case 2:
                {
                    int cura = Mathf.RoundToInt(stats.statsTank.hpMax / 2);
                    stats.statsTank.hp += cura;
                    if (stats.statsTank.hp > stats.statsTank.hpMax)
                    {
                        stats.statsTank.hp = stats.statsTank.hpMax;
                    }
                    ui.AggiornaVita();
                    break;
                }
            case 3:
                {
                    int cura = Mathf.RoundToInt(stats.statsDps.hpMax / 2);
                    stats.statsDps.hp += cura;
                    if (stats.statsDps.hp > stats.statsDps.hpMax)
                    {
                        stats.statsDps.hp = stats.statsDps.hpMax;
                    }
                    ui.AggiornaVita();
                    break;
                }
            default:
                break;
        }
    }
}
