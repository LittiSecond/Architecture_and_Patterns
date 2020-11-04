using System;


namespace Task_lesson8
{
    class StringContainerController : IController
    {
        private IStringContainerWiev _view;
        private IStringContainerModel _model;
        private string _lastString;

        public StringContainerController(IStringContainerWiev view, IStringContainerModel model)
        {
            _view = view;
            _model = model;
            _lastString = String.Empty;
        }

        public void AddString(string newString)
        {
            if (newString != null)
            {
                if (newString != _lastString)
                {
                    _lastString = newString;
                    _model.AddString(newString);
                }
            }
        }
    }
}
