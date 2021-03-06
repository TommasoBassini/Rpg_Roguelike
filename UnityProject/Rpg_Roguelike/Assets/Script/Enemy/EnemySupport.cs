﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySupport : Enemy
{
    public bool isPlayerNear = false;
    private Vector2 endPos;

    public GameObject curaEffect;
    public Sprite curaSprite;
    public Sprite alpha;

    public GameObject attaccoSprite;
    public Sprite attaccoSpriteBox;
    GameObject target;
    Vector2 targetPos;

    public AudioClip audioCura;

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
        player.SubisciDannoMagico(att);
        yield return new WaitForSeconds(2);
        cc.EndOfTurn();
    }

    public override void Ai()
    {
        bool enemyInDifficolta = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var _enemy in enemies)
        {
            if (_enemy.GetComponent<Enemy>() != null)
            {
                Enemy enemy = _enemy.GetComponent<Enemy>();
                int soglia = Mathf.RoundToInt((enemy.hpMax * 40) / 100);
                if (enemy.hp < soglia)
                {
                    target = _enemy;
                    targetPos = enemy.pos;
                    enemyInDifficolta = true;
                    break;
                }
            }
        }
        if (enemyInDifficolta)
        {
            int random = (int)Random.Range(0.0f, 100.0f);
            if (grid.CheckTarget(this.pos, this.passi, targetPos) && random > 65)
            {
                StartCoroutine(Cura(grid.cells[(int)targetPos.x, (int)targetPos.y].occupier));
            }
            else
            {
                NearestCellToPlayer(base.pos, this.passi, target);
            }
        }
        else
        {
            Invoke("CheckPlayerNear", 0.5f);
        }
    }


    void CheckPlayerNear()
    {
        if (grid.EnemyCheckPlayer(this.pos, this.passi, this.gameObject, out targetPos))
        {
            StartCoroutine(Attacco((grid.cells[(int)targetPos.x, (int)targetPos.y].occupier)));
            StartCoroutine(Attack(grid.cells[(int)targetPos.x, (int)targetPos.y].occupier));
        }
        else
        {
            FindNearestPlayer();
        }
    }

    IEnumerator Cura(GameObject _player)
    {
        CombatController cc = FindObjectOfType<CombatController>();
        Enemy enemy = _player.GetComponent<Enemy>();
        //costo e variabili
        int cura = Mathf.RoundToInt((enemy.hpMax * 25) / 100);
        //calcola effetto
        enemy.hp += cura;
        GameObject effect = Instantiate(curaEffect);
        effect.transform.position = _player.transform.position;
        AudioSource audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audio.PlayOneShot(audioCura);
        //roba per ui
        UiController ui = FindObjectOfType<UiController>();
        ui.DamageText(_player, cura, Color.green);
        GameObject info = GameObject.Find("EnemyInfo");
        Image icona = ui.enemyInfoPanel.transform.Find("Image").GetComponent<Image>();
        icona.sprite = curaSprite;
        Text nome = ui.enemyInfoPanel.transform.Find("NomeSpell").GetComponent<Text>();
        nome.text = "Cura";
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
