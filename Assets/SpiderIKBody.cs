using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderIKBody : MonoBehaviour
{
    public RaycastIKBody[] pernas;
    Vector3 average;
    public Vector3 offset;
    Vector3 yVelocity;
    private void FixedUpdate()
    {
        average = GetMeanVector(pernas);

        this.transform.localPosition = Vector3.SmoothDamp(this.transform.position, average + offset, ref yVelocity, 1);

    }

    private Vector3 GetMeanVector(RaycastIKBody[] positions)
    {
        if (positions.Length == 0)
            return Vector3.zero;
        float x = 0f;
        float y = 0f;
        float z = 0f;
        foreach (RaycastIKBody pos in positions)
        {
            x += pos.transform.localPosition.x;
            y += pos.transform.localPosition.y;
            z += pos.transform.localPosition.z;
        }
        return new Vector3(x / positions.Length, y / positions.Length, z / positions.Length);
    }

}
