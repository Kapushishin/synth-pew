using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer lineRenderer;

    [SerializeField] float laserLength;
    
    public static RaycastHit2D hit;

    public GameObject explosionVFX;

    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        ResetLaser();
    }

    public void ResetLaser()
    {
        lineRenderer.SetPosition(1, new Vector3(0f, laserLength, 0f));
    }

    public void FixedUpdate()
    {
        int layerMask = 1 << 3;
        layerMask = ~layerMask;

        hit = Physics2D.Raycast(transform.position, transform.up, laserLength, layerMask);
        if (hit.collider != null)
        {
            lineRenderer.SetPosition(1, new Vector3(0f, Vector3.Distance(transform.position, hit.point), 0f));
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Hit");
                //CircleSettings.Destr(hit.collider.gameObject);
            }
        }
        else
        {
            ResetLaser();
        }
    }
}
