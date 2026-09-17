using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpColliderTrigger : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Merger _merger;
    private bool IsFrozen = false;

    public int GetLevelValue() => _level.GetValue();
    public Rigidbody2D GetRigidbody() => _rigidbody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsFrozen) return;

        foreach (var contact in collision.contacts)
        {
            var currentCollider = contact.collider;
            if (IsLevelObject(currentCollider, out LevelUpColliderTrigger other) && IsSameLevel(other))
            {
                LevelUp(other);
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (IsLevelObject(otherCollider, out LevelUpColliderTrigger other) && IsSameLevel(other))
        {
            LevelUp(other);
        }
    }

    private void LevelUp(LevelUpColliderTrigger other)
    {
        other.Freeze();
        _merger.Unite(_rigidbody, other.GetRigidbody());
        _level.LevelUp();
    }

    public void Freeze() => IsFrozen = true;

    private bool IsSameLevel(LevelUpColliderTrigger other)
        => other.GetLevelValue() == GetLevelValue();

    private bool IsLevelObject(Collider2D collider, out LevelUpColliderTrigger other)
        => collider.TryGetComponent(out other);
}
