using System;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Api_ASP.NET_Core
{
    public class Productos{
        public int id { get; set; }
        public string nombre { get; set; }
        public string codigo_barra { get; set; }
        public double precio { get; set; }
        public int disponible { get; set; }
        public string detalle { get; set; }
        public string imagen { get; set; }

        internal AppDb Db { get; set; }

        public Productos(){

        }

        internal Productos(AppDb db){
            Db = db;
        }

        public async Task InsertAsync(){
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL spInsertarProduto(@nombre, @codigo_barra, @precio, @disponible, @detalle, @imagen);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            id = (int) cmd.LastInsertedId;
            // Console.WriteLine(cmd.LastInsertedId);
        }

        public async Task UpdateAsync(){
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL spActualizarProduto(@id, @nombre, @codigo_barra, @precio, @disponible, @detalle, @imagen);";
            BindId(cmd);
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(){
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"CALL spEliminarProduto(@id);";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd){
            cmd.Parameters.Add(new MySqlParameter{
                ParameterName = "@id", DbType = DbType.Int32, Value = id
            });
        }

        private void BindParams(MySqlCommand cmd){
            cmd.Parameters.Add(new MySqlParameter{
                ParameterName = "@nombre", DbType = DbType.String, Value = nombre 
            });
            cmd.Parameters.Add(new MySqlParameter{
                ParameterName = "@codigo_barra", DbType = DbType.String, Value = codigo_barra 
            });
            cmd.Parameters.Add(new MySqlParameter{
                ParameterName = "@precio", DbType = DbType.Double, Value = precio 
            });
            cmd.Parameters.Add(new MySqlParameter{
                ParameterName = "@disponible", DbType = DbType.Int32, Value = disponible 
            });
            cmd.Parameters.Add(new MySqlParameter{
                ParameterName = "@detalle", DbType = DbType.String, Value = detalle 
            });
            cmd.Parameters.Add(new MySqlParameter{
                ParameterName = "@imagen", DbType = DbType.String, Value = imagen 
            });
        }
    }
}