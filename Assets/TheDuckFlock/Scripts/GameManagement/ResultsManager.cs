using UnityEngine;

namespace TheDuckFlock
{
    public class ResultsManager : MonoSingleton<ResultsManager> //, IGameplayEventsListener<Vector3>
    {
        [SerializeField] private int _numberOfHatchedEggs = 0;
        [SerializeField] private int _numberOfMissedDuckies = 0;

        

        public int NumberOfHatchedEggs { get { return _numberOfHatchedEggs; } }
        public int NumberOfMissedDuckies { get { return _numberOfMissedDuckies; } }


        // Start is called before the first frame update
        void Start()
        {
            
        }


        // Update is called once per frame
        void Update()
        {

        }
       

        #region Public methods
        public void ResetResults()
        {
            _numberOfHatchedEggs = 0;
            _numberOfMissedDuckies = 0;
        }
        #endregion

    }
}
