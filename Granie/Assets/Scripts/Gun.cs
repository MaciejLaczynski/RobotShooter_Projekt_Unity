using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    [Range(0.1f, 1.5f)]
    private float fireRate = 0.4f;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    [SerializeField]
    private AudioSource gunFire;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= fireRate)
        {
            if(Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }
    private void FireGun()
    {

        muzzleParticle.Play();
        gunFire.Play();

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 1f);
        RaycastHit hitInfo; 

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<EnemyHealth>();
            
            if (health != null)
                health.TakeDamage(damage);
        }
    }
}
