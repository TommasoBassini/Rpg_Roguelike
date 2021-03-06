﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiControlExploration : MonoBehaviour
{
    public GameObject menuStats;
    public Sprite[] characterSprite;
    public int nCharacter = 0;
    public Button[] buttons;

    public Sprite[] AbilityMage;
    public Sprite[] AbilityTank;
    public Sprite[] AbilityDps;

    private Sprite[] anim = new Sprite[4];

    public Sprite[] animMago;
    public Sprite[] animTank;
    public Sprite[] animDps;

    private bool mageOpen = false;
    private bool tankOpen = false;
    private bool dpsOpen = false;

    private PlayerMovement player;
    public GameObject loaderBox;
    public GameObject abilityBox;

    public int[] step = { 4, 8, 15, 22, 30 };
    public int[] costoAbilita = { 400, 700, 1400, 2500, 5000 };
    public GameObject averiPanel;

    public GameObject info0;
    public GameObject info1;
    public GameObject info2;

    public GameObject tastiPanel;
    public GameObject pausePanel;
    private bool pause = false;

    public bool isMenuOpen = false;
    public GameObject vitaMenu;
    private bool isVita = false;
    public GameObject manaMenu;
    private bool isMana = false;
    public GameObject panelVita;
    public GameObject panelMana;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        AggiornaAveri();
        Invoke("AggiornaMana", 0.1f);
        Invoke("AggiornaVita", 0.1f);
    }

    void OnEnable()
    {
        AggiornaAveri();
        Invoke("AggiornaMana", 0.1f);
        Invoke("AggiornaVita", 0.1f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            if (!isMenuOpen)
            {
                isMenuOpen = true;
                StartCoroutine(AnimImage());
                player.isOpenMenu = true;
                tankOpen = false;
                dpsOpen = false;
                mageOpen = true;
                nCharacter = 1;
                menuStats.SetActive(false);
                menuStats.SetActive(true);
                Invoke("SwitchaChar", 0.01f);
                menuStats.transform.Find("Button/Destrezza/DestrezzaButton").GetComponent<Button>().Select();
                menuStats.transform.Find("Button/Forza/ForzaButton").GetComponent<Button>().Select();
                Text RbText = menuStats.transform.Find("Playermenu/RB/Text").GetComponent<Text>();
                Text LbText = menuStats.transform.Find("Playermenu/LB/Text").GetComponent<Text>();
                RbText.text = "Johell";
                LbText.text = "Jupep";
            }
            else
            {
                isMenuOpen = false;
                player.isOpenMenu = false;
                menuStats.SetActive(false);
                nCharacter = 1;
                StopAllCoroutines();
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && isMenuOpen)
        {
            isMenuOpen = false;
            player.isOpenMenu = false;
            menuStats.SetActive(false);
            nCharacter = 1;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button4) && !isMenuOpen)
        {
            isMenuOpen = false;
            player.isOpenMenu = false;
            menuStats.SetActive(false);
            nCharacter = 1;
        }

        if (Input.GetKey(KeyCode.Joystick1Button6) && !isMenuOpen)
        {
            tastiPanel.SetActive(true);
        }
        else
        {
            tastiPanel.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button5) && isMenuOpen)
        {
            if (nCharacter < 3)
            {
                nCharacter++;
            }
            else
            {
                nCharacter = 1;
            }

            Invoke("SwitchaChar", 0.01f);

            Text RbText = menuStats.transform.Find("Playermenu/RB/Text").GetComponent<Text>();
            Text LbText = menuStats.transform.Find("Playermenu/LB/Text").GetComponent<Text>();
            switch (nCharacter)
            {
                case 1:
                    {
                        RbText.text = "Johell";
                        LbText.text = "Jupep";
                        break;
                    }
                case 2:
                    {
                        RbText.text = "Jupep";
                        LbText.text = "Elibeth";
                        break;
                    }
                case 3:
                    {
                        RbText.text = "Elibeth";
                        LbText.text = "Johell";
                        break;
                    }
                default:
                    break;
            }
        }


        if ((Input.GetKeyUp(KeyCode.Joystick1Button4)) && !isMenuOpen && !player.isSpeaking)
        {
            if (isVita)
            {
                player.isSpeaking = false;
                isVita = false;
                panelMana.GetComponent<Image>().color = new Color(0.83f, 0.83f, 0.83f);
                panelVita.GetComponent<Image>().color = new Color(0.83f, 0.83f, 0.83f);
                vitaMenu.SetActive(false);
                return;
            }
            else
            {                
                isVita = true;
                isMana = false;
                manaMenu.SetActive(false);
                vitaMenu.SetActive(true);
                panelMana.GetComponent<Image>().color = new Color(0.83f, 0.83f, 0.83f);
                panelVita.GetComponent<Image>().color = new Color(0.99f, 0.77f, 0.53f);
                player.isSpeaking = true;
                return;
            }
        }

        if ((Input.GetKeyUp(KeyCode.Joystick1Button5)) && !isMenuOpen && !player.isSpeaking)
        {
            if (isMana)
            {
                player.isSpeaking = false;
                isMana = false;
                panelMana.GetComponent<Image>().color = new Color(0.83f, 0.83f, 0.83f);
                panelVita.GetComponent<Image>().color = new Color(0.83f, 0.83f, 0.83f);
                manaMenu.SetActive(false);
                return;
            }
            else
            {
                player.isSpeaking = true;
                isMana = true;
                isVita = false;
                panelMana.GetComponent<Image>().color = new Color(0.99f, 0.77f, 0.53f);
                panelVita.GetComponent<Image>().color = new Color(0.83f, 0.83f, 0.83f);
                manaMenu.SetActive(true);
                vitaMenu.SetActive(false);
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && !isMenuOpen && isVita)
        {
            player.isSpeaking = false;
            panelMana.GetComponent<Image>().color = new Color(0.83f, 0.83f, 0.83f);
            panelVita.GetComponent<Image>().color = new Color(0.83f, 0.83f, 0.83f);
            isVita = false;
            vitaMenu.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && !isMenuOpen && isMana)
        {
            player.isSpeaking = false;
            panelMana.GetComponent<Image>().color = new Color(0.83f, 0.83f, 0.83f);
            panelVita.GetComponent<Image>().color = new Color(0.83f, 0.83f, 0.83f);
            isMana = false;
            manaMenu.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button4) && isMenuOpen)
        {
            if (nCharacter > 1)
            {
                nCharacter--;
            }
            else
            {
                nCharacter = 3;
            }
            Invoke("SwitchaChar", 0.01f);

            Text RbText = menuStats.transform.Find("Playermenu/RB/Text").GetComponent<Text>();
            Text LbText = menuStats.transform.Find("Playermenu/LB/Text").GetComponent<Text>();
            switch (nCharacter)
            {
                case 1:
                    {
                        RbText.text = "Johell";
                        LbText.text = "Jupep";
                        break;
                    }
                case 2:
                    {
                        RbText.text = "Jupep";
                        LbText.text = "Elibeth";
                        break;
                    }
                case 3:
                    {
                        RbText.text = "Elibeth";
                        LbText.text = "Johell";
                        break;
                    }
                default:
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!mageOpen)
            {
                player.isOpenMenu = true;
                tankOpen = false;
                dpsOpen = false;
                mageOpen = true;
                nCharacter = 1;
                menuStats.SetActive(false);
                menuStats.SetActive(true);
                Invoke("SwitchaChar", 0.01f);
                menuStats.transform.Find("Button/Forza/ForzaButton").GetComponent<Button>().Select();
            }
            else
            {
                mageOpen = false;
                player.isOpenMenu = false;
                menuStats.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!tankOpen)
            {
                player.isOpenMenu = true;
                tankOpen = true;
                dpsOpen = false;
                mageOpen = false;
                nCharacter = 2;
                menuStats.SetActive(false);
                menuStats.SetActive(true);
                Invoke("SwitchaChar", 0.01f);
                menuStats.transform.Find("Button/Forza/ForzaButton").GetComponent<Button>().Select();
            }
            else
            {
                tankOpen = false;
                player.isOpenMenu = false;
                menuStats.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!dpsOpen)
            {
                player.isOpenMenu = true;
                tankOpen = false;
                dpsOpen = true;
                mageOpen = false;
                nCharacter = 3;
                menuStats.SetActive(false);
                menuStats.SetActive(true);
                Invoke("SwitchaChar", 0.01f);
                menuStats.transform.Find("Button/Forza/ForzaButton").GetComponent<Button>().Select();
            }
            else
            {
                dpsOpen = false;
                player.isOpenMenu = false;
                menuStats.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.Joystick1Button7)))
        {
            if (pause)
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1.0f;
            }

            if (tankOpen || dpsOpen || mageOpen)
            {
                player.isOpenMenu = false;
                menuStats.SetActive(false);
                tankOpen = false;
                dpsOpen = false;
                mageOpen = false;
            }
            else
            {
                pause = true;
                pausePanel.SetActive(true);
                Time.timeScale = 0.0f;
                pausePanel.transform.GetChild(0).GetComponent<Button>().Select();
            }
        }

    }

    public void Continua()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Esci()
    {
        Application.Quit();
    }

    public void AggiornaAveri()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        Text esperience = averiPanel.transform.Find("Esperience/Text").GetComponent<Text>();
        esperience.text = stats.esperience.ToString();

        Text blood = averiPanel.transform.Find("Blood/Text").GetComponent<Text>();
        blood.text = stats.soldi.ToString();
    }

    public void AggiornaVita()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();


        Image image = info0.transform.Find("Health").GetComponent<Image>();
        image.fillAmount = ((100 *(float) stats.statsMago.hp) / (float)stats.statsMago.hpMax) / 100;
        Text textVita = info0.transform.Find("VitaText").GetComponent<Text>();
        textVita.text = stats.statsMago.hp.ToString() + "/" + stats.statsMago.hpMax.ToString();

        Image image1 = info1.transform.Find("Health").GetComponent<Image>();
        image1.fillAmount = ((100 * (float)stats.statsTank.hp) / (float)stats.statsTank.hpMax) / 100;
        Text textVita1 = info1.transform.Find("VitaText").GetComponent<Text>();
        textVita1.text = stats.statsTank.hp.ToString() + "/" + stats.statsTank.hpMax.ToString();

        Image image2 = info2.transform.Find("Health").GetComponent<Image>();
        image2.fillAmount = ((100 * (float)stats.statsDps.hp) / (float)stats.statsDps.hpMax) / 100;
        Text textVita2 = info2.transform.Find("VitaText").GetComponent<Text>();
        textVita2.text = stats.statsDps.hp.ToString() + "/" + stats.statsDps.hpMax.ToString();
    }


    public void AggiornaMana()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();


        Image image = info0.transform.Find("Mana").GetComponent<Image>();
        image.fillAmount = ((100 * (float)stats.statsMago.mp) / (float)stats.statsMago.mpMax) / 100;
        Text textVita = info0.transform.Find("ManaText").GetComponent<Text>();
        textVita.text = stats.statsMago.mp.ToString() + "/" + stats.statsMago.mpMax.ToString();

        Image image1 = info1.transform.Find("Mana").GetComponent<Image>();
        image1.fillAmount = ((100 * (float)stats.statsTank.mp) / (float)stats.statsTank.mpMax) / 100;
        Text textVita1 = info1.transform.Find("ManaText").GetComponent<Text>();
        textVita1.text = stats.statsTank.mp.ToString() + "/" + stats.statsTank.mpMax.ToString();

        Image image2 = info2.transform.Find("Mana").GetComponent<Image>();
        image2.fillAmount = ((100 * (float)stats.statsDps.mp) / (float)stats.statsDps.mpMax) / 100;
        Text textVita2 = info2.transform.Find("ManaText").GetComponent<Text>();
        textVita2.text = stats.statsDps.mp.ToString() + "/" + stats.statsDps.mpMax.ToString();
    }
    
    public void AggiornaPotion()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        Text text1 = transform.Find("Vita/Health/Text").GetComponent<Text>();
        text1.text = stats.nPotionHealth.ToString();

        Text text2 = transform.Find("Mana/Mana/Text").GetComponent<Text>();
        text2.text = stats.nPotionMana.ToString();
    }

    public void AggiornaKey()
    {
        PlayerMovement player = FindObjectOfType<PlayerMovement>();

        Text text1 = transform.Find("Keys/Keys/Text").GetComponent<Text>();
        text1.text = player.nKeys.ToString();
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

                    for (int i = 0; i < animMago.Length; i++)
                    {
                        anim[i] = animMago[i];
                    }

                    int livello = stats.statsMago.forza + stats.statsMago.Spirito + stats.statsMago.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();

                    //ParteCentrale
                    Forzalvl.text = (stats.statsMago.forza + 1).ToString();
                    Destrezzalvl.text = (stats.statsMago.destrezza + 1).ToString();
                    Spiritolvl.text = (stats.statsMago.Spirito + 1).ToString();
                    //Button
                    abilita1.onClick.RemoveAllListeners();
                    abilita1.onClick.AddListener(() => MageAbility(0, costoAbilita[0]));
                    BuyAbility ability1 = abilita1.GetComponent<BuyAbility>();
                    abilita1.onClick.AddListener(() => ability1.ShowInfo());

                    abilita1.image.sprite = AbilityMage[1];
                    Text abilitaText = menuStats.transform.Find("Button/Abilita1/Abilita1/Text").GetComponent<Text>();
                    abilitaText.text = "Cura";

                    abilita2.onClick.RemoveAllListeners();
                    abilita2.onClick.AddListener(() => MageAbility(1, costoAbilita[1]));
                    abilita2.image.sprite = AbilityMage[0];
                    BuyAbility ability2 = abilita1.GetComponent<BuyAbility>();
                    abilita2.onClick.AddListener(() => ability2.ShowInfo());
                    Text abilitaText2 = menuStats.transform.Find("Button/Abilita2/Abilita2/Text").GetComponent<Text>();
                    abilitaText2.text = "Protezione";

                    abilita3.onClick.RemoveAllListeners();
                    abilita3.onClick.AddListener(() => MageAbility(2, costoAbilita[2]));
                    BuyAbility ability3 = abilita1.GetComponent<BuyAbility>();
                    abilita3.onClick.AddListener(() => ability3.ShowInfo());
                    abilita3.image.sprite = AbilityMage[2];
                    Text abilitaText3 = menuStats.transform.Find("Button/Abilita3/Abilita3/Text").GetComponent<Text>();
                    abilitaText3.text = "Assorbi anima";

                    abilita4.onClick.RemoveAllListeners();
                    abilita4.onClick.AddListener(() => MageAbility(3, costoAbilita[3]));
                    BuyAbility ability4 = abilita1.GetComponent<BuyAbility>();
                    abilita4.onClick.AddListener(() => ability4.ShowInfo());
                    abilita4.image.sprite = AbilityMage[3];
                    Text abilitaText4 = menuStats.transform.Find("Button/Abilita4/Abilita4/Text").GetComponent<Text>();
                    abilitaText4.text = "Fulmine";

                    abilita5.onClick.RemoveAllListeners();
                    abilita5.onClick.AddListener(() => MageAbility(4, costoAbilita[4]));
                    BuyAbility ability5 = abilita1.GetComponent<BuyAbility>();
                    abilita5.onClick.AddListener(() => ability5.ShowInfo());
                    abilita5.image.sprite = AbilityMage[4];
                    Text abilitaText5 = menuStats.transform.Find("Button/Abilita5/Abilita5/Text").GetComponent<Text>();
                    abilitaText5.text = "Ragnatela";

                    CheckButton();
                    buttons[1].Select();
                    buttons[0].Select();
                    break;
                }
            case 2:
                {
                    nomeText.text = "Johell";

                    for (int i = 0; i < animTank.Length; i++)
                    {
                        anim[i] = animTank[i];
                    }
                    int livello = stats.statsTank.forza + stats.statsTank.Spirito + stats.statsTank.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();

                    //ParteCentrale
                    Forzalvl.text = (stats.statsTank.forza + 1).ToString();
                    Destrezzalvl.text = (stats.statsTank.destrezza + 1).ToString();
                    Spiritolvl.text = (stats.statsTank.Spirito + 1).ToString();

                    //Button
                    abilita1.onClick.RemoveAllListeners();
                    abilita1.onClick.AddListener(() => TankAbility(0, costoAbilita[0]));
                    abilita1.image.sprite = AbilityTank[0];
                    BuyAbility ability1 = abilita1.GetComponent<BuyAbility>();
                    abilita1.onClick.AddListener(() => ability1.ShowInfo());
                    Text abilitaText = menuStats.transform.Find("Button/Abilita1/Abilita1/Text").GetComponent<Text>();
                    abilitaText.text = "Sassata";

                    abilita2.onClick.RemoveAllListeners();
                    abilita2.onClick.AddListener(() => TankAbility(1, costoAbilita[1]));
                    BuyAbility ability2 = abilita1.GetComponent<BuyAbility>();
                    abilita2.onClick.AddListener(() => ability2.ShowInfo());
                    abilita2.image.sprite = AbilityTank[1];
                    Text abilitaText2 = menuStats.transform.Find("Button/Abilita2/Abilita2/Text").GetComponent<Text>();
                    abilitaText2.text = "Percuotere";

                    abilita3.onClick.RemoveAllListeners();
                    abilita3.onClick.AddListener(() => TankAbility(2, costoAbilita[2]));
                    BuyAbility ability3 = abilita1.GetComponent<BuyAbility>();
                    abilita3.onClick.AddListener(() => ability3.ShowInfo());
                    abilita3.image.sprite = AbilityTank[2];
                    Text abilitaText3 = menuStats.transform.Find("Button/Abilita3/Abilita3/Text").GetComponent<Text>();
                    abilitaText3.text = "Frantuma Scudo";

                    abilita4.onClick.RemoveAllListeners();
                    abilita4.onClick.AddListener(() => TankAbility(3, costoAbilita[3]));
                    BuyAbility ability4 = abilita1.GetComponent<BuyAbility>();
                    abilita4.onClick.AddListener(() => ability4.ShowInfo());
                    abilita4.image.sprite = AbilityTank[3];
                    Text abilitaText4 = menuStats.transform.Find("Button/Abilita4/Abilita4/Text").GetComponent<Text>();
                    abilitaText4.text = "Spezza Arma";

                    abilita5.onClick.RemoveAllListeners();
                    abilita5.onClick.AddListener(() => TankAbility(4, costoAbilita[4]));
                    BuyAbility ability5 = abilita1.GetComponent<BuyAbility>();
                    abilita5.onClick.AddListener(() => ability5.ShowInfo());
                    abilita5.image.sprite = AbilityTank[4];
                    Text abilitaText5 = menuStats.transform.Find("Button/Abilita5/Abilita5/Text").GetComponent<Text>();
                    abilitaText5.text = "Spaccateschio";

                    // SetInteractable button
                    CheckButton();
                    buttons[1].Select();
                    buttons[0].Select();
                    break;
                }
            case 3:
                {
                    nomeText.text = "Jupep";

                    for (int i = 0; i < animDps.Length; i++)
                    {
                        anim[i] = animDps[i];
                    }
                    int livello = stats.statsDps.forza + stats.statsDps.Spirito + stats.statsDps.destrezza + 3;
                    textLvl.text = "Livello " + livello.ToString();

                    //ParteCentrale
                    Forzalvl.text = (stats.statsDps.forza + 1).ToString();
                    Destrezzalvl.text = (stats.statsDps.destrezza + 1).ToString();
                    Spiritolvl.text = (stats.statsDps.Spirito + 1).ToString();

                    //Button
                    abilita1.onClick.RemoveAllListeners();
                    abilita1.onClick.AddListener(() => DpsAbility(0, costoAbilita[0]));
                    BuyAbility ability1 = abilita1.GetComponent<BuyAbility>();
                    abilita1.onClick.AddListener(() => ability1.ShowInfo());
                    abilita1.image.sprite = AbilityDps[0];
                    Text abilitaText = menuStats.transform.Find("Button/Abilita1/Abilita1/Text").GetComponent<Text>();
                    abilitaText.text = "Movimento oscuro";

                    abilita2.onClick.RemoveAllListeners();
                    abilita2.onClick.AddListener(() => DpsAbility(1, costoAbilita[1]));
                    BuyAbility ability2 = abilita1.GetComponent<BuyAbility>();
                    abilita2.onClick.AddListener(() => ability2.ShowInfo());
                    abilita2.image.sprite = AbilityDps[1];
                    Text abilitaText2 = menuStats.transform.Find("Button/Abilita2/Abilita2/Text").GetComponent<Text>();
                    abilitaText2.text = "Esortazione";

                    abilita3.onClick.RemoveAllListeners();
                    abilita3.onClick.AddListener(() => DpsAbility(2, costoAbilita[2]));
                    BuyAbility ability3 = abilita1.GetComponent<BuyAbility>();
                    abilita3.onClick.AddListener(() => ability3.ShowInfo());
                    abilita3.image.sprite = AbilityDps[2];
                    Text abilitaText3 = menuStats.transform.Find("Button/Abilita3/Abilita3/Text").GetComponent<Text>();
                    abilitaText3.text = "Frecce gemelle";

                    abilita4.onClick.RemoveAllListeners();
                    abilita4.onClick.AddListener(() => DpsAbility(3, costoAbilita[3]));
                    BuyAbility ability4 = abilita1.GetComponent<BuyAbility>();
                    abilita4.onClick.AddListener(() => ability4.ShowInfo());
                    abilita4.image.sprite = AbilityDps[3];
                    Text abilitaText4 = menuStats.transform.Find("Button/Abilita4/Abilita4/Text").GetComponent<Text>();
                    abilitaText4.text = "Dardo avvelenato";

                    abilita5.onClick.RemoveAllListeners();
                    abilita5.onClick.AddListener(() => DpsAbility(4, costoAbilita[4]));
                    BuyAbility ability5 = abilita1.GetComponent<BuyAbility>();
                    abilita5.onClick.AddListener(() => ability5.ShowInfo());
                    abilita5.image.sprite = AbilityDps[4];
                    Text abilitaText5 = menuStats.transform.Find("Button/Abilita5/Abilita5/Text").GetComponent<Text>();
                    abilitaText5.text = "Pioggia di frecce";

                    // SetInteractable button
                    CheckButton();
                    buttons[1].Select();
                    buttons[0].Select();
                    break;
                }
            }
    }

    public void CheckButton()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        switch (nCharacter)
        {
            case 1:
                {
                    // SetInteractable button
                    if (stats.statsMago.costoForza > stats.esperience)
                    {
                        buttons[0].interactable = false;
                    }
                    else if (stats.statsMago.costoForza <= stats.esperience)
                    {
                        buttons[0].interactable = true;
                    }

                    if (stats.statsMago.costoDestrezza > stats.esperience)
                    {
                        buttons[1].interactable = false;
                    }
                    else if (stats.statsMago.costoDestrezza <= stats.esperience)
                    {
                        buttons[1].interactable = true;
                    }

                    if (stats.statsMago.costoSpirito > stats.esperience)
                    {
                        buttons[2].interactable = false;
                    }
                    else if (stats.statsMago.costoSpirito <= stats.esperience)
                    {
                        buttons[2].interactable = true;
                    }

                    for (int i = 0; i < stats.statsMago.costoAbilita.Length; i++)
                    {
                        if (costoAbilita[i] > stats.esperience || stats.statsMago.livello < step[i])
                        {
                            buttons[i + 3].interactable = false;
                        }
                        else
                            buttons[i + 3].interactable = true;
                    }
                    break;
                }
            case 2:
                {
                    if (stats.statsTank.costoForza > stats.esperience)
                    {
                        buttons[0].interactable = false;
                    }
                    else if (stats.statsTank.costoForza <= stats.esperience)
                    {
                        buttons[0].interactable = true;
                    }

                    if (stats.statsTank.costoDestrezza > stats.esperience)
                    {
                        buttons[1].interactable = false;
                    }
                    else if (stats.statsTank.costoDestrezza <= stats.esperience)
                    {
                        buttons[1].interactable = true;
                    }

                    if (stats.statsTank.costoSpirito > stats.esperience)
                    {
                        buttons[2].interactable = false;
                    }
                    else if (stats.statsTank.costoSpirito <= stats.esperience)
                    {
                        buttons[2].interactable = true;
                    }

                    for (int i = 0; i < stats.statsTank.costoAbilita.Length; i++)
                    {
                        if (costoAbilita[i] > stats.esperience || stats.statsTank.livello < step[i])
                        {
                            buttons[i + 3].interactable = false;
                        }
                        else
                            buttons[i + 3].interactable = true;
                    }
                    break;
                }
            case 3:
                {
                    if (stats.statsDps.costoForza > stats.esperience)
                    {
                        buttons[0].interactable = false;
                    }
                    else if (stats.statsDps.costoForza <= stats.esperience)
                    {
                        buttons[0].interactable = true;
                    }

                    if (stats.statsDps.costoDestrezza > stats.esperience)
                    {
                        buttons[1].interactable = false;
                    }
                    else if (stats.statsDps.costoDestrezza <= stats.esperience)
                    {
                        buttons[1].interactable = true;
                    }

                    if (stats.statsDps.costoSpirito > stats.esperience)
                    {
                        buttons[2].interactable = false;
                    }
                    else if (stats.statsDps.costoSpirito <= stats.esperience)
                    {
                        buttons[2].interactable = true;
                    }

                    for (int i = 0; i < stats.statsDps.costoAbilita.Length; i++)
                    {
                        if (costoAbilita[i] > stats.esperience || stats.statsDps.livello < step[i])
                        {
                            buttons[i + 3].interactable = false;
                        }
                        else
                            buttons[i + 3].interactable = true;
                    }
                    break;
                }
            default:
            break;
        }
    }

    public void MageAbility(int i ,int costo)
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        if (costo < stats.esperience && !stats.statsMago.abilitaSbloccate[i])
        {
            stats.esperience -= costo;
            stats.statsMago.abilitaSbloccate[i] = true;
            AggiornaAveri();
        }

        buttons[0].GetComponent<StatsLvlUp>().CheckCostForza();
        buttons[1].GetComponent<StatsLvlUp>().CheckCostDestrezza();
        buttons[2].GetComponent<StatsLvlUp>().CheckCostSpirito();
    }

    public void TankAbility(int i, int costo)
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        if (costo < stats.esperience && !stats.statsTank.abilitaSbloccate[i])
        {
            stats.esperience -= costo;
            stats.statsTank.abilitaSbloccate[i] = true;
            AggiornaAveri();
        }
        buttons[0].GetComponent<StatsLvlUp>().CheckCostForza();
        buttons[1].GetComponent<StatsLvlUp>().CheckCostDestrezza();
        buttons[2].GetComponent<StatsLvlUp>().CheckCostSpirito();
    }

    public void DpsAbility(int i, int costo)
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        if (costo < stats.esperience && !stats.statsDps.abilitaSbloccate[i])
        {
            stats.esperience -= costo;
            stats.statsDps.abilitaSbloccate[i] = true;
            AggiornaAveri();
        }
        buttons[0].GetComponent<StatsLvlUp>().CheckCostForza();
        buttons[1].GetComponent<StatsLvlUp>().CheckCostDestrezza();
        buttons[2].GetComponent<StatsLvlUp>().CheckCostSpirito();
    }

    IEnumerator AnimImage()
    {
        int i = 0;
        while (isMenuOpen)
        {
            i++;
            if (i == 4)
            {
                i = 0;
            }
            Image charImage = menuStats.transform.Find("Character/CharacterSprite").GetComponent<Image>();
            charImage.sprite = anim[i];
            yield return new WaitForSeconds(0.15f);
        }
    }
}
