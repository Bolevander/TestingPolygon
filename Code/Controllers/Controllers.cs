using System.Collections.Generic;

namespace MVC
{
    internal sealed class Controllers : IInitialization, IExecute, ILateExecute, ICleanup
    {
        private readonly List<IExecute> _executeControllers;
        private readonly List<IInitialization> _initializationControllers;
        private readonly List<ILateExecute> _lateExecuteControllers;
        private readonly List<ICleanup> _cleanupControllers;

        internal Controllers()
        {
            _executeControllers = new List<IExecute>();
            _initializationControllers = new List<IInitialization>();
            _lateExecuteControllers = new List<ILateExecute>();
            _cleanupControllers = new List<ICleanup>();
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is IInitialization initializationController)
            {
                _initializationControllers.Add(initializationController);
            }

            if (controller is ILateExecute lateExecuteController)
            {
                _lateExecuteControllers.Add(lateExecuteController);
            }

            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }

            return this;
        }

        public void Initialization()
        {
            for (int i = 0; i < _initializationControllers.Count; i++)
            {
                _initializationControllers[i].Initialization();
            }
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _executeControllers.Count; i++)
            {
                _executeControllers[i].Execute(deltaTime);
            }
        }

        public void LateExecute(float deltaTime)
        {
            for (int i = 0; i < _lateExecuteControllers.Count; i++)
            {
                _lateExecuteControllers[i].LateExecute(deltaTime);
            }
        }

        public void Cleanup()
        {
            for (int i = 0; i < _cleanupControllers.Count; i++)
            {
                _cleanupControllers[i].Cleanup();
            }
        }
    }
}
