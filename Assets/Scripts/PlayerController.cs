using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _player;
    private Vector3 _moveDir;

    private float _moveSpeed = 20f;
    private float _gravity = -9.81f;    // Gravedad est�ndar
    private float _jumpHeight = 3f;     // Altura del salto

    private float _rotationSpeed = 180f; // Velocidad de rotaci�n (grados por segundo)

    // Variables para la detecci�n del suelo
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded;
    private float _verticalVelocity;

    private void Awake()
    {
        _player = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Verificar si est� en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && _verticalVelocity < 0)
        {
            _verticalVelocity = -2f; // Asegurarse de que el jugador est� pegado al suelo
        }

        // Movimiento horizontal
        _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (_moveDir.magnitude > 1)
            _moveDir = _moveDir.normalized * _moveSpeed;
        else
            _moveDir = _moveDir * _moveSpeed;

        // Rotaci�n del jugador
        float rotationInput = Input.GetAxis("Mouse X"); // Tambi�n puedes usar otro eje, como Horizontal para rotar con teclado
        transform.Rotate(0, rotationInput * _rotationSpeed * Time.deltaTime, 0);

        // Ajustar direcci�n de movimiento al frente del jugador
        _moveDir = transform.TransformDirection(_moveDir);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity); // F�rmula f�sica para el salto
        }

        // Aplicar gravedad
        _verticalVelocity += _gravity * Time.deltaTime;

        // Movimiento vertical (gravedad + salto)
        _moveDir.y = _verticalVelocity;

        // Mover el jugador
        _player.Move(_moveDir * Time.deltaTime);
    }
}
