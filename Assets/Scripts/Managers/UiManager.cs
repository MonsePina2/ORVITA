using UnityEngine;
using TMPro;
namespace Managers
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text gameScoreText;

        public void UpdateScore(float score) {
            gameScoreText.text = $" {score:f2}s";
        }

    }
}
