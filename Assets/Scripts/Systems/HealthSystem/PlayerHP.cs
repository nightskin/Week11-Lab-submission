using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : HealthComponent
{

    protected void Start()
    {
        PlayerEvents.Invoke_OnPlayerHealthSet(this);
    }

}
