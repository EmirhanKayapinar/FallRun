using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutCollider : MonoBehaviour
{
    [SerializeField] GameObject _player;

    [SerializeField] Transform[] _transforms;

    GameObject _enemy;
    Animator _enemyAnim;

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("donut");
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);
            collision.gameObject.GetComponent<Animator>().SetBool("__isHit", true);
            _player.GetComponent<PlayerController>()._isRun = false;
            _player.GetComponent<PlayerController>().enabled = false;

            Invoke("GetUp", 2f);

        }

    }

    IEnumerator EnemyBekle()
    {
        yield return new WaitForSeconds(2);
        _enemyAnim.SetBool("__isHit", false);
        _enemyAnim.SetBool("__isDeath", false);
        _enemyAnim.SetBool("__isRun", false);
        _enemy.GetComponent<EnemyController>().enabled = true;
    }


    void GetUp()
    {
        _player.GetComponent<PlayerController>().enabled = true;
        _player.GetComponent<PlayerController>()._isRun = false;
        _player.GetComponent<Animator>().SetBool("__isHit", false);
        _player.GetComponent<Animator>().SetBool("__isDeath", false);
        _player.GetComponent<Animator>().SetBool("__isRun", false);
    }
   
    void Raycast()
    {

        for (int i = 0; i < _transforms.Length; i++)
        {
            
            
            RaycastHit _hit;
            if (i ==0)
            {
                Ray _ray = new Ray(_transforms[i].position, transform.TransformDirection(Vector3.left * 0.2f));
                Debug.DrawRay(_transforms[i].position, transform.TransformDirection(Vector3.left * 0.2f), Color.red);
                if (Physics.Raycast(_ray, out _hit, 0.2f) && _hit.collider.tag == "Player")
                {  
                    _player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.left * 5;
                   
                    Debug.Log("bbb");
                }

                if (Physics.Raycast(_ray, out _hit, 0.2f) && _hit.collider.tag == "Enemy")
                {
                    _hit.collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.left * 5;
                    
                    Debug.Log("aaa");
                }
            }
            else
            {
                Ray _ray = new Ray(_transforms[i].position, transform.TransformDirection(Vector3.left * 0.4f));
                Debug.DrawRay(_transforms[i].position, transform.TransformDirection(Vector3.left * 0.4f), Color.red);
                if (Physics.Raycast(_ray, out _hit, 0.4f)&& _hit.collider.tag=="Player")
                {
                    Debug.Log("ccc");
                    _player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.left * 5;
                    
                }

                if (Physics.Raycast(_ray, out _hit, 0.3f) && _hit.collider.tag == "Enemy")
                {
                    Debug.Log("aaa");
                    _hit.collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.left * 5;
                    
                }
            }
            
        }

    }

    private void Update()
    {
        Raycast();
      
    }
}
