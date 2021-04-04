using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ZombieComponent))]
public class ZombieHP : HealthComponent
{
    private StateMachine ZombieStateMachine;
    void Awake()
    {
        ZombieStateMachine = GetComponent<StateMachine>();
    }

    public override void Destroy()
    {
        ZombieStateMachine.ChangeState(ZombieStateType.Dead);
    }

}
