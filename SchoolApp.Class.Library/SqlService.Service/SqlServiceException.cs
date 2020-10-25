using System;
using System.Data.SqlClient;

namespace SqlServer.Service
{
    public class SqlServiceException : SystemException
    {
        #region internals
        private SqlException _sqlException;
        private SqlParameterCollection _sqlParameterCollection;
        #endregion

        #region interface
        public byte Class
        {
            get
            {
                return _sqlException.Class;
            }
        }

        public SqlErrorCollection Errors
        {
            get
            {
                return _sqlException.Errors;
            }
        }

        public int LineNumber
        {
            get
            {
                return _sqlException.LineNumber;
            }
        }

        public override string Message
        {
            get
            {
                return _sqlException.Message;
            }
        }

        public int Number
        {
            get
            {
                return _sqlException.Number;
            }
        }

        public string Procedure
        {
            get
            {
                return _sqlException.Procedure;
            }
        }

        public string Server
        {
            get
            {
                return _sqlException.Server;
            }
        }

        public override string Source
        {
            get
            {
                return _sqlException.Source;
            }
        }

        public byte State
        {
            get
            {
                return _sqlException.State;
            }
        }

        public SqlParameterCollection Parameters
        {
            get
            {
                return _sqlParameterCollection;
            }
        }

        #endregion

        #region methods
        public SqlServiceException(SqlException e, SqlParameterCollection parms)
        {
            _sqlException = e;
            _sqlParameterCollection = parms;
        }

        #endregion
    }
}
