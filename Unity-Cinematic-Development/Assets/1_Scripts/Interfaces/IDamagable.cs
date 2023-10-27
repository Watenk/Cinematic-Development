using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    int MaxHealth { get; }
    int Health { get; set; }
    void TakeDamage(int _amount);
    void Die();
}
