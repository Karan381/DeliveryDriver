using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destdelay;
    bool pickedPackage = false;
    [SerializeField] Color32 haspackagecolor = new Color32 (1,1,1,1);
    [SerializeField] Color32 nopackagecolor = new Color32(1, 1, 1, 1);
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bump");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "package")
        {
            if (pickedPackage != true)
            {
                Debug.Log("Package");
                pickedPackage = true;
                spriteRenderer.color = haspackagecolor;
                Destroy(collision.gameObject, destdelay);
            }
        }
        if (collision.tag == "customer" && pickedPackage == true)
        {
            Debug.Log("Delivered Package");
            pickedPackage = false;
            spriteRenderer.color = nopackagecolor;
        }

    }

}
