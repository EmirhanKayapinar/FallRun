using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCollider : MonoBehaviour
{
    [SerializeField] GameObject _main,paintWall;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>()._isRun = false;

            other.gameObject.GetComponent<PlayerController>().enabled = false;

            other.gameObject.GetComponent<Animator>().SetBool("__isRun", false);

            paintWall.SetActive(true);
            other.gameObject.transform.position = new Vector3(1.31f, 0.03759584f, 48.05179f);
        }

    }
}
