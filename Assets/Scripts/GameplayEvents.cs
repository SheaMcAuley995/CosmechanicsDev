using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayEvents : MonoBehaviour
{
    public static GameplayEvents instance;

    private void Awake()
    {
        instance = this;
    }

    public event Action onGameplayInitialize;

}
