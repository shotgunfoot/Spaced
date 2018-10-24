using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SawnOffShotgun : SingleHandItem
{
    //The spawn point for any projectiles created by this gun.
    [Required]
    public Weapon weaponInfo;
    [Required]
    public Transform ProjectileSpawnPoint;
    [Required]
    public Transform shellEjectionPoint;

    /// <summary>
    /// INSTEAD OF THIS HARD CODE SHIT
    /// change it to a event system where the gun subscribes to the inventory when it is picked up
    /// Needs more thought than this tho.
    /// </summary>    
    private SpentAmmoSpawner spentAmmoSpawner;
    private ParticleSystem muzzleFlash;
    private TimeSince shotTimer;
    private TimeSince reloadTimer;
    private int shotsRemaining;
    private int shotsSpent;
    private bool reloading;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spentAmmoSpawner = GetComponentInChildren<SpentAmmoSpawner>();
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
        shotsRemaining = weaponInfo.startingAmmo;
        shotTimer = 100;
        shotsSpent = 0;
    }

    //IEnumerator Reload()
    //{
    //    reloadTimer = 0;
    //    reloading = true;

    //    for (int i = shotsSpent; i > 0; i--)
    //    {
    //        spentAmmoSpawner.SpawnWithForce();
    //        shotsSpent--;
    //    }

    //    audioSource.clip = weaponInfo.reloadSound;
    //    audioSource.Play();

    //    while (reloadTimer < weaponInfo.reloadTime)
    //    {
    //        yield return null;
    //    }

    //    for (int i = 0; i <= weaponInfo.shotsBeforeReload; i++)
    //    {
    //        if (inventory.GetShellsRemaining() > 0)
    //        {
    //            inventory.AddShells(-1);
    //            shotsRemaining++;
    //        }
    //        i++;
    //    }

    //    reloading = false;

    //    yield return null;
    //}



    private void Update()
    {
        Transform startPos;
        startPos = ProjectileSpawnPoint;
        //draw weapon firing angle
        for (int i = 0; i <= 1; i++)
        {
            Vector3 angle = new Vector3(0, ProjectileSpawnPoint.localRotation.eulerAngles.y + (i < 1 ? -weaponInfo.projectileSpread : weaponInfo.projectileSpread), 0);
            startPos.localRotation = Quaternion.Euler(angle);
            Debug.DrawLine(startPos.position, startPos.position + (ProjectileSpawnPoint.forward * weaponInfo.range));
        }
    }

    public override void Action()
    {
        Debug.Log("Firing shotgun!");
    }

    //public override void Action()
    //{

    //    if (inventory == null)
    //    {
    //        inventory = GetComponentInParent<InventoryBasic>();
    //    }

    //    if (shotsRemaining > 0 && shotTimer > weaponInfo.timeBetweenShots)
    //    {
    //        shotTimer = 0;

    //        audioSource.PlayOneShot(weaponInfo.firingSound);
    //        muzzleFlash.Emit(1);

    //        //get an angle between min and max angle
    //        float minAngle, maxAngle;
    //        minAngle = -weaponInfo.projectileSpread;
    //        maxAngle = weaponInfo.projectileSpread;                       

    //        for (int i = 0; i < weaponInfo.projectilesPerShot; i++)
    //        {                           
    //            Vector3 firingAngle = new Vector3(0, Random.Range(minAngle, maxAngle), 0);                
    //            GameObject bullet;                
    //            bullet = Instantiate(weaponInfo.bullet, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation);
    //            bullet.transform.Rotate(firingAngle);
    //            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * weaponInfo.projectileSpeed, ForceMode.Impulse);
    //        }


    //        ////Fire bullets in a cone.
    //        //for (int i = 0; i < weaponInfo.projectilesPerShot; i++)
    //        //{
    //        //    float angle = Random.Range(minAngle, maxAngle);

    //        //    Quaternion firingAngle = Quaternion.Euler(0, angle, 0);

    //        //    GameObject bullet;

    //        //    bullet = Instantiate(weaponInfo.bullet, ProjectileSpawnPoint.position, firingAngle);
    //        //    bullet.GetComponent<Rigidbody>().AddForce(ProjectileSpawnPoint.forward * weaponInfo.projectileSpeed, ForceMode.Impulse);
    //        //}

    //        //work out if hit

    //        //calculate damage (each unit away from the initial fire point to the target means 1 less damage)

    //        shotsSpent++;
    //        shotsRemaining--;
    //    }
    //    else if (!reloading && shotsRemaining <= 0 && inventory.GetShellsRemaining() > 0)
    //    {
    //        StartCoroutine(Reload());
    //    }
    //}

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
