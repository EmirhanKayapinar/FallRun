using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform[] _transforms;
    [SerializeField] GameObject _player;
    [SerializeField] Animator _enemyAnim;
     Rigidbody _rigid;
    public Vector3 _enemySpawn;
    bool _isHit;
    public bool _isFinish;
    void Run()
    {
        if (!_isHit&& !_isFinish)
        {
            transform.position += new Vector3(0, 0, 2 * Time.deltaTime);
            _enemyAnim.SetBool("__isRun", true);

        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zemin"))
        {
            _enemyAnim.SetBool("__isFall", true);
            _enemyAnim.SetBool("__isHit", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Zemin"))
        {
            _enemyAnim.SetBool("__isFall", false);
        }
    }
    
    IEnumerator Bekle()
    {
        transform.position += new Vector3(0, 0, 0);
        _enemyAnim.SetBool("__isRun", false);
        yield return new WaitUntil(()=>_isHit);
        
        //transform.position += new Vector3(0, 0, 0);
        
        yield return new WaitForSeconds(0.5f);
        _isHit = false;
    }
    void Raycast()
    {
        for (int i = 0; i < _transforms.Length; i++)
        {
            Ray _ray = new Ray(_transforms[i].position, transform.TransformDirection(_transforms[i].forward * 2.5f));
            Debug.DrawRay(_transforms[i].position, transform.TransformDirection(_transforms[i].forward * 2.5f), Color.red);
            RaycastHit _hit;

            if (Physics.Raycast(_ray, out _hit, 2.5f))
            {
                if (_hit.collider.tag == "SagTuzak")
                {
                   


                        _enemyAnim.SetBool("__isRun", true);
                        transform.position += new Vector3(-0.75f * Time.deltaTime,0, 0);
                        Debug.Log("1");
                    
                    
                    
                }
                if (_hit.collider.tag == "SolTuzak")
                {
                    
                        _enemyAnim.SetBool("__isRun", true);
                        transform.position += new Vector3(0.75f * Time.deltaTime, 0, 0);
                        Debug.Log("2");
                    
                    
                }
                if (_hit.collider.tag == "Rotatorr")
                {
                    
                      _enemyAnim.SetBool("__isRun", true);
                      transform.position += new Vector3(2f * Time.deltaTime, 0, 0);
                    
                    
                }
                if (_hit.collider.tag == "DikeyTuzak" || _hit.collider.tag == "SagDonut" || _hit.collider.tag == "SolDonut")
                {
                    
                        
                        _isHit = true;
                        StartCoroutine(Bekle());
                    
                    
                }

                if (_hit.collider.tag == "Rotator"|| _hit.collider.tag == "RotatorStick")
                {
                    
                        _isHit = true;
                        Debug.Log("4");
                        StartCoroutine(Bekle());
                    
                    
                }


            }
        }
    }
    private void FixedUpdate()
    {
        Raycast();
        Run();
    }

    public void GetUp()
    {
        _enemyAnim.SetBool("__isHit", false);
        _enemyAnim.SetBool("__isDeath", false);
        
    }

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }
    void Start()
    {
        _enemySpawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
