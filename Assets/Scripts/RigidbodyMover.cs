using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance;
    [SerializeField] private Transform _target;

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
        if (_target != null)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, _target.position);

            if (distance > _stopDistance)
            {
                Vector3 moveVector = direction * _speed * Time.deltaTime;
                _rigidbody.MovePosition(transform.position + moveVector);
            }
        }
    }
}