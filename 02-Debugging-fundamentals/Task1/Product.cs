namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        /// <summary>
        /// Compares object of <see cref="Product"/> type with self by comparing each field of the class.
        /// </summary>
        /// <param name="obj">Object of <see cref="Product"/> type to compare with.</param>
        /// <returns>True if objects are equal. False if not euqal.</returns>
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Product product = (Product)obj;
                return (this.Name == product.Name) && (this.Price == product.Price);
            }
        }
    }
}
