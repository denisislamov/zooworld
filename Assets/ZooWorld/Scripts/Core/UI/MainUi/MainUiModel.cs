using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZooWorld.UI;

public class MainUiModel : BaseModel
{
    private int _preyKillCount;
    private int _predatorKillCount;

    public int PreyKillCount => _preyKillCount;
    public int PredatorKillCount => _predatorKillCount;
    
    public void AddPrey(int count)
    {
        _preyKillCount += count;
    }
    
    public void AddPredator(int count)
    {
        _predatorKillCount += count;
    }
    
    
}
