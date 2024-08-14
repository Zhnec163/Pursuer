using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance;
    [SerializeField] private Player _player;

    private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Chase();
    }

    private void Chase()
    {
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, _player.transform.position);

        if (distance > _stopDistance)
        {
            Vector3 moveVector = direction * _speed * Time.deltaTime;
            _rigidbody.MovePosition(transform.position + moveVector);
        }
    }
}