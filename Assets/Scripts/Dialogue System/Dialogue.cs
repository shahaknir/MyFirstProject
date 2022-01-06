using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Question", menuName = "Mission/Question", order = 0)]
public class Dialogue : ScriptableObject
{

    public List<mission> questions = new List<mission>();

    [System.Serializable]
    public struct mission
    {
        public string titleOfTheQuestion;
        public string theMissionQ;
        public string answer;

    }

}
