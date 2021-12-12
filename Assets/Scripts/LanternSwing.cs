using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternSwing : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    public float swingSpeed;
    public float maxAngle;
    bool swingLeft = true;

    private void Start()
    {
        transform.Translate(new Vector3(0, 3, 0));
    }
    // Update is called once per frame
    void Update()
    {
        float angle = transform.eulerAngles.z;
        if(angle >= 180)
        {
            angle -= 360;
        }
        if (swingLeft)
        {
            rigid2D.angularVelocity = swingSpeed * ((maxAngle - Mathf.Abs(angle))/maxAngle + 0.1f);
            if (angle >= maxAngle)
            {
                swingLeft = false;
            }
        }
        else
        {
            rigid2D.angularVelocity = -swingSpeed * ((maxAngle - Mathf.Abs(angle) )/ maxAngle + 0.1f);
            if (angle <= -maxAngle)
            {
                swingLeft = true;
            }
        }
    }
}
