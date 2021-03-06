﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyRanged : Enemy
{
    public bool isPlayerNear = false;
    private Vector2 endPos;

    public GameObject dardoVeleno;
    public GameObject veleno;
    public Sprite dardoAvvelenato;
    public Sprite alpha;

    public GameObject attaccoSprite;
    public Sprite attaccoSpriteBox;

    public AudioClip audioAttaccoVeleno;

    public override void Ai()
    {
        Invoke("CheckPlayerNear", 0.5f);
    }

    public override IEnumerator Attack(GameObject Target)
    {
        CombatController cc = FindObjectOfType<CombatController>();
        Animator anim = GetComponent<Animator>();

        if (Target.transform.position.x > this.transform.position.x)
        {
            anim.SetTrigger("AttackRight");
        }
        else
        {
            anim.SetTrigger("AttackLeft");
        }
        yield return new WaitForSeconds(0.5f);
        if (attackEffect != null)
        {
            GameObject effect = Instantiate(attackEffect);
            effect.transform.position = Target.transform.position;
        }
        // Suono
        if (audioAttack != null)
        {
            AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
            audio.PlayOneShot(audioAttack);
        }

        Player player = Target.GetComponent<Player>();
        player.SubisciDanno(att);
        yield return new WaitForSeconds(2);
        cc.EndOfTurn();
    }

    void CheckPlayerNear()
    {
        Vector2 targetPos;
        if (grid.EnemyCheckPlayer(this.pos, this.passi, this.gameObject, out targetPos))
        {
            ChooseAbility(targetPos);
        }
        else
        {
            FindNearestPlayer();
        }
    }

    void ChooseAbility(Vector2 targetPos)
    {
        float random = Random.Range(0.0f, 100.0f);
        if (random > 80)
        {
            if (grid.cells[(int)targetPos.x, (int)targetPos.y].occupier.GetComponent<Player>().turniVeleno == 0)
            {
                StartCoroutine(Poison(grid.cells[(int)targetPos.x, (int)targetPos.y].occupier));
            }
            else
            {
                StartCoroutine(Attacco((grid.cells[(int)targetPos.x, (int)targetPos.y].occupier)));
                StartCoroutine(Attack(grid.cells[(int)targetPos.x, (int)targetPos.y].occupier));
            }
        }
        else
        {
            StartCoroutine(Attacco((grid.cells[(int)targetPos.x, (int)targetPos.y].occupier)));
            StartCoroutine(Attack(grid.cells[(int)targetPos.x, (int)targetPos.y].occupier));
        }
    }

    IEnumerator Poison(GameObject _player)
    {
        CombatController cc = FindObjectOfType<CombatController>();

        //costo e variabili
        int nturni = 2;
        int percentualeVeleno = 5;
        int danni = att;
        //calcola effetto
        Player player = _player.GetComponent<Player>();
        GameObject effect = Instantiate(dardoVeleno);
        effect.transform.position = _player.transform.position;
        GameObject effect1 = Instantiate(veleno);
        effect1.transform.SetParent(_player.transform);
        effect1.transform.position = _player.transform.position;
        player.turniVeleno += nturni;
        player.percVeleno = percentualeVeleno;

        AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audio.PlayOneShot(audioAttaccoVeleno);

        //roba per ui
        UiController ui = FindObjectOfType<UiController>();
        GameObject info = GameObject.Find("EnemyInfo");
        Image icona = ui.enemyInfoPanel.transform.Find("Image").GetComponent<Image>();
        icona.sprite = dardoAvvelenato;
        Text nome = ui.enemyInfoPanel.transform.Find("NomeSpell").GetComponent<Text>();
        nome.text = "Dardo Avvelenato";
        Image vita = ui.enemyInfoPanel.transform.Find("Health").GetComponent<Image>();
        vita.color = new Color(vita.color.r, vita.color.g, vita.color.b, 0);
        Image BaseHealth = ui.enemyInfoPanel.transform.Find("BaseHealth").GetComponent<Image>();
        BaseHealth.color = new Color(BaseHealth.color.r, BaseHealth.color.g, BaseHealth.color.b, 0);
        Text textVita = ui.enemyInfoPanel.transform.Find("HealthText").GetComponent<Text>();
        textVita.text = "";
        yield return new WaitForSeconds(1.5f);
        icona.sprite = alpha;
        nome.text = "";

        cc.EndOfTurn();
    }

    IEnumerator Attacco(GameObject _player)
    {
        //roba per ui
        GameObject effect = Instantiate(attaccoSprite);
        effect.transform.position = _player.transform.position;
        UiController ui = FindObjectOfType<UiController>();
        GameObject info = GameObject.Find("EnemyInfo");
        Image icona = info.transform.Find("Image").GetComponent<Image>();
        icona.sprite = attaccoSpriteBox;
        Text nome = info.transform.Find("NomeSpell").GetComponent<Text>();
        nome.text = "Attacco";
        Image vita = ui.enemyInfoPanel.transform.Find("Health").GetComponent<Image>();
        vita.color = new Color(vita.color.r, vita.color.g, vita.color.b, 0);
        Image BaseHealth = ui.enemyInfoPanel.transform.Find("BaseHealth").GetComponent<Image>();
        BaseHealth.color = new Color(BaseHealth.color.r, BaseHealth.color.g, BaseHealth.color.b, 0);
        Text textVita = ui.enemyInfoPanel.transform.Find("HealthText").GetComponent<Text>();
        textVita.text = "";
        yield return new WaitForSeconds(1.5f);
        icona.sprite = alpha;
        nome.text = "";
    }
}
