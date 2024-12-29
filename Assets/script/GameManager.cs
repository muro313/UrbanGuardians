using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject dragging_lumber;
    public GameObject current_cell;
    public static GameManager inst;

    public void Start()
    {
        Awake();
    }

    private void Awake()
    {
        inst = this;
    }

    public void PlaceLumber()
    {
        if (dragging_lumber != null && current_cell != null)
        {
            Instantiate(dragging_lumber.GetComponent<LumberDragging>().card.lumb_game, current_cell.transform);
            current_cell.GetComponent<Cell>().is_empty = false;
        }    
    }
}
