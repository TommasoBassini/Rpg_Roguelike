using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyAbility : MonoBehaviour
{
    public string[] nomi;
    public int nButton;
    public int[] step = {4,8,15,22,30};
    public Sprite[] abilityGrande;
    public string[] infoAbility;
    public int[] costoAbilita = { 400, 700, 1400, 2500, 5000 };

    public void ShowInfo()
    {
        UiControlExploration ui = FindObjectOfType<UiControlExploration>();
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        ui.abilityBox.SetActive(true);
        ui.loaderBox.SetActive(false);
        Text costo = ui.menuStats.transform.Find("LoaderBox/AbilityBox/Costo").GetComponent<Text>();
        Image costoImage = ui.menuStats.transform.Find("LoaderBox/AbilityBox/ExpSprite").GetComponent<Image>();
        Text nome = ui.menuStats.transform.Find("LoaderBox/AbilityBox/Titolo/Text").GetComponent<Text>();
        Text richiede = ui.menuStats.transform.Find("LoaderBox/AbilityBox/Richiede").GetComponent<Text>();

        Image abilitySprite = ui.menuStats.transform.Find("LoaderBox/AbilityBox/AbilityImage").GetComponent<Image>();
        Text mp = ui.menuStats.transform.Find("LoaderBox/AbilityBox/Mp").GetComponent<Text>();
        Text info = ui.menuStats.transform.Find("LoaderBox/AbilityBox/Info/Text").GetComponent<Text>();

        Text help = ui.menuStats.transform.Find("Info").GetComponent<Text>();
        help.text = "Impara abilità";

        switch (ui.nCharacter)
        {
            case 1:
                {
                    nome.text = nomi[ui.nCharacter - 1];
                    if (stats.statsMago.livello < step[nButton])
                    {
                        costoImage.enabled = false;
                        richiede.text = "Richiede il livello " + (step[nButton] + 3);
                        costo.text = "";
                    }
                    else
                    {
                        costoImage.enabled = true;
                        costo.text = costoAbilita[nButton].ToString();
                        richiede.text = "";
                    }

                    abilitySprite.sprite = abilityGrande[ui.nCharacter - 1];
                    mp.text = stats.statsMago.costoAbilita[nButton].ToString() + " MP";
                    info.text = infoAbility[ui.nCharacter - 1];
                    break;
                }
            case 2:
                {
                    nome.text = nomi[ui.nCharacter - 1];
                    if (stats.statsTank.livello < step[nButton])
                    {
                        costoImage.enabled = false;
                        richiede.text = "Richiede il livello " + (step[nButton] + 3);
                        costo.text = "";
                    }
                    else
                    {
                        costoImage.enabled = true;
                        costo.text = costoAbilita[nButton].ToString();
                        richiede.text = "";
                    }

                    abilitySprite.sprite = abilityGrande[ui.nCharacter - 1];
                    mp.text = stats.statsTank.costoAbilita[nButton].ToString() + " MP";
                    info.text = infoAbility[ui.nCharacter - 1];
                    break;
                }
            case 3:
                {
                    nome.text = nomi[ui.nCharacter - 1];
                    if (stats.statsDps.livello < step[nButton])
                    {
                        costoImage.enabled = false;
                        richiede.text = "Richiede il livello " + (step[nButton] + 3);
                        costo.text = "";
                    }
                    else
                    {
                        costoImage.enabled = true;
                        costo.text = costoAbilita[nButton].ToString();
                        richiede.text = "";
                    }

                    abilitySprite.sprite = abilityGrande[ui.nCharacter - 1];
                    mp.text = stats.statsDps.costoAbilita[nButton].ToString() + " MP";
                    info.text = infoAbility[ui.nCharacter - 1];
                    break;
                }
        }
    }

    public void CheckCostoAbilita(int i)
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        UiControlExploration ui = FindObjectOfType<UiControlExploration>();
        Text help = ui.menuStats.transform.Find("Info").GetComponent<Text>();
        Image infoSprite = ui.menuStats.transform.Find("InfoSprite").GetComponent<Image>();
        infoSprite.rectTransform.localPosition = new Vector3(-20f, infoSprite.rectTransform.localPosition.y, infoSprite.rectTransform.localPosition.z);
        infoSprite.gameObject.SetActive(true);
        switch (ui.nCharacter)
        {
            case 1:
                {
                    if (stats.esperience < costoAbilita[i] && stats.statsMago.livello >= ui.step[i])
                    {
                        infoSprite.gameObject.SetActive(false);
                        help.text = "Hai poca esperienza!";
                    }

                    if (stats.statsMago.livello < ui.step[i])
                    {
                        help.text = "Devi salire di livello!";
                        infoSprite.gameObject.SetActive(false);
                    }
                    break;
                }
            case 2:
                {
                    if (stats.esperience < costoAbilita[i] && stats.statsTank.livello >= ui.step[i])
                    {
                        help.text = "Hai poca esperienza!";
                        infoSprite.gameObject.SetActive(false);
                    }

                    if (stats.statsTank.livello < ui.step[i])
                    {
                        infoSprite.gameObject.SetActive(false);
                        help.text = "Devi salire di livello!";
                    }
                    break;
                }
            case 3:
                {
                    if (stats.esperience < costoAbilita[i] && stats.statsDps.livello >= ui.step[i])
                    {
                        infoSprite.gameObject.SetActive(false);
                        help.text = "Hai poca esperienza!";
                    }
                    if (stats.statsDps.livello < ui.step[i])
                    {
                        infoSprite.gameObject.SetActive(false);
                        help.text = "Devi salire di livello!";
                    }
                    break;
                }
        }
    }
}
