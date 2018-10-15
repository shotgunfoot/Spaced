using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/New Weapon")]
public class Weapon : ScriptableObject
{
    [PropertyTooltip("The location that this item sits at when in a player's left hand.")]
    public Vector3 LeftPickPosition;
    [PropertyTooltip("The rotation that this item requires when in a player's left hand.")]
    public Vector3 LeftPickRotation;

    [PropertyTooltip("The location that this item sits at when in a player's right hand.")]
    public Vector3 RightPickPosition;
    [PropertyTooltip("The rotation that this item requires when in a player's right hand.")]
    public Vector3 RightPickRotation;

    public int projectileCount;
    public int maxProjectileCount;
    public float reloadTime;
    public float projectileSpread;
    
}
