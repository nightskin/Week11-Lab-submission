using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.HealthSystems;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    
    [SerializeField] private TMP_Text hpText;
    private HealthComponent HealthComponent;
    
    void Awake()
    {
        PlayerEvents.OnPlayerHealthSet += PlayerEvents_OnPlayerHealthSet;
    }

    private void PlayerEvents_OnPlayerHealthSet(HealthComponent healthComponent)
    {
        HealthComponent = healthComponent;
    }
    
    void Update()
    {
        if(HealthComponent)
        {
            hpText.text = HealthComponent.health.ToString();
        }
    }
}
