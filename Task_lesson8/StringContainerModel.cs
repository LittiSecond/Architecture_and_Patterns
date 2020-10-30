using System;
using System.Collections.Generic;


namespace Task_lesson8
{
    class StringContainerModel : IStringContainerModel, IStringContainerModelEventer
    {

        private List<string> _strings;

        public StringContainerModel()
        {
            _strings = new List<string>();
        }

        #region IStringContainerModel

        public void AddString(string newString)
        {
            if (newString != null)
            {
                _strings.Add(newString);

                StringAdded?.Invoke();
            }

        }

        #endregion


        #region IStringContainerModelEventer

        public event Action StringAdded;

        public string GetLastString()
        {
            int length = _strings.Count;
            if (length == 0)
            {
                return null;
            }
            else
            {
                return _strings[length - 1];
            }
        }

        #endregion
    }
}
