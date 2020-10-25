using System;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections;
using System.Xml;
using System.Text;

namespace SqlServer.Service
{
    //[DebuggerStepThrough]
    public class SqlService : IDisposable
    {
        #region Protected Member Variables
        private string _connectionString = String.Empty;
        private SqlParameterCollection _parameterCollection;
        private ArrayList _parameters = new ArrayList();
        private bool _isSingleRow = false;
        private bool _convertEmptyValuesToDbNull = true;
        private bool _convertMinValuesToDbNull = true;
        private bool _convertMaxValuesToDbNull = false;
        private bool _autoCloseConnection = true;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        private int _commandTimeout = 30;
        private Int32 _rowsReturn;
        #endregion Protected Member Variables

        #region BlackList
        public static String[] blackList = {";--",
                                               "/*","*/","@@",//"@", 
                                           " alter "," begin ","<script>","></title><script src ","http://lilupophilupop.com",
                                           " create "," cursor "," declare "," delete "," drop ",
                                           " exec "," execute ", 
                                           " fetch "," insert "," kill ",//" open ", 
                                           " sys.","sysobjects",//"syscolumns", 
                                           " table "," update "};
        #endregion

        #region Contructors / Destructors
        //[DebuggerStepThrough]
        public SqlService(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        //[DebuggerStepThrough]
        public SqlService(string server, string database, string user, string password)
        {
            this.ConnectionString = "Server=" + server + ";Database=" + database + ";User ID=" + user + ";Password=" + password + ";";
        }

        //[DebuggerStepThrough]
        public SqlService(string server, string database)
        {
            this.ConnectionString = "Server=" + server + ";Database=" + database + ";Integrated Security=true;";
        }

        //[DebuggerStepThrough]
        public SqlService(SqlConnection connection)
        {
            this.Connection = connection;
            this.AutoCloseConnection = false;
        }

        //		~SqlService()
        //		{
        //			Disconnect();
        //		}
        #endregion Contructors

        #region Properties
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        public int CommandTimeout
        {
            get
            {
                return _commandTimeout;
            }
            set
            {
                _commandTimeout = value;
            }
        }

        public bool IsSingleRow
        {
            get
            {
                return _isSingleRow;
            }
            set
            {
                _isSingleRow = value;
            }
        }

        public bool AutoCloseConnection
        {
            get
            {
                return _autoCloseConnection;
            }
            set
            {
                _autoCloseConnection = value;
            }
        }

        public SqlConnection Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
                this.ConnectionString = _connection.ConnectionString;
            }
        }

        public SqlTransaction Transaction
        {
            get
            {
                return _transaction;
            }
            set
            {
                _transaction = value;
            }
        }

        public bool ConvertEmptyValuesToDbNull
        {
            get
            {
                return _convertEmptyValuesToDbNull;
            }
            set
            {
                _convertEmptyValuesToDbNull = value;
            }
        }

        public bool ConvertMinValuesToDbNull
        {
            get
            {
                return _convertMinValuesToDbNull;
            }
            set
            {
                _convertMinValuesToDbNull = value;
            }
        }

        public bool ConvertMaxValuesToDbNull
        {
            get
            {
                return _convertMaxValuesToDbNull;
            }
            set
            {
                _convertMaxValuesToDbNull = value;
            }
        }

        public SqlParameterCollection Parameters
        {
            get
            {
                return _parameterCollection;
            }
        }

        public int ReturnValue
        {
            get
            {
                if (_parameterCollection.Contains("@ReturnValue"))
                {
                    return (int)_parameterCollection["@ReturnValue"].Value;
                }
                else
                {
                    throw new Exception("You must call the AddReturnValueParameter method before executing your request.");
                }
            }
        }

        #endregion Properties

        #region public methods
        #region Public Execute Methods
        /// <summary>
        /// Executes sql text against the current connection.
        /// </summary>
        /// <param name="sql">A string containing the SQL commands to execute.</param>
        public Int32 ExecuteSqlNonQuery(string sql)
        {
            return _ExecuteSqlNonQuery(sql);
        }
        public String ExecuteSqlScalar(string sql)
        {
            return _ExecuteSqlScalar(sql);
        }
        public bool ExecuteSqlNonQueryBool(string sql)
        {
            return _ExecuteSqlNonQueryBool(sql);
        }
        public Int32 ExecuteSPNonQuery(string procedureName)
        {
            return _ExecuteSPNonQuery(procedureName);
        }
        public String ExecuteSPScalar(string procedureName)
        {
            return _ExecuteSPScalar(procedureName);
        }
        private bool ExecuteSPNonQueryBool(string procedureName)
        {
            return _ExecuteSPNonQueryBool(procedureName);
        }

        /// <summary>
        /// Executes sql text against the current connection.
        /// Returns a SqlDataReader.
        /// </summary>
        /// <param name="sql">A string containing the SQL commands to execute.</param>
        public SqlDataReader ExecuteSqlReader(string sql)
        {
            return _ExecuteSqlReader(sql);
        }

        /// <summary>
        /// Executes sql text against the current connection.
        /// Returns an XmlReader
        /// </summary>
        /// <param name="sql">A string containing the SQL commands to execute.</param>
        public XmlReader ExecuteSqlXmlReader(string sql)
        {
            return _ExecuteSqlXmlReader(sql);
        }

