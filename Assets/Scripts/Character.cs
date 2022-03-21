using UnityEngine;

public abstract class Character : MonoBehaviour {
    [SerializeField] protected float _maxHitPoints = 10;
    [SerializeField] protected HitPoints _hitPoints;
    [SerializeField] protected float _startingHitPoints = 5;
    public float MaxHitPoints
    {
        get
        {
            return _maxHitPoints;
        }
        set
        {
            _maxHitPoints = value;
        }
    }
}