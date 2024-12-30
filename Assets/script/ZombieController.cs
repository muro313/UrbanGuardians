using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;

    private bool is_stopped;


    public float attack_step;

    private void Update()
    {
        if (!is_stopped)
            MoveToLeft();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8) // stop only when we see object
            return;
        is_stopped = true;
        StartCoroutine(Attack(collision));
    }

    IEnumerator Attack(Collider2D collision)
    {
        if(collision == null)
        {
            is_stopped = false;
        } else
        {
            collision.gameObject.GetComponent<DefencerController>().GetDamage(damage);
            yield return new WaitForSeconds(attack_step);
            StartCoroutine(Attack(collision));
        }
    }

    private void MoveToLeft()
    {
        transform.Translate(new Vector3(speed * -1, 0, 0));
    }

    public void GetDamage(int received_damage) { 
        if(health -  received_damage > 0)
        {
            health -= received_damage;
            return;
        }
       Die();
    }
    private void Die() { 
        transform.parent.GetComponent<SpawnPoint>().zombies.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

}
