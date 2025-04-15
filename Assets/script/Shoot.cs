using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public AudioSource src; 
    public AudioClip sfx;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            src.clip =  sfx;
            src.Play();
            Instantiate(bulletPrefab,shootingPoint.position,transform.rotation);
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            src.clip =  sfx;
            src.Play();
            Instantiate(bulletPrefab,shootingPoint.position,transform.rotation);
        }
    }
}
