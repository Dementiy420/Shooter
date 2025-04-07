using UnityEngine;

public class Stats
{
    private readonly CharacterData _charDat;
    
    public Stats(CharacterData charDat)
    {
        _charDat = charDat;
    }
    
    public CharacterData data
    {
        get { return _charDat; }
        private set { }
    }
}