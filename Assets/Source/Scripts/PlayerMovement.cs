using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed;
    private Rigidbody2D _rigidbody;
    private ParticleSystem _particleSystem;
    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _particleSystem.Play();
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _particleSystem.Stop();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bomb bomb))
        {
            bomb.Die();
        } 
    }
}
