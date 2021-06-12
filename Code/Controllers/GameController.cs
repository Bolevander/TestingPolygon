using UnityEngine;

namespace MVC
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private Data _data;
        private Controllers _controllers;

        private void Start()
        {
            Camera _camera = Camera.main; 
            var inputInitialization = new InputInitialization();
            //construct players and enemy + input
            _controllers = new Controllers();
            _controllers.Add(inputInitialization);
            _controllers.Add(new InputController(inputInitialization.GetInput()));
            //fill the controllers 
            _controllers.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}
