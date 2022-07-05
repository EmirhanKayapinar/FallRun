using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformCollider : MonoBehaviour
{

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.transform.SetParent(null);
            collision.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    

}
