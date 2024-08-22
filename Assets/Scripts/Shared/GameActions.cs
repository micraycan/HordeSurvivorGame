using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameActions
{
    // player actions
    public static Action<int> PlayerHealthChanged;

    // enemy actions
    public static Action<int, Transform, bool> EnemyDamaged;
    public static Action<Vector2> EnemyDeath;

    // drop actions
    public static Action<XpOrb> XpCollected;
}
