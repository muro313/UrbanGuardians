using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public bool is_empty;
    public GameManager manager;
    public Image backroung_image;

    private void Start()
    {
        manager = GameManager.inst;
        is_empty = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (manager.dragging_lumber != null && is_empty == true) {
            manager.current_cell = this.gameObject;
            backroung_image.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        manager.current_cell = null;
        backroung_image.enabled = false;
    }
}
