using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameControll : MonoBehaviour
    {

        private static GameControll _instance = null; 
        public static GameControll Instance 
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    _instance = go.AddComponent<GameControll>();
                }
                return _instance;
            }
        }
        public float ScrollSpeed = -1.5f;
        public float MovingSpeed = 0.01f;
        public float EnemySpeed = 0.2f;
        
        //the less, the faster
        public float EnemyRepeatingRate = 7f;
        public float FireRepeatingTime = 0.75f;

        //score text
        public GameObject ScoreText;
        private int _currentSocre = 0;
        private Text _text;


        // Use this for initialization
        void Start () {

        }
	
        // Update is called once per frame
        void Update () {
		
        }

        public void Score(int scoreToAdd) {
            _currentSocre += scoreToAdd;
            //_text = ScoreText.GetComponent<Text>();
            //_text.text = "score:" + _currentSocre;
        }
    }
}
