using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Enemy : Character
{

    public abstract void Ai();
    public List<CombatCell> cellToCross = new List<CombatCell>();
    public int hp;
    public int mp;
    public int difesa;
    public int att;

    public void FindNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject nearestPlayer = null;
        int nearestPlayerDistance = 10000;
        // Cerca il GO player più vicino
        foreach (GameObject player in players)
        {
            Character pl = player.GetComponent<Character>();
            int distance = Mathf.Abs((int)pl.pos.x - (int)pos.x) + Mathf.Abs((int)pl.pos.y - (int)pos.y);
            if (distance <= (nearestPlayerDistance))
            {
                nearestPlayerDistance = distance;
                nearestPlayer = player;

            }
        }
        StartCoroutine(NearestCellToPlayer(this.pos, this.passi, nearestPlayer));
    }

    IEnumerator NearestCellToPlayer(Vector2 _pos, int raggio, GameObject playerNear)
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
                if (distance <= nearestCellDistance && !base.grid.cells[i, y].isOccupied)
                {
                    if (nearestCell != null)
                    {

                        SpriteRenderer sr1 = nearestCell.gameObject.GetComponent<SpriteRenderer>();
                        sr1.color = Color.white;
                    }

                    nearestCellDistance = distance;
                    nearestCell = base.grid.cells[i, y];
                    SpriteRenderer sr = nearestCell.gameObject.GetComponent<SpriteRenderer>();
                    sr.color = Color.blue;
                    yield return new WaitForSeconds(0.2f);

                }
            }
        }

        if (nearestCell != null)
            StartCoroutine(GoToEndCell(_pos, nearestCell.pos));
    }



    IEnumerator GoToEndCell(Vector2 _pos, Vector2 endPos)
    {

        CombatController cc = FindObjectOfType<CombatController>();
        BattleGrid grid = FindObjectOfType<BattleGrid>();
        //
        SpriteRenderer sr = base.grid.cells[((int)_pos.x), (int)_pos.y].GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        //

        grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = false;
        int x = (int)endPos.x - (int)_pos.x;
        int y = (int)endPos.y - (int)_pos.y;
        int zy = 0;
        int zx = x / Mathf.Abs(x);

        for (int i = 1; i < Mathf.Abs(x) + 1; i++)
        {
            cellToCross.Add(base.grid.cells[((int)this.pos.x + (zx * i)), (int)this.pos.y]);
            //
            SpriteRenderer sr1 = base.grid.cells[((int)this.pos.x + (zx * i)), (int)this.pos.y].GetComponent<SpriteRenderer>();
            sr1.color = Color.blue;
            yield return new WaitForSeconds(0.2f);
            //
        }

        //Prendo l'ultima cella trovata se c'è
        if (cellToCross.Count != 0)
            x = (int)cellToCross[cellToCross.Count - 1].GetComponent<CombatCell>().pos.x;
        else
            x = (int)_pos.x;

        if (y != 0)
        {
            zy = y / Mathf.Abs(y);
        }
        for (int j = 1; j < Mathf.Abs(y) + 1; j++)
        {

            cellToCross.Add(base.grid.cells[x, (int)this.pos.y + (zy * j)]);
        }
        foreach (CombatCell item in cellToCross)
        {
            this.transform.position = item.gameObject.transform.position;
            base.pos = item.pos;
            SpriteRenderer sr2 = item.gameObject.GetComponent<SpriteRenderer>();
            sr2.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
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
                    //
                    SpriteRenderer sr1 = base.grid.cells[((int)this.pos.x + (zx * i)), (int)this.pos.y].GetComponent<SpriteRenderer>();
                    sr1.color = Color.blue;
                    yield return new WaitForSeconds(0.2f);
                    //
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
                    //
                    SpriteRenderer sr1 = base.grid.cells[x, (int)this.pos.y + (zy * j)].GetComponent<SpriteRenderer>();
                    sr1.color = Color.blue;
                    yield return new WaitForSeconds(0.2f);
                    //
                }
            }
        }
        // si muove fra le celle trovate
        foreach (CombatCell item in cellToCross)
        {
            this.transform.position = item.gameObject.transform.position;
            base.pos = item.pos;
            SpriteRenderer sr3 = item.gameObject.GetComponent<SpriteRenderer>();
            sr3.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
        // Setta la varie variabili e resetta la lista e fa iniziare la coroutine di attacco
        grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = true;
        grid.cells[(int)this.pos.x, (int)this.pos.y].occupier = this.gameObject;
        cellToCross.Clear();
        StartCoroutine(AttackPlayer(base.grid.cells[(int)oldPlayerPos.x, (int)oldPlayerPos.y].occupier));
    }

    public IEnumerator AttackPlayer(GameObject Target)
    {
        CombatController cc = FindObjectOfType<CombatController>();
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        sr.color = Color.red;
        Debug.Log("il nemico nella posizione " + this.pos + "ha attaccato il giocatore " + Target.name);
        Player player = Target.GetComponent<Player>();
        player.SubisciDanno(att);
        yield return new WaitForSeconds(2);
        cc.EndOfTurn();
    }

    public void SubisciDanno(int danni)
    {
        hp = hp - Mathf.RoundToInt(((((danni / difesa) * 100) * (danni / 2)) / 100) + (Random.Range(1.0f, 1.125f)));
        CombatController cc = FindObjectOfType<CombatController>();
        UiController ui = FindObjectOfType<UiController>();
        if(hp <= 0)
        {
            base.grid.cells[(int)this.pos.x,(int) this.pos.y].isOccupied = false;
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].occupier = null;
            cc.player.RemoveAll(item => item.name == this.gameObject.name);
            Destroy(this.gameObject);
            if (!cc.CheckWinner())
                cc.UpdateTurnPortrait();
            else
                cc.Win();
        }
    }
}
