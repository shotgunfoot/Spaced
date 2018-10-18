using UnityEngine;
using Sirenix.OdinInspector;

public abstract class SingleHandItem : MonoBehaviour
{
    public virtual void Action() { }
    public virtual void DisableColliders() { }
    public virtual void EnableColliders() { }

    [Title("Left Hand")]
    [PropertyTooltip("The location that this item sits at when in a player's left hand.")]
    public Vector3 LeftHandPosition;
    [PropertyTooltip("The rotation that this item requires when in a player's left hand.")]
    public Vector3 LeftHandRotation;
    [Title("Right Hand")]
    [PropertyTooltip("The location that this item sits at when in a player's right hand.")]
    public Vector3 RightHandPosition;
    [PropertyTooltip("The rotation that this item requires when in a player's right hand.")]
    public Vector3 RightHandRotation;
}
