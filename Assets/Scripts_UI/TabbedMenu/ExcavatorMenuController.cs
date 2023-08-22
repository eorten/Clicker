using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ExcavatorMenuController : MonoBehaviour
{
    [SerializeField] GameEvent excavator_DMG_pressed;
    [SerializeField] GameEvent excavator_ASP_pressed;
    [SerializeField] GameEvent excavator_Load_pressed;
     
    private ProgressBar progressBar;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        progressBar = root.Q<ProgressBar>("excavator1_queued");

        Button excavator_DMG = root.Q<Button>("excavator1_DMG");
        excavator_DMG.clicked += () => excavator_DMG_pressed.Raise();

        Button excavator_ASP = root.Q<Button>("excavator1_ASP");
        excavator_ASP.clicked += () => excavator_ASP_pressed.Raise();

        Button excavator_Load = root.Q<Button>("excavator1_Load");
        excavator_Load.clicked += () => excavator_Load_pressed.Raise();
    }

    public void SetExcavatorQueue(int maxValue, int currentValue)
    {
        progressBar.highValue = maxValue;
        progressBar.value = currentValue;
    }
}
