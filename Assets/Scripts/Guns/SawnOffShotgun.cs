using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SawnOffShotgun : SingleHandItem
{
    //The spawn point for any projectiles created by this gun.
    [Required]
    public Transform ProjectileSpawnPoint;
    public Weapon weaponInfo;

    /// <summary>
    /// INSTEAD OF THIS HARD CODE SHIT
    /// change it to a event system where the gun subscribes to the inventory when it is picked up
    /// Needs more thought than this tho.
    /// </summary>
    private InventoryBasic inventory;

    private TimeSince shotTimer;
    private TimeSince reloadTimer;
    private bool hasBulletsToFire;
    private int shotsRemaining;
    private bool reloading;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        shotsRemaining = weaponInfo.startingAmmo;

        if (shotsRemaining > 0)
        {
            hasBulletsToFire = true;
        }
        else
        {
            hasBulletsToFire = false;
        }

        shotTimer = 100;
    }

    IEnumerator Reload()
    {
        reloadTimer = 0;
        reloading = true;

        audioSource.clip = weaponInfo.reloadSound;
        audioSource.Play();

        while (reloadTimer < weaponInfo.reloadTime)
        {
            yield return null;
        }

        if(inventory.GetShellsRemaining() > 0)
        {
            for (int i = 0; i <= weaponInfo.shotsBeforeReload; i++)
            {
                if (inventory.GetShellsRemaining() > 0)
                {
                    inventory.AddShells(-1);
                    shotsRemaining++;
                }
                i++;
            }
        }
        else
        {
            Debug.Log("Empty! And no Shells in inventory!");
        }
        
        if(shotsRemaining > 0)
        {
            hasBulletsToFire = true;
        }

        reloading = false;

        yield return null;
    }

    public override void Action()
    {

        if (inventory == null)
        {
            inventory = GetComponentInParent<InventoryBasic>();
        }

        if (hasBulletsToFire && shotTimer > weaponInfo.timeBetweenShots)
        {
            shotTimer = 0;
            audioSource.PlayOneShot(weaponInfo.firingSound);
            shotsRemaining--;
            if (shotsRemaining <= 0)
            {
                hasBulletsToFire = false;
            }
        }
        else if (!reloading && !hasBulletsToFire)
        {
            StartCoroutine(Reload());
        }
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
