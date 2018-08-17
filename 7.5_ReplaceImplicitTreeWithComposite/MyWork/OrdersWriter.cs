using System.Text;

namespace ReplaceImplicitTreeWithComposite.MyWork
{
    public class OrdersWriter
    {
        private Orders orders;

        public OrdersWriter(Orders orders)
        {
            this.orders = orders;
        }

        public string getContents()
        {
            StringBuilder xml = new StringBuilder();
            writeOrderTo(xml);
            return xml.ToString();
        }

        private void writeOrderTo(StringBuilder xml)
        {
            var ordersTag = new TagNode("orders");
            for (int i = 0; i < orders.getOrderCount(); i++)
            {
                Order order = orders.getOrder(i);
                var orderTag = new TagNode("order");
                orderTag.addAttribute("id", order.getOrderId().ToString());
                writeProductsTo(orderTag, order);
                ordersTag.add(orderTag);
            }
            xml.Append(ordersTag.ToString());
        }

        private void writeProductsTo(TagNode orderTag, Order order)
        {
            for (int j = 0; j < order.getProductCount(); j++)
            {
                Product product = order.getProduct(j);
                var productTag = new TagNode("product");
                productTag.addAttribute("id", product.getId());
                productTag.addAttribute("color", colorFor(product));
                if (product.getSize() != productSize.NOT_APPLICABLE)
                    productTag.addAttribute("size", sizeFor(product).ToString());
                writePriceTo(productTag, product);
                productTag.addValue(product.getName());
                orderTag.add(productTag);
            }
        }

        private int sizeFor(Product product)
        {
            return product.getSize();
        }

        private string colorFor(Product product)
        {
            return "red";
        }

        private void writePriceTo(TagNode productTag, Product product)
        {
            var priceTag = new TagNode("price");
            priceTag.addAttribute("currency", currencyFor(product));
            priceTag.addValue(product.getPrice().ToString());
            productTag.add(priceTag);
        }

        private string currencyFor(Product product)
        {
            return "USD";
        }
    }

    internal class productSize
    {
        public static int NOT_APPLICABLE = 100;
    }
}