        /// <summary>
        /// Executes sql text against the current connection.
        /// Returns a DataSet.
        /// </summary>
        /// <param name="sql">A string containing the SQL commands to execute.</param>
        public DataSet ExecuteSqlDataSet(string sql)
        {
            return _ExecuteSqlDataSet(sql);
        }

        /// <summary>
        /// Executes sql text against the current connection.
        /// Returns DataSet with table named tableName.
        /// </summary>
        /// <param name="sql">A string containing the SQL commands to execute.</param>
        /// <param name="tableName">A string containing the name for the DataSet table.</param>
        public DataSet ExecuteSqlDataSet(string sql, string tableName)
        {
            return _ExecuteSqlDataSet(sql, tableName);
        }

        /// <summary>
        /// Executes sql text against the current connection.
        /// Results are stored in the given DataSet with table named tableName.
        /// </summary>
        /// <param name="dataSet">The DataSet to return the results in.</param>
        /// <param name="sql">A string containing the SQL commands to execute.</param>
        /// <param name="tableName">A string containing the name for the DataSet table.</param>
        public void ExecuteSqlDataSet(DataSet dataSet, string sql, string tableName)
        {
            _ExecuteSqlDataSet(dataSet, sql, tableName);
        }

        /// <summary>
        /// Executes the given stored procedure against the current connection.
        /// Returns a DataSet.
        /// </summary>
        /// <param name="procedureName">A string containing the name of the stored procedure to execute.</param>
        public DataSet ExecuteSPDataSet(string procedureName)
        {
            return _ExecuteSPDataSet(procedureName);
        }

        /// <summary>
        /// Executes the given stored procedure against the current connection.
        /// Returns a DataSet.
        /// </summary>
        /// <param name="procedureName">A string containing the name of the stored procedure to execute.</param>
        /// <param name="tableName">A string containing the name for the DataSet table to be filled.</param>
        public DataSet ExecuteSPDataSet(string procedureName, string tableName)
        {
            return _ExecuteSPDataSet(procedureName, tableName);
        }

        /// <summary>
        /// Executes the given stored procedure against the current connection.
        /// Returns the named DataSet.
        /// </summary>
        /// <param name="dataSet">A string containing the name of the existing DataSet to use.</param>
        /// <param name="procedureName">A string containing the name of the stored procedure to execute.</param>
        /// <param name="tableName">A string containing the name for the DataSet table to be filled.</param>
        public void ExecuteSPDataSet(DataSet dataSet, string procedureName, string tableName)
        {
            _ExecuteSPDataSet(dataSet, procedureName, tableName);
        }

        /// <summary>
        /// Executes the given stored procedure against the current connection.
        /// Returns the named DataSet.
        /// </summary>
        /// <param name="dataSet">A string containing the name of the existing DataSet to use.</param>
        /// <param name="procedureName">A string containing the name of the stored procedure to execute.</param>
        /// <param name="tableName">A string containing the name for the DataSet table to be filled.</param>
        /// <param name="tableMappings">A DataTableMappingCollection containing the names of the DataSource tables and the DataSet table names to map them to.</param>
        public void ExecuteSPDataSet(DataSet dataSet, string procedureName, string tableName, DataTableMappingCollection tableMappings)
        {
            _ExecuteSPDataSet(dataSet, procedureName, tableName, tableMappings);
        }

        /// <summary>
        /// Executes the insert, update, and delete commands against the current connection and 
        /// returns the updated DataSet.
        /// </summary>
        /// <param name="dataSet">A string containing the name of the existing DataSet to use.</param>
        /// <param name="tableName">A string containing DataSet table name to be updated.</param>
        /// <param name="insertCommand">The SQL InsertCommand to execute.</param>
        /// <param name="updateCommand">The SQL UpdateCommand to execute.</param>
        /// <param name="deleteCommand">The SQL DelteCommand to execute.</param>
        public void ExecuteUpdateDataSet(DataSet dataSet, string tableName, SqlCommand insertCommand, SqlCommand updateCommand, SqlCommand deleteCommand)
        {
            _ExecuteUpdateDataSet(dataSet, tableName, insertCommand, updateCommand, deleteCommand);
        }

        /// <summary>
        /// Executes the named stored procedure against the current connection.
        /// </summary>
        /// <param name="procedureName">A string containing the name of the stored procedure to execute.</param>
        public void ExecuteSP(string procedureName)
        {
            _ExecuteSP(procedureName);
        }

        /// <summary>
        /// Executes the named stored procedure against the current connection.
        /// Returns a SqlDataReader.
        /// </summary>
        /// <param name="procedureName">A string containing the name of the stored procedure to execute.</param>
        public SqlDataReader ExecuteSPReader(string procedureName)
        {
            return _ExecuteSPReader(procedureName);
        }

        /// <summary>
        /// Executes the named stored procedure against the current connection.
        /// Returns an XmlReader.
        /// </summary>
        /// <param name="procedureName">A string containing the name of the stored procedure to execute.</param>
        public XmlReader ExecuteSPXmlReader(string procedureName)
        {
            return _ExecuteSPXmlReader(procedureName);
        }

        #endregion

        #region Public AddParameter
        /// <summary>
        /// Adds a SqlParameter to the SqlService object.
        /// </summary>
        /// <param name="name">A string containing the name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        //[DebuggerStepThrough]
        public SqlParameter AddParameter(string name, object value)
        {
            return _AddParameter(name, value);
        }
        /// <summary>
        /// Adds a SqlParameter to the SqlService object.
        /// </summary>
        /// <param name="name">A string containing the name of the parameter.</param>
        /// <param name="type">The SqlDbType for the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        //[DebuggerStepThrough]
        public SqlParameter AddParameter(string name, SqlDbType type, object value)
        {
            return _AddParameter(name, type, value);
        }

