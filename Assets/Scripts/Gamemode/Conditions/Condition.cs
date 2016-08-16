using UnityEngine;
using System.Collections;

public abstract class Condition: MonoBehaviour{

    public abstract void Begin();
    public abstract void End();

    public abstract string Name();
    public abstract string Description();

    public abstract bool Lost();

    void Start()
    {
        initializeUI();
    }

    public void initializeUI()
    {
        GameObject uiElement = transform.GetChild(0).gameObject;
        uiElement.transform.SetParent(GameObject.Find("Canvas").transform, false);

        initialize(uiElement);
    }

    public abstract void initialize(GameObject uiElement);
}
