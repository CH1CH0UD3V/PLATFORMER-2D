using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] InputActionReference _moveInput;
    [SerializeField] InputActionReference _jumpInput;
    //[SerializeField] InputActionReference _actionButtonInput;
    //[SerializeField] InputActionReference _fightInput;
    [Header("Movement")]
    [SerializeField] float _speed = 4f;
    [SerializeField] Transform _root;
    [Header("Animator")]
    [SerializeField] Animator _animator;
    [SerializeField] float _movingThreshold = 0.1f;
    [Header("Jump")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Vector3 _jumpDirection;
    [Header("Raycast")]
    [SerializeField] Transform _footPoint;
    [SerializeField] float _raycastLength;

    Vector2 _playerMovement;
    bool _isGrounded;


    private void Start()
    {
        //move
        _moveInput.action.started += StartMove;
        _moveInput.action.performed += UpdateMove; ;
        _moveInput.action.canceled += EndMove; ;


       //jump
        _jumpInput.action.started += StartJump;
        _jumpInput.action.canceled += EndJump;
    }


    private void FixedUpdate()
    {
        //Deplacement horizontal
        
        Debug.Log(_playerMovement);       

        //Mouvement
        Vector2 direction = new Vector2(_playerMovement.x, 0);
        _root.transform.Translate(direction * Time.fixedDeltaTime * _speed, Space.World);

        //Animator
        Debug.Log($"Magnitude : {direction.magnitude}");

        if (direction.magnitude > _movingThreshold)  //si on est en train de bouger
        {
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }


        //Orientation personnage (le personnage s'oriente en fonction de la direction que )

        if (direction.x > 0) //Right
        {
            _root.rotation = Quaternion.Euler (0, 0, 0);
        }
        else if (direction.x < 0)   //Left
        {
            _root.rotation = Quaternion.Euler (0, 180, 0);
        }

        //isGrounded

        Debug.DrawRay(_footPoint.position, Vector2.down * _raycastLength, Color.red, 1f);
        int raycastLayerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(_footPoint.position, Vector2.down, _raycastLength, raycastLayerMask);

        if (hit.collider != null)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    private void StartMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();
        //Debug.Log($"KEYBOARD touche enfoncé ! {_playerMovement}");
    }
    private void UpdateMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();        
        //Debug.Log($"KEYBOARD UPDATE ! {_playerMovement}");
    }
    private void EndMove(InputAction.CallbackContext obj)
    {
        //Debug.Log("KEYBOARD Fin d'appui !");
        _playerMovement = new Vector2(0,0);
    }
    
    
    private void StartJump(InputAction.CallbackContext obj)
    {
        if (_isGrounded == true)
        {
            Debug.Log("j'ai sauté");
            _rb.AddForce(_jumpDirection);
        }

        else
        {
            Debug.Log("attens ouech t'as pas atteint le sol");
        }
    }

    private void EndJump(InputAction.CallbackContext obj)
    {
        Debug.Log("j'ai fini");
    }
}