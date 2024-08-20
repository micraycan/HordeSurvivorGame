using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    /// <summary>
    /// Checks if ready based on previous time and a cooldown.
    /// Updates previous time reference passed in.
    /// </summary>
    /// <param name="prevTime"></param>
    /// <param name="cooldown"></param>
    /// <returns></returns>
    public static bool IsReady(ref float prevTime, float cooldown)
    {
        if (Time.time - prevTime > cooldown)
        {
            prevTime = Time.time;
            return true;
        }
        return false;
    }
}
