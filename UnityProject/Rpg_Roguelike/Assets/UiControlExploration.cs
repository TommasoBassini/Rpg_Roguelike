using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiControlExploration : MonoBehaviour
{
    public GameObject menuStats;
    public Sprite[] characterSprite;
    public int nCharacter = 0;
    public GameObject[] buttons;

    public Sprite[] AbilityMage;
    public Sprite[] AbilityTank;
    public Sprite[] AbilityDps;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            nCharacter = 1;
            menuStats.SetActive(false);
            menuStats.SetActive(true);
            Invoke("SwitchaChar", 0.01f);
            menuStats.transform.Find("Button/Forza/ForzaButton").GetComponent<Button>().Select();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            nCharacter = 2;
            menuStats.SetActive(false);
            menuStats.SetActive(true);
            Invoke("SwitchaChar", 0.01f);
            menuStats.transform.Find("Button/Forza/ForzaButton").GetComponent<Button>().Select();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            nCharacter = 3;
            menuStats.SetActive(false);
            menuStats.SetActive(true);
            Invoke("SwitchaChar", 0.01f);
            menuStats.transform.Find("Button/Forza/ForzaButton").GetComponent<Button>().Select();

        }
    }

    void OnEnable()
    {
      
    }

    void SwitchaChar()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        Text nomeText = menuStats.transform.Find("Name/Text").GetComponent<Text>();
        Image charImage = menuStats.transform.Find("Character/CharacterSprite").GetComponent<Image>();
        Text textLvl = menuStats.transform.Find("Character/BaseLivello/Text").GetComponent<Text>();

        // Parte centrale
        Text Forzalvl = menuStats.transform.Find("Button/Forza/ForzaText/Value/Text").GetComponent<Text>();
        Text Destrezzalvl = menuStats.transform.Find("Button/Destrezza/DestrezzaText/Value/Text").GetComponent<Text>();
        Text Spiritolvl = menuStats.transform.Find("Button/Spirito/SpiritoText/Value/Text").GetComponent<Text>();

        //Parte centrale button abilità
        Button abilita1 = menuStats.transform.Find("Button/Abilita1/Abilita1Button").GetComponent<Button>();
        Button abilita2 = menuStats.transform.Find("Button/Abilita2/Abilita2Button").GetComponent<Button>();
        Button abilita3 = menuStats.transform.Find("Button/Abilita3/Abilita3Button").GetComponent<Button>();
        Button abilita4 = menuStats.transform.Find("Button/Abilita4/Abilita4Button").GetComponent<Button>();
        Button abilita5 = menuStats.transform.Find("Button/Abilita5/Abilita5Button").GetComponent<Button>();
        
        switch (nCharacter)
        {
            case 1:
                {
                    //Pannello Sinistro
                    nomeText.text = "Elibeth";
                    charImage.sprite = characterSprite[0];
                    int livello = stats.statsMago.forza + stats.statsMago.Spirito + stats.statsMago.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();

                    //ParteCentrale
                    Forzalvl.text = (stats.statsMago.forza + 1).ToString();
                    Destrezzalvl.text = (stats.statsMago.destrezza + 1).ToString();
                    Spiritolvl.text = (stats.statsMago.Spirito + 1).ToString();
                    //Button
                    abilita1.onClick.AddListener(() => MageAbility(1, 100));
                    abilita1.image.sprite = AbilityMage[0];
                    Text abilitaText = menuStats.transform.Find("Button/Abilita1/Abilita1/Text").GetComponent<Text>();
                    abilitaText.text = "Protezione";

                    abilita2.onClick.AddListener(() => MageAbility(2, 100));
                    abilita2.image.sprite = AbilityMage[1];
                    Text abilitaText2 = menuStats.transform.Find("Button/Abilita2/Abilita2/Text").GetComponent<Text>();
                    abilitaText2.text = "Cura";

                    abilita3.onClick.AddListener(() => MageAbility(3, 100));
                    abilita3.image.sprite = AbilityMage[2];
                    Text abilitaText3 = menuStats.transform.Find("Button/Abilita3/Abilita3/Text").GetComponent<Text>();
                    abilitaText3.text = "Assorbi anima";

                    abilita4.onClick.AddListener(() => MageAbility(4, 100));
                    abilita4.image.sprite = AbilityMage[3];
                    Text abilitaText4 = menuStats.transform.Find("Button/Abilita4/Abilita4/Text").GetComponent<Text>();
                    abilitaText4.text = "Fulmine";

                    abilita5.onClick.AddListener(() => MageAbility(5, 100));
                    abilita5.image.sprite = AbilityMage[4];
                    Text abilitaText5 = menuStats.transform.Find("Button/Abilita5/Abilita5/Text").GetComponent<Text>();
                    abilitaText5.text = "Ragnatela";

                    //Parte Destra
                    break;
                }
            case 2:
                {
                    nomeText.text = "Johell";
                    charImage.sprite = characterSprite[1];
                    int livello = stats.statsTank.forza + stats.statsTank.Spirito + stats.statsTank.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();

                    //ParteCentrale
                    Forzalvl.text = (stats.statsTank.forza + 1).ToString();
                    Destrezzalvl.text = (stats.statsTank.destrezza + 1).ToString();
                    Spiritolvl.text = (stats.statsTank.Spirito + 1).ToString();

                    //Button
                    abilita1.onClick.AddListener(() => TankAbility(1,100));
                    abilita1.image.sprite = AbilityTank[0];
                    Text abilitaText = menuStats.transform.Find("Button/Abilita1/Abilita1/Text").GetComponent<Text>();
                    abilitaText.text = "Sassata";

                    abilita2.onClick.AddListener(() => TankAbility(2, 100));
                    abilita2.image.sprite = AbilityTank[1];
                    Text abilitaText2 = menuStats.transform.Find("Button/Abilita2/Abilita2/Text").GetComponent<Text>();
                    abilitaText2.text = "Percuotere";

                    abilita3.onClick.AddListener(() => TankAbility(3, 100));
                    abilita3.image.sprite = AbilityTank[2];
                    Text abilitaText3 = menuStats.transform.Find("Button/Abilita3/Abilita3/Text").GetComponent<Text>();
                    abilitaText3.text = "Frantuma Scudo";

                    abilita4.onClick.AddListener(() => TankAbility(4, 100));
                    abilita4.image.sprite = AbilityTank[3];
                    Text abilitaText4 = menuStats.transform.Find("Button/Abilita4/Abilita4/Text").GetComponent<Text>();
                    abilitaText4.text = "Spezza Arma";

                    abilita5.onClick.AddListener(() => TankAbility(5, 100));
                    abilita5.image.sprite = AbilityTank[4];
                    Text abilitaText5 = menuStats.transform.Find("Button/Abilita5/Abilita5/Text").GetComponent<Text>();
                    abilitaText5.text = "Spaccateschio";
                    break;
                }
            case 3:
                {
                    nomeText.text = "Jupep";
                    charImage.sprite = characterSprite[2];
                    int livello = stats.statsDps.forza + stats.statsDps.Spirito + stats.statsDps.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();

                    //ParteCentrale
                    Forzalvl.text = (stats.statsDps.forza + 1).ToString();
                    Destrezzalvl.text = (stats.statsDps.destrezza + 1).ToString();
                    Spiritolvl.text = (stats.statsDps.Spirito + 1).ToString();

                    //Button
                    abilita1.onClick.AddListener(() => DpsAbility(1, 100));
                    abilita1.image.sprite = AbilityDps[0];
                    Text abilitaText = menuStats.transform.Find("Button/Abilita1/Abilita1/Text").GetComponent<Text>();
                    abilitaText.text = "Movimento oscuro";

                    abilita2.onClick.AddListener(() => DpsAbility(2, 100));
                    abilita2.image.sprite = AbilityDps[1];
                    Text abilitaText2 = menuStats.transform.Find("Button/Abilita2/Abilita2/Text").GetComponent<Text>();
                    abilitaText2.text = "Esortazione";

                    abilita3.onClick.AddListener(() => DpsAbility(3, 100));
                    abilita3.image.sprite = AbilityDps[2];
                    Text abilitaText3 = menuStats.transform.Find("Button/Abilita3/Abilita3/Text").GetComponent<Text>();
                    abilitaText3.text = "Frecce gemelle";

                    abilita4.onClick.AddListener(() => DpsAbility(4, 100));
                    abilita4.image.sprite = AbilityDps[3];
                    Text abilitaText4 = menuStats.transform.Find("Button/Abilita4/Abilita4/Text").GetComponent<Text>();
                    abilitaText4.text = "Dardo avvelenato";

                    abilita5.onClick.AddListener(() => DpsAbility(5, 100));
                    abilita5.image.sprite = AbilityDps[4];
                    Text abilitaText5 = menuStats.transform.Find("Button/Abilita5/Abilita5/Text").GetComponent<Text>();
                    abilitaText5.text = "Pioggia di frecce";
                    break;
                }
            }
    }

    public void MageAbility(int i ,int costo)
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        if (costo < stats.esperience)
        {
            stats.statsMago.abilitaSbloccate[i] = true;
        }
    }

    public void TankAbility(int i, int costo)
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        if (costo < stats.esperience)
        {
            stats.statsTank.abilitaSbloccate[i] = true;
        }
    }

    public void DpsAbility(int i, int costo)
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        if (costo < stats.esperience)
        {
            stats.statsDps.abilitaSbloccate[i] = true;
        }
    }
}
