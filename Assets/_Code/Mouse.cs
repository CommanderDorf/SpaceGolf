using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mouse
{
    public static Quaternion FaceMouse(Vector3 position)
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }
}
