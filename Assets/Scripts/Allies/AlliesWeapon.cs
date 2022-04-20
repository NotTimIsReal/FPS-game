using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliesWeapon : MonoBehaviour
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
            if (HitInfo.collider.gameObject.tag == "Enemy")
            {

                HitInfo.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }
    }
}
