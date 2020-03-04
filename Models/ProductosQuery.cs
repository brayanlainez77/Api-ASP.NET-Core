using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Api_ASP.NET_Core
{
    public class ProductosQuery
    {
        public AppDb Db { get; }

        public ProductosQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Productos> FindOneAsync(int id){
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL spConsularProdutos(@id);";
            cmd.Parameters.Add(new MySqlParameter{
                ParameterName = "@id", DbType = DbType.Int32, Value = id
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Productos>> AllProductosAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL spConsularProdutos(0);";
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result : null;
        }

        public async Task DeleteAllAsync()
        {
            // using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL spEliminarProduto(0);";
            await cmd.ExecuteNonQueryAsync();
            // await txn.CommitAsync();
        }

        private async Task<List<Productos>> ReadAllAsync(DbDataReader reader)
        {
            var productos = new List<Productos>();
            using(reader){
                while(await reader.ReadAsync()){
                    var producto = new Productos(Db)
                    {
                        id = reader.GetInt32(0),
                        nombre = reader.GetString(1),
                        codigo_barra = reader.GetString(2),
                        precio = reader.GetDouble(3),
                        disponible = reader.GetInt16(4),
                        detalle = reader.GetString(5),
                        imagen = reader.GetString(6)
                    };
                    productos.Add(producto);
                }
            }
            return productos;
        }
    }
}