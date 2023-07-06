using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor  = new Color32(1,1,1,1);
    [SerializeField] float delay = 0.5f;
    SpriteRenderer spriteRenderer;
    bool hasPackage;
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Boing!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage){
            Debug.Log("Package is picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, delay);
        }

        if(other.tag == "Customer" && hasPackage){
            Debug.Log("Package is delivered!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }   
}
