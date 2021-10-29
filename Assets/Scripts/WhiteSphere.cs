using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class WhiteSphere : BaseSphere
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Launch()
    {
        base.Launch();
    }
    
    protected override Vector3 GetLaunchForce()
    {
        return base.GetLaunchForce();
    }

    protected override IEnumerator OnLaunched()
    {
        yield return base.OnLaunched();
    }
}