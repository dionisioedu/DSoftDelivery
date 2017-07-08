//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data.SQLite;

//namespace DSoftConfig
//{
//    public class DSConfig
//    {
//        private static DSConfig _instance;
//        private SQLiteConnection _connection;

//        private const string APP_TITLE = "app_title";
//        private const string LOGIN_IMAGE = "login_image";
//        private const string BACKGROUND_IMAGE = "background_image";
//        private const string LICENCE_WARNING = "licence_warning";
//        private const string TICKET_MSG = "ticket_msg";
//        private const string ORDERS_REFRESH = "orders_refresh";
//        private const string ORDERS_COLUMN_ORDER = "orders_column_order_";
//        private const string ORDERS_COLUMN_WIDTH = "orders_column_width_";
//        private const string MAIN_LOCATION_X = "main_location_x";
//        private const string MAIN_LOCATION_Y = "main_location_y";
//        private const string MAIN_WIDTH = "main_width";
//        private const string MAIN_HEIGHT = "main_height";
//        private const string WINDOW_X = "_window_x";
//        private const string WINDOW_Y = "_window_y";
//        private const string WINDOW_WIDTH = "_window_width";
//        private const string WINDOW_HEIGHT = "_window_height";

//        public static DSConfig Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    _instance = new DSConfig();

//                    StartDatabase();
//                }

//                return _instance;
//            }
//        }

//        private SQLiteConnection Connection
//        {
//            get
//            {
//                if (_connection == null)
//                {
//                    _connection = new SQLiteConnection("Data Source=DSoftConfig.sqlite;Version=3;");
//                }

//                if (_connection.State != System.Data.ConnectionState.Open)
//                {
//                    _connection.Open();
//                }

//                return _connection;
//            }
//        }

//        private static void StartDatabase()
//        {
//            string command = "CREATE TABLE IF NOT EXISTS config (key varchar not null primary key, value varchar);";

//            using (SQLiteConnection conn = new SQLiteConnection("Data Source=DSoftConfig.sqlite;Version=3;"))
//            {
//                conn.Open();

//                using (SQLiteCommand com = new SQLiteCommand(command, conn))
//                {
//                    com.ExecuteNonQuery();
//                }
//            }
//        }

//        private bool InsertOrUpdate(string key, string value)
//        {
//            using (SQLiteCommand com = new SQLiteCommand(string.Format("SELECT key FROM config WHERE key = '{0}'", key)))
//            {
//                if (getString(com).Length > 0)
//                {
//                    com.CommandText = string.Format("UPDATE config set value = '{0}' where key = '{1}'", value, key);
//                    return ExecCommand(com);
//                }
//                else
//                {
//                    com.CommandText = string.Format("INSERT INTO config (key, value) values ('{0}', '{1}')", key, value);
//                    return ExecCommand(com);
//                }
//            }
//        }

//        private string GetValue(string key)
//        {
//            return getString(string.Format("SELECT value FROM config WHERE key = '{0}'", key));
//        }

//        private bool ExecCommand(string com)
//        {
//            return ExecCommand(new SQLiteCommand(com));
//        }

//        private bool ExecCommand(SQLiteCommand com)
//        {
//            com.Connection = Connection;
//            return com.ExecuteNonQuery() > 0;
//        }

//        private string getString(string com)
//        {
//            return getString(new SQLiteCommand(com));
//        }

//        private string getString(SQLiteCommand com)
//        {
//            com.Connection = Connection;

//            using (SQLiteDataReader dr = com.ExecuteReader())
//            {
//                if (dr.Read())
//                {
//                    return dr[0].ToString();
//                }
//                else
//                {
//                    return string.Empty;
//                }
//            }
//        }

//        public string Title
//        {
//            get
//            {
//                return GetValue(APP_TITLE);
//            }
//            set
//            {
//                InsertOrUpdate(APP_TITLE, value);
//            }
//        }

//        public string LoginImage
//        {
//            get
//            {
//                return GetValue(LOGIN_IMAGE);
//            }
//            set
//            {
//                InsertOrUpdate(LOGIN_IMAGE, value);
//            }
//        }

