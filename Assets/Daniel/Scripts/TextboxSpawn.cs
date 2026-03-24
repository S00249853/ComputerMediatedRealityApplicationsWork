using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(PlayerInput))]

public class TextboxSpawn : MonoBehaviour
{
    private Vector2 PointerPosition;
    [SerializeField] private TMP_Text Text;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Panel panel;
    private Character character;

    public void OnPointerPosition(InputValue inputValue)
    {
        PointerPosition = inputValue.Get<Vector2>();
    }

    private void Start()
    {
        canvas.enabled = false;
    }

    public void OnTap() 
    {
        Ray ray = Camera.main.ScreenPointToRay(PointerPosition);
        
        Debug.Log("Tapped");
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Hit");
        
               if (hit.collider.gameObject.TryGetComponent(out character))
                {
                    Debug.Log("Hit object");
                    canvas.enabled = true;
                    Text.text = character.Description;
                }
            else
            {
                Debug.Log("Didnt hit object");
            }
            
        }
    }

    public void OnBack()
    {
        canvas.enabled = false;
    }
}

