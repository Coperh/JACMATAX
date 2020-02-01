using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    [SerializeField] private readonly int defaultHealth = 100;
    private int health;

    public HealthSystem() {
        this.health = defaultHealth;
    }

    public bool IsAlive() {
        return health > 0;
    }

    public int GetHealth() {
        return this.health;
    }

    public void Damage(int damage)
    {
        int newHealth = health - damage;
        if (newHealth > 100) newHealth = 100;
        health = newHealth;
    }
    public void Heal(int healing) {
            int newHealth = health + healing;
            if (newHealth < 0) newHealth = 0;
            health = newHealth;
        }

}
