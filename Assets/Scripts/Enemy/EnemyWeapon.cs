using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float fireRate = 100f;
    public float damage = 10f;
    //gun
    public GameObject gun;

    public void Shoot()
    {
        Ray ray = new Ray(gun.transform.position, gun.transform.forward);
        RaycastHit HitInfo;
        if (Physics.Raycast(ray, out HitInfo, 100f))
        {
            if (HitInfo.collider.gameObject.name == "Player")
            {

                HitInfo.collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }
}
