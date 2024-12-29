using UnityEngine;
using UnityEngine.EventSystems;


public class LumberjackCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject lumb_drag;
    public GameObject lumb_game;
    public Canvas canvas;
    private GameObject lumb_drag_instance;
    private GameManager game_manager;


    public void Start()
    {
        game_manager = GameManager.inst;
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateMousePosition();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        lumb_drag_instance = Instantiate(lumb_drag, canvas.transform);
        UpdateMousePosition();
        lumb_drag_instance.GetComponent<LumberDragging>().card = this;

        game_manager.dragging_lumber = lumb_drag_instance;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        game_manager.PlaceLumber();
        game_manager.dragging_lumber = null;
        Destroy(lumb_drag_instance);
    }

    private void UpdateMousePosition()
    {
        lumb_drag_instance.transform.position = Input.mousePosition;
    }
}
