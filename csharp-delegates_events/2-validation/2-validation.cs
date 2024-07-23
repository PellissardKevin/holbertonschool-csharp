using System;


/// <summary>
/// Delegate to calculate health changes.
/// </summary>
/// <param name="amount">The amount to change health by.</param>
public delegate void CalculateHealth(float amount);

/// <summary>
/// Represents a player with a name, maximum health points (maxHp), and current health points (hp).
/// </summary>
public class Player
{
    /// <summary>
    /// Gets or sets the name of the player.
    /// </summary>
    private string name { get; set; }

    /// <summary>
    /// Gets or sets the maximum health points of the player.
    /// </summary>
    private float maxHp { get; set; }

    /// <summary>
    /// Gets or sets the current health points of the player.
    /// </summary>
    public float hp { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Player"/> class with a specified name and maximum health points.
    /// </summary>
    /// <param name="name">The name of the player. Defaults to "Player".</param>
    /// <param name="maxHp">The maximum health points of the player. Defaults to 100f.</param>
    public Player(string name = "Player", float maxHp = 100f)
    {
        this.name = name;
        if (maxHp <= 0)
        {
            this.maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }
        else
        {
            this.maxHp = maxHp;
        }

        this.hp = this.maxHp;
    }

    /// <summary>
    /// Prints the current health status of the player to the console.
    /// </summary>
    public void PrintHealth()
    {
        Console.WriteLine($"{name} has {hp} / {maxHp} health");
    }

    /// <summary>
    /// Reduces the player's health points by a specified amount.
    /// Prints the amount of damage taken.
    /// If the amount is negative, no damage is taken.
    /// </summary>
    /// <param name="damage">The amount of damage.</param>
    public void TakeDamage(float damage)
    {
        if (damage <= 0)
        {
            Console.WriteLine($"{name} takes 0 damage!");
        }
        else
        {
            Console.WriteLine($"{name} takes {damage} damage!");
            float newHp = Math.Max(hp - damage, 0);
            ValidateHP(newHp);
        }
    }

    /// <summary>
    /// Increases the player's health points by a specified amount.
    /// Prints the amount of health restored.
    /// If the amount is negative, no health is restored.
    /// </summary>
    /// <param name="heal">The amount of health to restore.</param>
    public void HealDamage(float heal)
    {
        if (heal <= 0)
        {
            Console.WriteLine($"{name} heals 0 HP!");
        }
        else
        {
            Console.WriteLine($"{name} heals {heal} HP!");
            float newHp = Math.Min(hp + heal, maxHp);
            ValidateHP(newHp);
        }
    }

    /// <summary>
    /// sets the new valoe of the player's HP
    /// </summary>
    /// <param name="newHp"></param>
    public void ValidateHP(float newHp)
    {
        if (newHp <= 0)
        {
            this.hp = 0;
        }
        else if (newHp > maxHp)
        {
            this.hp = maxHp;
        }
        else
        {
            this.hp = newHp;
        }
    }
}
