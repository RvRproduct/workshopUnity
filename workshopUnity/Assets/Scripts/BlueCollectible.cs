using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCollectible : BaseCollectible
{
    public override void OnHitAction()
    {
        // If you want base class behavior to be included.
        base.OnHitAction();

        if (PlayerManager.Instance.currentPlayerHP < PlayerManager.Instance.maxPlayerHP)
        {
            PlayerManager.Instance.currentPlayerHP += onHitOutcome;
            PlayerManager.Instance.UpdateHealthBar();
        }
        
        GameManager.Instance.blueCollectibles.Remove(gameObject);
        if (GameManager.Instance.blueCollectibles.Count <= 0)
        {
            GameManager.Instance.door.destroyDoor();
        }
        Destroy(gameObject);
    }
}
