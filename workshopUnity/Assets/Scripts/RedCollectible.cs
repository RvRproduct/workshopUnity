using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCollectible : BaseCollectible
{
    public override void OnHitAction()
    {
        // If you want base class behavior to be included.
        base.OnHitAction();

        if (PlayerManager.Instance.currentPlayerHP > 0)
        {
            PlayerManager.Instance.currentPlayerHP -= onHitOutcome;
            PlayerManager.Instance.UpdateHealthBar();
        }

        GameManager.Instance.blueCollectibles.Remove(GetComponent<GameObject>());
        Destroy(gameObject);
    }
}
