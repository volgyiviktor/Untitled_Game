using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public SelectChar[] character;
    public int CharacterCount {  get { return character.Length; } }
    public SelectChar GetSelectChar(int index)
    {  return character[index]; }
}
