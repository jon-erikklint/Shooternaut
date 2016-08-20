using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

    void Start () {
        List<UIAdder> uiadders = FindUIAdders();

        foreach (UIAdder ui in uiadders)
        {
            ui.UIElement().transform.SetParent(this.transform, false);
        }
	}

    private List<UIAdder> FindUIAdders()
    {
        List<UIAdder> uis = new List<UIAdder>();

        GameObject[] gameObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject gameObject in gameObjects)
        {
            Component[] uiAdders = gameObject.GetComponents(typeof(UIAdder));

            foreach(Component ui in uiAdders)
            {
                uis.Add( (UIAdder) ui );
            }
        }

        return uis;
    }
}
