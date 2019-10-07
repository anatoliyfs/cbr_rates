using System;
using System.Data;
using System.Data.SqlClient;

namespace dbHanler
{
    public class PD_Data
    {
        private string connectionString = "Data Source=TOLIKFS\\SQLEXPRESS2014;Initial Catalog=OptTest;Integrated Security=True";
        public SqlConnection Conn;
        public PD_Data()
        {
            Conn = new SqlConnection(connectionString);
        }

        /// <summary>
        /// без возвращения данных (сохранение)
        /// </summary>
        /// <param name="CommandText">текст команды</param>
        /// <returns>успешно/нет отработало</returns>
        public bool ExecCommand(string CommandText)
        {
            bool result = false;
            try
            {
                if (string.IsNullOrEmpty(CommandText)) return true;
                Conn.Open();
                using (SqlCommand cmd = new SqlCommand(CommandText, Conn) { CommandType = CommandType.Text })
                {
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (SqlException err)//ошибки бд
            {
                if (err.Number == 1205)//ошибка взаимоблакировки
                {
                    
                }
            }
            catch (Exception err)//другие ошибки
            {
                
            }
            finally
            {
                // в любом случае закрываем соединени
                Conn.Close();
            }
            return result;
        }

        /// <summary>
        ////возвращаем набор данных в DataTable
        /// </summary>
        /// <param name="selectCommand">sql запрос</param>
        /// <returns>DataTable с данными</returns>
        public DataTable GetData(string selectCommand)
        {
            var dt = new DataTable();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter() { SelectCommand = new SqlCommand(selectCommand, Conn) };
                dataAdapter.Fill(dt);
            }
            catch (SqlException err)
            {
                
            }
            catch (Exception err)
            {
                
            }
            return dt;
        }

        /// <summary>
        //// команда sql возвращает единственное значение
        /// </summary>
        /// <param name="CommandText"></param>
        /// <returns></returns>
        public object ExecCommandWithResult(string CommandText)
        {
            object result = null;
            try
            {
                Conn.Open();
                using (SqlCommand cmd = new SqlCommand(CommandText, Conn) { CommandType = CommandType.Text, CommandTimeout = 60 })
                {
                    result = cmd.ExecuteScalar();
                }
            }
            catch (SqlException err)
            {
                
            }
            catch (Exception err)
            {
                
            }
            finally
            {
                Conn.Close();
            }
            return result;
        }
    }
}