        /// <summary>
        /// Adds a SqlParameter to the SqlService object.
        /// </summary>
        /// <param name="name">A string containing the name of the parameter.</param>
        /// <param name="type">The SqlDbType for the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="convertZeroToDBNull">If true, will convert zero values to DBNull.</param>
        //[DebuggerStepThrough]
        public SqlParameter AddParameter(string name, SqlDbType type, object value, bool convertZeroToDBNull)
        {
            return _AddParameter(name, type, value, convertZeroToDBNull);
        }

        /// <summary>
        /// Adds a SqlParameter to the SqlService object.
        /// </summary>
        /// <param name="name">A string containing the name of the parameter.</param>
        /// <param name="type">The SqlDbType for the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="size">The column length for the parameter.</param>
        //[DebuggerStepThrough]
        public SqlParameter AddParameter(string name, SqlDbType type, object value, int size)
        {
            return _AddParameter(name, type, value, size);
        }

        /// <summary>
        /// Adds a SqlParameter to the SqlService object.
        /// </summary>
        /// <param name="name">A string containing the name of the parameter.</param>
        /// <param name="type">The SqlDbType for the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="direction">The parameter direction: Input, Output, InputOutput</param>
        //[DebuggerStepThrough]
        public SqlParameter AddParameter(string name, SqlDbType type, object value, ParameterDirection direction)
        {
            return _AddParameter(name, type, value, direction);
        }

        /// <summary>
        /// Adds a SqlParameter to the SqlService object.
        /// </summary>
        /// <param name="name">A string containing the name of the parameter.</param>
        /// <param name="type">The SqlDbType for the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="size">The column length for the parameter.</param>
        /// <param name="direction">The parameter direction: Input, Output, InputOutput, ReturnValue</param>
        //[DebuggerStepThrough]
        public SqlParameter AddParameter(string name, SqlDbType type, object value, int size, ParameterDirection direction)
        {
            return _AddParameter(name, type, value, size, direction);
        }

        /// <summary>
        /// Adds a SqlParameter to the SqlService object.
        /// </summary>
        /// <param name="parameter">An existing SqlParameter to add.</param>
        //[DebuggerStepThrough]
        public void AddParameter(SqlParameter parameter)
        {
            _AddParameter(parameter);
        }

        public void AddParameterRange(params SqlParameter[] parameterList)
        {
            _AddParameterRange(parameterList);
        }
        #endregion

        #region Public Specialized AddParameter Methods
        /// <summary>
        /// Adds an Output SqlParameter to the SqlService object.
        /// </summary>
        /// <param name="name">A string containing the name of the parameter.</param>
        /// <param name="type">The SqlDbType for the parameter.</param>
        //[DebuggerStepThrough]
        public SqlParameter AddOutputParameter(string name, SqlDbType type)
        {
            return _AddOutputParameter(name, type);
        }

        /// <summary>
        /// Adds an Output SqlParameter to the SqlService object.
        /// </summary>
        /// <param name="name">A string containing the name of the parameter.</param>
        /// <param name="type">The SqlDbType for the parameter.</param>
        /// <param name="size">The column length for the parameter.</param>
        //[DebuggerStepThrough]
        public SqlParameter AddOutputParameter(string name, SqlDbType type, int size)
        {
            return _AddOutputParameter(name, type, size);
        }

        /// <summary>
        /// Adds an Output SqlParameter to the SqlService object.
        /// </summary>
        /// <param name="name">A string containing the name of the parameter.</param>
        /// <param name="type">The SqlDbType for the parameter.</param>
        /// <param name="value">The initial value of the parameter.</param>
        /// <param name="size">The column length for the parameter.</param>
        //[DebuggerStepThrough]
        public SqlParameter AddOutputParameter(string name, SqlDbType type, object value, int size)
        {
            return _AddOutputParameter(name, type, value, size);
        }

        /// <summary>
        /// Adds a ReturnValue SqlParameter to the SqlService object.
        /// </summary>
        //[DebuggerStepThrough]
        public SqlParameter AddReturnValueParameter()
        {
            return _AddReturnValueParameter();
        }

        /// <summary>
        /// Adds a SqlParameter whose value comes from a binary Stream.
        /// </summary>
        /// <param name="name">A string containing the name of the parameter.</param>
        /// <param name="value">The Stream to read the parameter value from.</param>
        //[DebuggerStepThrough]
        public SqlParameter AddStreamParameter(string name, Stream value)
        {
            return _AddStreamParameter(name, value, SqlDbType.Image);
        }

        /// <summary>
        /// Adds a SqlParameter whose value comes from a Stream.
        /// </summary>
        /// <param name="name">A string containing the name of the parameter.</param>
        /// <param name="value">The Stream to read the parameter value from.</param>
        /// <param name="type">The SqlDbType of the parameter.</param>
        //[DebuggerStepThrough]
        public SqlParameter AddStreamParameter(string name, Stream value, SqlDbType type)
        {
            return _AddStreamParameter(name, value, type);
        }

