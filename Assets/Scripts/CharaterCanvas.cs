using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class CharaterCanvas : MonoBehaviour
{
    [SerializeField] private Image[] image;


    public Sprite spriteA;
    public Sprite spriteB;
    void Start()
    {
        spriteA = image[0].sprite;
        spriteB = image[1].sprite;
        

    }
    private void Update()
    {
        // if(canSwitch)
    }
    [ContextMenu("Do Something")]
    public void SwitchPlayerImage()
    {

        image[1].sprite = spriteA;
        image[0].sprite = spriteB;


    }
}
