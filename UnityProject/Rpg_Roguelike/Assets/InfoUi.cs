using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoUi : MonoBehaviour
{

    public GameObject info;

    private Text nome;
    public string nomeString;

    private Image icona;
    public Sprite immagine;

    private Text spiegazione;
    public string spiegazioneText;

    private Text costoMp;
    public string costoText;

    public Sprite fullAlpha;

    void Awake()
    {

        icona = info.transform.Find("Image").GetComponent<Image>();
        spiegazione = info.transform.Find("Info").GetComponent<Text>();
        costoMp = info.transform.Find("Mp").GetComponent<Text>();
        nome = info.transform.Find("NomeSpell").GetComponent<Text>();
    }

    public void InfoText()
    {
        
        Image vita = info.transform.Find("Health").GetComponent<Image>();
        vita.color = new Color(vita.color.r, vita.color.g, vita.color.b, 0);
        Image BaseHealth = info.transform.Find("BaseHealth").GetComponent<Image>();
        BaseHealth.color = new Color(BaseHealth.color.r, BaseHealth.color.g, BaseHealth.color.b, 0);
        Text textVita = info.transform.Find("HealthText").GetComponent<Text>();
        textVita.text = "";

        info.SetActive(true);

        nome.text = nomeString;
        icona.sprite = immagine;
        spiegazione.text = spiegazioneText;
        costoMp.text = costoText;
    }

    public void ClearInfo()
    {
        info.SetActive(true);

        nome.text = "";
        icona.sprite = fullAlpha;
        spiegazione.text = "";
        costoMp.text = "";
    }
}
