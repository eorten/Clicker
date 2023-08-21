using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameEvent blockDestroyed;
    [SerializeField] private S_Inventory playerInventory;
    private OreProfile profile;
    private SpriteRenderer sr;
    private int currentHP;
    private Color32 destroyedColor = new Color32(0, 0, 0, 255);

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Initialize(OreProfile profile)
    {
        this.profile = profile;
        currentHP = profile.hp;
        sr.color = profile.color;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            playerInventory.Add(profile, 1);
            blockDestroyed.Raise();
            SetColor();
            return;
        }
        SetColor();
    }

    private void SetColor()
    {
        sr.color = Color32.Lerp(destroyedColor, profile.color, (float)currentHP / (float)profile.hp);
    }

    public OreProfile GetProfile()
    {
        return profile;
    }

    public int GetHP()
    {
        return currentHP;
    }
}

