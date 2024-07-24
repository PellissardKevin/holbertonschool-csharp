using System;

/// <summary>
/// Modifier used with delegates
/// </summary>
public enum Modifier
{
    /// <summary>
    /// Weak default value should be 0.5
    /// </summary>
    Weak,
    /// <summary>
    /// Base default value should be 1
    /// </summary>
    Base,
    /// <summary>
    /// Strong default value should be 1.5
    /// </summary>
    Strong
}

/// <summary>
/// Player's CalculateHealth Delegate
/// </summary>
/// <param name="amount">Amount for health,</param>
public delegate void CalculateHealth(float amount);

/// <summary>
/// Calculate Modifier Delegate
/// </summary>
/// <param name="baseValue">Base value</param>
/// <param name="modifier">Modifier: Weak, Base, Strong</param>
/// <returns>Returns a delegate</returns>
public delegate float CalculateModifier(float baseValue, Modifier modifier);

/// <summary>
/// Player class
/// </summary>
public class Player
{
    /// <summary>
    /// EventHanlder for CurrentHPArgs
    /// </summary>
    public event EventHandler<CurrentHPArgs> HPCheck;

    // Player's name
    private string name { get; set; }

    // Player's max hp.
    private float maxHp { get; set; }

    // Player's hp
    private float hp { get; set; }

    // Player's status
    private string status { get; set; }

    /// <summary>
    /// Player constructor
    /// </summary>
    /// <param name="name">Player's name</param>
    /// <param name="maxHp">Player's max hp</param>
    /// <param name="status">Player's status </param>
    public Player(string name = "Player", float maxHp = 100f, string status = "Undefined")
    {
        this.name = name;
        if (maxHp <= 0)
        {
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
            maxHp = 100f;
        }
        this.maxHp = maxHp;
        this.hp = maxHp;
        if (status == "Undefined")
        {
            this.status = $"{name} is ready to go!";
        }
        HPCheck += CheckStatus;
    }

    /// <summary>
    /// Prints player Health.
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
    /// Define new player's hp depending on occured event.
    /// </summary>
    /// <param name="newHp">Sets up the new player's hp.</param>
    public void ValidateHP(float newHp)
    {
        if (newHp < 0)
        {
            this.hp = 0;
        }
        else if (newHp >= maxHp)
        {
            this.hp = maxHp;
        }
        else
        {
            this.hp = newHp;
        }
        CheckStatus(HPCheck, new CurrentHPArgs(this.hp));
    }

    /// <summary>
    /// Method used with delegate to apply a BaseValue depending on the modifier
    /// </summary>
    /// <param name="baseValue">Base value to apply</param>
    /// <param name="modifier">Modifier : Weak, Base, Strong</param>
    /// <returns></returns>
    public float ApplyModifier(float baseValue, Modifier modifier)
    {
        float modifiedVal = baseValue;
        switch (modifier)
        {
            case Modifier.Weak:
                modifiedVal = baseValue * 0.5f;
                break;
            case Modifier.Base:
                modifiedVal = baseValue * 1f;
                break;
            case Modifier.Strong:
                modifiedVal = baseValue * 1.5f;
                break;
        }
        return modifiedVal;
    }

    /// <summary>
    /// Handles the HPCheck event and prints the current status.
    /// </summary>
    /// <param name="sender">The event source.</param>
    /// <param name="e">Event data.</param>
    private void CheckStatus(object sender, CurrentHPArgs e)
    {
        if (e.currentHp == this.maxHp)
            status = $"{name} is in perfect health!";
        else if (e.currentHp >= (this.maxHp * 0.5) && e.currentHp < this.maxHp)
            status = $"{name} is doing well!";
        else if (e.currentHp >= (this.maxHp * 0.25) && e.currentHp < this.maxHp)
            status = $"{name} isn't doing too great...";
        else if (e.currentHp > 0 && e.currentHp < (this.maxHp * 0.25))
            status = $"{name} needs help!";
        else if (e.currentHp <= 0)
            status = $"{name} is knocked out!";
        Console.WriteLine(status);
    }
}

/// <summary>
/// Current HP Args
/// </summary>
public class CurrentHPArgs : EventArgs
{
    /// <summary>
    /// currentHp cannot be modified
    /// </summary>
    /// <value>Getter only</value>
    public readonly float currentHp;

    /// <summary>
    /// Takes a float newHp and sets it as currentHp‘s value
    /// </summary>
    /// <param name="newHp">New currentHp's value</param>
    public CurrentHPArgs(float newHp)
    {
        this.currentHp = newHp;
    }
}

