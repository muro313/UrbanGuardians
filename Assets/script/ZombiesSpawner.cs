using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ZombiesSpawner: MonoBehaviour
{
    public GameObject zombie;
    public List<ZombieMeta> zombie_metas;

    private void Update()
    {
        foreach (ZombieMeta meta in zombie_metas)
        {
            
            if (meta.is_spawn == true)
                continue;
            if (meta.spawn_time > Time.time)
                continue;

            GameObject zombie_inst = Instantiate(zombie, transform.GetChild(meta.row_number).transform);
            meta.is_spawn = true;

        }
    }
}
