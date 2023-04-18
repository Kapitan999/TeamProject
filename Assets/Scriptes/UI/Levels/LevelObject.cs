using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu (fileName = "New Level", menuName =" Scriptable Object")]

public class LevelObject : ScriptableObject
{
    public int levelIndex;
    public Object sceneToLoad;


}