//        public string BackgroundImage
//        {
//            get
//            {
//                return GetValue(BACKGROUND_IMAGE);
//            }
//            set
//            {
//                InsertOrUpdate(BACKGROUND_IMAGE, value);
//            }
//        }

//        public string LicenceWarning
//        {
//            get
//            {
//                return GetValue(LICENCE_WARNING);
//            }
//            set
//            {
//                InsertOrUpdate(LICENCE_WARNING, value);
//            }
//        }

//        public string TicketMsg
//        {
//            get
//            {
//                return GetValue(TICKET_MSG);
//            }
//            set
//            {
//                InsertOrUpdate(TICKET_MSG, value);
//            }
//        }

//        public string OrdersRefresh
//        {
//            get
//            {
//                return GetValue(ORDERS_REFRESH);
//            }
//            set
//            {
//                InsertOrUpdate(ORDERS_REFRESH, value);
//            }
//        }

//        public void SetOrdersColumnOrder(string column, string order)
//        {
//            InsertOrUpdate(ORDERS_COLUMN_ORDER + column, order);
//        }

//        public string GetOrdersColumnOrder(string column)
//        {
//            return GetValue(ORDERS_COLUMN_ORDER + column);
//        }

//        public void SetOrdersColumnWidth(string column, string width)
//        {
//            InsertOrUpdate(ORDERS_COLUMN_WIDTH + column, width);
//        }

//        public string GetOrdersColumnWidth(string column)
//        {
//            return GetValue(ORDERS_COLUMN_WIDTH + column);
//        }

//        public void ClearOrdersColumnsPreferences()
//        {
//            ExecCommand(string.Format("DELETE FROM config WHERE key LIKE '{0}%'", ORDERS_COLUMN_ORDER));
//            ExecCommand(string.Format("DELETE FROM config WHERE key LIKE '{0}%'", ORDERS_COLUMN_WIDTH));
//        }

//        public string MainLocationX
//        {
//            get
//            {
//                return GetValue(MAIN_LOCATION_X);
//            }
//            set
//            {
//                InsertOrUpdate(MAIN_LOCATION_X, value);
//            }
//        }

//        public string MainLocationY
//        {
//            get
//            {
//                return GetValue(MAIN_LOCATION_Y);
//            }
//            set
//            {
//                InsertOrUpdate(MAIN_LOCATION_Y, value);
//            }
//        }

//        public string MainWidth
//        {
//            get
//            {
//                return GetValue(MAIN_WIDTH);
//            }
//            set
//            {
//                InsertOrUpdate(MAIN_WIDTH, value);
//            }
//        }

//        public string MainHeight
//        {
//            get
//            {
//                return GetValue(MAIN_HEIGHT);
//            }
//            set
//            {
//                InsertOrUpdate(MAIN_HEIGHT, value);
//            }
//        }

//        public void SaveWindowProperties(string window, string x, string y, string width, string height)
//        {
//            InsertOrUpdate(string.Concat(window, WINDOW_X), x);
//            InsertOrUpdate(string.Concat(window, WINDOW_Y), y);
//            InsertOrUpdate(string.Concat(window, WINDOW_WIDTH), width);
//            InsertOrUpdate(string.Concat(window, WINDOW_HEIGHT), height);
//        }

//        public void Save(WindowProperties prop)
//        {
//            SaveWindowProperties(prop.Name, prop.X, prop.Y, prop.Width, prop.Height);
//        }

//        public WindowProperties LoadWindowProperties(string window)
//        {
//            WindowProperties prop = new WindowProperties();

//            prop.X = GetValue(string.Concat(window, WINDOW_X));
//            prop.Y = GetValue(string.Concat(window, WINDOW_Y));
//            prop.Width = GetValue(string.Concat(window, WINDOW_WIDTH));
//            prop.Height = GetValue(string.Concat(window, WINDOW_HEIGHT));

//            if (prop.X == string.Empty && prop.Y == string.Empty && prop.Width == string.Empty && prop.Height == string.Empty)
//                return null;

//            return prop;
//        }
//    }
//}
