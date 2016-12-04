using UnityEngine;
using System.Collections;

public abstract class AutomaticCurveBus : CurveBus {

    public bool isMoving = true;
    public float speedFactor = 1;
	
	// Update is called once per frame
	void Update () {
        
        if (isMoving)
        {
            float dt = Time.deltaTime;
            MovePositions(dt * speedFactor);
            MoveGameObjects(dt * speedFactor);
            RotateGameObjects(dt * speedFactor);
        }
	}

    /* * * * * * * * * * * * * * * * * * * * * * * * *
     * Change the values of list GameObjectPositions * 
     * * * * * * * * * * * * * * * * * * * * * * * * */

    protected virtual void MovePositions(float dt)
    {
		for (int i = 0; i < gameObjects.Count; i++) {
			MovePosition(i, dt);
		}
    }

    protected abstract void MovePosition(int i, float dt);

    /* * * * * * * * * * * * *
     * Move the GameObjects  * 
     * * * * * * * * * * * * */

    protected virtual void MoveGameObjects(float dt)
    {
        for (int i = 0; i < gameObjects.Count; i++)
            MoveGameObject(i, dt);
    }

    protected virtual void MoveGameObject(int i, float dt)
    {
        GameObject obj = gameObjects[i];
        float currPos = gameObjectsPositions[i];

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            obj.transform.localPosition = PointAt(currPos);
        }
        else
        {
            rb.velocity = (GlobalPointAt(currPos) - obj.transform.position)*speedFactor/dt;
        }
    }

    /* * * * * * * * * * * * * *
     * Rotate the GameObjects  * 
     * * * * * * * * * * * * * */

    protected virtual void RotateGameObjects(float dt)
    {
        for (int i = 0; i < gameObjects.Count; i++)
            RotateGameObject(i, dt);
    }

    protected virtual void RotateGameObject(int i, float dt) { }

    /* * * * * * * * * * * * * * * * *
     * Change the state of isMoving  *
     * * * * * * * * * * * * * * * * */

    void StopMoving()
    {
        isMoving = false;
    }

    void StartMoving()
    {
        isMoving = true;
    }

    void ToggleMoving()
    {
        isMoving = !isMoving;
    }

}
