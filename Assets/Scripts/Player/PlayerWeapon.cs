using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public float fireRate = 100f;
    public float damage = 10f;
    //gun
    public GameObject gun;
    private Camera cam;
    private InputManager inputManager;
    public GameObject flash;
    public AudioClip shooting;
    private new AudioSource audio;
    private bool shootStop = true;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        inputManager = GetComponent<InputManager>();
        cam = GetComponent<PlayerLook>().camera;

    }

    // Update is called once per frame
    void Update()
    {
        flash.GetComponent<MeshRenderer>().enabled = false;

        if (inputManager.onFoot.Shoot.ReadValue<float>() > .1f)
        {
            Shoot();

        }
        if (inputManager.onFoot.ADS.ReadValue<float>() > .1f)
        {
            ADS();
        }
        inputManager.onFoot.Shoot.performed += ctx =>
        {
            shootStop = false;
            audio.loop = true;
            audio.clip = shooting;
            if (audio.isPlaying && !shootStop && audio.clip != shooting)
            {
                audio = gameObject.AddComponent<AudioSource>();
                audio.loop = true;
                audio.clip = shooting;
                audio.Play();
            }
            audio.Play();

        };
        inputManager.onFoot.Shoot.canceled += ctx =>
        {
            audio = GetComponent<AudioSource>();
            shootStop = true;
            audio.clip = shooting;
            audio.Stop();
        };
        inputManager.onFoot.ADS.canceled += ctx => gun.transform.localPosition = new Vector3(0.58f, -0.19f, 0.96f);
    }
    public void Shoot()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit HitInfo;
        flash.GetComponent<MeshRenderer>().enabled = true;
        if (Physics.Raycast(ray, out HitInfo, 100f))
        {
            if (HitInfo.collider.gameObject.name == "Enemy")
            {
                HitInfo.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }
    }
    public void ADS()
    {
        gun.transform.localPosition = new Vector3(0, -.05f, 1.3f);
    }
}
