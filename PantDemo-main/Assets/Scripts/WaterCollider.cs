using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollider : MonoBehaviour
{
    [SerializeField] Animator _playerAnim;
    [SerializeField] GameObject _player;
    Animator _enemyAnim;
    GameObject _enemy;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            _playerAnim.SetBool("__isDeath", true);
            _player.GetComponent<PlayerController>().enabled = false;
            
            Invoke("StartAgain", 1f);
        }

 
    }
    IEnumerator EnemyBekle()
    {

        yield return new WaitForSeconds(2);
        _enemy.GetComponent<EnemyController>().enabled = true;
        _enemy.GetComponent<Transform>().position = _enemy.GetComponent<EnemyController>()._enemySpawn;
        _enemyAnim.SetBool("__isDeath", false);
        _enemyAnim.SetBool("__isRun", false);
        
    }
    public void StartAgain()
    {

        _player.transform.position = _player.GetComponent<PlayerController>()._playerSpawn;
        _playerAnim.SetBool("__isDeath", false);
        _player.GetComponent<PlayerController>().enabled = true;
        _player.GetComponent<PlayerController>()._isRun = false;
        _playerAnim.SetBool("__isRun", false);
        

    }
}
