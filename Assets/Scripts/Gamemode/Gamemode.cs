using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gamemode: MonoBehaviour{

    public List<Objective> objectives;
    public List<Condition> conditions;
    public List<Achievement> achievements;

    public bool hasStarted { get { return _hasStarted; } }
    private bool _hasStarted;

    private Player player;

    void Awake()
    {
        objectives = new List<Objective>(GetComponentsInChildren<Objective>());
        conditions = new List<Condition>(GetComponentsInChildren<Condition>());
        achievements = new List<Achievement>(GetComponentsInChildren<Achievement>());

        player = FindObjectOfType<Player>();
        player.playerActs.AddListener(Begin);

        _hasStarted = false;
    }

    public void Begin()
    {
        player.playerActs.RemoveListener(Begin);

        foreach(Objective objective in objectives)
        {
            objective.Begin();
        }

        foreach(Condition condition in conditions)
        {
            condition.Begin();
        }

        foreach(Achievement achievement in achievements)
        {
            achievement.Begin();
        }

        _hasStarted = true;
    }

    public bool Defeat()
    {
        foreach(Condition condition in conditions)
        {
            if (condition.Lost())
            {
                return true;
            }
        }

        return false;
    }

    public bool Victory()
    {
        foreach (Objective objective in objectives)
        {
            if (!objective.Achieved())
            {
                return false;
            }
        }

        return !Defeat();
    }

    public List<Achievement> CompletedAchievements()
    {
        List<Achievement> achieved = new List<Achievement>();

        foreach(Achievement achievement in achievements)
        {
            if (achievement.Fulfilled())
            {
                achieved.Add(achievement);
            }
        }

        return achieved;
    }
}
