using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Entity _owner;
    private float _maxHealth;
    private float _currentHealth;

    public void Initialized(Entity owner)
    {
        _owner = owner;
    }

    public void ApplyeDamage(float damage)
    {
        _currentHealth = Mathf.Max(_currentHealth - damage, 0);

    }
}
