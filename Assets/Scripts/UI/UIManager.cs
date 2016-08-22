using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    private Transform canvas;

    void Start () {
        xMin = - (Screen.width / 2);
        xMax = Screen.width / 2;
        yMax = Screen.height / 2;
        yMin = - (Screen.height / 2);

        canvas = transform;

        InitializeGamemode();
        InitializePlayerUI();
	}

    private void InitializeGamemode()
    {
        Gamemode gamemode = FindObjectOfType<Gamemode>();

        List<Condition> conditions = gamemode.conditions;

        for(int i = 0; i < conditions.Count; i++)
        {
            float y = yMax - (50 * ((i / 2) + 1));
            float x;
            if(i%2 == 0)
            {
                x = xMin + 170;
            }
            else
            {
                x = xMax - 170;
            }

            GameObject uiElement = conditions[i].UIElement();
            InitializeUiElement(uiElement, x, y);
        }
    }

    private void InitializePlayerUI()
    {
        Player player = FindObjectOfType<Player>();
        Activateable left = player.mouseLeft;
        Activateable right = player.GetRight();

        float y = yMin + 50;
        float leftX = xMin + 170;
        float rightX = xMax - 170;

        InitializeUiElement(left.UIElement(), leftX, y);

        if(right != null)
        {
            InitializeUiElement(player.mouseRight.UIElement(), rightX, y);
        }
    }

    private void InitializeUiElement(GameObject element, float x, float y)
    {
        element.transform.SetParent(canvas, false);
        element.transform.localPosition = new Vector3(x, y, 0);
    }
}
