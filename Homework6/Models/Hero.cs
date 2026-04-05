namespace Homework6.Models;

public class Hero
{
    public string Name { get; set; }  = string.Empty;
    public int Health { get; set; } = 100;
    public int Power { get; set; } = 20;

    public override string ToString()
    {
        return $"{Name}, {Health} HP, {Power} MP";
    }
}