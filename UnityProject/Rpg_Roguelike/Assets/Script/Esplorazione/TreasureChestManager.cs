using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TreasureChestManager : MonoBehaviour
{
    public bool hpPotion;
    public bool mpPotion;
    public bool tankPowerUp;
    public bool dpsPowerUp;
    public bool magePowerUp;
    public bool soldi;
    public int nSoldi;
    public bool isClosed = true;
    public bool inFront = false;
    public Sprite openChest;
    private SpriteRenderer sr;
    public GameObject interact;

    public GameObject panelAvvisi;

    public Sprite vitaGrande;
    public Sprite manaGrande;
    public Sprite tankPowerUpSprite;
    public Sprite magePowerUpSprite;
    public Sprite dpsPowerUpSprite;
    public Sprite soldiSprite;
    public AudioClip openChests;
    private GameControl gc;

    void Start()
    {
        Invoke("SetObjectToCell", 0.3f);
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
        gc = FindObjectOfType<GameControl>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && isClosed == false )
        {
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            player.isSpeaking = false;
            panelAvvisi.SetActive(false);
            return;
        }

         if (inFront == true && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyUp(KeyCode.Joystick1Button0)) && isClosed == true && !gc.incontroON) 
        {
            GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(openChests);
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            player.isSpeaking = true;
            Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
            Grid grid = FindObjectOfType<Grid>();
            grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = this.gameObject;
            grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isSemiWall = true;
            

            isClosed = false;
            if (hpPotion)
            {
                PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
                UiControlExploration ui = FindObjectOfType<UiControlExploration>();
                stats.nPotionHealth++;
                ui.AggiornaPotion();

                panelAvvisi.SetActive(true);

                Text titolo = panelAvvisi.transform.Find("Titolo").GetComponent<Text>();
                Image image = panelAvvisi.transform.Find("Image").GetComponent<Image>();
                Text info = panelAvvisi.transform.Find("Info").GetComponent<Text>();

                titolo.text = "Hai trovato: Essenza di vita";
                image.sprite = vitaGrande;
                info.text = "Usa questo oggetto per ripristinare la vita";
            }
            if (mpPotion)
            {
                PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
                UiControlExploration ui = FindObjectOfType<UiControlExploration>();
                stats.nPotionMana++;
                ui.AggiornaPotion();

                panelAvvisi.SetActive(true);

                Text titolo = panelAvvisi.transform.Find("Titolo").GetComponent<Text>();
                Image image = panelAvvisi.transform.Find("Image").GetComponent<Image>();
                Text info = panelAvvisi.transform.Find("Info").GetComponent<Text>();

                titolo.text = "Hai trovato: Essenza di mana";
                image.sprite = manaGrande;
                info.text = "Usa questo oggetto per ripristinare il mana";
            }
            if (soldi)
            {
                PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
                UiControlExploration ui = FindObjectOfType<UiControlExploration>();
                stats.soldi += nSoldi;
                ui.AggiornaAveri();

                panelAvvisi.SetActive(true);

                Text titolo = panelAvvisi.transform.Find("Titolo").GetComponent<Text>();
                Image image = panelAvvisi.transform.Find("Image").GetComponent<Image>();
                Text info = panelAvvisi.transform.Find("Info").GetComponent<Text>();

                titolo.text = "Hai trovato: " + nSoldi.ToString() + " soldi";
                image.sprite = soldiSprite;
                info.text = "Usali per acquistare pozioni";
            }
            if (tankPowerUp)
            {
                PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
                UiControlExploration ui = FindObjectOfType<UiControlExploration>();

                stats.statsTank.livello++;
                stats.statsTank.forza++;
                stats.statsTank.hpMax += stats.incrementiTank.hpPerForza;
                stats.statsTank.mpMax += stats.incrementiTank.mpPerForza;
                stats.statsTank.attMelee += stats.incrementiTank.attMeleePerForza;
                stats.statsTank.attDistanza += stats.incrementiTank.attDistanzaPerForza;
                stats.statsTank.attMagico += stats.incrementiTank.attMagicoPerForza;
                stats.statsTank.difFisica += stats.incrementiTank.difFisicaPerForza;
                stats.statsTank.difMagica += stats.incrementiTank.difMagicaPerForza;
                stats.statsTank.velocita += stats.incrementiTank.velocitaPerForza;

                ui.AggiornaMana();
                ui.AggiornaVita();

                panelAvvisi.SetActive(true);

                Text titolo = panelAvvisi.transform.Find("Titolo").GetComponent<Text>();
                Image image = panelAvvisi.transform.Find("Image").GetComponent<Image>();
                Text info = panelAvvisi.transform.Find("Info").GetComponent<Text>();

                titolo.text = "Hai trovato: Runa della forza";
                image.sprite = tankPowerUpSprite;
                info.text = "Questo oggetto ha aumentato la caratteristica forza di Johell";
            }
            if (magePowerUp)
            {
                PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
                UiControlExploration ui = FindObjectOfType<UiControlExploration>();

                stats.statsMago.livello++;
                stats.statsMago.Spirito++;
                stats.statsMago.hpMax += stats.incrementiMago.hpPerSpirito;
                stats.statsMago.mpMax += stats.incrementiMago.mpPerSpirito;
                stats.statsMago.attMelee += stats.incrementiMago.attMeleePerSpirito;
                stats.statsMago.attDistanza += stats.incrementiMago.attDistanzaPerSpirito;
                stats.statsMago.attMagico += stats.incrementiMago.attMagicoPerSpirito;
                stats.statsMago.difFisica += stats.incrementiMago.difFisicaPerSpirito;
                stats.statsMago.difMagica += stats.incrementiMago.difMagicaPerSpirito;
                stats.statsMago.velocita += stats.incrementiMago.velocitaPerSpirito;

                ui.AggiornaMana();
                ui.AggiornaVita();

                panelAvvisi.SetActive(true);

                Text titolo = panelAvvisi.transform.Find("Titolo").GetComponent<Text>();
                Image image = panelAvvisi.transform.Find("Image").GetComponent<Image>();
                Text info = panelAvvisi.transform.Find("Info").GetComponent<Text>();

                titolo.text = "Hai trovato: Runa dello spirito";
                image.sprite = magePowerUpSprite;
                info.text = "Questo oggetto ha aumentato la caratteristica sprito di Elibeth";
            }
            if (dpsPowerUp)
            {
                PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
                UiControlExploration ui = FindObjectOfType<UiControlExploration>();

                stats.statsDps.livello++;
                stats.statsDps.destrezza++;
                stats.statsDps.hpMax += stats.incrementiDps.hpPerDestrezza;
                stats.statsDps.mpMax += stats.incrementiDps.mpPerDestrezza;
                stats.statsDps.attMelee += stats.incrementiDps.attMeleePerDestrezza;
                stats.statsDps.attDistanza += stats.incrementiDps.attDistanzaPerDestrezza;
                stats.statsDps.attMagico += stats.incrementiDps.attMagicoPerDestrezza;
                stats.statsDps.difFisica += stats.incrementiDps.difFisicaPerDestrezza;
                stats.statsDps.difMagica += stats.incrementiDps.difMagicaPerDestrezza;
                stats.statsDps.velocita += stats.incrementiDps.velocitaPerDestrezza;

                ui.AggiornaMana();
                ui.AggiornaVita();

                panelAvvisi.SetActive(true);

                Text titolo = panelAvvisi.transform.Find("Titolo").GetComponent<Text>();
                Image image = panelAvvisi.transform.Find("Image").GetComponent<Image>();
                Text info = panelAvvisi.transform.Find("Info").GetComponent<Text>();

                titolo.text = "Hai trovato: Runa della destrezza";
                image.sprite = dpsPowerUpSprite;
                info.text = "Questo oggetto ha aumentato la caratteristica destrezza di Jupep";
            }
            sr.sprite = openChest;
            return;
        }
    }

    void SetObjectToCell()
    {
        Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
        Grid grid = FindObjectOfType<Grid>();
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = this.gameObject;
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isSemiWall = true;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = 100 - (int)pos.y;
    }


    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player" && isClosed == true)
        {
            inFront = true;
            Text text = interact.transform.Find("A/Text").GetComponent<Text>();
            text.text = "Apri scrigno";
            interact.SetActive(true);
        }          
	}

    void OnTriggerExit2D(Collider2D coll)
    {
        inFront = false;
        interact.SetActive(false);
    }
}
