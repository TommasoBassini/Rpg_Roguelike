using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UiController : MonoBehaviour
{
    private CombatController cc;
    public GameObject MainPanel;
    public GameObject MovePanel;
    public GameObject ActionPanel;
    public Button MoveButton;
    private Vector2 startPos;
    public bool isPlayerMove = false;

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
        MoveButton.interactable = true;
        MainPanel.SetActive(true);
        MovePanel.SetActive(false);
    }

    public void Attack()
    {

    }
}
