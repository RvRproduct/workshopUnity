using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public int maxPlayerHP = 50;
    [HideInInspector] public int currentPlayerHP;
    [SerializeField] private RectTransform healthBarFill;
    [SerializeField] private RectTransform healthBarContainer;
    public static PlayerManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            currentPlayerHP = maxPlayerHP;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHealthBar()
    {
        float fillAmount = (float)currentPlayerHP / maxPlayerHP;

        float newWidth = fillAmount * healthBarContainer.rect.width;
        healthBarFill.sizeDelta = new Vector2(newWidth, healthBarFill.sizeDelta.y);
    }
}
