using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    Animator _enemyAnim;

    EnemyController _enemyControl;

    Rigidbody _rigid;
    IEnumerator EnemyBekle()
    {

        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Transform>().position = _enemyControl._enemySpawn ;
        
        _enemyAnim.SetBool("__isDeath", false);
        _enemyControl.enabled = true;


    }

    IEnumerator EnemyBekle2()
    {
        yield return new WaitForSeconds(2);
        _enemyAnim.SetBool("__isHit", false);
        //_enemyAnim.SetBool("__isDeath", false);
        _enemyAnim.SetBool("__isRun", false);
        _enemyControl.enabled = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DikeyTuzak")|| collision.gameObject.CompareTag("Water")  || collision.gameObject.CompareTag("RotatorStick"))
        {
            
            _rigid.velocity = Vector3.back * 5;

            _enemyAnim.SetBool("__isDeath", true);

            _enemyControl.enabled = false;

            StartCoroutine(EnemyBekle());
        }

        if (collision.gameObject.CompareTag("SagDonut") || collision.gameObject.CompareTag("SolDonut")|| collision.gameObject.CompareTag("SagTuzak")||collision.gameObject.CompareTag("SolTuzak"))
        {
          

            _rigid.velocity = new Vector3(0, 0, -5);

            _enemyAnim.SetBool("__isHit", true);

            _enemyControl.enabled = false;

            StartCoroutine(EnemyBekle2());

        }

        if (collision.gameObject.CompareTag("RotatorStick"))
        {
            
            Vector3 _vector = collision.gameObject.transform.position - transform.position;

            _rigid.velocity = _vector * 15;

            _enemyControl.enabled = false;

            _enemyAnim.SetBool("__isDeath", true);
            
            StartCoroutine(EnemyBekle());
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rotator1"))
        {
            transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);
            Debug.Log("Sag");
        }

        if (collision.gameObject.CompareTag("Rotator2"))
        {
            transform.position += new Vector3(+1 * Time.deltaTime, 0, 0);
            Debug.Log("Sol");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishWall"))
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            gameObject.GetComponent<EnemyController>().enabled = false;
            gameObject.GetComponent<Animator>().SetBool("__isRun", false);
            Debug.Log("bitti");
        }

        
    }

    
    private void Awake()
    {
        _enemyControl = GetComponent<EnemyController>();
        _enemyAnim = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody>();
    }
}
