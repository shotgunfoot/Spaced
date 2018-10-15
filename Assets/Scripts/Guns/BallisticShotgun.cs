using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BallisticShotgun : SingleHandItem
{
    //The spawn point for any projectiles created by this gun.
    [Required]
    public Transform ProjectileSpawnPoint;

    public Weapon weaponInfo; 

    public override void Action()
    {
        Debug.Log(gameObject.name + " Fired!");
    }

    public override void DisableColliders()
    {
        foreach (BoxCollider coll in GetComponentsInChildren<BoxCollider>())
        {
            coll.enabled = false;
        }
    }

    public override void EnableColliders()
    {
        foreach (BoxCollider coll in GetComponentsInChildren<BoxCollider>())
        {
            coll.enabled = true;
        }
    }
}
