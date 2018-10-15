using UnityEngine;
using Sirenix.OdinInspector;

public abstract class SingleHandItem : MonoBehaviour
{
    public virtual void Action() { }
    public virtual void DisableColliders() { }
    public virtual void EnableColliders() { }

    [Title("Left Hand")]
    public Vector3 LeftHandPosition;
    public Vector3 LeftHandRotation;
    [Title("Right Hand")]
    public Vector3 RightHandPosition;
    public Vector3 RightHandRotation;
}
