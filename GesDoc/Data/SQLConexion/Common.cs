using System;
using System.Collections.Generic;
using System.Data;

namespace DataObjects.Sources.AdoNet.SqlServer
{
    class Common
    {
        public Common()
        {

        }

        public static bool ReaderContainsColumn(IDataReader reader, string name)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i).Equals(name, StringComparison.CurrentCultureIgnoreCase)) return true;

            return false;
        }

        public static int IsNull(IDataReader reader, string name)
        {
            int result;

            if (reader[name] is DBNull)
                result = 0;
            else
                result = int.Parse(reader[name].ToString());

            return result;
        }

        public static double IsNull(IDataReader reader, string name, string format)
        {
            double result;

            if (reader[name] is DBNull)
                result = 0;
            else
                result = double.Parse(reader[name].ToString());

            return result;
        }
    }
}
