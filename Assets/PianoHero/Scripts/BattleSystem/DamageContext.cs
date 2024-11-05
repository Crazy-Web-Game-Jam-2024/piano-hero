using System.Collections.Generic;


public class DamageContext
{
    public int damage;
    public GameCharacterController owner;
    List<GameEffectStatus> effects;
}

public class GameEffectStatus
{
    public GameEffect effect;
    public int duration;
}

public enum GameEffect
{
    Slow,
    Ignite,
    Freeze,
    Poison,
    Lighting
}
