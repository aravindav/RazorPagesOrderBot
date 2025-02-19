using Microsoft.Data.Sqlite;

namespace OrderBot
{
      public class Order : ISQLModel
    {
        private string _meatType = String.Empty;
        private string _phone = String.Empty;
        private string _name = String.Empty;
        private string _size = String.Empty;
        private string _quantity = String.Empty;

        public string Phone{
            get => _phone;
            set => _phone = value;
        }

        public string Size{
            get => _size;
            set => _size = value;
        }

         public string Quantity{
            get => _quantity;
            set => _quantity = value;
        }

        public string MeatType{
            get => _meatType;
            set => _meatType = value;
        }
        public string Name{
            get => _name;
            set => _name = value;
        }

       
        public void Save(){
           using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandUpdate = connection.CreateCommand();
                commandUpdate.CommandText =
                @"
        UPDATE orders
        SET size = $size
        WHERE phone = $phone
    ";
                commandUpdate.Parameters.AddWithValue("$size", Size);
                commandUpdate.Parameters.AddWithValue("$phone", Phone);
                int nRows = commandUpdate.ExecuteNonQuery();
                if(nRows == 0){
                    var commandInsert = connection.CreateCommand();
                    commandInsert.CommandText =
                    @"
            INSERT INTO orders(size, phone)
            VALUES($size, $phone)
        ";
                    commandInsert.Parameters.AddWithValue("$size", Size);
                    commandInsert.Parameters.AddWithValue("$phone", Phone);
                    int nRowsInserted = commandInsert.ExecuteNonQuery();

                }
            }

        }
     }
}
