using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPunchTrigger : MonoBehaviour
{
    public UnityEvent OnDamageEnemy;

    private void Awake()
    {
        if (OnDamageEnemy == null) OnDamageEnemy = new UnityEvent();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage(1);
            OnDamageEnemy.Invoke();
        }
    }
}
