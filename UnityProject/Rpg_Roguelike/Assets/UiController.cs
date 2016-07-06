using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UiController : MonoBehaviour
{
    private CombatController cc;
    public GameObject UI;
    public GameObject MainPanel;
    public GameObject MovePanel;
    public GameObject ActionPanel;
    public GameObject EnemyListPanel;
    public Button MoveButton;
    private Vector2 startPos;
    public bool isPlayerMove = false;

    public Button SelectEnemyButton;
     

    void Start ()
    {
        cc = FindObjectOfType<CombatController>();
	}

    public void Move()
    {
        Character character = cc.player[cc.turno].GetComponent<Character>();
        startPos = character.pos;
        character.Move();
        MainPanel.SetActive(false);
        MovePanel.SetActive(true);
    }

    public void ConfirmPosition()
    {
        cc.ConfirmMovement();
        MoveButton.interactable = false;
        MainPanel.SetActive(true);
        MovePanel.SetActive(false);
    }

    public void CancelMovement()
    {
        Character character = cc.player[cc.turno].GetComponent<Character>();
        character.PlayerMove(startPos);
        MainPanel.SetActive(true);
        MovePanel.SetActive(false);
    }

    public void Action()
    {
        MainPanel.SetActive(false);
        ActionPanel.SetActive(true);
    }

    public void PassaTurno()
    {
        cc.EndOfTurn();

        foreach (Transform child in EnemyListPanel.transform)
        {
            Destroy(child.gameObject);
        }

        MoveButton.interactable = true;
        MainPanel.SetActive(true);
        MovePanel.SetActive(false);
        EnemyListPanel.SetActive(false);
        ActionPanel.SetActive(false);

    }

    public void Attack()
    {


        Player player = cc.player[cc.turno].GetComponent<Player>();
        player.CheckAttack();
        ActionPanel.SetActive(false);
        EnemyListPanel.SetActive(true);

        foreach (GameObject enemy in player.enemyDisp)
        {
            Button newButton = Instantiate(SelectEnemyButton);
            newButton.transform.SetParent(EnemyListPanel.transform,false);

            EnemyButton enemyButton = newButton.GetComponent<EnemyButton>();
            enemyButton.enemy = enemy;

            Text text = newButton.GetComponentInChildren<Text>();
            text.text = enemy.name;
        }
        player.enemyDisp.Clear();
    }
}
