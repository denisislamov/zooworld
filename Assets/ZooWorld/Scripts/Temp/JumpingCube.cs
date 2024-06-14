using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class JumpingCube : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _pauseBetweenJumps;
    
    [SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {
        StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        while (true)
        {
            var randomDirection = Random.insideUnitSphere;
            Vector3 targetPosition = transform.position + randomDirection * _distance;
            
            bool leftOrRight = Random.value > 0.5f;
            Vector3 rotationDirection = leftOrRight ? -transform.up : transform.up;
            
            _rigidbody.AddRelativeTorque(rotationDirection * 5, ForceMode.Impulse);
            yield return new WaitForSeconds(1.0f);
            yield return new WaitForFixedUpdate();
            
            _rigidbody.AddForce(Vector3.up * 10 + transform.forward, ForceMode.Impulse);
            yield return new WaitForSeconds(_pauseBetweenJumps);
            yield return new WaitForFixedUpdate();
        }
    }
}