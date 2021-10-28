using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSphere : BaseSphere
{
    protected override void Start()
    {
        base.Start();
    }

    protected override Vector3 GetLaunchForce()
    {
        Debug.Log(_mMovementDirection);
        Vector3 forceX = Vector3.left * _mMovementDirection.y * forceModifier / 2;
        Vector3 forceY = Vector3.up * _mMovementDirection.y * 3;
        Vector3 forceZ = Vector3.forward * _mMovementDirection.x * forceModifier;

        Debug.Log(forceZ);
        return forceX + forceY + forceZ;
    }

    protected override IEnumerator OnLaunched()
    {
        yield return base.OnLaunched();
    }
}