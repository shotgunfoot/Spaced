using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/New Weapon")]
public class Weapon : ScriptableObject
{
    public int damagePerProjectile;
    public int projectilesPerShot;    
    public float timeBetweenShots;
    public float reloadTime;
    public int shotsBeforeReload;
    public float projectileSpread;
    public int startingAmmo;
    public float projectileSpeed;

    public AudioClip reloadSound;
    public AudioClip firingSound;
}
