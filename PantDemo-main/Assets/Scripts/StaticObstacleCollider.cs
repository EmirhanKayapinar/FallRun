using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObstacleCollider : MonoBehaviour
{
    [SerializeField] GameObject _player;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("static");
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);
            collision.gameObject.GetComponent<Animator>().SetBool("__isHit", true);
            _player.GetComponent<PlayerController>().enabled = false;

            Invoke("GetUp", 2f);
            
        }


    }

    void GetUp()
    {
        _player.GetComponent<PlayerController>().enabled = true;
        _player.GetComponent<PlayerController>()._isRun = false;
        _player.GetComponent<Animator>().SetBool("__isHit" , false);
        _player.GetComponent<Animator>().SetBool("__isRun" , false);


    }
}
