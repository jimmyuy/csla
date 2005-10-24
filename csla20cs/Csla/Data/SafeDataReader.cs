using System;
using System.Data;

namespace Csla.Data
{
  /// <summary>
  /// This is a DataReader that 'fixes' any null values before
  /// they are returned to our business code.
  /// </summary>
  public class SafeDataReader : IDataReader
  {
    private IDataReader _dataReader;

    protected IDataReader DataReader
    {
      get { return _dataReader; }
    }

    /// <summary>
    /// Initializes the SafeDataReader object to use data from
    /// the provided DataReader object.
    /// </summary>
    /// <param name="dataReader">The source DataReader object containing the data.</param>
    public SafeDataReader(IDataReader dataReader)
    {
      _dataReader = dataReader;
    }

    /// <summary>
    /// Gets a string value from the datareader.
    /// </summary>
    /// <remarks>
    /// Returns "" for null.
    /// </remarks>
    public string GetString(string name)
    {
      return GetString(_dataReader.GetOrdinal(name));
    }

    public string GetString(int i)
    {
      if (_dataReader.IsDBNull(i))
        return string.Empty;
      else
        return _dataReader.GetString(i);
    }


    /// <summary>
    /// Gets a value of type <see cref="System.Object" /> from the datareader.
    /// </summary>
    /// <remarks>
    /// Returns Nothing for null.
    /// </remarks>
    public object GetValue(string name)
    {
      return GetValue(_dataReader.GetOrdinal(name));
    }

    public object GetValue(int i)
    {
      if (_dataReader.IsDBNull(i))
        return null;
      else
        return _dataReader.GetValue(i);
    }

    /// <summary>
    /// Gets an integer from the datareader.
    /// </summary>
    /// <remarks>
    /// Returns 0 for null.
    /// </remarks>
    public int GetInt32(string name)
    {
      return GetInt32(_dataReader.GetOrdinal(name));
    }

    public int GetInt32(int i)
    {
      if (_dataReader.IsDBNull(i))
        return 0;
      else
        return _dataReader.GetInt32(i);
    }

    /// <summary>
    /// Gets a double from the datareader.
    /// </summary>
    /// <remarks>
    /// Returns 0 for null.
    /// </remarks>
    public double GetDouble(string name)
    {
      return GetDouble(_dataReader.GetOrdinal(name));
    }

    public double GetDouble(int i)
    {
      if (_dataReader.IsDBNull(i))
        return 0;
      else
        return _dataReader.GetDouble(i);
    }

    /// <summary>
    /// Gets a <see cref="T:Csla.SmartDate" /> from the datareader.
    /// </summary>
    /// <remarks>
    /// A null is converted into either the min or max possible date
    /// depending on the MinIsEmpty parameter. See Chapter 5 for more
    /// details on the SmartDate class.
    /// </remarks>
    /// <param name="i">The column number within the datareader.</param>
    public Csla.SmartDate GetSmartDate(string name)
    {
      return GetSmartDate(_dataReader.GetOrdinal(name));
    }

    public Csla.SmartDate GetSmartDate(int i)
    {
      if (_dataReader.IsDBNull(i))
        return new Csla.SmartDate(false);

      else
        return new Csla.SmartDate(_dataReader.GetDateTime(i), false);
    }

    /// <summary>
    /// Gets a <see cref="T:Csla.SmartDate" /> from the datareader.
    /// </summary>
    /// <remarks>
    /// A null is converted into either the min or max possible date
    /// depending on the MinIsEmpty parameter. See Chapter 5 for more
    /// details on the SmartDate class.
    /// </remarks>
    /// <param name="i">The column number within the datareader.</param>
    /// <param name="MinIsEmpty">A flag indicating whether the min 
    /// or max value of a data means an empty date.</param>
    public Csla.SmartDate GetSmartDate(string name, bool minIsEmpty)
    {
      return GetSmartDate(_dataReader.GetOrdinal(name), minIsEmpty);
    }

    public Csla.SmartDate GetSmartDate(int i, bool minIsEmpty)
    {
      if (_dataReader.IsDBNull(i))
        return new Csla.SmartDate(minIsEmpty);

      else
        return new Csla.SmartDate(_dataReader.GetDateTime(i), minIsEmpty);
    }

