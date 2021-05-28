using System;

namespace CSharp2SQLLib
{
    internal class UsersController
    {
        private Connection connection;

        public UsersController(Connection connection)
        {
            this.connection = connection;
        }

        internal object GetByCode(string userCode)
        {
            throw new NotImplementedException();
        }
    }
}