using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace PulsarFit.DAL.Helpers
{
    public static class Extensions
    {
        public static T QueryFunctionFirstOrDefault<T>(this DbConnection connection, string functionName, object parameters = null)
        {
            return connection.QueryFirstOrDefault<T>(functionName, parameters?.ToDynamic(), commandType: CommandType.StoredProcedure);
        }

        public static IEnumerable<T> QueryFunction<T>(this DbConnection connection, string functionName, object parameters = null)
        {
            return connection.Query<T>(functionName, parameters?.ToDynamic(), commandType: CommandType.StoredProcedure);
        }

        public static async Task<IEnumerable<T>> QueryFunctionAsync<T>(this DbConnection connection, string functionName, object parameters = null)
        {
           return await connection.QueryAsync<T>(functionName, parameters?.ToDynamic(), commandType: CommandType.StoredProcedure);
        }

        public static void ExecuteFunction(this DbConnection connection, string functionName, object parameters = null)
        {
            connection.Execute(functionName, parameters?.ToDynamic(), commandType: CommandType.StoredProcedure);
        }

        public static async Task ExecuteFunctionAsync(this DbConnection connection, string functionName, object parameters = null)
        {
            await connection.ExecuteAsync(functionName, parameters?.ToDynamic(), commandType: CommandType.StoredProcedure);
        }

        public static DynamicParameters ToDynamic(this object parameters)
        {
            var dynamicParameters = new DynamicParameters();

            if (parameters != null)
            {
                foreach (var parameter in parameters.GetType().GetProperties())
                    dynamicParameters.Add(parameter.Name, parameter.GetValue(parameters));
            }

            return dynamicParameters;
        }
    }
}
