﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BattleGrid : MonoBehaviour
{

    public int width;
    public int height;

    public CombatCell[,] cells;
    public GameObject cellPrefab;

    public GameObject[] playerPrefab = new GameObject[3];
    public List<int> nUsatiPlayer = new List<int>();
    public List<CombatCell> cellWalkable = new List<CombatCell>();

    private CombatController cc;

    public GameObject[] enemy;
    public List<int> nUsatiEnemy = new List<int>();
    public GameObject availableMovementPrefab;
    public List<GameObject> nBlocchiMovement = new List<GameObject>();

    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;

    public GameObject boss1Last;
    public GameObject boss2Last;
    public GameObject boss3Last;
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Battle"));
        cells = new CombatCell[width, height];
        cc = FindObjectOfType<CombatController>();

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject newCell = Instantiate(cellPrefab);
                newCell.transform.position = new Vector3(i + this.transform.position.x + 0.5f, this.transform.position.y + j + 0.5f, 0);
                newCell.name = "Cell " + i + " " + j;
                cells[i, j] = newCell.GetComponent<CombatCell>();
                cells[i, j].pos = new Vector2(i, j);
            }
        }
        int uiinfo = 1;

        foreach (GameObject player in playerPrefab)
        {
            string info = "InfoP" + uiinfo;
            int n = Random.Range(0, nUsatiPlayer.Count);
            int y = Random.Range(0, 7);
            GameObject NewPlayer = Instantiate(player);
            NewPlayer.transform.position = cells[nUsatiPlayer[n],y].gameObject.transform.position;
            SpriteRenderer sr = NewPlayer.GetComponent<SpriteRenderer>();
            sr.sortingOrder = 10-y;
            Player character = NewPlayer.GetComponent<Player>();
            NewPlayer.name = character.nome;
            character.uiInfo = GameObject.Find(info);
            uiinfo++;
            character.TakeStats();
            character.pos = new Vector2(nUsatiPlayer[n], y);
            cells[nUsatiPlayer[n], y].isOccupied = true;
            cells[nUsatiPlayer[n], y].occupier = NewPlayer;

            for (int i = 1; i < 100; i++)
            {
                cc.tempo.Add(character.velocita * i);
                cc.player.Add(NewPlayer);

            }
            nUsatiPlayer.RemoveAt(n);
        }
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();

        if (stats.tipoIncontro == 0)
        {
            int random = Random.Range(2, 5);
            for (int p = 0; p < random; p++)
            {
                int enemX = Random.Range(0, nUsatiEnemy.Count);
                int enemY = Random.Range(0, 7);
                int random2 = Random.Range(0, 3);
                GameObject newEnemy = Instantiate(enemy[random2]);
                newEnemy.name = enemy[random2].name + " " + p;
                newEnemy.transform.position = cells[nUsatiEnemy[enemX], enemY].gameObject.transform.position;
                SpriteRenderer srEnemy = newEnemy.GetComponent<SpriteRenderer>();
                srEnemy.sortingOrder = 3;
                Enemy characterEnemy = newEnemy.GetComponent<Enemy>();
                characterEnemy.velocita = Random.Range(0.7f, 1.1f);
                characterEnemy.pos = new Vector2(nUsatiEnemy[enemX], enemY);
                cells[nUsatiEnemy[enemX], enemY].isOccupied = true;
                cells[nUsatiEnemy[enemX], enemY].occupier = newEnemy;
                for (int z = 1; z < 100; z++)
                {
                    cc.tempo.Add(characterEnemy.velocita * z);
                    cc.player.Add(newEnemy);
                }
                nUsatiEnemy.RemoveAt(enemX);
            }
            cc.TurnOrder(cc.tempo, cc.tempo.Count);
        }
        else if (stats.tipoIncontro == 1)
        {
            int enemX = Random.Range(0, nUsatiEnemy.Count);
            int enemY = Random.Range(0, 7);
            GameObject newEnemy = Instantiate(boss1);
            newEnemy.name = boss1.name;
            newEnemy.transform.position = cells[nUsatiEnemy[enemX], enemY].gameObject.transform.position;
            SpriteRenderer srEnemy = newEnemy.GetComponent<SpriteRenderer>();
            srEnemy.sortingOrder = 3;
            Enemy characterEnemy = newEnemy.GetComponent<Enemy>();
            characterEnemy.velocita = Random.Range(0.7f, 1.1f);
            characterEnemy.pos = new Vector2(nUsatiEnemy[enemX], enemY);
            cells[nUsatiEnemy[enemX], enemY].isOccupied = true;
            cells[nUsatiEnemy[enemX], enemY].occupier = newEnemy;
            cc.enemyLvl.Add(characterEnemy.level);
            for (int z = 1; z < 100; z++)
            {
                cc.tempo.Add(characterEnemy.velocita * z);
                cc.player.Add(newEnemy);
            }
            nUsatiEnemy.RemoveAt(enemX);
            cc.TurnOrder(cc.tempo, cc.tempo.Count);
        }
        else if (stats.tipoIncontro == 2)
        {
            int enemX = Random.Range(0, nUsatiEnemy.Count);
            int enemY = Random.Range(0, 7);
            GameObject newEnemy = Instantiate(boss2);
            newEnemy.name = boss2.name;
            newEnemy.transform.position = cells[nUsatiEnemy[enemX], enemY].gameObject.transform.position;
            SpriteRenderer srEnemy = newEnemy.GetComponent<SpriteRenderer>();
            srEnemy.sortingOrder = 3;
            Enemy characterEnemy = newEnemy.GetComponent<Enemy>();
            characterEnemy.velocita = Random.Range(0.7f, 1.1f);
            characterEnemy.pos = new Vector2(nUsatiEnemy[enemX], enemY);
            cells[nUsatiEnemy[enemX], enemY].isOccupied = true;
            cells[nUsatiEnemy[enemX], enemY].occupier = newEnemy;
            cc.enemyLvl.Add(characterEnemy.level);
            for (int z = 1; z < 100; z++)
            {
                cc.tempo.Add(characterEnemy.velocita * z);
                cc.player.Add(newEnemy);
            }
            nUsatiEnemy.RemoveAt(enemX);
            cc.TurnOrder(cc.tempo, cc.tempo.Count);
        }
        else if (stats.tipoIncontro == 3)
        {
            int enemX = Random.Range(0, nUsatiEnemy.Count);
            int enemY = Random.Range(0, 7);
            GameObject newEnemy = Instantiate(boss3);
            newEnemy.name = boss3.name;
            newEnemy.transform.position = cells[nUsatiEnemy[enemX], enemY].gameObject.transform.position;
            SpriteRenderer srEnemy = newEnemy.GetComponent<SpriteRenderer>();
            srEnemy.sortingOrder = 3;
            Enemy characterEnemy = newEnemy.GetComponent<Enemy>();
            characterEnemy.velocita = Random.Range(0.7f, 1.1f);
            characterEnemy.pos = new Vector2(nUsatiEnemy[enemX], enemY);
            cells[nUsatiEnemy[enemX], enemY].isOccupied = true;
            cells[nUsatiEnemy[enemX], enemY].occupier = newEnemy;
            cc.enemyLvl.Add(characterEnemy.level);
            for (int z = 1; z < 100; z++)
            {
                cc.tempo.Add(characterEnemy.velocita * z);
                cc.player.Add(newEnemy);
            }
            nUsatiEnemy.RemoveAt(enemX);
            cc.TurnOrder(cc.tempo, cc.tempo.Count);
        }
        else if (stats.tipoIncontro == 4)
        {
            for (int i = 0; i < 3; i++)
            {
                int enemX = Random.Range(0, nUsatiEnemy.Count);
                int enemY = Random.Range(0, 7);
                if (i == 0)
                {
                    GameObject newEnemy = Instantiate(boss1Last);
                    newEnemy.name = boss1.name;
                    newEnemy.transform.position = cells[nUsatiEnemy[enemX], enemY].gameObject.transform.position;
                    SpriteRenderer srEnemy = newEnemy.GetComponent<SpriteRenderer>();
                    srEnemy.sortingOrder = 3;
                    Enemy characterEnemy = newEnemy.GetComponent<Enemy>();
                    characterEnemy.velocita = Random.Range(0.7f, 1.1f);
                    characterEnemy.pos = new Vector2(nUsatiEnemy[enemX], enemY);
                    cells[nUsatiEnemy[enemX], enemY].isOccupied = true;
                    cells[nUsatiEnemy[enemX], enemY].occupier = newEnemy;
                    cc.enemyLvl.Add(characterEnemy.level);
                    for (int z = 1; z < 100; z++)
                    {
                        cc.tempo.Add(characterEnemy.velocita * z);
                        cc.player.Add(newEnemy);
                    }
                    nUsatiEnemy.RemoveAt(enemX);

                }
                if (i == 1)
                {
                    GameObject newEnemy = Instantiate(boss2Last);
                    newEnemy.name = boss2.name;
                    newEnemy.transform.position = cells[nUsatiEnemy[enemX], enemY].gameObject.transform.position;
                    SpriteRenderer srEnemy = newEnemy.GetComponent<SpriteRenderer>();
                    srEnemy.sortingOrder = 3;
                    Enemy characterEnemy = newEnemy.GetComponent<Enemy>();
                    characterEnemy.velocita = Random.Range(0.7f, 1.1f);
                    characterEnemy.pos = new Vector2(nUsatiEnemy[enemX], enemY);
                    cells[nUsatiEnemy[enemX], enemY].isOccupied = true;
                    cells[nUsatiEnemy[enemX], enemY].occupier = newEnemy;
                    cc.enemyLvl.Add(characterEnemy.level);
                    for (int z = 1; z < 100; z++)
                    {
                        cc.tempo.Add(characterEnemy.velocita * z);
                        cc.player.Add(newEnemy);
                    }
                    nUsatiEnemy.RemoveAt(enemX);
                }
                if (i == 2)
                {
                    GameObject newEnemy = Instantiate(boss3Last);
                    newEnemy.name = boss3.name;
                    newEnemy.transform.position = cells[nUsatiEnemy[enemX], enemY].gameObject.transform.position;
                    SpriteRenderer srEnemy = newEnemy.GetComponent<SpriteRenderer>();
                    srEnemy.sortingOrder = 3;
                    Enemy characterEnemy = newEnemy.GetComponent<Enemy>();
                    characterEnemy.velocita = Random.Range(0.7f, 1.1f);
                    characterEnemy.pos = new Vector2(nUsatiEnemy[enemX], enemY);
                    cells[nUsatiEnemy[enemX], enemY].isOccupied = true;
                    cells[nUsatiEnemy[enemX], enemY].occupier = newEnemy;
                    cc.enemyLvl.Add(characterEnemy.level);
                    for (int z = 1; z < 100; z++)
                    {
                        cc.tempo.Add(characterEnemy.velocita * z);
                        cc.player.Add(newEnemy);
                    }
                    nUsatiEnemy.RemoveAt(enemX);
                }
                cc.TurnOrder(cc.tempo, cc.tempo.Count);
            }

        }
    }


    public void AvailableMovement(Vector2 _pos, int raggio)
    {
        int _x = (int)_pos.x;
        int _y = (int)_pos.y;

        for (int i = (_x - raggio); i <= (_x + raggio); i++)
        {
            for (int y = (_y - raggio); y <= (_y + raggio); y++)
            {


                if (i < 0)
                    continue;
                if (y < 0)
                    continue;
                if (i > width - 1)
                    continue;
                if (y > height - 1)
                    continue;

                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) <= (raggio))
                {
                    if (!cells[i, y].isOccupied)
                    {
                        GameObject newMovement = Instantiate(availableMovementPrefab);
                        newMovement.transform.position = cells[i, y].gameObject.transform.position;
                        nBlocchiMovement.Add(newMovement);
                        cells[i, y].isWalkable = true;
                        cellWalkable.Add(cells[i, y]);
                        
                    }
                }
            }
        }
        cells[_x, _y].isWalkable = true;
        cellWalkable.Add(cells[_x, _y]);
        GameObject newMovement1 = Instantiate(availableMovementPrefab);
        newMovement1.transform.position = cells[_x, _y].gameObject.transform.position;
        nBlocchiMovement.Add(newMovement1);
    }

    public void ResetWalkableCell ()
    {
        foreach (CombatCell cell in cellWalkable)
        {
            cell.isWalkable = false;
            cell.isOccupied = false;
            cell.occupier = null;
        }
        cellWalkable.Clear();
        foreach (GameObject cell in nBlocchiMovement)
        {
            Destroy(cell);
        }
        nBlocchiMovement.Clear();
    }

    public bool EnemyCheckPlayer(Vector2 _pos, int raggio, GameObject _enemy, out Vector2 _targetPos)
    {
        // Questo è il metodo che controlla se c'è il player nel raggio di azione del nemico 

        int _x = (int)_pos.x;
        int _y = (int)_pos.y;
        bool isNear = false;
        
        Vector2 targetPos = _pos;


        // incomincia a scansionare l'area
        for (int i = (_x - raggio); i <= (_x + raggio); i++)
        {
            bool isFind = false;
            for (int y = (_y - raggio); y <= (_y + raggio); y++)
            {

                // Controlla se il raggio non esce dalla griglia
                if (i < 0)
                    continue;
                if (y < 0)
                    continue;
                if (i > width - 1)
                    continue;
                if (y > height - 1)
                    continue;

                // Distanza manhattan
                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) <= (raggio))
                {
                    // controlla se la cella è occupata
                    if (cells[i, y].occupier != null)
                    {
                        // Controlla se la cella occupata è occupata dal gameobjcet con il tag "Player"
                        if (cells[i, y].occupier.CompareTag("Player"))
                        {
                            isNear = true;
                            isFind = true;
                            targetPos = cells[i, y].occupier.GetComponent<Player>().pos;
                            break;
                        }
                    }
                }
            }
            if (isFind)
            {
                break;
            }
        }
        if (!isNear)
        {
            _targetPos = targetPos;
            return false;
        }
        else
        {
            _targetPos = targetPos;
            return true;
        }
    }

    public bool CheckTarget(Vector2 _pos, int raggio,Vector2 target)
    {
        // Questo è il metodo che controlla se c'è il player nel raggio di azione del nemico 

        int _x = (int)_pos.x;
        int _y = (int)_pos.y;

        int targetX = (int)target.x;
        int targetY = (int)target.y;

        if (Mathf.Abs(targetX - _x) + Mathf.Abs(targetY - _y) <= (raggio))
        {
            return true;
        }
        else
            return false;
    }

    public bool isEnemyNearPlayer(Vector2 targetPos, GameObject _enemyCheck)
    {
        Vector2[] directions = new Vector2[4];

        directions[0] = new Vector2(-1, 0);
        directions[1] = new Vector2(0, -1);
        directions[2] = new Vector2(1, 0);
        directions[3] = new Vector2(0, 1);

        foreach (Vector2 dir in directions)
        {
            int new_x = (int)targetPos.x + (int)dir.x;
            int new_y = (int)targetPos.y + (int)dir.y;

            if (new_x < 0)
                continue;
            if (new_y < 0)
                continue;
            if (new_x > width - 1)
                continue;
            if (new_y > height - 1)
                continue;

            if (cells[new_x, new_y].occupier != null)
            {
                if (cells[new_x, new_y].occupier == _enemyCheck)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
