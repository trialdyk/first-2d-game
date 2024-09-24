using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    
    [SerializeField] private Color32 hasPackageColor = new Color32(255,255,0,255);
    [SerializeField] private Color32 noPackageColor = new Color32(255,255,255,255);
    
    private bool _hasPackage;

    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = noPackageColor;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Aduh..");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Package" when !_hasPackage:
                Debug.Log("Pickup Package");
                _hasPackage = true;
                _spriteRenderer.color = hasPackageColor;
                Destroy(other.gameObject,0.5f);
                break;
            case "Customer" when _hasPackage:
                Debug.Log("Package Delivered");
                _hasPackage = false;
                _spriteRenderer.color = noPackageColor;
                break;
        }
    }
}
