using System.Collections;
using UnityEngine;

public class LinearCube : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    
    private void Start()
    {
        StartCoroutine(Move());
        StartCoroutine(Rotate());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            _rigidbody.velocity = transform.forward * _speed;
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            bool leftOrRight = Random.value > 0.5f;
            Vector3 rotationDirection = leftOrRight ? -transform.up : transform.up;
            
            _rigidbody.AddRelativeTorque(rotationDirection * 5, ForceMode.Impulse);
            yield return new WaitForSeconds(2.0f);
            yield return new WaitForFixedUpdate();
        }
    }
}