        /// <summary>
        /// Adds a SqlParameter of type Text.
        /// </summary>
        /// <param name="name">A string containing the name of the parameter.</param>
        /// <param name="value">A string containing the value of the parameter.</param>
        //[DebuggerStepThrough]
        public SqlParameter AddTextParameter(string name, string value)
        {
            return _AddTextParameter(name, value);
        }

        /// <summary>
        /// Adds a SqlParameter to the SqlService object.
        /// </summary>
        /// <param name="parameterName">A string containing the name of the parameter.</param>
        /// <param name="values">The array of values of the parameter.</param>
        /// <param name="fieldName">A string containing the name of the database field respective to the array of values.</param>
        ////[DebuggerStepThrough]
        public SqlParameter AddArrayParameter(string parameterName, Array values, string fieldName)
        {
            return _AddArrayParameter(parameterName, values, fieldName);
        }

        /// <summary>
        /// Adds a SqlParameter to the SqlService object.
        /// </summary>
        /// <param name="parameterName">A string containing the name of the parameter.</param>
        /// <param name="values">The array of values of the parameter.</param>
        /// <param name="size">The length for the varchar parameter containing the serialized array of values.</param>
        /// <param name="fieldName">A string containing the name of the database field respective to the array of values.</param>
        /// <param name="ommitZeroValues">Indicates whether values equal to zero should be ommitted from the serialized array.</param>
        //[DebuggerStepThrough]
        public SqlParameter AddArrayParameter(string parameterName, Array values, string fieldName, bool ommitZeroValues)
        {
            return _AddArrayParameter(parameterName, values, fieldName, ommitZeroValues);
        }
        #endregion

        #region Public Misc Methods
        /// <summary>
        /// Opens the Sql Connection.
        /// </summary>
        //[DebuggerStepThrough]
        public void Connect()
        {
            _Connect();
        }

        /// <summary>
        /// Closes the Sql Connection.
        /// </summary>
        //[DebuggerStepThrough]
        public void Disconnect()
        {
            _Disconnect();
        }

        /// <summary>
        /// Starts a Transaction.
        /// </summary>
        //[DebuggerStepThrough]
        public void BeginTransaction()
        {
            _BeginTransaction();
        }

        /// <summary>
        /// Commits the current transaction.
        /// </summary>
        //[DebuggerStepThrough]
        public void CommitTransaction()
        {
            _CommitTransaction();
        }

        /// <summary>
        /// Rolls back the current transaction.
        /// </summary>
        //[DebuggerStepThrough]
        public void RollbackTransaction()
        {
            _RollbackTransaction();
        }

        /// <summary>
        /// Reset the SqlService object, clearing any parameters.
        /// </summary>
        //[DebuggerStepThrough]
        public void Reset()
        {
            _Reset();
        }

        #endregion

        #endregion

