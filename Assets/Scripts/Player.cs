using UnityEngine;

public class Player : Character{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            ItemData hitObject = collision.gameObject.
            GetComponent<Consumable>().Item;
            if (hitObject != null)
            {
                print("Hit: " + hitObject.ObjectName);
                switch (hitObject.Type)
                {
                    case ItemData.ItemType.Coin:
                        break;
                    case ItemData.ItemType.Health:
                        AdjustHitPoints(hitObject.Quantity);
                        break;
                }
                collision.gameObject.SetActive(false);
            }
        }
    }
    public void AdjustHitPoints(int amount)
    {
        _hitPoints = _hitPoints + amount;
        print("Adjusted hitpoints by: " + amount + ". New value: " +
        _hitPoints);
    }

}
