using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    private Rigidbody _rb;
    private Camera _mainCamera;

    private float _moveVertical;
    private float _moveHorizontal;
    private float _moveSpeed = 5f;
    private float _speedLimiter = 0.7f;
    private Vector2 _moveVelocity;

    private Vector2 _mousePos;
    private Vector2 _offset;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletSpawn;
   
    bool _isShooting = false;
    private float _bulletSpeed = 15f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _moveVertical = Input.GetAxisRaw("Vertical");

        _moveVelocity = new Vector2(_moveHorizontal,  _moveVertical) * _moveSpeed;

        if (Input.GetMouseButtonDown(0))
        {
            _isShooting = true;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
        RotationPlayer();

        if (_isShooting)
        {
            StartCoroutine(File());
        }
    }

    void MovePlayer()
    {
        
    }
}