        #region methods
        #region Execute Methods
        private Int32 _ExecuteSqlNonQuery(string sql)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();
                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = sql;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                if (!CheckInputBool(cmd.CommandText))
                {
                    cmd.CommandType = CommandType.Text;
                    this.CopyParameters(cmd);
                    _rowsReturn = cmd.ExecuteNonQuery();
                    _parameterCollection = cmd.Parameters;
                }
            }
            catch (SqlException e)
            {
                if (this.AutoCloseConnection) this.Disconnect();
                throw new SqlServiceException(e, cmd.Parameters);
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
            return _rowsReturn;
        }
        private Int32 _ExecuteSPNonQuery(string procedureName)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();
                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = procedureName;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                this.CopyParameters(cmd);
                _rowsReturn = cmd.ExecuteNonQuery();
                _parameterCollection = cmd.Parameters;
            }
            catch (SqlException e)
            {
                if (this.AutoCloseConnection) this.Disconnect();
                throw new SqlServiceException(e, cmd.Parameters);
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
            return _rowsReturn;
        }
        private String _ExecuteSqlScalar(string sql)
        {
            String RetSingleVlaue = String.Empty;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();
                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = sql;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandType = CommandType.Text;
                this.CopyParameters(cmd);
                RetSingleVlaue = Convert.ToString(cmd.ExecuteScalar()).Trim();
                _parameterCollection = cmd.Parameters;
            }
            catch (SqlException e)
            {
                if (this.AutoCloseConnection) this.Disconnect();
                throw new SqlServiceException(e, cmd.Parameters);
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
            return RetSingleVlaue;
        }
        private String _ExecuteSPScalar(string procedureName)
        {
            String RetSingleVlaue = String.Empty;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();
                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = procedureName;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                this.CopyParameters(cmd);
                RetSingleVlaue = Convert.ToString(cmd.ExecuteScalar()).Trim();
                _parameterCollection = cmd.Parameters;
            }
            catch (SqlException e)
            {
                if (this.AutoCloseConnection) this.Disconnect();
                throw new SqlServiceException(e, cmd.Parameters);
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
            return RetSingleVlaue;
        }
        private bool _ExecuteSqlNonQueryBool(string sql)
        {
            String RetSingleVlaue = String.Empty;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();
                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = sql;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandType = CommandType.Text;
                this.CopyParameters(cmd);
                _rowsReturn = cmd.ExecuteNonQuery();
                _parameterCollection = cmd.Parameters;
            }
            catch (SqlException e)
            {
                if (this.AutoCloseConnection) this.Disconnect();
                throw new SqlServiceException(e, cmd.Parameters);
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
            if (_rowsReturn > 0)
                return true;
            else
                return false;
        }
        private bool _ExecuteSPNonQueryBool(string procedureName)
        {
            String RetSingleVlaue = String.Empty;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();
                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = procedureName;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                this.CopyParameters(cmd);
                _rowsReturn = cmd.ExecuteNonQuery();
                _parameterCollection = cmd.Parameters;
            }
            catch (SqlException e)
            {
                if (this.AutoCloseConnection) this.Disconnect();
                throw new SqlServiceException(e, cmd.Parameters);
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
            if (_rowsReturn > 0)
                return true;
            else
                return false;
        }
        private SqlDataReader _ExecuteSqlReader(string sql)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();
                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = sql;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandType = CommandType.Text;
                this.CopyParameters(cmd);
                CommandBehavior behavior = CommandBehavior.Default;
                if (this.AutoCloseConnection) behavior = behavior | CommandBehavior.CloseConnection;
                if (_isSingleRow) behavior = behavior | CommandBehavior.SingleRow;
                SqlDataReader reader = cmd.ExecuteReader(behavior);
                _parameterCollection = cmd.Parameters;
                return reader;
            }
            catch (SqlException e)
            {
                if (this.AutoCloseConnection) this.Disconnect();
                throw new SqlServiceException(e, cmd.Parameters);
            }
            catch (Exception e)
            {
                if (this.AutoCloseConnection) this.Disconnect();
                throw e;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }
        private SqlDataReader _ExecuteSPReader(string procedureName)
        {
            SqlDataReader reader;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();

                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = procedureName;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                this.CopyParameters(cmd);

                CommandBehavior behavior = CommandBehavior.Default;

                if (this.AutoCloseConnection) behavior = behavior | CommandBehavior.CloseConnection;
                if (_isSingleRow) behavior = behavior | CommandBehavior.SingleRow;

                reader = cmd.ExecuteReader(behavior);

                _parameterCollection = cmd.Parameters;

                return reader;
            }
            catch (SqlException e)
            {
                if (this.AutoCloseConnection) this.Disconnect();
                throw new SqlServiceException(e, cmd.Parameters);
            }
            catch (Exception e)
            {
                if (this.AutoCloseConnection) this.Disconnect();
                throw e;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }
        private XmlReader _ExecuteSqlXmlReader(string sql)
        {
            XmlReader reader;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();
                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = sql;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandType = CommandType.Text;
                this.CopyParameters(cmd);
                reader = cmd.ExecuteXmlReader();
                _parameterCollection = cmd.Parameters;
                return reader;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }
        private XmlReader _ExecuteSPXmlReader(string procedureName)
        {
            XmlReader reader;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();

                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = procedureName;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                this.CopyParameters(cmd);

                reader = cmd.ExecuteXmlReader();

                _parameterCollection = cmd.Parameters;

                return reader;
            }
            catch (SqlException e)
            {
                if (this.AutoCloseConnection) this.Disconnect();
                throw new SqlServiceException(e, cmd.Parameters);
            }
            catch (Exception e)
            {
                if (this.AutoCloseConnection) this.Disconnect();
                throw e;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }
        private DataSet _ExecuteSqlDataSet(string sql)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();
                da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandTimeout = this.CommandTimeout;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                this.CopyParameters(cmd);

                da.SelectCommand = cmd;

                da.Fill(ds);

                _parameterCollection = cmd.Parameters;

                return ds;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
        }
        private DataSet _ExecuteSqlDataSet(string sql, string tableName)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();
                da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandTimeout = this.CommandTimeout;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                this.CopyParameters(cmd);

                da.SelectCommand = cmd;

                da.Fill(ds, tableName);

                _parameterCollection = cmd.Parameters;

                return ds;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
        }
        private DataSet _ExecuteSPDataSet(string procedureName)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();
                da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = procedureName;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                this.CopyParameters(cmd);

                da.SelectCommand = cmd;

                da.Fill(ds);

                _parameterCollection = cmd.Parameters;

                return ds;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
        }
        private DataSet _ExecuteSPDataSet(string procedureName, string tableName)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();
                da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = procedureName;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                this.CopyParameters(cmd);

                da.SelectCommand = cmd;

                da.Fill(ds, tableName);

                _parameterCollection = cmd.Parameters;

                return ds;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
        }
        private void _ExecuteSqlDataSet(DataSet dataSet, string sql, string tableName)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = null;

            try
            {
                cmd = new SqlCommand();
                this.Connect();
                da = new SqlDataAdapter();

                cmd.CommandTimeout = this.CommandTimeout;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                this.CopyParameters(cmd);

                da.SelectCommand = cmd;

                da.Fill(dataSet, tableName);

                _parameterCollection = cmd.Parameters;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
        }
        private void _ExecuteSPDataSet(DataSet dataSet, string procedureName, string tableName)
        {
            ExecuteSPDataSet(dataSet, procedureName, tableName, null);
        }
        private void _ExecuteSPDataSet(DataSet dataSet, string procedureName, string tableName, DataTableMappingCollection tableMappings)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = null;

            try
            {
                cmd = new SqlCommand();
                this.Connect();
                da = new SqlDataAdapter();

                foreach (DataTableMapping mapping in tableMappings)
                {
                    da.TableMappings.Add(mapping.SourceTable, mapping.DataSetTable);
                }

                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = procedureName;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                this.CopyParameters(cmd);

                da.SelectCommand = cmd;

                da.Fill(dataSet, tableName);

                _parameterCollection = cmd.Parameters;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
        }
        private void _ExecuteUpdateDataSet(DataSet dataSet, string tableName, SqlCommand insertCommand, SqlCommand updateCommand, SqlCommand deleteCommand)
        {
            SqlDataAdapter da = null;

            try
            {
                this.Connect();
                da = new SqlDataAdapter();
                da.InsertCommand = insertCommand;
                da.UpdateCommand = updateCommand;
                da.DeleteCommand = deleteCommand;

                insertCommand.CommandTimeout = this.CommandTimeout;
                updateCommand.CommandTimeout = this.CommandTimeout;
                deleteCommand.CommandTimeout = this.CommandTimeout;

                insertCommand.Connection = _connection;
                updateCommand.Connection = _connection;
                deleteCommand.Connection = _connection;

                if (_transaction != null)
                {
                    insertCommand.Transaction = _transaction;
                    updateCommand.Transaction = _transaction;
                    deleteCommand.Transaction = _transaction;
                }

                da.Update(dataSet, tableName);
            }
            finally
            {
                if (da != null) da.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
        }
        private void _ExecuteSP(string procedureName)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                this.Connect();
                cmd.CommandTimeout = this.CommandTimeout;
                cmd.CommandText = procedureName;
                cmd.Connection = _connection;
                if (_transaction != null) cmd.Transaction = _transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                this.CopyParameters(cmd);
                cmd.ExecuteNonQuery();
                _parameterCollection = cmd.Parameters;
            }
            catch (SqlException e)
            {
                if (this.AutoCloseConnection) this.Disconnect();
                throw new SqlServiceException(e, cmd.Parameters);
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (this.AutoCloseConnection) this.Disconnect();
            }
        }
    
      
        public bool CheckInputBool(String parameter)
        {
            bool chkStatus = false;

            for (int i = 0; i < blackList.Length; i++)
            {
                if ((parameter.IndexOf(blackList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    chkStatus = true;
                }
            }
            if (chkStatus)
            {
               
                throw new Exception("SQL Injection Happen");
               // SqlException ex;
                //throw new SqlServiceException(ex, parameter);
                //HttpContext.Current.Session["SQlInjQuery"] = parameter;
                //HttpContext.Current.Response.Redirect("~/SecurityPopUp.aspx", false);
            }
            return chkStatus;
        }
        #endregion Execute Methods

        #region AddParameter

        private SqlParameter _AddParameter(string name, object value)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = name;
            prm.Value = this.PrepareSqlValue(value);
            _parameters.Add(prm);
            return prm;
        }
        private SqlParameter _AddParameter(string name, SqlDbType type, object value)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            prm.Value = this.PrepareSqlValue(value);
            _parameters.Add(prm);
            return prm;
        }

        private SqlParameter _AddParameter(string name, SqlDbType type, object value, bool convertZeroToDBNull)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            prm.Value = this.PrepareSqlValue(value, convertZeroToDBNull);
            _parameters.Add(prm);
            return prm;
        }

        private SqlParameter _AddParameter(string name, SqlDbType type, object value, int size)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            prm.Size = size;
            prm.Value = this.PrepareSqlValue(value);
            _parameters.Add(prm);
            return prm;
        }

        private SqlParameter _AddParameter(string name, SqlDbType type, object value, ParameterDirection direction)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = direction;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            prm.Value = this.PrepareSqlValue(value);
            _parameters.Add(prm);
            return prm;
        }

        private SqlParameter _AddParameter(string name, SqlDbType type, object value, int size, ParameterDirection direction)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = direction;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            prm.Size = size;
            prm.Value = this.PrepareSqlValue(value);
            _parameters.Add(prm);
            return prm;
        }

        private void _AddParameter(SqlParameter parameter)
        {
            _parameters.Add(parameter);
        }

        private void _AddParameterRange(SqlParameter[] parameterList)
        {
            _parameters.AddRange(parameterList);
        }

        #endregion

        #region Specialized AddParameter Methods
        //[DebuggerStepThrough]
        private SqlParameter _AddOutputParameter(string name, SqlDbType type)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Output;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            _parameters.Add(prm);
            return prm;
        }

        //[DebuggerStepThrough]
        private SqlParameter _AddOutputParameter(string name, SqlDbType type, int size)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Output;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            prm.Size = size;
            _parameters.Add(prm);
            return prm;
        }

        private SqlParameter _AddOutputParameter(string name, SqlDbType type, object value, int size)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.InputOutput;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            prm.Size = size;
            prm.Value = this.PrepareSqlValue(value);
            _parameters.Add(prm);
            return prm;
        }

        //[DebuggerStepThrough]
        private SqlParameter _AddArrayParameter(string parameterName, Array values, string fieldName)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = parameterName;
            prm.SqlDbType = SqlDbType.Text;
            prm.Value = this.PrepareSqlValue(values, fieldName);
            //prm.Size = ((string)prm.Value).Length;
            _parameters.Add(prm);
            return prm;
        }

        //[DebuggerStepThrough]
        private SqlParameter _AddArrayParameter(string parameterName, Array values, string fieldName, bool ommitZeroValues)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = parameterName;
            prm.SqlDbType = SqlDbType.Text;
            prm.Value = this.PrepareSqlValue(values, fieldName, ommitZeroValues);
            //prm.Size = ((string)prm.Value).Length;
            _parameters.Add(prm);
            return prm;
        }

        //[DebuggerStepThrough]
        private SqlParameter _AddReturnValueParameter()
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.ReturnValue;
            prm.ParameterName = "@ReturnValue";
            prm.SqlDbType = SqlDbType.Int;
            _parameters.Add(prm);
            return prm;
        }

        //[DebuggerStepThrough]
        private SqlParameter _AddStreamParameter(string name, Stream value, SqlDbType type)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            value.Position = 0;
            byte[] data = new byte[value.Length];
            value.Read(data, 0, (int)value.Length);
            prm.Value = data;
            _parameters.Add(prm);
            return prm;
        }

        //[DebuggerStepThrough]
        private SqlParameter _AddTextParameter(string name, string value)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = name;
            prm.SqlDbType = SqlDbType.Text;
            prm.Value = this.PrepareSqlValue(value);
            //prm.Size = ((string)prm.Value).Length;
            _parameters.Add(prm);
            return prm;
        }

        #endregion Specialized AddParameter Methods

        #region Private Methods
        //[DebuggerStepThrough]
        private void CopyParameters(SqlCommand command)
        {
            for (int i = 0; i < _parameters.Count; i++)
            {
                command.Parameters.Add(_parameters[i]);
            }
        }

        //[DebuggerStepThrough]
        private object PrepareSqlValue(object value)
        {
            return this.PrepareSqlValue(value, false);
        }

        //[DebuggerStepThrough]
        private object PrepareSqlValue(Array values, string fieldName)
        {
            return this.PrepareSqlValue(values, fieldName, false);
        }

        //[DebuggerStepThrough]
        private object PrepareSqlValue(object value, bool convertZeroToDBNull)
        {
            if (value == null) return DBNull.Value;

            switch (value.GetType().ToString())
            {
                case "System.String":
                    if (this.ConvertEmptyValuesToDbNull && (string)value == String.Empty)
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return _StripInvalidCharacters((string)value);
                    }
                case "System.Guid":
                    if (this.ConvertEmptyValuesToDbNull && (Guid)value == Guid.Empty)
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return value;
                    }
                case "System.DateTime":
                    if ((this.ConvertMinValuesToDbNull && (DateTime)value == DateTime.MinValue)
                        || (this.ConvertMaxValuesToDbNull && (DateTime)value == DateTime.MaxValue))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return value;
                    }
                case "System.Int16":
                    if ((this.ConvertMinValuesToDbNull && (Int16)value == Int16.MinValue)
                        || (this.ConvertMaxValuesToDbNull && (Int16)value == Int16.MaxValue)
                        || (convertZeroToDBNull && (Int16)value == 0))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return value;
                    }
                case "System.Int32":
                    if ((this.ConvertMinValuesToDbNull && (Int32)value == Int32.MinValue)
                        || (this.ConvertMaxValuesToDbNull && (Int32)value == Int32.MaxValue)
                        || (convertZeroToDBNull && (Int32)value == 0))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return value;
                    }
                case "System.Int64":
                    if ((this.ConvertMinValuesToDbNull && (Int64)value == Int64.MinValue)
                        || (this.ConvertMaxValuesToDbNull && (Int64)value == Int64.MaxValue)
                        || (convertZeroToDBNull && (Int64)value == 0))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return value;
                    }
                case "System.Single":
                    if ((this.ConvertMinValuesToDbNull && (Single)value == Single.MinValue)
                        || (this.ConvertMaxValuesToDbNull && (Single)value == Single.MaxValue)
                        || (convertZeroToDBNull && (Single)value == 0))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return value;
                    }
                case "System.Double":
                    if ((this.ConvertMinValuesToDbNull && (Double)value == Double.MinValue)
                        || (this.ConvertMaxValuesToDbNull && (Double)value == Double.MaxValue)
                        || (convertZeroToDBNull && (Double)value == 0))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return value;
                    }
                case "System.Decimal":
                    if ((this.ConvertMinValuesToDbNull && (Decimal)value == Decimal.MinValue)
                        || (this.ConvertMaxValuesToDbNull && (Decimal)value == Decimal.MaxValue)
                        || (convertZeroToDBNull && (Decimal)value == 0))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return value;
                    }
                default:
                    return value;
            }
        }


        //[DebuggerStepThrough]
        private object PrepareSqlValue(Array values, string fieldName, bool ommitZeroValues)
        {
            StringBuilder xml = new StringBuilder("<" + fieldName + "List>");

            foreach (object value in values)
            //			for (int i = 0; i < values.Length; i++)
            {
                //				object value = values[i];

                switch (value.GetType().ToString())
                {
                    case "System.String":
                        if ((string)value != String.Empty)
                        {
                            xml.Append("<" + fieldName + ">" + _StripInvalidCharacters((string)value) + "</" + fieldName + ">");
                        }
                        break;
                    case "System.Guid":
                        if ((Guid)value != Guid.Empty)
                        {
                            xml.Append("<" + fieldName + ">" + value + "</" + fieldName + ">");
                        }
                        break;
                    case "System.DateTime":
                        if ((!this.ConvertMinValuesToDbNull || (DateTime)value != DateTime.MinValue)
                            && (!this.ConvertMaxValuesToDbNull || (DateTime)value != DateTime.MaxValue))
                        {
                            xml.Append("<" + fieldName + ">" + value + "</" + fieldName + ">");
                        }
                        break;
                    case "System.Int16":
                        if ((this.ConvertMinValuesToDbNull && (Int16)value == Int16.MinValue)
                            || (this.ConvertMaxValuesToDbNull && (Int16)value == Int16.MaxValue)
                            || (ommitZeroValues && (Int16)value == 0))
                        {
                            xml.Append("<" + fieldName + ">" + 0 + "</" + fieldName + ">");
                        }
                        else
                        {
                            xml.Append("<" + fieldName + ">" + value + "</" + fieldName + ">");
                        }
                        break;
                    case "System.Int32":
                        if ((this.ConvertMinValuesToDbNull && (Int32)value == Int32.MinValue)
                            || (this.ConvertMaxValuesToDbNull && (Int32)value == Int32.MaxValue)
                            || (ommitZeroValues && (Int32)value == 0))
                        {
                            xml.Append("<" + fieldName + ">" + 0 + "</" + fieldName + ">");
                        }
                        else
                        {
                            xml.Append("<" + fieldName + ">" + value + "</" + fieldName + ">");
                        }
                        break;
                    case "System.Int64":
                        if ((this.ConvertMinValuesToDbNull && (Int64)value == Int64.MinValue)
                            || (this.ConvertMaxValuesToDbNull && (Int64)value == Int64.MaxValue)
                            || (ommitZeroValues && (Int64)value == 0))
                        {
                            xml.Append("<" + fieldName + ">" + 0 + "</" + fieldName + ">");
                        }
                        else
                        {
                            xml.Append("<" + fieldName + ">" + value + "</" + fieldName + ">");
                        }
                        break;
                    case "System.Single":
                        if ((this.ConvertMinValuesToDbNull && (Single)value == Single.MinValue)
                            || (this.ConvertMaxValuesToDbNull && (Single)value == Single.MaxValue)
                            || (ommitZeroValues && (Single)value == 0))
                        {
                            xml.Append("<" + fieldName + ">" + 0 + "</" + fieldName + ">");
                        }
                        else
                        {
                            xml.Append("<" + fieldName + ">" + value + "</" + fieldName + ">");
                        }
                        break;
                    case "System.Double":
                        if ((this.ConvertMinValuesToDbNull && (Double)value == Double.MinValue)
                            || (this.ConvertMaxValuesToDbNull && (Double)value == Double.MaxValue)
                            || (ommitZeroValues && (Double)value == 0))
                        {
                            xml.Append("<" + fieldName + ">" + 0 + "</" + fieldName + ">");
                        }
                        else
                        {
                            xml.Append("<" + fieldName + ">" + value + "</" + fieldName + ">");
                        }
                        break;
                    case "System.Decimal":
                        if ((this.ConvertMinValuesToDbNull && (Decimal)value == Decimal.MinValue)
                            || (this.ConvertMaxValuesToDbNull && (Decimal)value == Decimal.MaxValue)
                            || (ommitZeroValues && (Decimal)value == 0))
                        {
                            xml.Append("<" + fieldName + ">" + 0 + "</" + fieldName + ">");
                        }
                        else
                        {
                            xml.Append("<" + fieldName + ">" + value + "</" + fieldName + ">");
                        }
                        break;
                }
            }
            xml.Append("</" + fieldName + "List>");
            return xml.ToString();
        }
        #endregion Private Methods

        #region Misc Methods
        private void _Connect()
        {
            try
            {
                if (_connection != null)
                {
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }
                }
                else
                {
                    if (_connectionString != String.Empty)
                    {
                        _connection = new SqlConnection(_connectionString);
                        _connection.Open();
                    }
                    else
                    {
                        throw new InvalidOperationException("You must set a connection object or specify a connection string before calling Connect.");
                    }
                }
            }
            catch (Exception e)
            {
                try
                {
                    System.Diagnostics.EventLog.WriteEntry("SqlService", "Failure while opening sql connection: " + _connection.ConnectionString, System.Diagnostics.EventLogEntryType.Error);
                }
                catch
                { }
                throw e;
            }
        }

        private void _Disconnect()
        {
            if ((_connection != null) && (_connection.State != ConnectionState.Closed))
            {
                _connection.Close();
            }

            if (_connection != null) _connection.Dispose();
            if (_transaction != null) _transaction.Dispose();

            _transaction = null;
            _connection = null;
        }

        private void _BeginTransaction()
        {
            if (_connection != null)
            {
                _transaction = _connection.BeginTransaction();
            }
            else
            {
                throw new InvalidOperationException("You must have a valid connection object before calling BeginTransaction.");
            }
        }

        private void _CommitTransaction()
        {
            if (_transaction != null)
            {
                try
                {
                    _transaction.Commit();
                }
                catch
                {
                    // TODO: We need to handle this situation.  Maybe just write a log entry or something.
                }
            }
            else
            {
                throw new InvalidOperationException("You must call BeginTransaction before calling CommitTransaction.");
            }
        }

        private void _RollbackTransaction()
        {
            if (_transaction != null)
            {
                try
                {
                    _transaction.Rollback();
                }
                catch
                {
                    // TODO: We need to handle this situation.  Maybe just write a log entry or something.
                }
            }
            else
            {
                throw new InvalidOperationException("You must call BeginTransaction before calling RollbackTransaction.");
            }
        }

        private void _Reset()
        {
            if (_parameters != null)
            {
                _parameters.Clear();
            }

            if (_parameterCollection != null)
            {
                _parameterCollection = null;
            }
        }

        private string _StripInvalidCharacters(string input)
        {
            return input;
        }

        #endregion

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _Disconnect();
        }

        #endregion
    }
}