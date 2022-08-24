using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputActionReference _moveInput;
    //[SerializeField] InputActionReference _jumpInput;
    //[SerializeField] InputActionReference _actionButtonInput;
    //[SerializeField] InputActionReference _fightInput;
    [SerializeField] float _speed = 2f;
    [SerializeField] Transform _root;
    [SerializeField] Animator _animator;
    [SerializeField] float _movingThreshold = 0.1f;
    //[SerializeField] float _jumpingThreshold = 0.1f;

    //[SerializeField] Rigidbody2D _Player;

    Vector2 _playerMovement;
    //Vector2 _playerJump;


    private void Start()
    {
        //move
        _moveInput.action.started += StartMove;
        _moveInput.action.performed += UpdateMove; ;
        _moveInput.action.canceled += EndMove; ;


       /* //jump
        _jumpInput.action.started += StartJump;
        _jumpInput.action.canceled += EndJump;*/
    }


    private void FixedUpdate()
    {
        //Deplacement horizontal
        
        Debug.Log(_playerMovement);       

        //Mouvement
        Vector2 direction = new Vector2(_playerMovement.x, 0);
        _root.transform.Translate(direction * Time.fixedDeltaTime * _speed);

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


        //Orientation personnage

        if (direction.x > 0) //Right
        {
            _root.localScale = new Vector3
        }


       /* Debug.Log(_playerJump);

        //Mouvement
        Vector2 jumpDirection = new Vector2(0, _playerJump.y);
        _root.transform.Translate(jumpDirection * Time.fixedDeltaTime * _speed);

        //Animator
        Debug.Log($"Magnitude : {jumpDirection.magnitude}");

        if (jumpDirection.magnitude > _jumpingThreshold)  //si on est en train de bouger
        {
            _animator.SetBool("IsJumping", true);
        }
        else
        {
            _animator.SetBool("IsJumping", false);
        }*/

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
    
    
    
    
   /* private void StartJump(InputAction.CallbackContext obj)
    {
        Debug.Log("j'ai sauté");

        //_playerJump = obj.ReadValue<Vector2>();
        //Debug.Log($"Jump touche enfoncé ! {_playerJump}");
    }

    private void EndJump(InputAction.CallbackContext obj)
    {
        Debug.Log("j'ai fini");
    }*/
}