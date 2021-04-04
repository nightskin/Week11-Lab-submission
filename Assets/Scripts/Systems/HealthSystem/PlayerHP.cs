using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : HealthComponent
{

    protected override void Start()
    {
        base.Start();
        PlayerEvents.Invoke_OnPlayerHealthSet(this);
    }

}
