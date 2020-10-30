using System;


namespace Task_lesson8
{
    /// <summary>
    /// интерфейс модели для представления
    /// </summary>
    public interface IStringContainerModelEventer
    {
        event Action StringAdded;
        string GetLastString();
    }
}
