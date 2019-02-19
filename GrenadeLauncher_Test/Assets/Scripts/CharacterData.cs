using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Character", order = 1)]
public class CharacterData : ScriptableObject
{
    public float health;
    public float speed;
    public float triggerDistance;
}
