using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField]
    Transform firingPoint;
    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    float fireSpeed;

    public static PlayerGun Instance;

    private float lastTimeShot = 0;
  
    void Awake()
    {
        Instance = GetComponent<PlayerGun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (lastTimeShot + fireSpeed <= Time.time)
        {
            lastTimeShot = Time.time;
            Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
        }
     
    }
}
