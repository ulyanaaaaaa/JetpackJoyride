using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Scripts.UI
{
    public class ScenesLoad : MonoBehaviour
    {
        public void GameScene()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void MainScene()
        {
            SceneManager.LoadScene("MainMenu");
        }
        
        
    }
}
