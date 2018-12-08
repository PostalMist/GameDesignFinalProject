using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Set In Inspector")]
    public float power = 30.0f;
    //public ParticleSystem SmallExplosion;
    public float radius = 10.0f;
    public float upForce = 5.0f;
    // Use this for initialization
   // [Header("Dynamically Set In Inspector")]
    // private Rigidbody explosiveBody;
    public GameObject explosionPrefab;
    public AudioSource explosionSound;

    void Start()
    {
        // explosiveBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    /*void FixedUpdate () {
        if (explosiveBody.IsSleeping()) {
            Detonate();
           Destroy(this);
            fire = Instantiate(SmallExplosion);
            fire.transform.

        }
	}*/
    void OnCollisionEnter(Collision collision)
    {
        // Invoke("Detonate",1.0f);
        Detonate();
    }

    public void Detonate()
    {
        Vector3 explosionPosition = this.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);

        //fire = Instantiate(SmallExplosion);
        GameObject go = Instantiate(explosionPrefab) as GameObject;
        go.transform.position = this.transform.position;
        Invoke("playExplosion", 100f);
         //explosion.transform.position = transform.position;
         //explosion.Play(true);
         //Destroy(fire,3.0f);
        print(colliders);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                if (this.gameObject != null)
                {
                    Destroy(this.gameObject);
                }
                // Destroy(fire);

            }
        }
       // Destroy(go);
        //explosionSound.Play();
        //fire.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    void playExplosion() {
        explosionSound.Play();
    }
}
