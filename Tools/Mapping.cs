using AutoMapper;
using Newtonsoft.Json;
using System;

namespace Tools
{
    /// <summary>
    /// Clase para mapeo de datos
    /// </summary>
    public class Mapping
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static E ConverModelTo<T, E>(T source)
        {
            try
            {
                var modelTarget = Mapper.Map<T, E>(source);
                return modelTarget;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deserializa un objeto json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DeserializeJson<T>(string json)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}