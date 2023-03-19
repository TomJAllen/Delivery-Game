using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);

    [SerializeField] float destroyDelay = 1f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    private void Start() {
      spriteRenderer = GetComponent<SpriteRenderer
      >();
    }

   private void OnCollisionEnter2D(Collision2D other)
   {
      Debug.Log("HIT!!!");
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
    if (other.tag == "Pizza" && !hasPackage)
    {
      Debug.Log("Picked Up!");
      hasPackage = true;
      spriteRenderer.color = hasPackageColor;
      Destroy(other.gameObject, destroyDelay);
    }
    if (other.tag == "Customer" && hasPackage)
    {
      Debug.Log("Delivered!");
      spriteRenderer.color = noPackageColor;
      hasPackage = false;
    }
   }
}
