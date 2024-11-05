using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


public class GameCharacterController : MonoBehaviour
{
    [SerializeField] int id;
    private int _atk;
    private int _hp;

    public IObservable<int> HpObservable;
    public int Hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }
    public Queue<BaseSkill> _skillQueue;

    public BaseSkill _currentSkill;

    private void Awake()
    {
        HpObservable = (new Subject<int>()).AsObservable();
    }
    public virtual void Update()
    {
        if (_currentSkill != null)
        {
            _currentSkill.Tick(Time.deltaTime);
            if (_currentSkill.IsDone)
            {
                _currentSkill = null;
            }
        }
        else if (_skillQueue.Count > 0)
        {
            _currentSkill = _skillQueue.Dequeue();
        }

        if (_currentSkill != null)
        {
            _currentSkill.Tick(Time.deltaTime);
            if (_currentSkill.IsDone)
            {
                _currentSkill = null;
            }
        }
    }
    public void UseSkill(BaseSkill skill)
    {
        _skillQueue.Enqueue(skill);
    }

    public void OnDamage(DamageContext damageContext)
    {

    }
}

