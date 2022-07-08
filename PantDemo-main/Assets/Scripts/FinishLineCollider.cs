using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCollider : MonoBehaviour
{
    [SerializeField] GameObject _main,paintWall,_finishTrigger;

    [SerializeField] GameObject[] enemy; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>()._isRun = false;

            other.gameObject.GetComponent<PlayerController>().enabled = false;

            other.gameObject.GetComponent<Animator>().SetBool("__isRun", false);

            paintWall.SetActive(true);
            other.gameObject.transform.position = new Vector3(1.31f, 0.03759584f, 48.05179f);

            _main.GetComponent<RankManager>()._isFinish = true;
            foreach (GameObject item in enemy)
            {
                item.transform.position = new Vector3(0, 200, 0);
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                item.GetComponent<EnemyController>().enabled = false;
            }
            _finishTrigger.SetActive(false);
        }

    }
}
