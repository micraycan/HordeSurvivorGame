using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpOrb : ItemDrop
{
    protected override void Collected()
    {
        GameActions.XpCollected?.Invoke(this);
    }
}
