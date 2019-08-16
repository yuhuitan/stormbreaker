using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/SkillStat")]
public class SkillStat : ScriptableObject
{
    public int player_index;
    public int player_state;
    public int skill_index;
}