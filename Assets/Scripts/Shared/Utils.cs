using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

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

    /// <summary>
    /// Creates object pool, needs to declare functions in parameters.<br/>
    /// () => Insantiate(prefab, transform) <br/>
    /// var = var.gameObject.setActive(true) <br/>
    /// var = var.gameObject.setActive(false) <br />
    /// var = Destroy(var.gameObject) <br />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="createFunction"></param>
    /// <param name="actionOnGet"></param>
    /// <param name="actionOnRelease"></param>
    /// <param name="actionOnDestroy"></param>
    /// <returns></returns>
    public static ObjectPool<T> CreateObjectPool<T>(
            Func<T> createFunction, 
            Action<T> actionOnGet,
            Action<T> actionOnRelease,
            Action<T> actionOnDestroy) where T : MonoBehaviour
    {
        return new ObjectPool<T>(createFunction, actionOnGet, actionOnRelease, actionOnDestroy);
    }
}
