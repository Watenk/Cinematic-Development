using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    Rigidbody rb { get; }
    void Move(Vector3 direction, float forceMultiplier, ForceMode forceMode);
}
