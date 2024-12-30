using UnityEngine;

public class Axe : MonoBehaviour
{
    public float speed;
    public int damage;

    private void Update()
    {
        MoveToRight();
    }

    private void MoveToRight()
    {
        transform.Translate(new Vector3(speed, 0, 0));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 9) // dissapear only when we see zombie
            return;
        Damage(collision.gameObject);
        Disappear();
    }

    private void Damage(GameObject zombie)
    {
        zombie.GetComponent<ZombieController>().GetDamage(damage);
    }

    private void Disappear()
    {
        Destroy(this.gameObject);
    }
}
