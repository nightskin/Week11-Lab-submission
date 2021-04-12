using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHUDWidget : MonoBehaviour
{
    public virtual void EnableWidget()
    {
        gameObject.SetActive(true);
    }

    public virtual void DisableWidget()
    {
        gameObject.SetActive(false);
    }
}
