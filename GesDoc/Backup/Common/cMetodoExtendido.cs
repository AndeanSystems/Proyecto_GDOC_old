using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class cMetodoExtendido
    {
        public static String ToText(this object s)
        {
            String sReturn = String.Empty;

            try
            { sReturn = Convert.ToString(s); }
            catch (Exception ex)
            { sReturn = String.Empty; }

            return sReturn;
        }

        public static int ToInt(this object s)
        {
            int sReturn = 0;

            try
            { sReturn = Convert.ToInt32(s); }
            catch (Exception ex)
            { sReturn = -1; }

            return sReturn;
        }

        public static Int16 ToInt16(this object s)
        {
            Int16 sReturn = 0;

            try
            { sReturn = Convert.ToInt16(s); }
            catch (Exception ex)
            { sReturn = -1; }

            return sReturn;
        }

        public static Int32 ToInt32(this object s)
        {
            Int32 sReturn = 0;

            try
            { sReturn = Convert.ToInt32(s); }
            catch (Exception ex)
            { sReturn = -1; }

            return sReturn;
        }

        public static Int64 ToInt64(this object s)
        {
            Int64 sReturn = 0;

            try
            { sReturn = Convert.ToInt64(s); }
            catch (Exception ex)
            { sReturn = -1; }

            return sReturn;
        }

        public static Decimal ToDecimal(this object s)
        {
            decimal sReturn = 0;

            try
            { sReturn = Convert.ToDecimal(s); }
            catch (Exception ex)
            { sReturn = -1; }

            return sReturn;
        }

        public static Boolean ToBoolean(this object s)
        {
            Boolean sReturn = false;

            try
            { sReturn = Convert.ToBoolean(s); }
            catch (Exception ex)
            { sReturn = false; }

            return sReturn;
        }
        
        public static bool ToBool(this object s)
        {
            bool sReturn = false;

            try
            { sReturn = Convert.ToBoolean(s); }
            catch (Exception ex)
            { sReturn = false; }

            return sReturn;
        }

        public static byte ToBit(this object s)
        {
            byte sReturn = 0;

            try
            { sReturn = Convert.ToByte(s); }
            catch (Exception ex)
            { sReturn = 0; }

            return sReturn;
        }

        public static DateTime ToDateTime(this object s)
        {
            DateTime sReturn = DateTime.Now;

            try
            { sReturn = Convert.ToDateTime(s); }
            catch (Exception ex)
            { sReturn = DateTime.Now; }

            return sReturn;
        }


    }
}
