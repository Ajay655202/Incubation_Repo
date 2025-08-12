using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation_DotNet.Singleton
{
    internal class DbProvider
    {

        static Lazy<DbProvider> LazyInstance = new Lazy<DbProvider>(() => new DbProvider());

        private static readonly object LockObject = new object();
        private SqlConnection sqlConnection;

        public SqlConnection SqlConnection
        {
            get
            {
                return sqlConnection;
            }

        }

        static DbProvider Instance;

        public DbProvider()
        {
        }

        public static DbProvider GetInstance()
        {
            return LazyInstance.Value;
        }


    }

    public class ProgramClass
    {
        public static void Main1()
        {
            Parallel.Invoke
                (
                () => GetCon1(),
                () => GetCon2()
                );
        }

        public static  SqlConnection GetCon1()
        {
            return DbProvider.GetInstance().SqlConnection;
        }
        public static SqlConnection GetCon2()
        {
            return DbProvider.GetInstance().SqlConnection;
        }
    }
}
