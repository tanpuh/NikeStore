using MongoDB.Driver;
using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiNike
{
    public partial class ProductMng : Form
    {
        IMongoCollection<Product> productCollection;

        public ProductMng()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase(databaseName);
            productCollection = database.GetCollection<Product>("products");

            LoadProductData();
        }

        private void LoadProductData()
        {
            var filterCond = Builders<Product>.Filter.Empty;
            var products = productCollection.Find(filterCond).ToList();
            dataGridView1.DataSource = products;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var p = new Product()
            {
                ProductName = txtProductName.Text
            };

            productCollection.InsertOne(p);
            LoadProductData();
        }
    }
}
