using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCollectible : BaseCollectible
{
    public override void OnHitAction()
    {
        // If you want base class behavior to be included.
        base.OnHitAction();
        PlayerManager.Instance.playerHP -= onHitOutcome;

        GameManager.Instance.blueCollectibles.Remove(GetComponent<GameObject>());
        Destroy(gameObject);
    }
}
