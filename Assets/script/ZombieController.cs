using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;

    private bool is_stopped;

    private void Update()
    {
        if (!is_stopped)
            MoveToLeft();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        is_stopped = true;
    }

    private void MoveToLeft()
    {
        transform.Translate(new Vector3(speed * -1, 0, 0));
    }

}
