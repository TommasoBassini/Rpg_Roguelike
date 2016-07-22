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

    void Start()
    {

        nome = info.transform.Find("NomeSpell").GetComponent<Text>();
        icona = info.transform.Find("Image").GetComponent<Image>();
        spiegazione = info.transform.Find("Info").GetComponent<Text>();
        costoMp = info.transform.Find("Mp").GetComponent<Text>();
    }

    public void InfoText()
    {
        info.SetActive(true);

        nome.text = nomeString;
        icona.sprite = immagine;
        spiegazione.text = spiegazioneText;
        costoMp.text = costoText;
    }
}
