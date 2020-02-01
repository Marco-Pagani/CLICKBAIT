using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour {
    public Transform target;
    public int minX = -3, maxX = 3, minY = -5, maxY = 5;
    void Update () {
        float x = -target.position.z.Remap (-13, 10, minX, maxX);
        float y = target.position.x.Remap (-22, 22, minY, maxY);
        transform.rotation = Quaternion.Euler (66 + x, y, 0);
    }

}

public static class ExtensionMethods {
    //src: https://forum.unity.com/threads/re-map-a-number-from-one-range-to-another.119437/
    public static float Remap (this float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}