﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class IncrementiNemici
{
    public int hpMax;
    public int att;
    public int difesa;
}

public abstract class Enemy : Character
{

    public abstract void Ai();
    public abstract IEnumerator Attack(GameObject Target);
    public List<CombatCell> cellToCross = new List<CombatCell>();

    public Sprite icona;

    public int level;

    public int hpMax;
    public int hp;
    public int difesa;
    public int difesaMagica;
    public int att;


    public AudioClip audioAttack;

    public GameObject attackEffect;

    // liste debuff
    public List<int> nturnoDifesa = new List<int>();
    public List<int> debuffDifesa = new List<int>();

    public List<int> nturnoAttacco = new List<int>();
    public List<int> debuffAttacco = new List<int>();

    public int turniVeleno = 0;
    public int percVeleno;

    public bool stun = false;

    public GameObject[] playersDefault;

    public IncrementiNemici incrementi;

    new void Start()
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        level = Random.Range(stats.livelloNemici - 1, stats.livelloNemici + 3);
        if (level == 0)
        {
            level = 1;
        }
        grid = FindObjectOfType<BattleGrid>();
        hpMax += (incrementi.hpMax * (level -1));
        hp = hpMax;
        difesa += (incrementi.difesa * (level -1));
        difesaMagica += (incrementi.difesa * (level - 1));
        att += (incrementi.att * (level -1));
        CombatController cc = FindObjectOfType<CombatController>();
        cc.enemyLvl.Add(level);
    }

    public void FindNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject nearestPlayer = null;
        int nearestPlayerDistance = 10000;

        // Cerca il GO player più vicino
        if (players.Length != 0)
        {
            foreach (GameObject player in players)
            {
                if (player.GetComponent<Player>() != null)
                {
                    Player pl = player.GetComponent<Player>();
                    int distance = Mathf.Abs((int)pl.pos.x - (int)base.pos.x) + Mathf.Abs((int)pl.pos.y - (int)base.pos.y);
                    if (distance <= (nearestPlayerDistance))
                    {
                        nearestPlayerDistance = distance;
                        nearestPlayer = player;
                    }
                }
            }
            if (nearestPlayer != null)
            {
                NearestCellToPlayer(base.pos, this.passi, nearestPlayer);
            }
            else
                FindNearestPlayer();
        }
    }

    public void NearestCellToPlayer(Vector2 _pos, int raggio, GameObject playerNear)
    {
        if (playerNear.GetComponent<Player>() != null)
        {
            Player player = playerNear.GetComponent<Player>();
            CombatCell nearestCell = null;
            int nearestCellDistance = 10000;

            int _x = (int)_pos.x;
            int _y = (int)_pos.y;

            // incomincia a scansionare l'area
            for (int i = (_x - raggio); i <= (_x + raggio); i++)
            {
                for (int y = (_y - raggio); y <= (_y + raggio); y++)
                {
                    if (i < 0)
                        continue;
                    if (y < 0)
                        continue;
                    if (i > base.grid.width - 1)
                        continue;
                    if (y > base.grid.height - 1)
                        continue;

                    int distance = Mathf.Abs(i - (int)player.pos.x) + Mathf.Abs(y - (int)player.pos.y);
                    if (distance <= nearestCellDistance && !base.grid.cells[i, y].isOccupied && Mathf.Abs(i - _x) + Mathf.Abs(y - _y) < raggio)
                    {
                        nearestCellDistance = distance;
                        nearestCell = base.grid.cells[i, y];
                    }
                }
            }

            if (nearestCell != null)
                StartCoroutine(GoToEndCell(_pos, nearestCell.pos));
        }
        else
            FindNearestPlayer();
    }



    IEnumerator GoToEndCell(Vector2 _pos, Vector2 endPos)
    {

        CombatController cc = FindObjectOfType<CombatController>();
        BattleGrid grid = FindObjectOfType<BattleGrid>();

        grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = false;
        int x = (int)endPos.x - (int)_pos.x;
        int y = (int)endPos.y - (int)_pos.y;

        if (x != 0)
        {
            int zx = x / Mathf.Abs(x);
            for (int i = 1; i < Mathf.Abs(x) + 1; i++)
            {
                cellToCross.Add(base.grid.cells[((int)this.pos.x + (zx * i)), (int)this.pos.y]);
            }
        }

        //Prendo l'ultima cella trovata se c'è
        if (cellToCross.Count != 0)
            x = (int)cellToCross[cellToCross.Count - 1].GetComponent<CombatCell>().pos.x;
        else
            x = (int)_pos.x;

        if (y != 0)
        {
            int zy = y / Mathf.Abs(y);
            for (int j = 1; j < Mathf.Abs(y) + 1; j++)
            {
                cellToCross.Add(base.grid.cells[x, (int)this.pos.y + (zy * j)]);
            }
        }
        int newX = (int)_pos.x;
        Animator anim = GetComponent<Animator>();
        if (newX < (int)endPos.x)
        {
            anim.SetBool("WalkRight", true);
        }
        if (newX >= (int)endPos.x)
        {
            anim.SetBool("WalkLeft", true);
        }

        foreach (CombatCell item in cellToCross)
        {
            Vector3 distance;
            Vector3 direction;
            bool isMoving = true;

            while (isMoving)
            {
                distance = item.gameObject.transform.position - this.transform.position;
                direction = distance.normalized;
                this.transform.position = this.transform.position + direction * Time.deltaTime * 2;
                if (distance.sqrMagnitude < 0.01f)
                {
                    isMoving = false;
                    this.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, 0);
                }
                base.pos = item.pos;
                yield return null;
            }
            //  this.transform.position = item.gameObject.transform.position;
            // 
            //SpriteRenderer sr2 = item.gameObject.GetComponent<SpriteRenderer>();
            //sr2.color = Color.white;
        }
        anim.SetBool("WalkLeft", false);
        anim.SetBool("WalkRight", false);
        anim.SetBool("IdleLeft", true);
        grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = true;
        grid.cells[(int)this.pos.x, (int)this.pos.y].occupier = this.gameObject;
        cellToCross.Clear();
        cc.EndOfTurn();
    }

    public IEnumerator GoToCellNearPlayer(Vector2 _pos, Vector2 PlayerPos)
    {
        // prendo i componenti che mi servono
        BattleGrid grid = FindObjectOfType<BattleGrid>();

        // mi setto la posizione del player
        Vector2 oldPlayerPos = PlayerPos;

        // creo una lista dei posti disponibili attorno al player
        List<Vector2> posDisp = new List<Vector2>();

        //classico controllo delle direzioni
        Vector2[] directions = new Vector2[4];

        directions[0] = new Vector2(-1, 0);
        directions[1] = new Vector2(0, -1);
        directions[2] = new Vector2(1, 0);
        directions[3] = new Vector2(0, 1);

        foreach (Vector2 dir in directions)
        {
            int new_x = (int)PlayerPos.x + (int)dir.x;
            int new_y = (int)PlayerPos.y + (int)dir.y;

            if (new_x < 0)
                continue;
            if (new_y < 0)
                continue;
            if (new_x > base.grid.width - 1)
                continue;
            if (new_y > base.grid.height - 1)
                continue;
            //se non esce dalla griglia e non è occupata aggiungo la posizione alla lista posDisp
            if (!base.grid.cells[new_x, new_y].isOccupied)
                posDisp.Add(dir);
        }
        //se c'è qualcosa nella lista aggiungo un vettore casuale (fra quelli disponibili) al posizione del player
        if (posDisp.Count > 0)
        {
            PlayerPos += posDisp[Random.Range(0, posDisp.Count)];

            //Metto che la cella attuale non è più occupata
            grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = false;

            // Uso il metodo usato di sopra e mi muovo nella cella trovata
            int x = (int)PlayerPos.x - (int)_pos.x;
            int y = (int)PlayerPos.y - (int)_pos.y;

            if (x != 0)
            {
                int zx = x / Mathf.Abs(x);
                for (int i = 1; i < Mathf.Abs(x) + 1; i++)
                {
                    cellToCross.Add(base.grid.cells[((int)this.pos.x + (zx * i)), (int)this.pos.y]);
                }
            }

            //Prendo l'ultima cella trovata se c'è
            if (cellToCross.Count != 0)
                x = (int)cellToCross[cellToCross.Count - 1].GetComponent<CombatCell>().pos.x;
            else
                x = (int)_pos.x;

            if (y != 0)
            {
                int zy = y / Mathf.Abs(y);
                for (int j = 1; j < Mathf.Abs(y) + 1; j++)
                {
                    cellToCross.Add(base.grid.cells[x, (int)this.pos.y + (zy * j)]);
                }
            }
        }

        int newX = (int)_pos.x;
        Animator anim = GetComponent<Animator>();
        if (newX < (int)PlayerPos.x)
        {
            anim.SetBool("WalkRight", true);
        }
        if (newX >= (int)PlayerPos.x)
        {
            anim.SetBool("WalkLeft", true);
        }

        // si muove fra le celle trovate
        foreach (CombatCell item in cellToCross)
        {
            Vector3 distance;
            Vector3 direction;
            bool isMoving = true;

            while (isMoving)
            {
                distance = item.gameObject.transform.position - this.transform.position;
                direction = distance.normalized;
                this.transform.position = this.transform.position + direction * Time.deltaTime * 2;
                if (distance.sqrMagnitude < 0.01f)
                {
                    isMoving = false;
                    this.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, 0);
                }
                base.pos = item.pos;
                yield return null;
            }
        }

        anim.SetBool("WalkLeft", false);
        anim.SetBool("WalkRight", false);
        if (PlayerPos.x > this.pos.x)
        {
            anim.SetBool("IdleRight", true);
        }
        else
        {
            anim.SetBool("IdleLeft", true);
        }
        // Setta la varie variabili e resetta la lista e fa iniziare la coroutine di attacco
        grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = true;
        grid.cells[(int)this.pos.x, (int)this.pos.y].occupier = this.gameObject;
        cellToCross.Clear();
        StartCoroutine(Attack(base.grid.cells[(int)oldPlayerPos.x, (int)oldPlayerPos.y].occupier));
    }

    public void SubisciDannoMelee(int danni, GameObject enemy)
    {
        int danniTot = Mathf.RoundToInt(((((danni / difesa) * 100) * (danni / 2)) / 100) * (Random.Range(1.0f, 1.5f)));
        hp = hp - danniTot;
        CombatController cc = FindObjectOfType<CombatController>();
        UiController ui = FindObjectOfType<UiController>();
        ui.DamageText(enemy, danniTot, Color.red);
        if (hp <= 0)
        {
            List<int> n = new List<int>();
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = false;
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].occupier = null;
            //cc.player.RemoveAll(item => item == enemy);
            for (int j = cc.turno +1; j < cc.player.Count; j++)
            {
                if (cc.player[j] == enemy)
                    n.Add(j);
            }
            for (int i = n.Count - 1; i >= 0; i--)
            {
                cc.player.RemoveAt(n[i]);
            }
            if (!cc.CheckWinner())
                cc.UpdateTurnPortrait();
            else
                cc.Win();
            Destroy(this.gameObject);
        }
        Image vita = ui.enemyInfoPanel.transform.Find("Health").GetComponent<Image>();
        float _hp = (float)this.hp;
        float _hpMax = (float)this.hpMax;
        vita.fillAmount = ((100 * _hp) / _hpMax) / 100;
        Text textVita = ui.enemyInfoPanel.transform.Find("HealthText").GetComponent<Text>();
        textVita.text = hp + "/" + hpMax;
    }

    public void SubisciDannoRanged(int danni, GameObject enemy)
    {
        int danniTot = Mathf.RoundToInt(((((danni / difesa) * 100) * (danni / 2)) / 100) * (Random.Range(1.0f, 1.5f)));
        hp = hp - danniTot;
        UiController ui = FindObjectOfType<UiController>();
        ui.DamageText(enemy, danniTot, Color.red);
        CombatController cc = FindObjectOfType<CombatController>();

        if (hp <= 0)
        {
            hp = 0;
            List<int> n = new List<int>();
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = false;
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].occupier = null;
            //cc.player.RemoveAll(item => item == enemy);
            for (int j = cc.turno + 1; j < cc.player.Count; j++)
            {
                if (cc.player[j] == enemy)
                    n.Add(j);
            }
            for (int i = n.Count - 1; i >= 0; i--)
            {
                cc.player.RemoveAt(n[i]);
            }
            if (!cc.CheckWinner())
                cc.UpdateTurnPortrait();
            else
                cc.Win();
            Destroy(this.gameObject);
        }
        Image vita = ui.enemyInfoPanel.transform.Find("Health").GetComponent<Image>();
        float _hp = (float)this.hp;
        float _hpMax = (float)this.hpMax;
        vita.fillAmount = ((100 * _hp) / _hpMax) / 100;
        Text textVita = ui.enemyInfoPanel.transform.Find("HealthText").GetComponent<Text>();
        textVita.text = hp + "/" + hpMax;
    }

    public int SubisciDannoRangedAndReturn(int danni, GameObject enemy)
    {
        int danniTot = Mathf.RoundToInt(((((danni / difesa) * 100) * (danni / 2)) / 100) * (Random.Range(1.0f, 1.5f)));
        hp = hp - danniTot;
        UiController ui = FindObjectOfType<UiController>();
        ui.DamageText(enemy, danniTot, Color.red);
        CombatController cc = FindObjectOfType<CombatController>();
        if (hp <= 0)
        {
            List<int> n = new List<int>();
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = false;
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].occupier = null;
            //cc.player.RemoveAll(item => item == enemy);
            for (int j = cc.turno + 1; j < cc.player.Count; j++)
            {
                if (cc.player[j] == enemy)
                    n.Add(j);
            }
            for (int i = n.Count - 1; i >= 0; i--)
            {
                cc.player.RemoveAt(n[i]);
            }

            if (!cc.CheckWinner())
                cc.UpdateTurnPortrait();
            else
            {
                cc.win = true;
                cc.Win();
            }
            Destroy(this.gameObject);
        }
        return danniTot;
    }

    public void SubisciDannoMagico(int danni, GameObject enemy)
    {
        int danniTot = Mathf.RoundToInt(((((danni / difesaMagica) * 100) * (danni / 2)) / 100) * (Random.Range(1.0f, 1.5f)));
        hp = hp - danniTot;
        UiController ui = FindObjectOfType<UiController>();
        ui.DamageText(enemy, danniTot, Color.red);
        CombatController cc = FindObjectOfType<CombatController>();

        if (hp <= 0)
        {
            hp = 0;
            List<int> n = new List<int>();
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = false;
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].occupier = null;
            //cc.player.RemoveAll(item => item == enemy);
            for (int j = cc.turno + 1; j < cc.player.Count; j++)
            {
                if (cc.player[j] == enemy)
                    n.Add(j);
            }
            for (int i = n.Count - 1; i >= 0; i--)
            {
                cc.player.RemoveAt(n[i]);
            }

            if (!cc.CheckWinner())
                cc.UpdateTurnPortrait();
            else
            {
                cc.win = true;
                cc.Win();
            }
            Destroy(this.gameObject);
        }
        Image vita = ui.enemyInfoPanel.transform.Find("Health").GetComponent<Image>();
        float _hp = (float)this.hp;
        float _hpMax = (float)this.hpMax;
        vita.fillAmount = ((100 * _hp) / _hpMax) / 100;
        Text textVita = ui.enemyInfoPanel.transform.Find("HealthText").GetComponent<Text>();
        textVita.text = hp + "/" + hpMax;
    }

    public void StartTurn()
    {
        if(nturnoDifesa.Count != 0)
        {
            CheckDebuffDifesa();
        }

        if (nturnoAttacco.Count != 0)
        {
            CheckDebuffAttacco();
        }
        if(turniVeleno > 0)
        {
            CheckVeleno();
        }
    }

    void CheckDebuffDifesa()
    {
        for (int i = nturnoDifesa.Count - 1; i >= 0; i--)
        {
            nturnoDifesa[i]--;
            if(nturnoDifesa[i] == 0)
            {
                difesa += debuffDifesa[i];
                debuffDifesa.RemoveAt(i);
                nturnoDifesa.RemoveAt(i);
            }
        }
    }

    void CheckDebuffAttacco()
    {
        for (int i = nturnoAttacco.Count - 1; i >= 0; i--)
        {
            nturnoAttacco[i]--;
            if (nturnoDifesa[i] == 0)
            {
                att += debuffAttacco[i];
                debuffAttacco.RemoveAt(i);
                nturnoAttacco.RemoveAt(i);
            }
        }
    }

    void CheckVeleno()
    {
        int danno = Mathf.RoundToInt(((hpMax * 5) / 100) * Random.Range(1.0f,1.5f));
        hp = hp - danno;
        UiController ui = FindObjectOfType<UiController>();
        CombatController cc = FindObjectOfType<CombatController>();
        ui.DamageText(this.gameObject, danno, Color.green);
        if (hp <= 0)
        {
            List<int> n = new List<int>();
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = false;
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].occupier = null;
            //cc.player.RemoveAll(item => item == enemy);
            for (int j = cc.turno + 1; j < cc.player.Count; j++)
            {
                if (cc.player[j] == this.gameObject)
                    n.Add(j);
            }
            for (int i = n.Count - 1; i >= 0; i--)
            {
                cc.player.RemoveAt(n[i]);
            }

            if (!cc.CheckWinner())
            {
                cc.EndOfTurn();
            }
            else
            {
                cc.win = true;
                cc.Win();
            }
            Destroy(this.gameObject);

        }

        turniVeleno--;
        if (turniVeleno == 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
