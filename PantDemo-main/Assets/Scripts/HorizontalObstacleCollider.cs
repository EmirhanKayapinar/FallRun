using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacleCollider : MonoBehaviour
{
    [SerializeField] Animator _playerAnim;
    [SerializeField] GameObject _player;
    Animator _enemyAnim;
    GameObject _enemy;

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody _rigid = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 _vector = collision.gameObject.transform.position - transform.position;

            _rigid.velocity = Vector3.back * 5;

            _playerAnim.SetBool("__isDeath", true);

            _player.GetComponent<PlayerController>().enabled = false;

            Invoke("StartAgain", 2);

            gameObject.GetComponent<Collider>().enabled = false;
        }

        //if (collision.gameObject.CompareTag("Enemy"))
        //{

        //    Rigidbody _rigid = collision.gameObject.GetComponent<Rigidbody>();

        //    Vector3 _vector = collision.gameObject.transform.position - transform.position;

        //    _rigid.velocity = Vector3.back * 5;

        //    collision.gameObject.GetComponent<Animator>().SetBool("__isDeath", true);

        //    collision.gameObject.GetComponent<EnemyController>().enabled = false;
            

        //    gameObject.GetComponent<Collider>().enabled = false;

        //    _enemyAnim = collision.gameObject.GetComponent<Animator>();
        //    _enemy = collision.gameObject;

        //    StartCoroutine(EnemyBekle());
                
            
            
                

            
        //}
    }
    IEnumerator EnemyBekle()
    {

        yield return new WaitForSeconds(2);
        _enemy.GetComponent<Transform>().position = _enemy.GetComponent<EnemyController>()._enemySpawn;
        gameObject.GetComponent<Collider>().enabled = true;
        _enemyAnim.SetBool("__isDeath", false);
        _enemy.GetComponent<EnemyController>().enabled = true;


    }
    public void StartAgain()
    {

        _player.transform.position = _player.GetComponent<PlayerController>()._playerSpawn;
        _playerAnim.SetBool("__isDeath", false);
        _player.GetComponent<PlayerController>().enabled = true;
        _playerAnim.SetFloat("__isRun", 0);
        gameObject.GetComponent<Collider>().enabled = true;

    }

}
