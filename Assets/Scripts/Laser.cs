using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] float laserLength;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        ResetLaser();
    }

    void ResetLaser()
    {
        lineRenderer.SetPosition(1, new Vector3(0f, laserLength, 0f));
    }

    private void FixedUpdate()
    {
        int layerMask = 1 << 3;
        layerMask = ~layerMask;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, laserLength, layerMask);
        Destroy(gameObject.GetComponent<EdgeCollider2D>());
        
        if (hit.collider != null)
        {
            lineRenderer.SetPosition(1, new Vector3(0f, Vector3.Distance(transform.position, hit.point), 0f));
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Hit");
            }
        }
        else
        {
            ResetLaser();
        }
    }
}
