using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesSpawner: MonoBehaviour
{
    public List<ZombieMeta> zombie_metas;

    private void Update()
    {
        foreach (ZombieMeta meta in zombie_metas)
        {
            if (meta.is_spawn)
                continue;
        }
    }
}
