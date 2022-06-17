using System;

namespace TutorProject.Account.BLL.Utils
{
    [Serializable]
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException()
        {
        }

        public BusinessLogicException(string message) : base(ConstructMessage(message))
        {
        }

        public BusinessLogicException(string message, Exception inner) : base(ConstructMessage(message), inner)
        {
        }

        private static string ConstructMessage(string message)
        {
            return "Логическая ошибка: \n" + message;
        }
    }
}