using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class DefencerController : MonoBehaviour
{
    public List<GameObject> zombies;
    public GameObject axe;
    public int health;
    public int damage;
    public bool in_attacak;

    public float attack_step;
    private float next_attact_time;

    private void Update()
    {
        ChangeAttactStatusIfNeeded();
        ThrowAxe();
    }

    private void ChangeAttactStatusIfNeeded()
    {
        if(zombies.Count > 0 && !in_attacak)
            in_attacak = true;
        else if (zombies.Count == 0 && in_attacak)
            in_attacak = false;
    }

    private void ThrowAxe()
    {
        if (!in_attacak)
            return;

        if (next_attact_time > Time.time)
            return;
        next_attact_time = Time.time + attack_step;
        GameObject axe_inst = Instantiate(axe, transform);
        axe_inst.GetComponent<Axe>().damage = damage;
    }

    public void GetDamage(int received_damage)
    {
        if (health - received_damage > 0)
        {
            health -= received_damage;
            return;
        }
        Die();
    }
    private void Die()
    {
        Destroy(this.gameObject);
    }

}
