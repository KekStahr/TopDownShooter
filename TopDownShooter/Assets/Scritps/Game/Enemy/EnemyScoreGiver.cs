using UnityEngine;

public class EnemyScoreGiver : MonoBehaviour
{
    [SerializeField] private int killScoreValue;

    private ScoreController scoreController;

    private void Awake(){
        //Has to be changed, if i do a multiplayer game!!!
        scoreController = Object.FindFirstObjectByType<ScoreController>();
    }

    public void AllocateScore(){
        scoreController.AddScore(killScoreValue);
    }
}