    /// <summary>
    /// Gets a Guid value from the datareader.
    /// </summary>
    public System.Guid GetGuid(string name)
    {
      return GetGuid(_dataReader.GetOrdinal(name));
    }

    public System.Guid GetGuid(int i)
    {
      if (_dataReader.IsDBNull(i))
        return Guid.Empty;
      else
        return _dataReader.GetGuid(i);
    }

    /// <summary>
    /// Reads the next row of data from the datareader.
    /// </summary>
    public bool Read()
    {
      return _dataReader.Read();
    }

    /// <summary>
    /// Moves to the next result set in the datareader.
    /// </summary>
    public bool NextResult()
    {
      return _dataReader.NextResult();
    }

    /// <summary>
    /// Closes the datareader.
    /// </summary>
    public void Close()
    {
      _dataReader.Close();
    }

    /// <summary>
    /// Returns the depth property value from the datareader.
    /// </summary>
    public int Depth
    {
      get
      {
        return _dataReader.Depth;
      }
    }

    /// <summary>
    /// Returns the FieldCount property from the datareader.
    /// </summary>
    public int FieldCount
    {
      get
      {
        return _dataReader.FieldCount;
      }
    }

    /// <summary>
    /// Gets a boolean value from the datareader.
    /// </summary>
    public bool GetBoolean(string name)
    {
      return GetBoolean(_dataReader.GetOrdinal(name));
    }

    public bool GetBoolean(int i)
    {
      if (_dataReader.IsDBNull(i))
        return false;
      else
        return _dataReader.GetBoolean(i);
    }

    /// <summary>
    /// Gets a byte value from the datareader.
    /// </summary>
    public byte GetByte(string name)
    {
      return GetByte(_dataReader.GetOrdinal(name));
    }

    public byte GetByte(int i)
    {
      if (_dataReader.IsDBNull(i))
        return 0;
      else
        return _dataReader.GetByte(i);
    }

    /// <summary>
    /// Invokes the GetBytes method of the underlying datareader.
    /// </summary>
    public Int64 GetBytes(string name, Int64 fieldOffset,
      byte[] buffer, int bufferoffset, int length)
    {
      return GetBytes(_dataReader.GetOrdinal(name), fieldOffset, buffer, bufferoffset, length);
    }

    public Int64 GetBytes(int i, Int64 fieldOffset,
      byte[] buffer, int bufferoffset, int length)
    {
      if (_dataReader.IsDBNull(i))
        return 0;
      else
        return _dataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
    }

    /// <summary>
    /// Gets a char value from the datareader.
    /// </summary>
    public char GetChar(string name)
    {
      return GetChar(_dataReader.GetOrdinal(name));
    }

    public char GetChar(int i)
    {
      if (_dataReader.IsDBNull(i))
        return char.MinValue;
      else
      {
        char[] myChar = new char[1];
        _dataReader.GetChars(i, 0, myChar, 0, 1);
        return myChar[0];
      }
    }

    /// <summary>
    /// Invokes the GetChars method of the underlying datareader.
    /// </summary>
    public Int64 GetChars(string name, Int64 fieldoffset,
      char[] buffer, int bufferoffset, int length)
    {
      return GetChars(_dataReader.GetOrdinal(name), fieldoffset, buffer, bufferoffset, length);
    }

    public Int64 GetChars(int i, Int64 fieldoffset,
      char[] buffer, int bufferoffset, int length)
    {
      if (_dataReader.IsDBNull(i))
        return 0;
      else
        return _dataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
    }

    /// <summary>
    /// Invokes the GetData method of the underlying datareader.
    /// </summary>
    public IDataReader GetData(string name)
    {
      return GetData(_dataReader.GetOrdinal(name));
    }

    public IDataReader GetData(int i)
    {
      return _dataReader.GetData(i);
    }

    /// <summary>
    /// Invokes the GetDataTypeName method of the underlying datareader.
    /// </summary>
    public string GetDataTypeName(string name)
    {
      return GetDataTypeName(_dataReader.GetOrdinal(name));
    }

    public string GetDataTypeName(int i)
    {
      return _dataReader.GetDataTypeName(i);
    }

    /// <summary>
    /// Gets a date value from the datareader.
    /// </summary>
    public DateTime GetDateTime(string name)
    {
      return GetDateTime(_dataReader.GetOrdinal(name));
    }

    public DateTime GetDateTime(int i)
    {
      if (_dataReader.IsDBNull(i))
        return DateTime.MinValue;
      else
        return _dataReader.GetDateTime(i);
    }

