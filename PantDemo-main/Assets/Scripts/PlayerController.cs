using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject _rotator;

    [SerializeField] Animator _playerAnim;

    [SerializeField] Transform _rayTransform;

    [SerializeField] float _speed;

    [SerializeField] float _Xspeed;

     float _amount;

    [SerializeField] float _smoot;

    float _xPosition, _xOffset;   

    public Vector3 _playerSpawn;

    Rigidbody _rigid;

    public bool _isRun;




    void Move()
    {
        if (_isRun)
        {
            transform.Translate(transform.forward * Time.deltaTime * _speed);
        }



    }


    public void Hareket(float x)
    {
        if (_isRun)
        {
            _amount = x * _Xspeed * Time.deltaTime;

            Vector3 target = new Vector3(_amount, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, _smoot);
        }


    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zemin"))
        {
            _playerAnim.SetBool("__isFall", true);
            _playerAnim.SetBool("__isHit", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Zemin"))
        {
            _playerAnim.SetBool("__isFall", false);
        }
    }

    public void GetUp()
    {
        _rigid.velocity = Vector3.up * 2;
    }

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        _playerSpawn = transform.position;
        
    }



    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _isRun = true;
            _playerAnim.SetBool("__isRun", true);
            _xOffset = Input.mousePosition.x - _xPosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isRun = false;
            _playerAnim.SetBool("__isRun", false);
            _xOffset = 0f;

        }
        if (Input.GetMouseButtonDown(0))
        {
            _xPosition = Input.mousePosition.x;
        }


    }


    private void FixedUpdate()
    {
        Move();
        if (_xOffset != 0)
        {
            Hareket(_xOffset);
        }
    }

}
