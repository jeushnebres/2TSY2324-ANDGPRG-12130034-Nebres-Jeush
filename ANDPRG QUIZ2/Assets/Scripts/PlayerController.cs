using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
        HandleRotationInput();
        HandleShootInput();
    }

    void HandleMovementInput()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        Vector3 _movement = new Vector3(_horizontal, 0, _vertical);
        transform.Translate(_movement * movementSpeed * Time.deltaTime, Space.World);
    }

    void HandleRotationInput()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        }
    }

    void HandleShootInput()
    {
        if (Input.GetButton("Fire1"))
        {
            PlayerGun.Instance.Shoot();
        }
    }
}