    /// <summary>
    /// Gets a decimal value from the datareader.
    /// </summary>
    public decimal GetDecimal(string name)
    {
      return GetDecimal(_dataReader.GetOrdinal(name));
    }

    public decimal GetDecimal(int i)
    {
      if (_dataReader.IsDBNull(i))
        return 0;
      else
        return _dataReader.GetDecimal(i);
    }

    /// <summary>
    /// Invokes the GetFieldType method of the underlying datareader.
    /// </summary>
    public Type GetFieldType(string name)
    {
      return GetFieldType(_dataReader.GetOrdinal(name));
    }

    public Type GetFieldType(int i)
    {
      return _dataReader.GetFieldType(i);
    }

    /// <summary>
    /// Gets a Single value from the datareader.
    /// </summary>
    public float GetFloat(string name)
    {
      return GetFloat(_dataReader.GetOrdinal(name));
    }

    public float GetFloat(int i)
    {
      if (_dataReader.IsDBNull(i))
        return 0;
      else
        return _dataReader.GetFloat(i);
    }

    /// <summary>
    /// Gets a Short value from the datareader.
    /// </summary>
    public short GetInt16(string name)
    {
      return GetInt16(_dataReader.GetOrdinal(name));
    }

    public short GetInt16(int i)
    {
      if (_dataReader.IsDBNull(i))
        return 0;
      else
        return _dataReader.GetInt16(i);
    }

    /// <summary>
    /// Gets a Long value from the datareader.
    /// </summary>
    public Int64 GetInt64(string name)
    {
      return GetInt64(_dataReader.GetOrdinal(name));
    }

    public Int64 GetInt64(int i)
    {
      if (_dataReader.IsDBNull(i))
        return 0;
      else
        return _dataReader.GetInt64(i);
    }

    /// <summary>
    /// Invokes the GetName method of the underlying datareader.
    /// </summary>
    public string GetName(int i)
    {
      return _dataReader.GetName(i);
    }

    /// <summary>
    /// Gets an ordinal value from the datareader.
    /// </summary>
    public int GetOrdinal(string name)
    {
      return _dataReader.GetOrdinal(name);
    }

    /// <summary>
    /// Invokes the GetSchemaTable method of the underlying datareader.
    /// </summary>
    public DataTable GetSchemaTable()
    {
      return _dataReader.GetSchemaTable();
    }


    /// <summary>
    /// Invokes the GetValues method of the underlying datareader.
    /// </summary>
    public int GetValues(object[] values)
    {
      return _dataReader.GetValues(values);
    }

    /// <summary>
    /// Returns the IsClosed property value from the datareader.
    /// </summary>
    public bool IsClosed
    {
      get
      {
        return _dataReader.IsClosed;
      }
    }

    /// <summary>
    /// Invokes the IsDBNull method of the underlying datareader.
    /// </summary>
    public bool IsDBNull(int i)
    {
      return _dataReader.IsDBNull(i);
    }

    /// <summary>
    /// Returns a value from the datareader.
    /// </summary>
    /// <remarks>
    /// Returns Nothing if the value is null.
    /// </remarks>
    public object this[string name]
    {
      get
      {
        object val = _dataReader[name];
        if (DBNull.Value.Equals(val))
          return null;
        else
          return val;
      }
    }

    /// <summary>
    /// Returns a value from the datareader.
    /// </summary>
    /// <remarks>
    /// Returns Nothing if the value is null.
    /// </remarks>
    public object this[int i]
    {
      get
      {
        if (_dataReader.IsDBNull(i))
          return null;
        else
          return _dataReader[i];
      }
    }
    /// <summary>
    /// Returns the RecordsAffected property value from the underlying datareader.
    /// </summary>
    public int RecordsAffected
    {
      get
      {
        return _dataReader.RecordsAffected;
      }
    }

    #region IDisposable Support

    private bool _disposedValue; // To detect redundant calls

    // IDisposable
    protected virtual void Dispose(bool disposing)
    {
      if (!_disposedValue)
      {
        if (disposing)
        {
          // free unmanaged resources when explicitly called
          _dataReader.Dispose();
        }

        // free shared unmanaged resources
      }
      _disposedValue = true;
    }

    // This code added by Visual Basic to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    #endregion

  }
}
