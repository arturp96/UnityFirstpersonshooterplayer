
/*using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 2f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject speedFromFps;
    

    private float nextTimeToFire = 0f;

   
    // Update is called once per frame
    void  FixedUpdate () {

        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 10f / fireRate;
        }
        if (Input.GetButton("Fire1")) //&& Time.time >=nextTimeToFire)
        {

            //nextTimeToFire = Time.time + 1f / fireRate;
            speedFromFps.GetComponent<FpsController>().speed = 5f;
            Shoot();
            


        }
        else
        {
            speedFromFps.GetComponent<FpsController>().speed = 10f;
        }
        
        

    }

    public void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);

            
        }
    }

    
}
*/
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    //public float fireRate = 0.5f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject speedFromFps;

    private float nextTimeToFire = 0f;

    void Update()
    {

        // This isn't what you asked for help with,
        // but you may want to move this firing code to
        // Update(). Since FixedUpdate() isn't guaranteed
        // to run every frame, firing may feel unresponsive
        // if a lot of physics interactions are occurring
        // in the scene.

        if (Input.GetButton("Fire1")) //&& Time.time >= nextTimeToFire)
        {

           // nextTimeToFire = Time.time + fireRate;
            FpsController.Instance.speed = 5f;

            Shoot();
        }
        else if (FpsController.Instance.speed != 10f)
        {
            FpsController.Instance.speed = 10f;
        }

    }

    public void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);


        }
    }
}