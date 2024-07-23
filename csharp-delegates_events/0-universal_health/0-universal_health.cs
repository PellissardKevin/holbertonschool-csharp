using System;

/// <summary>
/// Represents a player with a name, maximum health points (maxHp), and current health points (hp).
/// </summary>
public class Player
{
    /// <summary>
    /// Gets or sets the name of the player.
    /// </summary>
    public string name { get; set; }

    /// <summary>
    /// Gets or sets the maximum health points of the player.
    /// </summary>
    public float maxHp { get; set; }

    /// <summary>
    /// Gets or sets the current health points of the player.
    /// </summary>
    public float hp { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Player"/> class with a specified name and maximum health points.
    /// </summary>
    /// <param name="name">The name of the player. Defaults to "Player".</param>
    /// <param name="maxHp">The maximum health points of the player. Defaults to 100f.</param>
    public Player(string name = "Player", float maxHp = 100f)
    {
        this.name = name;
        this.maxHp = maxHp;

        if (maxHp <= 0)
        {
            this.maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
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
}
