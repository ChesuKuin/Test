using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Camera myCam;
    private Vector3 screenPos;
    private float angleOffset;
    private Collider2D col;
    private bool canRotate = true;

    private void Start()
    {
        myCam = Camera.main;
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Vector3 mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (col == Physics2D.OverlapPoint(mousePos) && canRotate)
            {
                screenPos = myCam.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (col == Physics2D.OverlapPoint(mousePos) && canRotate)
            {
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                float newZRotation = angle + angleOffset;

                // Check if the new rotation is within the -1 to 1 degree range
                if (newZRotation > 1 || newZRotation < -1)
                {
                    transform.eulerAngles = new Vector3(0, 0, newZRotation);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    canRotate = false; // Disable further rotation
                }
            }
        }
    }
}

