using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCollectible : BaseCollectible
{
    public override void OnHitAction()
    {
        // If you want base class behavior to be included.
        base.OnHitAction();

        PlayerManager.Instance.playerHP += onHitOutcome;

        GameManager.Instance.blueCollectibles.Remove(GetComponent<GameObject>());
        if (GameManager.Instance.blueCollectibles.Count <= 0)
        {
            GameManager.Instance.door.destroyDoor();
        }
        Destroy(gameObject);
    }
}
