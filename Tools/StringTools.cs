using System;
using System.Configuration;

namespace Tools.String
{
    /// <summary>
    /// Utilidades para manejar strings
    /// </summary>
    public static class StringTools
    {
        /// <summary>
        /// Lee una llave del web config
        /// </summary>
        /// <param name="keyName">llave web config</param>
        /// <param name="valueDefault">valor por default</param>
        /// <returns>string key web config</returns>
        public static string ReadAppConfig(this string keyName, string valueDefault = "")
        {
            try
            {
                return ConfigurationManager.AppSettings[keyName] ?? valueDefault;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee una cadena de conexion en el web config por llave
        /// </summary>
        /// <param name="keyName">nombre de la llave</param>
        /// <returns>string connection web config</returns>
        public static string ReadConnectionString(this string keyName)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[keyName].ConnectionString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee una cadena de conexion y retorna el ProviderName
        /// </summary>
        /// <param name="keyName">nombre de la llave</param>
        /// <returns>string ProviderName connection string web config</returns>
        public static string ReadConnectionProviderName(this string keyName)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[keyName].ProviderName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}