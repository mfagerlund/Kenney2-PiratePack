using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private float _lastFireTime = 0;

    public Transform bulletSpawnPosition;
    public GameObject bullet;
    public float fireCooldownPeriod = 1f;
    public LayerMask targetLayer;

    void FixedUpdate()
    {
        if ((Time.time - _lastFireTime) > fireCooldownPeriod)
        {
            var hit = Physics2D.Raycast(bulletSpawnPosition.position, transform.right, 1000, targetLayer);
            if (hit.collider != null)
            {
                Instantiate(bullet, bulletSpawnPosition.position, transform.rotation);
                _lastFireTime = Time.time;
            }
        }
    }
}
