using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorStickCollider : MonoBehaviour
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

            _rigid.velocity = _vector * 15;

            _playerAnim.SetBool("__isDeath", true);

            collision.gameObject.GetComponent<PlayerController>().enabled = false;

            Invoke("StartAgain", 2);

        }

    }

    IEnumerator EnemyBekle()
    {
        yield return new WaitForSeconds(2);

        _enemy.GetComponent<EnemyController>().enabled = true;

        _enemy.transform.position = _enemy.GetComponent<EnemyController>()._enemySpawn;

        _enemyAnim.SetBool("__isDeath", false);
    }

    public void StartAgain()
    {

        _player.transform.position = _player.GetComponent<PlayerController>()._playerSpawn;

        _playerAnim.SetBool("__isDeath", false);

        _player.GetComponent<PlayerController>().enabled = true;
        _player.GetComponent<PlayerController>()._isRun = false;

    }
}
