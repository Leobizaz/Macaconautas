using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[ExecuteAlways]
public class RaycastIKBody : MonoBehaviour
{
    public Vector3 offset;
    public LayerMask layerMask;
    public RaycastIKBody otherLeg;
    public GameObject targetJoint;
    public float currentDist;
    public bool grounded;
    public AnimationCurve yCurve;
    Sequence sequence;
    Vector3 yVelocity;
    float t = 0;
    private void Start()
    {
        sequence = DOTween.Sequence();
    }

    private void FixedUpdate()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(transform.position + offset, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
        {
            transform.position = hit.point;
        }

        currentDist = Vector3.Distance(targetJoint.transform.position, this.transform.position);

        if(currentDist > 2f && grounded && otherLeg.grounded)
        {
            t = 0;
            grounded = false;
            //targetJoint.transform.DOMove(this.transform.position, 0.3f).SetEase(Ease.Linear);
            //targetJoint.transform.DOMoveY(targetJoint.transform.position.y + 1, 0.4f).SetEase(yCurve);
            //targetJoint.transform.position = Vector3.SmoothDamp(targetJoint.transform.position, this.transform.position, ref yVelocity , 0.3f);
        }

        if(!grounded)
        {
            t += Time.deltaTime;

            float index = Mathf.InverseLerp(0, 0.3f, t);
            targetJoint.transform.position = new Vector3(Mathf.Lerp(targetJoint.transform.position.x, this.transform.position.x, index),
                Mathf.Lerp(targetJoint.transform.position.y + 2 * index, this.transform.position.y, index), 
                Mathf.Lerp(targetJoint.transform.position.z, this.transform.position.z, index));

            if(t >= 0.3f)
            {
                SetGrounded();
            }
        }



    }

    void SetGrounded()
    {
        grounded = true;
    }
}
