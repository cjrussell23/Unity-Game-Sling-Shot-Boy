using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Player : Character{
    [SerializeField] private HealthBar _healthBarPrefab;
    private HealthBar _healthBar;
    [SerializeField] Inventory _inventoryPrefab;
    [SerializeField] protected HitPoints _hitPoints;
    private Inventory _inventory;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            ItemData hitObject = collision.gameObject.GetComponent<Consumable>().Item;
            if (hitObject != null)
            {
                print("Hit: " + hitObject.Type);
                bool shouldDisappear = false;
                switch (hitObject.Type)
                {
                    case ItemData.ItemType.Coin:
                        shouldDisappear = _inventory.AddItem(hitObject);
                        break;
                    case ItemData.ItemType.Ruby:
                        shouldDisappear = _inventory.AddItem(hitObject);
                        break;
                    case ItemData.ItemType.Emerald:
                        shouldDisappear = _inventory.AddItem(hitObject);
                        break;
                    case ItemData.ItemType.Sapphire:
                        shouldDisappear = _inventory.AddItem(hitObject);
                        break;
                    case ItemData.ItemType.Health:
                        shouldDisappear = AdjustHitPoints(hitObject.Quantity);
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
            // When big heart is picked up it adds 10, possibly going over max.
            if (_hitPoints.Value > _maxHitPoints)
            {
                _hitPoints.Value = _maxHitPoints;
            }
            print("Adjusted HP by: " + amount + ". New value: " + _hitPoints.Value);
            return true;
        }
        return false;
    }
    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            StartCoroutine(FlickerCharacter());
            _hitPoints.Value = _hitPoints.Value - damage;
            if (_hitPoints.Value <= float.Epsilon)
            {
                KillCharacter();
                break;
            }
            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }
    public override void KillCharacter()
    {
        base.KillCharacter();
        Destroy(_healthBar.gameObject);
        Destroy(_inventory.gameObject);
    }
    public override void ResetCharacter()
    {
        _inventory = Instantiate(_inventoryPrefab);
        _healthBar = Instantiate(_healthBarPrefab);
        _healthBar.Character = this;
        _hitPoints.Value = _startingHitPoints;
    }
    private void OnEnable()
    {
        ResetCharacter();
    }
}
