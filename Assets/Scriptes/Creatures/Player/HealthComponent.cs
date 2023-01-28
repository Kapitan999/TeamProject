using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _onDamage;
    [SerializeField] private UnityEvent _onHeal;
    [SerializeField] private UnityEvent _onFullHeal;

    [SerializeField] private UnityEvent _onDie;

    private int defaultHeath;
    public int Health => _health;

    private void Awake() {
        defaultHeath = _health;
    }
    public void ApplyDamage(int hpDelta){

        if (_health<=0) return;
        _health+=hpDelta;

        if (hpDelta<0){
            _onDamage?.Invoke();
        }

        if (hpDelta>0){
            _onHeal?.Invoke();
        }
        
        if (_health == defaultHeath){
            _onFullHeal?.Invoke();
        }

        if (_health<=0){
            _onDie?.Invoke();
        }
    }

}
