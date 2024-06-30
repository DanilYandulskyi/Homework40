using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Enemy : Entity
{
    [SerializeField] private Vector2 _direction;
    
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        _mover.Move(_direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.Health.Decrease(Damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PatrolPoint patrol))
        {
            _direction = _mover.DeployVector(_direction);
        }
    }
}
