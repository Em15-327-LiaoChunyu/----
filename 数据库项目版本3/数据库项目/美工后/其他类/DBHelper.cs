using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Test
{    
    //注意：connect()和disconnect()函数需要用户调用,下面函数没有sqlConnection.Open()操作->不一定
    class DBHelper
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlCommand updateCommand = new SqlCommand();
        SqlParameter sqlParameter;
        SqlDataReader sqlDataReader;
        SqlDataAdapter sqlDataAdapter;

        public DBHelper()
        {
            sqlConnection = new SqlConnection(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog = Project;Persist Security Info=True;User ID=sa;Password=123456");
        }

        public SqlConnection getSqlConnection()
        {
            return sqlConnection;
        }

        //连接数据库
        public void connect()
        {
            //移到构造函数中
            //sqlConnection = new SqlConnection(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog = Project;Persist Security Info=True;User ID=sa;Password=123456");
            //5/23：可以加入sqlConnection的状态判断
            sqlConnection.Open();
        }
        
        //关闭数据库
        public void disconnect()
        {
            //???查询时又sqlDataReader对象，但是insert时没有该对象
            if (!sqlDataReader.IsClosed)
                sqlDataReader.Close();
            sqlConnection.Close();
        }

        //插入时关闭数据库
        public void disconnectInsert()
        {
            sqlConnection.Close();
        }

        //----登录模块-----
        /*
         * 查询
         * 参数：从界面上得到的name,password
         * 返回：state的int值，标识是否登录成功
         */
        public int queryUser(string name,string password)
        {
            int state = 0;
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select name,password,role from SystemUser where name = '"+name+"'";
            sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                if (sqlDataReader["password"].ToString().Trim() == password)//登录成功
                {
                    //state = 1;//登录成功
                    if (sqlDataReader["role"].ToString().Trim() == "teacher")
                        state = 4;
                    else if (sqlDataReader["role"].ToString().Trim() == "student")
                        state = 5;
                }
                else
                    state = 2;//密码错误
            }
            else
                state = 3;//用户不存在
            return state;
        }

        /*
         * 插入user到用户表
         * 参数：SqlParameter[]
         * 返回：state的int值，标识是否注册成功
         */
        public int insertUser(string[] information)
        {
            //id如何处理->id自动增加
            string sql = "insert into SystemUser(name,password,role) values(@name,@password,@role)";
            SqlParameter sName = new SqlParameter("@name", information[0]);
            SqlParameter sPassword = new SqlParameter("@password", information[1]);
            SqlParameter sRole = new SqlParameter("@role", information[2]);
            //然后构造SqlCommand对象
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add(sName);
            sqlCommand.Parameters.Add(sPassword);
            sqlCommand.Parameters.Add(sRole);
            int state = sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();//!!!
            return state;

        }

        //修改(待解决）
        public void update(SqlCommand sqlCommand)
        {
        }

        //删除(管理员来操作)
        public void delete(SqlCommand sqlCommand)
        {
        }

        /*
         * 插入路径到试题表中
         * 参数:path(路径)
         * 返回:state的int值，标识是否插入成功
         */
        public int insertShiti(string path)
        {
            //模式设计完要改！！！！
            string sql = "insert into Shiti() values()";
            SqlParameter sPath = new SqlParameter("@path", path);
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add(sPath);
            int state = sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();
            return state;
        }

        public void updateShiti(string path)
        {

        }


        public void deleteShiti(string path)
        {

        }


        //------InsertTiku模块(教师)-----
        //插入选择题
        public int insertXuanze(string[] information)
        {
            string sql = "insert into xuanze (number,typeID,chapter,point,method,degree,topic,A,B,C,D,answer,value,jieda,dianping) values(@number,@typeID,@chapter,@point,@method,@degree,@topic,@A,@B,@C,@D,@answer,@value,@jieda,@dianping)";
            SqlParameter sNumber = new SqlParameter("@number", information[0]);
            SqlParameter sTypeID = new SqlParameter("@typeID", 1);
            SqlParameter sChapter = new SqlParameter("@chapter", information[2]);
            SqlParameter sPoint = new SqlParameter("@point", information[3]);
            SqlParameter sMethod = new SqlParameter("@method", information[4]);
            SqlParameter sDegree = new SqlParameter("@degree", information[5]);
            SqlParameter sTopic = new SqlParameter("@topic", information[6]);
            SqlParameter sA = new SqlParameter("@A", information[7]);
            SqlParameter sB = new SqlParameter("@B", information[8]);
            SqlParameter sC = new SqlParameter("@C", information[9]);
            SqlParameter sD = new SqlParameter("@D", information[10]);
            SqlParameter sAnswer = new SqlParameter("@answer", information[11]);
            SqlParameter sValue = new SqlParameter("@value", information[12]);
            SqlParameter sJieda = new SqlParameter("@jieda", information[13]);
            SqlParameter sDianping = new SqlParameter("@dianping", information[14]);
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add(sNumber);
            sqlCommand.Parameters.Add(sTypeID);
            sqlCommand.Parameters.Add(sChapter);
            sqlCommand.Parameters.Add(sPoint);
            sqlCommand.Parameters.Add(sMethod);
            sqlCommand.Parameters.Add(sDegree);
            sqlCommand.Parameters.Add(sTopic);
            sqlCommand.Parameters.Add(sA);
            sqlCommand.Parameters.Add(sB);
            sqlCommand.Parameters.Add(sC);
            sqlCommand.Parameters.Add(sD);
            sqlCommand.Parameters.Add(sAnswer);
            sqlCommand.Parameters.Add(sValue);
            sqlCommand.Parameters.Add(sJieda);
            sqlCommand.Parameters.Add(sDianping);

            int state = sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();//!!!
            return state;
        }
    
        //插入填空题
        public int insertTiankong(string[] information)
        {
            string sql = "insert into tiankong (number,typeID,chapter,point,method,degree,topic,k1,k2,k3,k4,k5,answer,value,jieda,dianping) values(@number,@typeID,@chapter,@point,@method,@degree,@topic,@k1,@k2,@k3,@k4,@k5,@answer,@value,@jieda,@dianping)";
            SqlParameter sNumber = new SqlParameter("@number", information[0]);
            SqlParameter sTypeID = new SqlParameter("@typeID", 2);//题型：填空题
            SqlParameter sChapter = new SqlParameter("@chapter", information[2]);
            SqlParameter sPoint = new SqlParameter("@point", information[3]);
            SqlParameter sMethod = new SqlParameter("@method", information[4]);
            SqlParameter sDegree = new SqlParameter("@degree", information[5]);
            SqlParameter sTopic = new SqlParameter("@topic", information[6]);
            SqlParameter sk1 = new SqlParameter("@k1", information[7]);
            SqlParameter sk2 = new SqlParameter("@k2", information[8]);
            SqlParameter sk3 = new SqlParameter("@k3", information[9]);
            SqlParameter sk4 = new SqlParameter("@k4", information[10]);
            SqlParameter sk5 = new SqlParameter("@k5", information[11]);
            SqlParameter sAnswer = new SqlParameter("@answer", information[12]);
            SqlParameter sValue = new SqlParameter("@value", information[13]);
            SqlParameter sJieda = new SqlParameter("@jieda", information[14]);
            SqlParameter sDianping = new SqlParameter("@dianping", information[15]);
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add(sNumber);
            sqlCommand.Parameters.Add(sTypeID);
            sqlCommand.Parameters.Add(sChapter);
            sqlCommand.Parameters.Add(sPoint);
            sqlCommand.Parameters.Add(sMethod);
            sqlCommand.Parameters.Add(sDegree);
            sqlCommand.Parameters.Add(sTopic);
            sqlCommand.Parameters.Add(sk1);
            sqlCommand.Parameters.Add(sk2);
            sqlCommand.Parameters.Add(sk3);
            sqlCommand.Parameters.Add(sk4);
            sqlCommand.Parameters.Add(sk5);
            sqlCommand.Parameters.Add(sAnswer);
            sqlCommand.Parameters.Add(sValue);
            sqlCommand.Parameters.Add(sJieda);
            sqlCommand.Parameters.Add(sDianping);
            
            int state = sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();//!!!
            return state;
        }
        
        //插入判断题
        public int insertPanduan(string[] information)
        {
            string sql = "insert into panduan(number,typeID,chapter,point,method,degree,topic,answer) values(@number,@typeID,@chapter,@point,@method,@degree,@topic,@answer)";
            SqlParameter sNumber = new SqlParameter("@number", information[0]);
            SqlParameter sTypeID = new SqlParameter("@typeID", 3);//题型：判断题
            SqlParameter sChapter = new SqlParameter("@chapter", information[2]);
            SqlParameter sPoint = new SqlParameter("@point", information[3]);
            SqlParameter sMethod = new SqlParameter("@method", information[4]);
            SqlParameter sDegree = new SqlParameter("@degree", information[5]);
            SqlParameter sTopic = new SqlParameter("@topic", information[6]);
            SqlParameter sAnswer = new SqlParameter("@answer", information[7]);
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add(sNumber);
            sqlCommand.Parameters.Add(sTypeID);
            sqlCommand.Parameters.Add(sChapter);
            sqlCommand.Parameters.Add(sPoint);
            sqlCommand.Parameters.Add(sMethod);
            sqlCommand.Parameters.Add(sDegree);
            sqlCommand.Parameters.Add(sTopic);
            sqlCommand.Parameters.Add(sAnswer);

            int state = sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();
            return state;
        }

        //插入简答题
        public int insertJianda(string[] information)
        {
            string sql = "insert into jianda(number,typeID,chapter,point,method,degree,topic,answer,value,jieda,dianping) values(@number,@typeID,@chapter,@point,@method,@degree,@topic,@answer,@value,@jieda,@dianping)";
            SqlParameter sNumber = new SqlParameter("@number", information[0]);
            SqlParameter sTypeID = new SqlParameter("@typeID", 4);//题型：判断题
            SqlParameter sChapter = new SqlParameter("@chapter", information[2]);
            SqlParameter sPoint = new SqlParameter("@point", information[3]);
            SqlParameter sMethod = new SqlParameter("@method", information[4]);
            SqlParameter sDegree = new SqlParameter("@degree", information[5]);
            SqlParameter sTopic = new SqlParameter("@topic", information[6]);
            SqlParameter sAnswer = new SqlParameter("@answer", information[7]);
            SqlParameter sValue = new SqlParameter("@value", information[8]);
            SqlParameter sJieda = new SqlParameter("@jieda", information[9]);
            SqlParameter sDianping = new SqlParameter("@dianping", information[10]);
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add(sNumber);
            sqlCommand.Parameters.Add(sTypeID);
            sqlCommand.Parameters.Add(sChapter);
            sqlCommand.Parameters.Add(sPoint);
            sqlCommand.Parameters.Add(sMethod);
            sqlCommand.Parameters.Add(sDegree);
            sqlCommand.Parameters.Add(sTopic);
            sqlCommand.Parameters.Add(sAnswer);
            sqlCommand.Parameters.Add(sValue);
            sqlCommand.Parameters.Add(sJieda);
            sqlCommand.Parameters.Add(sDianping);

            int state = sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();
            return state;
        }

        //遍历题库中某张试题表
        public int traverseTable(string type)
        {
            int row = 0;
            string sql = "";
            if(type.Equals("选择题"))
            {
                sql = "select * from xuanze";
            }
            else if (type.Equals("填空题"))
            {
                sql = "select * from tiankong";
            }
            else if (type.Equals("判断题"))
            {
                sql = "select * from panduan";
            }
            else if (type.Equals("简答题"))
            {
                sql = "select * from jianda";
            }
            sqlCommand = new SqlCommand(sql,sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (row < Convert.ToInt32(sqlDataReader[0].ToString().Trim()))
                    row = Convert.ToInt32(sqlDataReader[0].ToString().Trim());
            }
            sqlDataReader.Close();//!!!!!这边也要改
            //sqlConnection.Close();//用户调用
            return row;
        }
    
        
        
        //-----UDTiku模块(教师)-----6/6
        //UDTiku界面显示
        //刚进入该模块时dataGridView显示选择题目
        public DataSet showXuanzeInUDTku()
        {
            string sql = "select * from xuanze";
            DataSet ds = new DataSet();
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(ds, "xuanze");
            return ds;
        }
        public DataSet showTiankongInUDTku()
        {
            string sql = "select * from tiankong";
            DataSet ds = new DataSet();
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(ds, "tiankong");
            return ds;
        }
        public DataSet showJiandaInUDTku()
        {
            string sql = "select * from jianda";
            DataSet ds = new DataSet();
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(ds, "jianda");
            return ds;
        }
        //按chapter查找
        public DataTable queryByChapterInUDTiku(string type,string key)
        {
            DataTable dt = new DataTable();
            sqlCommand = new SqlCommand();
            if (type == "填空题")
                sqlCommand.CommandText = "select * from tiankong where chapter = '" + key + "'";
            else if (type == "选择题")
                sqlCommand.CommandText = "select * from xuanze where chapter = '" + key + "'";
            else if (type == "简答题")
                sqlCommand.CommandText = "select * from jianda where chapter = '" + key + "'";
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["chapter"].ToString().Trim() == key)
                    dt.NewRow();
                else
                    break;
            }
            sqlDataReader.Close();
            sqlDataAdapter.Fill(dt);
            return dt;
        }
        //按point查找
        public DataTable queryByPointInUDTiku(string type, string key)
        {
            DataTable dt = new DataTable();
            sqlCommand = new SqlCommand();
            if (type == "填空题")
                sqlCommand.CommandText = "select * from tiankong where point = '" + key + "'";
            else if (type == "选择题")
                sqlCommand.CommandText = "select * from xuanze where point = '" + key + "'";
            else if(type == "简答题")
                sqlCommand.CommandText = "select * from jianda where point = '" + key + "'";
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["point"].ToString().Trim() == key)
                    dt.NewRow();
                else
                    break;
            }
            sqlDataReader.Close();
            sqlDataAdapter.Fill(dt);
            return dt;
        }
        //按method查找
        public DataTable queryByMethodInUDTiku(string type, string key)
        {
            DataTable dt = new DataTable();
            sqlCommand = new SqlCommand();
            if (type == "填空题")
                sqlCommand.CommandText = "select * from tiankong where method = '" + key + "'";
            else if (type == "选择题")
                sqlCommand.CommandText = "select * from xuanze where method = '" + key + "'";
            else if (type == "简答题")
                sqlCommand.CommandText = "select * from jianda where method = '" + key + "'";
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["method"].ToString().Trim() == key)
                    dt.NewRow();
                else
                    break;
            }
            sqlDataReader.Close();
            sqlDataAdapter.Fill(dt);
            return dt;
        }
        //按degree查找
        public DataTable queryByDegreeInUDTiku(string type, string key)
        {
            DataTable dt = new DataTable();
            sqlCommand = new SqlCommand();
            if (type == "填空题")
                sqlCommand.CommandText = "select * from tiankong where degree = '" + key + "'";
            else if (type == "选择题")
                sqlCommand.CommandText = "select * from xuanze where degree = '" + key + "'";
            else if (type == "简答题")
                sqlCommand.CommandText = "select * from jianda where degree = '" + key + "'";
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["degree"].ToString().Trim() == key)
                    dt.NewRow();
                else
                    break;
            }
            sqlDataReader.Close();
            sqlDataAdapter.Fill(dt);
            return dt;
        }
        //update操作
        public DataSet updateTimuInUDTiku(string type, string sql)
        {
            DataSet ds = new DataSet();
            if (type == "选择题")
            {
                updateCommand.CommandText = sql;
                updateCommand.Connection = sqlConnection;
                updateCommand.ExecuteNonQuery();
                string sql2 = "select * from xuanze";
                sqlDataAdapter = new SqlDataAdapter(sql2, sqlConnection);
                sqlDataAdapter.Fill(ds, "xuanze");
                return ds;
            }
            else if (type == "填空题")
            {
                updateCommand.CommandText = sql;
                updateCommand.Connection = sqlConnection;
                updateCommand.ExecuteNonQuery();
                string sql2 = "select * from tiankong";
                sqlDataAdapter = new SqlDataAdapter(sql2, sqlConnection);
                sqlDataAdapter.Fill(ds, "tiankong");
                return ds;
            }
            else if (type == "简答题")
            {
                updateCommand.CommandText = sql;
                updateCommand.Connection = sqlConnection;
                updateCommand.ExecuteNonQuery();
                string sql2 = "select * from jianda";
                sqlDataAdapter = new SqlDataAdapter(sql2, sqlConnection);
                sqlDataAdapter.Fill(ds, "jianda");
                return ds;

            }
            return ds;
        }
        //UDTiku中修改题目插入到Log表中
        public int insertLog(string[] information)
        {
            string sql = "insert into Log(name,time,tableName,record,ziduan,oldContent,newContent) values(@name,@time,@tableName,@record,@ziduan,@oldContent,@newContent)";
            SqlParameter sName = new SqlParameter("@name", information[0]);
            SqlParameter sTime = new SqlParameter("@time",Convert.ToDateTime(information[1]));
            SqlParameter sTableName = new SqlParameter("@tableName", information[2]);
            SqlParameter sRecord = new SqlParameter("@record", Convert.ToInt32(information[3]));
            SqlParameter sZiduan = new SqlParameter("@ziduan", information[4]);
            SqlParameter sOldContent = new SqlParameter("@oldContent", information[5]);
            SqlParameter sNewContent = new SqlParameter("@newContent", information[6]);
            //MessageBox.Show(information[6]);information[6]值没有传入
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add(sName);
            sqlCommand.Parameters.Add(sTime);
            sqlCommand.Parameters.Add(sTableName);
            sqlCommand.Parameters.Add(sRecord);
            sqlCommand.Parameters.Add(sZiduan);
            sqlCommand.Parameters.Add(sOldContent);
            sqlCommand.Parameters.Add(sNewContent);
            int rows = sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();
            return rows;
        }
        //delete操作
        public int deleteShitiInUDTiku(string sql)
        {
            sqlCommand = new SqlCommand(sql, sqlConnection);
            int rows = sqlCommand.ExecuteNonQuery();
            return rows;
        }

        //多个条件搜索查询
        public DataTable queryInUDTiku(string sql)
        {
            DataTable dt = new DataTable();
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
                dt.NewRow();
            sqlDataReader.Close();
            sqlDataAdapter.Fill(dt);
            return dt;
        }


        //-----MakePaperTest模块-----6/6
        //显示所有题目
        public DataSet showTiankongInMakePaperTest()
        {
            string sql = "select * from tiankong";
            DataSet ds = new DataSet();
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(ds, "tiankong");
            return ds;
        }
        public DataSet showXuanzeInMakePaperTest()
        {
            string sql = "select * from xuanze";
            DataSet ds = new DataSet();
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(ds, "xuanze");
            return ds;
        }
        public DataSet showJiandaInMakePaperTest()
        {
            string sql = "select * from jianda";
            DataSet ds = new DataSet();
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(ds, "jianda");
            return ds;
        }
        //查询
        public DataTable queryInMakePaperTest(string sql)
        {
            DataTable dt = new DataTable();
            sqlCommand = new SqlCommand(sql,sqlConnection);
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
                dt.NewRow();
            sqlDataReader.Close();
            sqlDataAdapter.Fill(dt);
            return dt;
        }


        //-----GetSimilarTimu模块-----6/7
        //根据题号查询得到属性
        public string[] queryByNumberInGetSimilarTimu(string sql)
        {
            string[] attributes = new string[4];
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            //!!!
            attributes[0] = sqlDataReader["chapter"].ToString();
            attributes[1] = sqlDataReader["point"].ToString();
            attributes[2] = sqlDataReader["method"].ToString();
            attributes[3] = sqlDataReader["degree"].ToString();
            return attributes;
        }

        //查询相似题目
        public StringBuilder queryByDifferentSqlsInGetSimilarTimu(string sql)
        {
            StringBuilder results = new StringBuilder();
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            int i = 0;
            while (sqlDataReader.Read())
            {
                results.Append(sqlDataReader["topic"].ToString());
                i++;
                if (i == 10)
                    break;
            }
            return results;
        }

        //对tkRatio表的操作
        //检索是否存在
        public int queryIntkRatioInGetSimilarTimu(string sql)
        {
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            int count = dt.Rows.Count;
            return count;
        }
        //存在的话将记录中的
        public string[] queryIntkRatioInGetSimilarTimu2(string sql)
        {
            string[] results = new string[3];
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            results[0] = Convert.ToString(sqlDataReader.GetInt32(3));
            results[1] = Convert.ToString(sqlDataReader.GetInt32(4));
            results[2] = Convert.ToString(sqlDataReader.GetDecimal(5));
            return results;
        }
        //修改tkRatio表
        public void updatetkRatioInGetSimilarTimu(string sql)
        {
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }
        //新增记录到tkRatio表中
        public void insertIntotkRatioInGetSimilarTimu(string sql)
        {
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //对xzRatio表的操作
        public int queryInxzRatioInGetSimilarTimu(string sql)
        {
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            int count = dt.Rows.Count;
            return count;
        }
        public string[] queryInxzRatioInGetSimilarTimu2(string sql)
        {
            string[] results = new string[3];
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            results[0] = Convert.ToString(sqlDataReader.GetInt32(3));
            results[1] = Convert.ToString(sqlDataReader.GetInt32(4));
            results[2] = Convert.ToString(sqlDataReader.GetDecimal(5));
            return results;
        }
        public void updatexzRatioInGetSimilarTimu(string sql)
        {
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }
        public void insertIntoxzRatioInGetSimilarTimu(string sql)
        {
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //
        public decimal getRatioInGetSimilarTomu2(string sql)
        {
            decimal ratio = 0.000M;
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            bool flag = sqlDataReader.Read();
            if (flag == true)
            {
                MessageBox.Show(Convert.ToString(sqlDataReader.GetValue(5)));
                ratio = Convert.ToDecimal(sqlDataReader.GetValue(5));
            }
            else
                ratio = 1.111M;//一个超过1的数字标识错误
            return ratio;
        }

        //----MakePaper模块(教师)-----
        //条件检索
        //单个条件 参数1：题型 参数2：条件
        public DataTable queryByChapter(string type,string key)
        {

            DataTable dt = new DataTable();

            sqlCommand = new SqlCommand();
            if(type == "填空题")
                sqlCommand.CommandText = "select * from tiankong where chapter = '" + key + "'";
            else if(type == "选择题")
                sqlCommand.CommandText = "select * from xuanze where chapter = '" + key + "'";
            else if(type == "简答题")
                sqlCommand.CommandText = "select * from jianda where chapter = '" + key + "'";
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["chapter"].ToString().Trim() == key)
                    dt.NewRow();
                else
                    break;
            }
            sqlDataReader.Close();
            sqlDataAdapter.Fill(dt);

            return dt;
        }
        public DataTable queryByPoint(string type,string key)
        {
            DataTable dt = new DataTable();

            sqlCommand = new SqlCommand();
            if(type.Equals("填空题"))
                sqlCommand.CommandText = "select * from tiankong where point = '" + key + "'";
            else if(type.Equals("选择题"))
                sqlCommand.CommandText = "select * from xuanze where point = '" + key + "'";
            else if(type.Equals("简答题"))
                sqlCommand.CommandText = "select * from jianda where point = '" + key + "'";

            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["point"].ToString().Trim() == key)
                    dt.NewRow();
                else
                    break;
            }
            sqlDataReader.Close();
            sqlDataAdapter.Fill(dt);

            return dt;
        }
        public DataTable queryByMethod(string type,string key)
        {
            DataTable dt = new DataTable();

            sqlCommand = new SqlCommand();
            if(type == "填空题")
                sqlCommand.CommandText = "select * from tiankong where method = '" + key + "'";
            else if(type == "选择题")
                sqlCommand.CommandText = "select * from xuanze where method = '" + key + "'";
            else if(type == "简答题")
                sqlCommand.CommandText = "select * from jianda where method = '" + key + "'";
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["method"].ToString().Trim() == key)
                    dt.NewRow();
                else
                    break;
            }
            sqlDataReader.Close();
            sqlDataAdapter.Fill(dt);

            return dt;
        }
        public DataTable queryByDegree(string type,string key)
        {
            DataTable dt = new DataTable();

            sqlCommand = new SqlCommand();
            if(type == "填空题")
                sqlCommand.CommandText = "select * from tiankong where degree = '" + key + "'";
            else if(type == "选择题")
                sqlCommand.CommandText = "select * from xuanze where degree = '" + key + "'";
            else if(type == "简答题")
                sqlCommand.CommandText = "select * from jianda where degree = '" + key + "'";
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["degree"].ToString().Trim() == key)
                    dt.NewRow();
                else
                    break;
            }
            sqlDataReader.Close();
            sqlDataAdapter.Fill(dt);
            
            return dt;
        }
        //这里要改sql语句!!!!!
        public DataTable queryByTopic(string type,string key)
        {
            DataTable dt = new DataTable();

            sqlCommand = new SqlCommand();
            if(type == "填空题")
                sqlCommand.CommandText = "select * from tiankong where topic = '" + key + "'";
            else if(type == "选择题")
                sqlCommand.CommandText = "select * from xuanze where topic = '" + key + "'";
            else if(type == "简答题")
                sqlCommand.CommandText = "select * from jianda where topic = '" + key + "'";
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["topic"].ToString().Trim() == key)
                    dt.NewRow();
                else
                    break;
            }
            sqlDataReader.Close();
            sqlDataAdapter.Fill(dt);
            
            return dt;
        }

        //---ChangePassword模块(学生)-----
        /* 5/19
         * 修改密码模块
         * 返回值：int型flag标识结果
         */
        public int changePassword(string name,string password,string newPassword,string repeatPassword)
        {
            //1.判断是否存在该用户 2.输入的密码是否正确 3.两次密码是否输入一致
            int flag = 0;//错误情况的标识
            sqlCommand = new SqlCommand("select * from SystemUser", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read() == true)
            {
                if (sqlDataReader["name"].ToString().Trim() == name)
                {
                    flag = 1;//用户名存在
                    if (sqlDataReader["password"].ToString().Trim() == password)
                    {
                        flag = 2;//密码正确
                        if (repeatPassword == newPassword)
                        {
                            disconnectInsert();
                            sqlCommand.CommandText = "update SystemUser set password = '"+password+"'"+" where name = '"+name+"'";
                            connect();
                            sqlCommand.ExecuteNonQuery();
                            flag = 3;
                            break;
                        }
                    }

                }
            }
            return flag;
        }


        //-----MakePaperTest(insert) AnalyzePaper(query)-----
        //功能：MakePaperTest模块中将试卷每道题的题号插入paper表中 
        //参数：type-题目类型 shijuantihao-试卷中某种题型的题号 number-试卷中某道题在该类题表中的标号
        public int insertNumbersToPaperTable(int[] all)
        {
            string sql = "insert into paper(t1,t2,t3,t4,t5,t6,t7,t8,t9,t10,t11,t12,t13,t14,x1,x2,x3,x4,j1,j2,j3,j4,j5) values(@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,@t10,@t11,@t12,@t13,@t14,@x1,@x2,@x3,@x4,@j1,@j2,@j3,@j4,@j5)";
            SqlParameter sT1 = new SqlParameter("@t1", all[0]);
            SqlParameter sT2 = new SqlParameter("@t2", all[1]);
            SqlParameter sT3 = new SqlParameter("@t3", all[2]);
            SqlParameter sT4 = new SqlParameter("@t4", all[3]);
            SqlParameter sT5 = new SqlParameter("@t5", all[4]);
            SqlParameter sT6 = new SqlParameter("@t6", all[5]);
            SqlParameter sT7 = new SqlParameter("@t7", all[6]);
            SqlParameter sT8 = new SqlParameter("@t8", all[7]);
            SqlParameter sT9 = new SqlParameter("@t9", all[8]);
            SqlParameter sT10 = new SqlParameter("@t10", all[9]);
            SqlParameter sT11 = new SqlParameter("@t11", all[10]);
            SqlParameter sT12 = new SqlParameter("@t12", all[11]);
            SqlParameter sT13 = new SqlParameter("@t13", all[12]);
            SqlParameter sT14 = new SqlParameter("@t14", all[13]);

            SqlParameter sX1 = new SqlParameter("@x1", all[14]);
            SqlParameter sX2 = new SqlParameter("@x2", all[15]);
            SqlParameter sX3 = new SqlParameter("@x3", all[16]);
            SqlParameter sX4 = new SqlParameter("@x4", all[17]);

            SqlParameter sJ1 = new SqlParameter("@j1", all[18]);
            SqlParameter sJ2 = new SqlParameter("@j2", all[19]);
            SqlParameter sJ3 = new SqlParameter("@j3", all[20]);
            SqlParameter sJ4 = new SqlParameter("@j4", all[21]);
            SqlParameter sJ5 = new SqlParameter("@j5", all[22]);

            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add(sT1);
            sqlCommand.Parameters.Add(sT2);
            sqlCommand.Parameters.Add(sT3);
            sqlCommand.Parameters.Add(sT4);
            sqlCommand.Parameters.Add(sT5);
            sqlCommand.Parameters.Add(sT6);
            sqlCommand.Parameters.Add(sT7);
            sqlCommand.Parameters.Add(sT8);
            sqlCommand.Parameters.Add(sT9);
            sqlCommand.Parameters.Add(sT10);
            sqlCommand.Parameters.Add(sT11);
            sqlCommand.Parameters.Add(sT12);
            sqlCommand.Parameters.Add(sT13);
            sqlCommand.Parameters.Add(sT14);

            sqlCommand.Parameters.Add(sX1);
            sqlCommand.Parameters.Add(sX2);
            sqlCommand.Parameters.Add(sX3);
            sqlCommand.Parameters.Add(sX4);

            sqlCommand.Parameters.Add(sJ1);
            sqlCommand.Parameters.Add(sJ2);
            sqlCommand.Parameters.Add(sJ3);
            sqlCommand.Parameters.Add(sJ4);
            sqlCommand.Parameters.Add(sJ5);

            int state = sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();
            return state;
        }

        //参数：e.g:填空题第几道
        public int queryPaperTableByNumbers(string type, int shijuantihao)
        {
            string sql = "";
            if (type == "填空题" && shijuantihao == 1)
                sql = "select t1 from paper ";
            else if (type == "填空题" && shijuantihao == 2)
                sql = "select t2 from paper";
            else if (type == "填空题" && shijuantihao == 3)
                sql = "select t3 from paper";
            else if (type == "填空题" && shijuantihao == 4)
                sql = "select t4 from paper";
            else if (type == "填空题" && shijuantihao == 5)
                sql = "select t5 from paper";
            else if (type == "填空题" && shijuantihao == 6)
                sql = "select t6 from paper";
            else if (type == "填空题" && shijuantihao == 7)
                sql = "select t7 from paper";
            else if (type == "填空题" && shijuantihao == 8)
                sql = "select t8 from paper";
            else if (type == "填空题" && shijuantihao == 9)
                sql = "select t9 from paper";
            else if (type == "填空题" && shijuantihao == 10)
                sql = "select t10 from paper";
            else if (type == "填空题" && shijuantihao == 11)
                sql = "select t11 from paper";
            else if (type == "填空题" && shijuantihao == 12)
                sql = "select t12 from paper";
            else if (type == "填空题" && shijuantihao == 13)
                sql = "select t13 from paper";
            else if (type == "填空题" && shijuantihao == 14)
                sql = "select t14 from paper";

            else if (type == "选择题" && shijuantihao == 1)
                sql = "select x1 from paper";
            else if (type == "选择题" && shijuantihao == 2)
                sql = "select x2 from paper";
            else if (type == "选择题" && shijuantihao == 3)
                sql = "select x3 from paper";
            else if (type == "选择题" && shijuantihao == 4)
                sql = "select x4 from paper";

            else if (type == "简答题" && shijuantihao == 1)
                sql = "select j1 from paper";
            else if (type == "简答题" && shijuantihao == 2)
                sql = "select j2 from paper";
            else if (type == "简答题" && shijuantihao == 3)
                sql = "select j3 from paper";
            else if (type == "简答题" && shijuantihao == 4)
                sql = "select j4 from paper";
            else if (type == "简答题" && shijuantihao == 5)
                sql = "select j5 from paper";

            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            int result = sqlDataReader.GetInt32(0);
            return result;
        }
        //！！！选择题，简答题完善
        //再根据查询得到的题号再到具体题型的表中查询
        public string[] queryFankui(string type,int number)
        {
            string sql = "";
            string[] all = new string[7];
            if (type.Equals("填空题"))
            {
                sql = "select * from tiankong where number = " + number;
                sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                string chapter = sqlDataReader.GetString(2);
                string point = sqlDataReader.GetString(3);
                string method = sqlDataReader.GetString(4);
                string degree = sqlDataReader.GetString(5);
                string answer = sqlDataReader.GetString(12);
                string jieda = sqlDataReader.GetString(14);
                string dianping = sqlDataReader.GetString(15);
                all[0] = chapter;
                all[1] = point;
                all[2] = method;
                all[3] = degree;
                all[4] = answer;
                all[5] = jieda;
                all[6] = dianping;  
                return all;
            }
            else if (type.Equals("选择题"))
            {
                sql = "select * from xuanze where number = " + number;
                sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                string chapter = sqlDataReader.GetString(2);
                string point = sqlDataReader.GetString(3);
                string method = sqlDataReader.GetString(4);
                string degree = sqlDataReader.GetString(5);
                string answer = sqlDataReader.GetString(11);
                string jieda = sqlDataReader.GetString(13);
                string dianping = sqlDataReader.GetString(14);
                all[0] = chapter;
                all[1] = point;
                all[2] = method;
                all[3] = degree;
                all[4] = answer;
                all[5] = jieda;
                all[6] = dianping;
                return all;
            }
            else if (type.Equals("简答题"))
            {
                sql = "select * from jianda where number = " + number;
                sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                string chapter = sqlDataReader.GetString(2);
                string point = sqlDataReader.GetString(3);
                string method = sqlDataReader.GetString(4);
                string degree = sqlDataReader.GetString(5);
                string answer = sqlDataReader.GetString(7);
                string jieda = sqlDataReader.GetString(9);
                string dianping = sqlDataReader.GetString(10);
                all[0] = chapter;
                all[1] = point;
                all[2] = method;
                all[3] = degree;
                all[4] = answer;
                all[5] = jieda;
                all[6] = dianping;
                return all;
            }
            return all;
        }

        public string[] querySimilarTimus(string type, string point, string method, string degree,int score)
        {
            string[] results = new string[] { };//查询结果
            //根据历史记录
            if (type.Equals("填空题"))
            {
                
            }
            //根据历史记录
            else if (type.Equals("选择题"))
            {

            }
            else if (type.Equals("简答题"))
            {
                //简答题法则
                //1,2,3,4,5每到简答题的分值不同
                //分数/该题总分 s/t 
                int t = 10;//总分
                double ratio = Convert.ToDouble(score / t);
                if (ratio >= 0 && ratio < 0.3)
                {
                    //degree为简单
                    //point属性一定存在，但是method属性不一定存在，分情况讨论
                    string sql = "select topic from jianda where point = '" + point + "' and degree = '简单'";
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    int i = 0;//查询结果条数
                    while (sqlDataReader.Read())
                    {
                        results[i] = sqlDataReader.GetString(0);
                        i++;
                    }
                }
                else if (ratio >= 0.3 && ratio < 0.7)
                {
                    //degree为中等
                }
                else if (ratio >= 0.7 && ratio <= 1)
                {
                    //degree为难
                }
            }
            return results;
        }
    
    
        //-----Administer管理员类操作----- 6/11
        //可以删的！！！
        public DataTable getChangeInformation()
        {
            DataTable dt = new DataTable();
            string sql = "select * from Log";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(dt);
            return dt;
        }

        public DataTable getLogInformationInAMain()
        {
            DataTable dt = new DataTable();
            string sql = "select * from Log";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(dt);
            return dt;
        }

        public DataTable getUserInformationInAMain()
        {
            DataTable dt = new DataTable();
            string sql = "select * from SystemUser";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(dt);
            return dt;
        }

        public void deleteUserInAMain(string sql)
        {
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }



        //6/15
        public int queryIsPaperCreated(string sql)
        {
            int id = 0;
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while(sqlDataReader.Read())
            {
                id = Convert.ToInt32(sqlDataReader["id"]);
            }
            return id;
        }
    }
}
