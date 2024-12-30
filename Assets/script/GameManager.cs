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
            GameObject defencer_inst = Instantiate(dragging_lumber.GetComponent<LumberDragging>().card.lumb_game, current_cell.transform);
            defencer_inst.GetComponent<DefencerController>().zombies = current_cell.GetComponent<Cell>().spawn_point.zombies;
            current_cell.GetComponent<Cell>().is_empty = false;
        }    
    }
}
