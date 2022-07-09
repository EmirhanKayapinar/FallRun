using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCollider : MonoBehaviour
{
    [SerializeField] GameObject _main,paintWall,_finishTrigger,_duvarBoya;

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
                

                if (item.transform.position.z < transform.position.z)
                {
                    item.transform.position = new Vector3(0, 0, 0);
                    item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    item.GetComponent<Animator>().SetBool("__isRun", false);
                    item.GetComponent<EnemyController>()._isFinish = true;
                    item.GetComponent<EnemyController>().enabled = false;
                }
            }
            _finishTrigger.SetActive(false);
            _duvarBoya.SetActive(true);
        }

    }
}
