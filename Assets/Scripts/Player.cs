using UnityEngine;
using UnityEngine.UI;

public class Player : Character{
    [SerializeField] private HealthBar _healthBarPrefab;
    private HealthBar _healthBar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            ItemData hitObject = collision.gameObject.GetComponent<Consumable>().Item;
            if (hitObject != null)
            {
                print("Hit: " + hitObject.ObjectName);
                bool shouldDisappear = false;
                switch (hitObject.Type)
                {
                    case ItemData.ItemType.Coin:
                        shouldDisappear = true;
                        break;
                    case ItemData.ItemType.Health:
                        shouldDisappear =
                        AdjustHitPoints(hitObject.Quantity);
                        break;
                }
                if (shouldDisappear)
                    collision.gameObject.SetActive(false);
            }
        }
    }
    public bool AdjustHitPoints(int amount)
    {
        if (_hitPoints.Value < _maxHitPoints)
        {
            _hitPoints.Value = _hitPoints.Value + amount;
            print("Adjusted HP by: " + amount + ". New value: " + _hitPoints.Value);
            return true;
        }
        return false;
    }
    void Start()
    {
        _hitPoints.Value = _startingHitPoints;
        _healthBar = Instantiate(_healthBarPrefab);
        _healthBar.Character = this;
    }

}
