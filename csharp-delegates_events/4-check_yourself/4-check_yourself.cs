using System;

/// <summary>
/// Delegate to calculate health changes.
/// </summary>
/// <param name="amount">The amount to change health by.</param>
public delegate void CalculateHealth(float amount);

/// <summary>
/// Enum for modifier
/// </summary>
public enum Modifier
{
    /// <summary>
    /// Represents a weak modifier, which reduces the base value by half.
    /// </summary>
    Weak,

    /// <summary>
    /// Represents the base modifier, which keeps the base value unchanged.
    /// </summary>
    Base,

    /// <summary>
    /// Represents a strong modifier, which increases the base value by 1.5 times.
    /// </summary>
    Strong
}

/// <summary>
/// Delegate to modifier
/// </summary>
/// <param name="baseValue">Base value</param>
/// <param name="modifier">Modifier from the enum</param>
/// <returns>Modified value</returns>
public delegate float CalculateModifier(float baseValue, Modifier modifier);

/// <summary>
/// Represents a player with a name, maximum health points (maxHp), and current health points (hp).
/// </summary>
public class Player
{
    /// <summary>
    /// Delegate for the HPCheck event handler.
    /// </summary>
    /// <param name="sender">The event source.</param>
    /// <param name="e">Event data.</param>
    public delegate void HPCheckEventHandler(object sender, CurrentHPArgs e);

    /// <summary>
    /// Event triggered when the player's HP changes.
    /// </summary>
    public event HPCheckEventHandler HPCheck;

    /// <summary>
    /// Gets or sets the name of the player.
    /// </summary>
    private string name { get; set; }

    /// <summary>
    /// Gets or sets the maximum health points of the player.
    /// </summary>
    private float maxHp { get; set; }

    /// <summary>
    /// Gets the current health points of the player.
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
        HPCheck += CheckStatus; // Assign CheckStatus to the HPCheck event handler
        OnHPCheck(new CurrentHPArgs(this.hp, $"{name} is ready to go!"));
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
    /// Sets the new value of the player's HP.
    /// </summary>
    /// <param name="newHp">The new HP value.</param>
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
        OnHPCheck(new CurrentHPArgs(this.hp, GetStatus())); // Trigger the HPCheck event
    }

    /// <summary>
    /// Invokes the HPCheck event.
    /// </summary>
    /// <param name="e">Event data.</param>
    protected virtual void OnHPCheck(CurrentHPArgs e)
    {
        HPCheck?.Invoke(this, e);
    }

    /// <summary>
    /// Handles the HPCheck event and prints the current status.
    /// </summary>
    /// <param name="sender">The event source.</param>
    /// <param name="e">Event data.</param>
    private void CheckStatus(object sender, CurrentHPArgs e)
    {
        Console.WriteLine(e.Status);
    }

    /// <summary>
    /// Gets the current status of the player based on HP.
    /// </summary>
    /// <returns>The current status.</returns>
    private string GetStatus()
    {
        if (hp == maxHp)
            return $"{name} is at full health!";
        else if (hp == 0)
            return $"{name} is knocked out!";
        else
            return $"{name} is fighting!";
    }

    /// <summary>
    /// Applies a modifier to a base value.
    /// </summary>
    /// <param name="baseValue">The base value to modify.</param>
    /// <param name="modifier">The modifier to apply.</param>
    /// <returns>The modified value.</returns>
    public float ApplyModifier(float baseValue, Modifier modifier)
    {
        switch (modifier)
        {
            case Modifier.Weak:
                return baseValue / 2;
            case Modifier.Base:
                return baseValue;
            case Modifier.Strong:
                return baseValue * 1.5f;
            default:
                throw new ArgumentOutOfRangeException(nameof(modifier), modifier, null);
        }
    }
}

/// <summary>
/// Provides data for the HPCheck event.
/// </summary>
public class CurrentHPArgs : EventArgs
{
    /// <summary>
    /// Gets the current HP of the player.
    /// </summary>
    public float CurrentHp { get; private set; }

    /// <summary>
    /// Gets the status of the player.
    /// </summary>
    public string Status { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CurrentHPArgs"/> class.
    /// </summary>
    /// <param name="currentHp">The current HP of the player.</param>
    /// <param name="status">The status of the player.</param>
    public CurrentHPArgs(float currentHp, string status)
    {
        CurrentHp = currentHp;
        Status = status;
    }
}
