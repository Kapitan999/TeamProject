using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] private int damage;

    public void Damage(GameObject target){
        var _health = target.GetComponent<HealthComponent>();

        if (_health!= null){
            _health.ApplyDamage(damage);
        }
    }
}
