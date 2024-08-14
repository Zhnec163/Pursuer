using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _characterController;
    private string _horiazontal = "Horizontal";
    private string _vertical = "Vertical";

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis(_horiazontal);
        float verticalInput = Input.GetAxis(_vertical);
        Vector3 playerInput = new Vector3(horizontalInput, 0, verticalInput);

        if (_characterController.isGrounded)
            _characterController.Move(playerInput * _speed * Time.deltaTime + Vector3.down);
        else
            _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);
    }
}